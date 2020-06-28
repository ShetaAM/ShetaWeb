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
using Sheta.Data.Models.Entities.Site;
using Sheta.Data.Models.Entities.User;

namespace Sheta.CoreLayer.Servises
{
    public class UserService : IUserService
    {
        private DatabaseContext db;

        public UserService(DatabaseContext db)
        {
            this.db = db;
        }
        public bool IsExistUserName(string UserName)
        {
            return db.Users.Any(u => u.UserName == UserName);
        }

        public bool IsExistEmail(string Email)
        {
            return db.Users.Any(u => u.Email == Email);
        }

        public int AddUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return user.UserId;
        }

        public void AddUserRole(UserRole userrole)
        {
            db.UserRoles.Add(userrole);
            db.SaveChanges();
        }

        public User LoginUser(LoginViewModel login)
        {
            string username = login.UserName;
            string hashpass = PasswordHelper.EncodePasswordMd5(login.Password);

            return db.Users.SingleOrDefault(u => u.UserName == username && u.Password == hashpass);
        }

        public User LoginUserAdmin(LoginAdminViewModel login)
        {
            string email = FixedText.FixEmail(login.Email);
            string hashpass = PasswordHelper.EncodePasswordMd5(login.Password);

            return db.Users.SingleOrDefault(u => u.Email == email && u.Password == hashpass);
        }

        public bool ActiveAccount(string activeCode)
        {
            var user = db.Users.SingleOrDefault(u => u.ActiveCode == activeCode);
            if (user == null || user.IsActive)
                return false;

            user.IsActive = true;
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            db.SaveChanges();

            return true;
        }

        public User isExistEmail(string email)
        {
            return db.Users.SingleOrDefault(u => u.Email == email);
        }

        public User GetUserByActiveCode(string id)
        {
            return db.Users.SingleOrDefault(u => u.ActiveCode == id);
        }

        public void EditUser(User user, string pass)
        {
            throw new NotImplementedException();
        }

        public void user(User user, string pass)
        {
            string hash = PasswordHelper.EncodePasswordMd5(pass);
            user.ActiveCode = NameGenerator.GenerateUniqCode();
            user.Password = hash;
            db.SaveChanges();
        }

        public UserInformationvViewModel GetUserInformation(string username)
        {
            var user = db.Users.SingleOrDefault(u => u.UserName == username);
            UserInformationvViewModel userInformation = new UserInformationvViewModel()
            {
                UserName = user.UserName,
                Email = user.Email,
                UserAvatar = user.UserAvatar,
                RegisterDate = user.RegisterDate,
                Amount = Mandehesab(username)
            };
            return userInformation;

        }

        public int GetUserIdByUserName(string username)
        {
            return db.Users.Single(u => u.UserName == username).UserId;
        }
        public int Mandehesab(string username)
        {
            var userid = GetUserIdByUserName(username);
            var variz = db.Wallets.Where(w => w.UserId == userid && w.TypeId == 1 && w.IsPay).Select(w => w.Amount);
            var bardasht = db.Wallets.Where(w => w.UserId == userid && w.TypeId == 2 && w.IsPay).Select(w => w.Amount);
            int mande = variz.Sum() - bardasht.Sum();
            return mande;
        }

        public List<WalletViewModel> GetWallets(string username)
        {
            int userid = GetUserIdByUserName(username);
            return db.Wallets.Where(w => w.UserId == userid && w.IsPay)
                .Select(w => new WalletViewModel()
                {
                    Amount = w.Amount,
                    CreateDate = w.CreateDate,
                    Description = w.Description,
                    TypeId = w.TypeId
                }).ToList();
        }

        public int ChargeWalet(string userName, int amount, string description)
        {
            Wallet wallet = new Wallet()
            {
                Amount = amount,
                CreateDate = DateTime.Now,
                Description = description,
                IsPay = false,
                TypeId = 1,
                UserId = GetUserIdByUserName(userName)
            };
            return AddWallet(wallet);
        }

        public int AddWallet(Wallet wallet)
        {
            db.Wallets.Add(wallet);
            db.SaveChanges();
            return wallet.WalletId;
        }

        public Wallet GetWalletByWalletId(int walletid)
        {
            return db.Wallets.Find(walletid);
        }

        public void UpdateWallet(Wallet wallet)
        {
            db.Wallets.Update(wallet);
            db.SaveChanges();
        }

        public List<Wallet> GetAllWallets(int userid)
        {

            return db.Wallets.Include(w=>w.WalletType).Where(w => w.UserId == userid).ToList();
        }

        public User GetUserData(string username)
        {
            return db.Users.Single(u => u.UserName == username);
        }

        public void EditUserPanel(string username, IFormFile imgAvatar)
        {
            int userid= GetUserIdByUserName(username);
            User user = db.Users.SingleOrDefault(u => u.UserId == userid);
            if (imgAvatar != null && imgAvatar.IsImage())
            {
                if (user.UserAvatar != null)
                {
                    string deleteimagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/", user.UserAvatar);
                    if (File.Exists(deleteimagePath))
                    {
                        File.Delete(deleteimagePath);
                    }

                }
                user.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(imgAvatar.FileName);
                string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", user.UserAvatar);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    imgAvatar.CopyTo(stream);
                }

                ImageConvertor imgResizer = new ImageConvertor();
                string thumbPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images/Thumb", user.UserAvatar);

                imgResizer.Image_resize(imagePath, thumbPath, 150);
            }

