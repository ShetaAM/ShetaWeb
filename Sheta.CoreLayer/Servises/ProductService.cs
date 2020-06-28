using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Sheta.CoreLayer.Convertor;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Generator;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Context;
using Sheta.Data.Models.Entities.Brands;
using Sheta.Data.Models.Entities.Order;
using Sheta.Data.Models.Entities.Product;
using Sheta.Data.Models.Entities.User;

//using Sheta.Data.Models.Entities.Courses;

namespace Sheta.CoreLayer.Servises
{
    public class ProductService : IProductService
    {
        private DatabaseContext db;
        private IUserService _UserService;

        public ProductService(DatabaseContext db, IUserService userService)
        {
            this.db = db;
            _UserService = userService;
        }

        public List<ProductGroup> GetAllCourseGroups()
        {
            return db.ProductGroups.ToList();
        }

        public List<SelectListItem> GetGroupForAdmin()
        {
            return db.ProductGroups.Where(p => p.ParentId == null)
                .Select(s => new SelectListItem()
                {
                    Value = s.GroupId.ToString(),
                    Text = s.GroupTitle
                }).ToList();

        }
        public List<SelectListItem> GetSubGroupForAdmin(int Groupid)
        {
            return db.ProductGroups.Where(p => p.ParentId == Groupid)
                .Select(s => new SelectListItem()
                {
                    Value = s.GroupId.ToString(),
                    Text = s.GroupTitle
                }).ToList();
        }

        public List<SelectListItem> GetProductStatus()
        {
            return db.ProductStatuses.Select(s => new SelectListItem()
            {
                Value = s.StatusId.ToString(),
                Text = s.StatusTitle,
            }).ToList();
        }

        public List<SelectListItem> GetProductBrands()
        {
            return db.Brandses.Select(s => new SelectListItem()
            {
                Value = s.BrandId.ToString(),
                Text = s.BrandTitle,
            }).ToList();
        }

        public ProductForAdminViewModel GetProductsForAdmin(int pageid = 1, string Filter = "")
        {
            IQueryable<Product> result = db.Products;
            if (!string.IsNullOrEmpty(Filter))
            {
                result = result.Where(p =>
                    p.ProductTitle.Contains(Filter) || p.ProductDescription.Contains(Filter) ||
                    p.ProductPrice.ToString().Contains(Filter) || p.CourseG1.GroupTitle.Contains(Filter) ||
                    p.ProductStatus.StatusTitle.Contains(Filter) || p.Tags.Contains(Filter));
            }

            int take = 20;
            int skip = (pageid - 1) * take;
            ProductForAdminViewModel list = new ProductForAdminViewModel();
            list.CurrentPage = pageid;
            list.PageCount = result.Count()/take;
            list.Products = result.OrderBy(u => u.CreateDate).Skip(skip).Take(take).ToList();
            return list;
        }

        public int AddProduct(Product product, IFormFile ImgProuct)
        {
            product.CreateDate = DateTime.Now;
            product.ProductImageName = "p11.jpg";
            if (ImgProuct != null && ImgProuct.IsImage())
            {
                product.ProductImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(ImgProuct.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product", product.ProductImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    ImgProuct.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product/Thumb", product.ProductImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }

            db.Add(product);
            db.SaveChanges();

            return product.ProductId;
        }

        public Product GetProductById(int ProductId)
        {
            return db.Products.Find(ProductId);
        }

        public void UpdatatProduct(Product product, IFormFile ImgProuct)
        {

            if (ImgProuct != null && ImgProuct.IsImage())
            {
                if (product.ProductImageName != "c5.jpg")
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product/", product.ProductImageName);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                    string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product/Thumb", product.ProductImageName);
                    if (File.Exists(deletethumbPath))
                    {
                        File.Delete(deletethumbPath);
                    }
                }
                product.ProductImageName = NameGenerator.GenerateUniqCode() + Path.GetExtension(ImgProuct.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product", product.ProductImageName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    ImgProuct.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product/Thumb", product.ProductImageName);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }

