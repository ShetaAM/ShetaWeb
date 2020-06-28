using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Org.BouncyCastle.Crypto.Agreement;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Product
{
    [PermissionChecker(20)]
    public class CreateProductModel : PageModel
    {
        private IProductService _productService;

        public CreateProductModel(IProductService productService)
        {
            this._productService = productService;
        }

        [BindProperty] public Data.Models.Entities.Product.Product Product { get; set; }

        public void OnGet()
        {
            var groups = _productService.GetGroupForAdmin();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text");

            var subGrous = _productService.GetSubGroupForAdmin(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subGrous, "Value", "Text");

            var status = _productService.GetProductStatus();
            ViewData["Status"] = new SelectList(status, "Value", "Text");

            var brands = _productService.GetProductBrands();
            ViewData["Brands"] = new SelectList(brands, "Value", "Text");
        }

        public IActionResult OnPost(IFormFile imgProductUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _productService.AddProduct(Product, imgProductUp);
            return RedirectToPage("index");
        }
    }
}