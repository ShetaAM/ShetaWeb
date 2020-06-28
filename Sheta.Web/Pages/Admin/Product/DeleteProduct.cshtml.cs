using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Product
{
    [PermissionChecker(22)]
    public class DeleteProductModel : PageModel
    {
        private IProductService _productService;

        public DeleteProductModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty] 
        public Data.Models.Entities.Product.Product Product { get; set; }
        public void OnGet(int id)
        {
            Product = _productService.GetProductById(id);
        }
        public IActionResult OnPost(int id)
        {
            _productService.DeleteProductAdmin(id);
            return RedirectToPage("Index");
        }
    }
}