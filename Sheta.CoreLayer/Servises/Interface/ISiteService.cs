using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Sheta.CoreLayer.DTOs;
using Sheta.Data.Models.Entities.Order;
using Sheta.Data.Models.Entities.Product;
using Sheta.Data.Models.Entities.Site;
using Sheta.Data.Models.Entities.User;

namespace Sheta.CoreLayer.Servises.Interface
{
    public interface ISiteService
    {
        Slider GetSliderToShow();
        Address GetManagerAdress();
        List<Social> GetSocialToShow();
        Setting GetContactInfo();
        void AddContact(ContactUs contact);
        int GetUserIdByUsername(string username);
        List<ProductGroup> GetGroupsForFooter();

        int GetPostMoney();

        #region Admin

        List<UserAddress> GetAddressesUser(int userid);
        void AddAddress(Address address,int userid);
        int GetUserIdByAddressId(int addressid);

        Slider GetSliderForAdmin();

        void UpdateSlider(Slider slider,IFormFile imgslider);

        Setting GetSettingForAdmin();

        void UpdateSetting(Setting setting);

        User GetUserForAdmin(string username);
        void UpdateProfile(User user);
        bool isexistUser(string oldpass,string username);
        void UpdataPassword(string username, string password);

        bool SiteIsActive();
        string GetMasageNotFound();

        #region Tamasha

        TamashaViewModel GetAllTamas(int pageid = 1, string Filter = "");
        ContactUs GetInfoTamas(int tamasid);
        void DeleteTamas(int tamasid);

        #endregion
        #region Socials

        SocViewModel GetAllSocials(int pageid = 1, string Filter = "");
        void CreateSocial(Social social);
        Social GetInfoSocial(int socialid);
        void EditSocial(Social social);
        void DeleteSocial(int socialid);

        #endregion

        #region PostOrder

        PostOrdersDto GetAllPostOrders(int pageid=1,string Filter="");
        PostOrdersDto GetAllSuccessPostOrders(int pageid = 1, string Filter = "");
        OrderPost GetDetailOrderPost(int oderId);
        List<OrderDetail> GetOrderDetailsForPostOrder(int orderid);
        void SuccessPostOrder(int id);

        #endregion

        #endregion
    }
}
