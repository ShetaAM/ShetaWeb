using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.AspNetCore.Http;
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
using Sheta.Data.Models.Entities.Site;
using Sheta.Data.Models.Entities.User;

namespace Sheta.CoreLayer.Servises
{
    public class SiteService : ISiteService
    {
        private DatabaseContext db;
        private IUserService _userService;

        public SiteService(DatabaseContext db, IUserService userService)
        {
            this.db = db;
            _userService = userService;
        }
        public Slider GetSliderToShow()
        {
            return db.Sliders.FirstOrDefault();
        }

        public Address GetManagerAdress()
        {
            return db.UserAddresses.Where(a => a.UserId == 1002).Select(a => a.Address).Single();
        }

        public List<Social> GetSocialToShow()
        {
            return db.Socials.ToList();
        }

        public Setting GetContactInfo()
        {
            return db.Settings.FirstOrDefault();
        }

        public void AddContact(ContactUs contact)
        {
            db.ContactUses.Add(contact);
            db.SaveChanges();
        }

        public int GetUserIdByUsername(string username)
        {
            User user = db.Users.SingleOrDefault(u => u.UserName == username);
            int userid = user.UserId;
            return userid;
        }

        public List<ProductGroup> GetGroupsForFooter()
        {
            return db.ProductGroups.Where(p => p.ParentId != null).OrderBy(p => p.GroupId).Take(4).ToList();
        }

        public int GetPostMoney()
        {
            Setting setting = db.Settings.FirstOrDefault();
            return setting.PostMoney;
        }

        public List<UserAddress> GetAddressesUser(int userid)
        {
            return db.UserAddresses.Include(a => a.Address)
                .Where(a => a.UserId == userid).ToList();
        }

        public void AddAddress(Address address, int userid)
        {
            db.Addresses.Add(address);
            db.SaveChanges();
            UserAddress userAddress = new UserAddress()
            {
                AddressId = address.AddressId,
                UserId = userid
            };
            db.UserAddresses.Add(userAddress);
            db.SaveChanges();
        }

        public int GetUserIdByAddressId(int addressid)
        {
            return db.UserAddresses.Where(a => a.AddressId == addressid).Select(a => a.UserId).Single();
        }

        public Slider GetSliderForAdmin()
        {
            return db.Sliders.FirstOrDefault();
        }

