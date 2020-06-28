using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.ProductDetail
{
    [PermissionChecker(23)]
    public class IndexModel : PageModel
    {
        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public List<Data.Models.Entities.Product.ProductDetail> ProductDetails { get; set; }

        [BindProperty]
        public int Productid { get; set; }  
        public void OnGet(int id)
        {
            ProductDetails = _productService.GetaDetailForProductAdmin(id);
            Productid = _productService.GetProductId(id);

        }
    }
}