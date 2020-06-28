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
    [PermissionChecker(25)]
    public class DeleteDetailModel : PageModel
    {
        private IProductService _productService;

        public DeleteDetailModel(IProductService productService)
        {
            _productService = productService;
        }
        [BindProperty] 
        public Data.Models.Entities.Product.ProductDetail ProductDetail { get; set; }
        [BindProperty] 
        public int productid { get; set; }
        public void OnGet(int id)
        {
            ProductDetail = _productService.GetProductDetail(id);
        }

        public IActionResult OnPost(int id)
        {
            _productService.DeleteProductDetail(id);
            return Redirect("/Admin/Product/");
        }
    }
}