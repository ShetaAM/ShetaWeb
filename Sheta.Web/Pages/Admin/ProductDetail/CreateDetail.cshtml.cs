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
    [PermissionChecker(24)]
    public class CreateDetailModel : PageModel
    {
        private IProductService _productService;

        public CreateDetailModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Data.Models.Entities.Product.ProductDetail ProductDetail { get; set; }    

        [BindProperty] 
        public int PCode { get; set; }   
        public void OnGet(int id)
        {
            PCode = id;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.AddDetailProduct(PCode,ProductDetail);
            return Redirect("/Admin/ProductDetail/" + PCode);
        }
    }
}