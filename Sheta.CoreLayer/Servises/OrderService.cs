using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sheta.CoreLayer.Discount;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Migrations;
using Sheta.Data.Models.Context;
using Sheta.Data.Models.Entities.Discount;
using Sheta.Data.Models.Entities.Order;
using Sheta.Data.Models.Entities.Site;
using Sheta.Data.Models.Entities.User;

namespace Sheta.CoreLayer.Servises
{
    public class OrderService : IOrderService
    {
        private DatabaseContext db;
        private IUserService _userService;
        private IProductService _productService;
        private ISiteService _siteService;

        public OrderService(DatabaseContext db, IUserService userService, IProductService productService, ISiteService siteService)
        {
            this.db = db;
            _userService = userService;
            _productService = productService;
            _siteService = siteService;
        }

        public int AddOrder(string username, int productid)
        {
            int userid = _userService.GetUserIdByUserName(username);
            Order order = db.Orders.FirstOrDefault(o => o.UserId == userid && !o.IsFinaly);
            var product = db.Products.Find(productid);
            if (order == null)
            {
                if (product.ProductDiscount != 0)
                {
                    order = new Order()
                    {
                        UserId = userid,
                        IsFinaly = false,
                        CreateDate = DateTime.Now,
                        OrderSum = _productService.GetOffFromProduct(product.ProductId, product.ProductPrice, product.ProductDiscount),
                        OrderDetails = new List<OrderDetail>()
                        {
                            new OrderDetail()
                            {
                                ProductId = productid,
                                Count = 1,
                                Price =_productService.GetOffFromProduct(product.ProductId,product.ProductPrice,product.ProductDiscount),
                            }
                        }
                    };
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
                else
                {
                    order = new Order()
                    {
                        UserId = userid,
                        IsFinaly = false,
                        CreateDate = DateTime.Now,
                        OrderSum = product.ProductPrice,
                        OrderDetails = new List<OrderDetail>()
                        {
                            new OrderDetail()
                            {
                                ProductId = productid,
                                Count = 1,
                                Price =product.ProductPrice,
                            }
                        }
                    };
                    db.Orders.Add(order);
                    db.SaveChanges();
                }
            }
            else
            {
                OrderDetail detail =
                    db.OrderDetails.FirstOrDefault(d => d.OrderId == order.OrderId && d.ProductId == productid);
                if (detail != null)
                {
                    detail.Count += 1;
                    db.OrderDetails.Update(detail);
                }
                else
                {
                    if (product.ProductDiscount != 0)
                    {
                        detail = new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            Count = 1,
                            ProductId = productid,
                            Price = _productService.GetOffFromProduct(product.ProductId, product.ProductPrice, product.ProductDiscount),
                        };
                        db.OrderDetails.Add(detail);
                    }
                    else
                    {
                        detail = new OrderDetail()
                        {
                            OrderId = order.OrderId,
                            Count = 1,
                            ProductId = productid,
                            Price = product.ProductPrice,
                        };
                        db.OrderDetails.Add(detail);
                    }
                }
                db.SaveChanges();
                UpdatePrice(order.OrderId);
            }

            return order.OrderId;
        }

        public void UpdatePrice(int orderid)
        {
            var order = db.Orders.Find(orderid);
            order.OrderSum = db.OrderDetails.Where(d => d.OrderId == orderid).Sum(d => d.Price * d.Count);
            db.Orders.Update(order);
            db.SaveChanges();
        }

        public Order GetOrderForUserPanel(string username)
        {
            int userid = _userService.GetUserIdByUserName(username);
            return db.Orders
                .Include(o => o.OrderDetails)
                .ThenInclude(o => o.Product)
                .FirstOrDefault(o => o.UserId == userid && !o.IsFinaly);
        }

        public bool FinalyOrder(string username, int orderid)
        {
            int userId = _userService.GetUserIdByUserName(username);
            var order = db.Orders.Include(o => o.OrderDetails).ThenInclude(od => od.Product)
                .FirstOrDefault(o => o.OrderId == orderid && o.UserId == userId && !o.IsFinaly);

            if (order == null || order.IsFinaly)
            {
                return false;
            }

            if (_userService.Mandehesab(username) >= order.OrderSum)
            {
                order.IsFinaly = true;
                _userService.AddWallet(new Wallet()
                {
                    Amount = order.OrderSum,
                    CreateDate = DateTime.Now,
                    IsPay = true,
                    Description = "فاکتور شما #" + order.OrderId,
                    UserId = userId,
                    TypeId = 2
                });
                db.Orders.Update(order);
                db.SaveChanges();

                foreach (var detail in order.OrderDetails)
                {
                    db.UserProducts.Add(new UserProduct()
                    {
                        ProductId = detail.ProductId,
                        UserId = userId
                    });
                    db.SaveChanges();
                }

                return true;
            }

            return false;

        }

