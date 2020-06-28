using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sheta.CoreLayer.DTOs;
using Sheta.Data.Models.Context;
using Sheta.Data.Models.Entities.Brands;
using Sheta.Data.Models.Entities.Product;

//using Sheta.Data.Models.Entities.Courses;

namespace Sheta.CoreLayer.Servises.Interface
{
    public interface IProductService
    {
        List<ProductGroup> GetAllCourseGroups();
        List<SelectListItem> GetGroupForAdmin();
        List<SelectListItem> GetSubGroupForAdmin(int Groupid);

        List<SelectListItem> GetProductStatus();
        List<SelectListItem> GetProductBrands();
        ProductForAdminViewModel GetProductsForAdmin(int pageid = 1,string Filter="");

        int AddProduct(Product product, IFormFile ImgProuct);

        Product GetProductById(int ProductId);
        void UpdatatProduct(Product product, IFormFile ImgProuct);

        ProductGroupForAdminModel GetGroupsForAdmin(int pageid = 1, string Filter = "");

        string GetGroupTitleByParnetId(int? parentid);

        List<SelectListItem> GetBaseGroups();

        List<SelectListItem> GetBaseGroupsbybase();

        void AddGroup(ProductGroup productGroup);

        ProductGroup GetGroupById(int Groupid);
        void UpdateGroup(ProductGroup productGroup);

        List<Product> getDiscountProducts();
        int GetOffFromProduct(int id,int price, int prsent);

        #region ProductDetail

        List<ProductDetail> GetaDetailForProductAdmin(int productid);
        int GetProductId(int id);
        void AddDetailProduct(int pId, ProductDetail productDetail);

        ProductDetail GetProductDetail(int id);
        string GetProductTitleById(int ProductId);

        void DeleteProductDetail(int id);

        #endregion

        #region ShowProduct

        List<ShowProductViewModel> GetProductToShowArchive(int groupid,int pageid = 1, string filter = "", string getType = "all",
            String orderBy = "date");

        List<ShowProductViewModel> GetProductToShow(int pageid = 1, string filter = "", string getType = "all",
            String orderBy = "date");

        List<ShowProductViewModel> GetProductoff(int pageid = 1, string filter = "", string getType = "all",
            string orderBy = "date");
        ProductViewModel GetProductForShow(int id);

        bool IsProductForUser(string username, int productId);

        #endregion

        #region Brands

        List<Brands> GetAllBrandses();
        BrandForAdminViewModel GetBrandForAdmin(int pageid = 1, string Filter = "");

        int AddBrand(Brands brands, IFormFile ImgBrand);

        Brands GetBrandById(int brandid);
        void UpdatatBrand(Brands brands, IFormFile ImgBrand);

        void DeleteBrands(int id);

        #endregion

        #region Admin

        void DeleteGroupAndProduct(int groupid);

        ProductGroup GetGroupForDelete(int groupid);

        void DeleteProductAdmin(int productid);

        

        #endregion
    }
}