        public void UpdateSlider(Slider slider, IFormFile imgslider)
        {
            if (imgslider != null && imgslider.IsImage())
            {
                if (slider.SliderImage != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Site/images/", slider.SliderImage);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                    string deletethumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Site/images/thumb/", slider.SliderImage);
                    if (File.Exists(deletethumbPath))
                    {
                        File.Delete(deletethumbPath);
                    }
                }
                slider.SliderImage = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgslider.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Site/images", slider.SliderImage);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgslider.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Site/images/Thumb", slider.SliderImage);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }
            db.Sliders.Update(slider);
            db.SaveChanges();
        }

        public Setting GetSettingForAdmin()
        {
            return db.Settings.FirstOrDefault();
        }

        public void UpdateSetting(Setting setting)
        {
            db.Settings.Update(setting);
            db.SaveChanges();
        }

        public User GetUserForAdmin(string username)
        {
            int userid = _userService.GetUserIdByUserName(username);
            return db.Users.SingleOrDefault(u => u.UserId == userid);
        }

        public void UpdateProfile(User user)
        {
            db.Users.Update(user);
            db.SaveChanges();
        }
        public bool isexistUser(string oldpass, string username)
        {
            string hashpass = PasswordHelper.EncodePasswordMd5(oldpass);
            User user = db.Users.Single(u => u.Password == hashpass && u.UserName == username);
            if (user != null)
            {
                return true;
            }

            return false;
        }

        public void UpdataPassword(string username, string password)
        {
            string hashpass = PasswordHelper.EncodePasswordMd5(password);
            User user = GetUserForAdmin(username);
            user.Password = hashpass;
            db.Users.Update(user);
            db.SaveChanges();
        }

        public bool SiteIsActive()
        {
            Setting setting = db.Settings.FirstOrDefault();
            if (setting.SiteIsActive == "True")
            {
                return true;
            }

            return false;
        }

        public string GetMasageNotFound()
        {
            Setting setting = db.Settings.FirstOrDefault();
            return setting.NotActiveMassage;
        }

        public TamashaViewModel GetAllTamas(int pageid = 1, string Filter = "")
        {
            IQueryable<ContactUs> result = db.ContactUses;
            if (!string.IsNullOrEmpty(Filter))
            {
                result = db.ContactUses.Where(t => t.Email.Contains(Filter) ||
                                                t.Phone.Contains(Filter) ||
                                                t.name.Contains(Filter) ||
                                                t.Massage.Contains(Filter));
            }

            var take = 20;
            var skip = (pageid - 1) * take;
            TamashaViewModel list = new TamashaViewModel();
            list.CurrentPage = pageid;
            list.PageCount = result.Count() / take;
            list.ContactUses = result.OrderBy(t => t.UserId).Skip(skip).Take(take).ToList();
            return list;
        }

        public ContactUs GetInfoTamas(int tamasid)
        {
            return db.ContactUses.Single(t => t.TamasId == tamasid);
        }


        public void DeleteTamas(int tamasid)
        {
            ContactUs tamas = db.ContactUses.Find(tamasid);
            db.ContactUses.Remove(tamas);
            db.SaveChanges();
        }

        public SocViewModel GetAllSocials(int pageid = 1, string Filter = "")
        {
            IQueryable<Social> result = db.Socials;
            if (!string.IsNullOrEmpty(Filter))
            {
                result = db.Socials.Where(t => t.SocialName.Contains(Filter));
            }

            var take = 20;
            var skip = (pageid - 1) * take;
            SocViewModel list = new SocViewModel();
            list.CurrentPage = pageid;
            list.PageCount = result.Count() / take;
            list.Socials = result.OrderBy(t => t.SociaId).Skip(skip).Take(take)
                .ToList();
            return list;
        }

        public void CreateSocial(Social social)
        {
            db.Socials.Add(social);
            db.SaveChanges();
        }

        public Social GetInfoSocial(int socialid)
        {
            return db.Socials.Single(s => s.SociaId == socialid);
        }

        public void EditSocial(Social social)
        {
            db.Socials.Update(social);
            db.SaveChanges();
        }

        public void DeleteSocial(int socialid)
        {
            Social social = db.Socials.Find(socialid);
            db.Socials.Remove(social);
            db.SaveChanges();

        }

        public PostOrdersDto GetAllPostOrders(int pageid = 1, string Filter = "")
        {
            IQueryable<OrderPost> result = db.OrderPosts;
            if (!string.IsNullOrEmpty(Filter))
            {
                result = db.OrderPosts.Where(t => t.OrderId.ToString().Contains(Filter));
            }

            var take = 20;
            var skip = (pageid - 1) * take;
            PostOrdersDto list = new PostOrdersDto();
            list.CurrentPage = pageid;
            list.PageCount = result.Count() / take;
            list.OrderPosts = result
                .Include(o => o.OrderPostType)
                .Include(o => o.Orders)
                .ThenInclude(o => o.User)
                .Include(o => o.Orders)
                .ThenInclude(o => o.OrderDetails)
                .Include(o => o.Address)
                .Where(o => !o.IsSuccess)
                .OrderBy(t => t.TypeId).Skip(skip).Take(take)
                .ToList();
            return list;
        }

        public PostOrdersDto GetAllSuccessPostOrders(int pageid = 1, string Filter = "")
        {
            IQueryable<OrderPost> result = db.OrderPosts;
            if (!string.IsNullOrEmpty(Filter))
            {
                result = db.OrderPosts.Where(t => t.OrderId.ToString().Contains(Filter));
            }

            var take = 20;
            var skip = (pageid - 1) * take;
            PostOrdersDto list = new PostOrdersDto();
            list.CurrentPage = pageid;
            list.PageCount = result.Count() / take;
            list.OrderPosts = result
                .Include(o => o.OrderPostType)
                .Include(o => o.Orders)
                .ThenInclude(o => o.User)
                .Include(o => o.Orders)
                .ThenInclude(o => o.OrderDetails)
                .Include(o => o.Address)
                .Where(o => o.IsSuccess)
                .OrderBy(t => t.TypeId).Skip(skip).Take(take)
                .ToList();
            return list;
        }

        public OrderPost GetDetailOrderPost(int oderId)
        {
            return db.OrderPosts
                .Include(o => o.OrderPostType)
                .Include(o => o.Orders)
                .ThenInclude(o => o.User)
                .Include(o => o.Orders)
                .ThenInclude(o => o.OrderDetails)
                .Include(o => o.Address)
                .Single(o => o.OrderPostId == oderId);
        }

        public List<OrderDetail> GetOrderDetailsForPostOrder(int orderid)
        {
            return db.OrderDetails
                .Include(o => o.Product)
                .Where(o => o.OrderId == orderid).ToList();
        }

        public void SuccessPostOrder(int id)
        {
            OrderPost orderPost = db.OrderPosts.Find(id);
            orderPost.IsSuccess = true;
            db.OrderPosts.Update(orderPost);
            db.SaveChanges();
        }
    }
}