        public List<OrderDetail> SuratHesab(string username)
        {
            int userid = _userService.GetUserIdByUserName(username);
            return db.OrderDetails.Where(o => o.Order.UserId == userid && o.Order.IsFinaly).ToList();


        }

        public string GetProductTitleById(int productid)
        {
            return db.Products.Where(p => p.ProductId == productid).Select(p => p.ProductTitle).Single();
        }

        public List<UserProduct> GetUserProducts(string username)
        {
            int userid = _userService.GetUserIdByUserName(username);
            return db.UserProducts.Include(p => p.Product).Where(p => p.UserId == userid).ToList();
        }

        public OrderDetail GetOrderDetail(int odid)
        {
            return db.OrderDetails.FirstOrDefault(o => o.DetailId == odid);
        }

        public void DeleteOrderDetal(int did)
        {
            OrderDetail orderd = db.OrderDetails.Find(did);
            Order order = db.Orders.Single(o => o.OrderId == orderd.OrderId);
            db.OrderDetails.Remove(orderd);
            int sumorder = order.OrderSum;
            int detailprice = orderd.Price * orderd.Count;
            order.OrderSum = sumorder - detailprice;
            db.Orders.Update(order);
            db.SaveChanges();
            if (order.OrderSum == 0)
            {
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public void SuccessOrder(int orderid)
        {
            Order order = GetOderById(orderid);
            order.IsFinaly = true;
            db.Orders.Update(order);
            db.SaveChanges();
        }

        public DiscountUseType UseDiscount(string username, string code)
        {
            var discount = db.Discounts.SingleOrDefault(d => d.DiscountCode == code);
            if (discount == null)
            {
                return DiscountUseType.notfound;
            }

            if (discount.StartDate != null && discount.StartDate > DateTime.Now)
            {
                return DiscountUseType.expier;
            }

            if (discount.EndTime != null && discount.EndTime <= DateTime.Now)
            {
                return DiscountUseType.expier;
            }

            if (discount.UsableCount != null && discount.UsableCount <= 0)
            {
                return DiscountUseType.finished;
            }

            var order = GetOrderForUserPanel(username);
            if (db.UserDiscounts.Any(d => d.UserId == order.UserId && d.DiscountId == discount.DiscountId))
            {
                return DiscountUseType.userused;
            }

            int persent = (order.OrderSum * discount.DiscountPersent) / 100;
            order.OrderSum = order.OrderSum - persent;
            discount.UsableCount -= 1;
            db.Discounts.Update(discount);
            db.Orders.Update(order);
            db.SaveChanges();
            db.UserDiscounts.Add(new UserDiscount()
            {
                UserId = order.UserId,
                DiscountId = discount.DiscountId
            });
            db.SaveChanges();
            return DiscountUseType.success;
        }

        public List<Data.Models.Entities.Discount.Discount> DiscountsForAdmin(int pageid = 1, string filter = "",
            int pagecount = 0, int currentpage = 0)
        {
            IQueryable<Data.Models.Entities.Discount.Discount> result = db.Discounts;
            if (!string.IsNullOrEmpty(filter))
            {
                result = db.Discounts.Where(d => d.DiscountCode.Contains(filter) ||
                                                 d.DiscountId.ToString().Contains(filter) ||
                                                 d.UsableCount.ToString().Contains(filter));
            }

            int take = 20;
            int skip = (pageid - 1) * take;
            currentpage = pageid;
            pagecount = result.Count();
            return result.OrderBy(d => d.DiscountId).Skip(skip).Take(take).ToList();
        }

        public void AddDicount(Data.Models.Entities.Discount.Discount discount)
        {
            db.Discounts.Add(discount);
            db.SaveChanges();
        }

        public Data.Models.Entities.Discount.Discount GetDiscountForUpdate(int discountid)
        {
            return db.Discounts.FirstOrDefault(d => d.DiscountId == discountid);
        }

        public void UpdateDiscount(Data.Models.Entities.Discount.Discount discount)
        {
            db.Discounts.Update(discount);
            db.SaveChanges();
        }

        public void DeleteDiscount(int disid)
        {
            Data.Models.Entities.Discount.Discount discount = db.Discounts.SingleOrDefault(d => d.DiscountId == disid);
            UserDiscount userdiscount = db.UserDiscounts.FirstOrDefault(u => u.DiscountId == disid);
            List<UserDiscount> userDiscounts = db.UserDiscounts.Where(u => u.DiscountId == disid).ToList();

            foreach (var ud in userDiscounts)
            {
                db.UserDiscounts.Remove(userdiscount);
                db.SaveChanges();
            }

            db.Discounts.Remove(discount);
            db.SaveChanges();
        }

        public List<Order> GetAllOrder(int pageid = 1, string filter = "", int currentpage = 0, int pagecount = 0)
        {
            IQueryable<Order> result = db.Orders;
            if (!string.IsNullOrEmpty(filter))
            {
                result = db.Orders.Where(o => o.OrderId.ToString().Contains(filter) ||
                                              o.User.UserName.Contains(filter));
            }

            int take = 20;
            int skip = (pageid - 1) * take;
            currentpage = pageid;
            pagecount = result.Count();
            return result.OrderBy(o => o.OrderId).Skip(skip).Take(take).ToList();
        }

        public Order GetOrderDetailsByOrderId(int orderid)
        {
            return db.Orders
                .Include(o=>o.User)
                .Include(o => o.OrderDetails)
                .Single(d => d.OrderId == orderid);
        }

        public PostOrderDTO GetWizardInfo(string username)
        {
            int userid = _userService.GetUserIdByUserName(username);
            Order order = db.Orders.SingleOrDefault(o => o.UserId == userid && !o.IsFinaly);
            List<OrderDetail> orderDetails = db.OrderDetails.Include(o => o.Product).Where(d => d.OrderId == order.OrderId).ToList();
            List<UserAddress> userAddresses = db.UserAddresses.Include(a => a.Address).Where(d => d.UserId == userid).ToList();
            List<OrderPostType> orderPostTypes = db.OrderPostTypes.ToList();
            PostOrderDTO post = new PostOrderDTO()
            {
                OrderDetails = orderDetails,
                UserAddresses = userAddresses,
                OrderPostTypes = orderPostTypes,
                OrderId = order.OrderId,
                ordrsum = order.OrderSum
            };
            return post;

        }

        public OrderPost AddOrderPost(int orderid, int PayType, int SelectedAddress)
        {
            OrderPost orderPost = new OrderPost()
            {
                OrderId = orderid,
                TypeId = PayType,
                AddressId = SelectedAddress
            };
            db.OrderPosts.Add(orderPost);
            db.SaveChanges();
            return orderPost;
        }

        public int GetAmountByOrderid(int orderid)
        {
            Order order = db.Orders.SingleOrDefault(o => o.OrderId == orderid);
            return order.OrderSum;
        }

        public Order GetOderById(int orderid)
        {
            return db.Orders.Find(orderid);
        }

        public void UpdateOrder(Order order)
        {
            db.Orders.Update(order);
            db.SaveChanges();
        }

        public void AddProductToUser(Order order, int userId)
        {
            List<OrderDetail> orderDetails = db.OrderDetails.Where(o => o.OrderId == order.OrderId).ToList();
            foreach (var detail in orderDetails)
            {
                db.UserProducts.Add(new UserProduct()
                {
                    ProductId = detail.ProductId,
                    UserId = userId
                });
                db.SaveChanges();
            }
        }

        public OrderInfoDTO GetFactor(int orderId)
        {
            var order = db.Orders.Find(orderId);
            List<OrderDetail> list = db.OrderDetails.Include(o => o.Product).Where(o => o.OrderId == orderId).ToList();
            OrderPost orderPost = db.OrderPosts.Include(o => o.OrderPostType).Single(o => o.OrderId == orderId);
            OrderInfoDTO orders = new OrderInfoDTO()
            {
                ordrsDetails = list,
                CreateDate = DateTime.Now,
                OrderId = orderId,
                PostType = orderPost.OrderPostType.TypeTitle,
                OrderSum = order.OrderSum
            };
            return orders;
        }
    }
}
