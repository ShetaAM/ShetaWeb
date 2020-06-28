using System;
using System.Collections.Generic;
using System.Text;
using Sheta.CoreLayer.Discount;
using Sheta.CoreLayer.DTOs;
using Sheta.Data.Models.Entities.Order;
using Sheta.Data.Models.Entities.User;
using Sheta.Data.Models.Entities.Discount;
using Sheta.Data.Models.Entities.Site;

namespace Sheta.CoreLayer.Servises.Interface
{
    public interface IOrderService
    {
        int AddOrder(string username, int productid);
        void UpdatePrice(int orderid);
        Order GetOrderForUserPanel(string username);
        bool FinalyOrder(string username, int orderid);
        List<OrderDetail> SuratHesab(string username);
        string GetProductTitleById(int productid);
        List<UserProduct>GetUserProducts(string username);
        OrderDetail GetOrderDetail(int odid);
        void DeleteOrderDetal(int did);
        void SuccessOrder(int orderid);

        #region Discount

        DiscountUseType UseDiscount(string username,string code);
        List<Data.Models.Entities.Discount.Discount> DiscountsForAdmin(int pageid=1,string filter="",int pagecount=0,int currentpage=0);
        void AddDicount(Data.Models.Entities.Discount.Discount discount);
        Data.Models.Entities.Discount.Discount GetDiscountForUpdate(int discountid);
        void UpdateDiscount(Data.Models.Entities.Discount.Discount discount);

        void DeleteDiscount(int disid);

        #endregion

        #region OrderAdmin

        List<Order> GetAllOrder(int pageid=1,string filter="",int currentpage=0,int pagecount=0);
        Order GetOrderDetailsByOrderId(int orderid);

        #endregion


        #region PostOrder

        PostOrderDTO GetWizardInfo(string username);
        OrderPost AddOrderPost(int orderid, int PayType, int SelectedAddress);

        int GetAmountByOrderid(int orderid);
        Order GetOderById(int orderid);
        void UpdateOrder(Order order);

        void AddProductToUser(Order order,int userId);
        OrderInfoDTO GetFactor(int orderId);


        #endregion
    }
}
