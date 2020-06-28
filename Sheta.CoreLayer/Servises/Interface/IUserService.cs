using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Sheta.CoreLayer.DTOs;
using Sheta.Data.Models.Entities.Site;
using Sheta.Data.Models.Entities.User;

namespace Sheta.CoreLayer.Servises.Interface
{
    public interface IUserService
    {
        #region Register

        bool IsExistUserName(string UserName);
        bool IsExistEmail(string Email);
        int AddUser(User user);
        void AddUserRole(UserRole userrole);

        #endregion

        #region Login

        User LoginUser(LoginViewModel login);
        User LoginUserAdmin(LoginAdminViewModel login);

        #endregion

        #region Active

        bool ActiveAccount(string activecode);

        #endregion

        #region Forget

        User isExistEmail(string email);

        #endregion

        #region Reset Pass

        User GetUserByActiveCode(string id);
        void EditUser(User user, string pass);

        #endregion

        #region Wallets

        UserInformationvViewModel GetUserInformation(string username);
        int GetUserIdByUserName(string username);
        int Mandehesab(string username);
        List<WalletViewModel> GetWallets(string username);
        int ChargeWalet(string userName, int amount, string description);
        int AddWallet(Wallet wallet);

        Wallet GetWalletByWalletId(int walletid);
        void UpdateWallet(Wallet wallet);

        List<Wallet> GetAllWallets(int userid);

        #endregion

        #region EditProfile

        User GetUserData(string username);
        void EditUserPanel(string username,IFormFile imgAvatar);

        bool CompareOldPass(string OldPass, string username);
        void ChangePassword(string username, string NewPass);

        List<UserAddress> GetAdressInfo(string username);
        void AddAdress(Address address, string username);
        Address GetAddressInfo(int id);
        void UpdateAddress(Address address);
        void DeleteAddress(int id);

        #endregion

        #region AdminUser

        UserForAdminViewModel GetUsers(int Pageid = 1, string Filter = "");

        int AddUserFromAdmin(CreateUserViewModel user);

        void DeleteUser(int userId);
        InformationUserViewModel GetUserInformationforadmin(int id);
        User GetUserForShowInEditMode(int userId);
        void EditUserFromAdmin(User user,string password);
        UserForAdminViewModel GetDeleteUsers(int pageId = 1, string filterEmail = "", string filterUserName = "");
        string GetUserNameById(int userid);

        #endregion

    }
}