            db.Products.Update(product);
            db.SaveChanges();
        }

        public ProductGroupForAdminModel GetGroupsForAdmin(int pageid = 1, string Filter = "")
        {
            IQueryable<ProductGroup> result = db.ProductGroups;
            if (!string.IsNullOrEmpty(Filter))
            {
                result = result.Where(p => p.GroupTitle.Contains(Filter));
            }

            int take = 20;
            int skip = (pageid - 1) * take;
            ProductGroupForAdminModel list = new ProductGroupForAdminModel();
            list.CurrentPage = pageid;
            list.PageCount = result.Count()/take;
            list.ProductGroups = result.OrderBy(u => u.GroupId).Skip(skip).Take(take).ToList();
            return list;
        }

        public string GetGroupTitleByParnetId(int? parentid)
        {
            string group = db.ProductGroups.Where(g => g.GroupId == parentid).Select(g => g.GroupTitle).Single();
            return group;
        }

        public List<SelectListItem> GetBaseGroups()
        {

            return db.ProductGroups.Where(g => g.ParentId == null).Select(s => new SelectListItem()
            {
                Value = s.GroupId.ToString(),
                Text = s.GroupTitle
            }).ToList();
        }

        public List<SelectListItem> GetBaseGroupsbybase()
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "گروه اصلی",Value = null}
            };
            list.AddRange(GetBaseGroups());
            return list;
        }

        public void AddGroup(ProductGroup productGroup)
        {
            db.ProductGroups.Add(productGroup);
            db.SaveChanges();
        }

        public ProductGroup GetGroupById(int Groupid)
        {
            return db.ProductGroups.Find(Groupid);
        }

        public void UpdateGroup(ProductGroup productGroup)
        {
            db.ProductGroups.Update(productGroup);
            db.SaveChanges();
        }

        public List<Product> getDiscountProducts()
        {
            return db.Products.Where(p => p.ProductDiscount != 0).ToList();
        }

        public int GetOffFromProduct(int id, int price, int prsent)
        {
            Product product = db.Products.Find(id);
            int productprice = price;
            int productprsent = prsent;
            int darsad = (productprice * productprsent) / 100;
            int takhfif = productprice - darsad;
            return takhfif;
        }

        public List<ProductDetail> GetaDetailForProductAdmin(int productid)
        {
            return db.ProductDetails.Where(d => d.ProductId == productid).ToList();
        }

        public int GetProductId(int id)
        {
            return db.Products.Where(d => d.ProductId == id).Select(d => d.ProductId).Single();
        }

        public void AddDetailProduct(int pId, ProductDetail productDetail)
        {
            productDetail.ProductId = pId;
            db.ProductDetails.Add(productDetail);
            db.SaveChanges();
        }

        public string GetProductTitleById(int ProductId)
        {
            return db.Products.Where(p => p.ProductId == ProductId).Select(p => p.ProductTitle).Single();
        }

        public ProductDetail GetProductDetail(int id)
        {
            return db.ProductDetails.Find(id);
        }
        public void DeleteProductDetail(int id)
        {
            
            ProductDetail productdetail = db.ProductDetails.FirstOrDefault(p => p.PdId == id);
            db.ProductDetails.Remove(productdetail);
            db.SaveChanges();
        }

        public List<ShowProductViewModel> GetProductToShowArchive(int groupid, int pageid = 1, string filter = "", string getType = "all",
            string orderBy = "date")
        {
            IQueryable<Product> result = db.Products;
            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(p => p.ProductTitle.Contains(filter) || p.Tags.Contains(filter));
            }

            switch (getType)
            {
                case "all":
                    break;
                case "buy":
                {
                    result = result.Where(c => c.ProductPrice != 0);
                    break;
                }
                case "free":
                {
                    result = result.Where(c => c.ProductPrice == 0);
                    break;
                }

            }

            switch (orderBy)
            {
                case "date":
                {
                    result = result.OrderByDescending(p => p.CreateDate);
                    break;
                }
                case "price":
                {
                    result = result.OrderByDescending(p => p.ProductPrice);
                    break;
                }
            }

            int take = 20;
            int skip = (pageid - 1) * take;

            return result.Where(r => r.SubGroup == groupid).Select(p => new ShowProductViewModel()
                {
                    ProductId = p.ProductId,
                    ProductTitle = p.ProductTitle,
                    ProductImage = p.ProductImageName,
                    ProductPrice = p.ProductPrice,
                    ProductDiscount =p.ProductDiscount
                }).Skip(skip).Take(take).ToList()
                ;
        }

        public List<ShowProductViewModel> GetProductToShow(int pageid = 1, string filter = "", string getType = "all", string orderBy = "date")
        {
            IQueryable<Product> result = db.Products;
            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(p => p.ProductTitle.Contains(filter) || p.Tags.Contains(filter));
            }

            switch (getType)
            {
                case "all":
                    break;
                case "buy":
                {
                    result = result.Where(c => c.ProductPrice != 0);
                    break;
                }
                case "free":
                {
                    result = result.Where(c => c.ProductPrice == 0);
                    break;
                }

            }

            switch (orderBy)
            {
                case "date":
                {
                    result = result.OrderByDescending(p => p.CreateDate);
                    break;
                }
                case "price":
                {
                    result = result.OrderByDescending(p => p.ProductPrice);
                    break;
                }
            }

            int take = 20;
            int skip = (pageid - 1) * take;

            return result.Select(p => new ShowProductViewModel()
                {
                    ProductId = p.ProductId,
                    ProductTitle = p.ProductTitle,
                    ProductImage = p.ProductImageName,
                    ProductPrice = p.ProductPrice,
                    ProductDiscount = p.ProductDiscount
                }).Skip(skip).Take(take).ToList()
                ;
        }

        public List<ShowProductViewModel> GetProductoff(int pageid = 1, string filter = "", string getType = "all", string orderBy = "date")
        {
            IQueryable<Product> result = db.Products;
            if (!string.IsNullOrEmpty(filter))
            {
                result = result.Where(p => p.ProductTitle.Contains(filter) || p.Tags.Contains(filter));
            }

            switch (getType)
            {
                case "all":
                    break;
                case "buy":
                {
                    result = result.Where(c => c.ProductPrice != 0);
                    break;
                }
                case "free":
                {
                    result = result.Where(c => c.ProductPrice == 0);
                    break;
                }

            }

            switch (orderBy)
            {
                case "date":
                {
                    result = result.OrderByDescending(p => p.CreateDate);
                    break;
                }
                case "price":
                {
                    result = result.OrderByDescending(p => p.ProductPrice);
                    break;
                }
            }

            int take = 20;
            int skip = (pageid - 1) * take;

            return result.Where(p => p.ProductDiscount != 0).Select(p => new ShowProductViewModel()
                {
                    ProductId = p.ProductId,
                    ProductTitle = p.ProductTitle,
                    ProductImage = p.ProductImageName,
                    ProductPrice = p.ProductPrice,
                    ProductDiscount = p.ProductDiscount
                }).Skip(skip).Take(take).ToList()
                ;
        }
        public ProductViewModel GetProductForShow(int id)
        {
            Product product = db.Products.FirstOrDefault(p => p.ProductId == id);

            List<ProductDetail> detail = db.ProductDetails.Where(d => d.ProductId == id).ToList();

            ProductViewModel show = new ProductViewModel()
            {
                Product = product,
                ProductDetails = detail,
            };

            return show;
        }

        public bool IsProductForUser(string username ,int productId)
        {
            int userid = _UserService.GetUserIdByUserName(username);
            return db.UserProducts.Any(u => u.UserId == userid && u.ProductId==productId);
        }

        public List<Brands> GetAllBrandses()
        {
            return db.Brandses.ToList();
        }

        public BrandForAdminViewModel GetBrandForAdmin(int pageid = 1, string Filter = "")
        {
            IQueryable<Brands> result = db.Brandses;
            if (!string.IsNullOrEmpty(Filter))
            {
                result = result.Where(p => p.BrandTitle.Contains(Filter));
            }

            int take = 20;
            int skip = (pageid - 1) * take;
            BrandForAdminViewModel list = new BrandForAdminViewModel();
            list.CurrentPage = pageid;
            list.PageCount = result.Count()/take;
            list.Brandses = result.OrderBy(u => u.BrandId).Skip(skip).Take(take).ToList();
            return list;
        }

        public int AddBrand(Brands brands, IFormFile ImgBrand)
        {
            brands.BrandImage = "p11.jpg";
            if (ImgBrand != null && ImgBrand.IsImage())
            {
                brands.BrandImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(ImgBrand.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Brand", brands.BrandImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    ImgBrand.CopyTo(stream);
                }
            }

            db.Brandses.Add(brands);
            db.SaveChanges();

            return brands.BrandId;
        }

        public Brands GetBrandById(int brandid)
        {
            return db.Brandses.Find(brandid);
        }

        public void UpdatatBrand(Brands brands, IFormFile ImgBrand)
        {
            if (ImgBrand != null && ImgBrand.IsImage())
            {
                if (brands.BrandImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product/", brands.BrandImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }
                }
                brands.BrandImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(ImgBrand.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Product", brands.BrandImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    ImgBrand.CopyTo(stream);
                }
            }

            db.Brandses.Update(brands);
            db.SaveChanges();
        }

        public void DeleteBrands(int id)
        {
            Brands brands = db.Brandses.Find(id);
            brands.IsDelete = true;
            db.Brandses.Update(brands);
            db.SaveChanges();
        }

        public void DeleteGroupAndProduct(int groupid)
        {
            ProductGroup group = db.ProductGroups.SingleOrDefault(g => g.GroupId == groupid);
            ProductGroup subgroup = db.ProductGroups.FirstOrDefault(g => g.ParentId == groupid);
            List<ProductGroup> groups= db.ProductGroups.Where(g => g.ParentId == groupid).ToList();
            List<Product> products = db.Products.Where(p => p.GroupId == groupid).ToList();
            foreach (var p in products)
            {
                db.Products.Remove(p);
                db.SaveChanges();
            }

            if (group.ParentId==null)
            {
                foreach (var g in groups)
                {
                    db.ProductGroups.Remove(subgroup);
                    db.SaveChanges();
                }
                db.ProductGroups.Remove(group);
                db.SaveChanges();
            }
            else
            {
                db.ProductGroups.Remove(subgroup);
                db.SaveChanges();
            }
            

        }

        public ProductGroup GetGroupForDelete(int groupid)
        {
            return db.ProductGroups.SingleOrDefault(g => g.GroupId == groupid);
        }

        public void DeleteProductAdmin(int productid)
        {
            Product product = db.Products.SingleOrDefault(p => p.ProductId == productid);
            ProductDetail detail = db.ProductDetails.FirstOrDefault(d => d.ProductId == productid);
            List<ProductDetail> details = db.ProductDetails.Where(d => d.ProductId == productid).ToList();
            UserProduct userProduct = db.UserProducts.FirstOrDefault(d => d.ProductId == productid);
            List<UserProduct> userProducts = db.UserProducts.Where(d => d.ProductId == productid).ToList();
            OrderDetail orderDetail = db.OrderDetails.FirstOrDefault(d => d.ProductId == productid);
            List<OrderDetail> orderDetails = db.OrderDetails.Where(d => d.ProductId == productid).ToList();

            foreach (var d in details)
            {
                db.ProductDetails.Remove(detail);
                db.SaveChanges();
            }
            foreach (var up in userProducts)
            {
                db.UserProducts.Remove(userProduct);
                db.SaveChanges();
            }
            foreach (var od in orderDetails)
            {
                db.OrderDetails.Remove(orderDetail);
                db.SaveChanges();
            }

            db.Products.Remove(product);
            db.SaveChanges();


        }
    }
}