            db.Users.Update(user);
            db.SaveChanges();
        }

        public void userPanel(string username, EditProfleViewModel edit)
        {
            if (edit.UserAvatar != null)
            {
                string imagePath = "";
                if (edit.AvatarName != "avatar.png")
                {
                    imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", edit.AvatarName);
                    if (File.Exists(imagePath))
                    {
                        File.Delete(imagePath);
                    }
                }

                edit.AvatarName = NameGenerator.GenerateUniqCode() + Path.GetExtension(edit.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Images", edit.AvatarName);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    edit.UserAvatar.CopyTo(stream);
                }

            }

            var user = db.Users.SingleOrDefault(u => u.UserName == username);
            user.UserName = edit.UserName;
            user.Email = edit.Email;
            user.UserAvatar = edit.AvatarName;

            db.Users.Update(user);
            db.SaveChanges();
        }

        public bool CompareOldPass(string OldPass, string username)
        {
            string hashpass = PasswordHelper.EncodePasswordMd5(OldPass);
            return db.Users.Any(u => u.UserName == username && u.Password == hashpass);
        }

        public void ChangePassword(string username, string NewPass)
        {
            var user = db.Users.SingleOrDefault(u => u.UserName == username);
            user.Password = PasswordHelper.EncodePasswordMd5(NewPass);
            db.Users.Update(user);
            db.SaveChanges();
        }

        public List<UserAddress> GetAdressInfo(string username)
        {
            int userid = GetUserIdByUserName(username);
            List<UserAddress> userAddress =
                db.UserAddresses.Include(a => a.Address).Where(u => u.UserId == userid).ToList();
            return userAddress;
        }

        public void AddAdress(Address address,string username)
        {
            db.Addresses.Add(address);
            db.SaveChanges();
            UserAddress userAddress=new UserAddress()
            {
                AddressId = address.AddressId,
                UserId = GetUserIdByUserName(username)
            };
            db.UserAddresses.Add(userAddress);
            db.SaveChanges();
        }

        public Address GetAddressInfo(int id)
        {
            return db.Addresses.Single(a => a.AddressId == id);
        }

        public void UpdateAddress(Address address)
        {
            db.Addresses.Update(address);
            db.SaveChanges();
        }

        public void DeleteAddress(int id)
        {
            Address address = db.Addresses.Find(id);
            db.Addresses.Remove(address);
            db.SaveChanges();
        }

        public UserForAdminViewModel GetUsers(int Pageid = 1, string Filter = "")
        {
            IQueryable<User> result = db.Users;
            if (!string.IsNullOrEmpty(Filter))
            {
                result = result.Where(u => u.UserName.Contains(Filter) || u.Email.Contains(Filter));
            }

            int take = 20;
            int skip = (Pageid - 1) * take;
            UserForAdminViewModel list=new UserForAdminViewModel();
            list.CurentPage = Pageid;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();
            return list;

        }

        public int AddUserFromAdmin(CreateUserViewModel user)
        {
            User addUser = new User();
            addUser.Password = PasswordHelper.EncodePasswordMd5(user.Password);
            addUser.ActiveCode = NameGenerator.GenerateUniqCode();
            addUser.Email = user.Email;
            addUser.IsActive = true;
            addUser.RegisterDate = DateTime.Now;
            addUser.UserName = user.UserName;

            #region Save Avatar

            if (user.UserAvatar != null)
            {
                string imagePath = "";
                addUser.UserAvatar = NameGenerator.GenerateUniqCode() + Path.GetExtension(user.UserAvatar.FileName);
                imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserAvatar", addUser.UserAvatar);
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    user.UserAvatar.CopyTo(stream);
                }
            }

            #endregion

            return AddUser(addUser);

        }

        public void DeleteUser(int userId)
        {
            User user = db.Users.SingleOrDefault(u=>u.UserId==userId);
            user.isdelete = true;
            db.Users.Update(user);
            db.SaveChanges();
            
        }

        public InformationUserViewModel GetUserInformationforadmin(int id)
        {
            var user = db.Users.SingleOrDefault(u=>u.UserId==id);
            InformationUserViewModel information = new InformationUserViewModel();
            information.UserName = user.UserName;
            information.Email = user.Email;
            information.RegisterDate = user.RegisterDate;

            return information;
        }

        public User GetUserForShowInEditMode(int userId)
        {
            return db.Users.Find(userId);

        }

        public void EditUserFromAdmin(User user,string password)
        {
            if (!string.IsNullOrEmpty(password))
            {
                user.Password = PasswordHelper.EncodePasswordMd5(password);
            }

            db.Users.Update(user);
            db.SaveChanges();
        }

        public UserForAdminViewModel GetDeleteUsers(int pageId = 1, string filterEmail = "", string filterUserName = "")
        {
            IQueryable<User> result = db.Users.IgnoreQueryFilters().Where(u => u.isdelete);

            if (!string.IsNullOrEmpty(filterEmail))
            {
                result = result.Where(u => u.Email.Contains(filterEmail));
            }

            if (!string.IsNullOrEmpty(filterUserName))
            {
                result = result.Where(u => u.UserName.Contains(filterUserName));
            }

            // Show Item In Page
            int take = 20;
            int skip = (pageId - 1) * take;


            UserForAdminViewModel list = new UserForAdminViewModel();
            list.CurentPage = pageId;
            list.PageCount = result.Count() / take;
            list.Users = result.OrderBy(u => u.RegisterDate).Skip(skip).Take(take).ToList();

            return list;
        }

        public string GetUserNameById(int userid)
        {
            return db.Users.Where(u => u.UserId == userid).Select(u => u.UserName).Single();
        }
    }
}
