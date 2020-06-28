using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Brands;

namespace Sheta.Web.Pages.Admin.Brand
{
    [PermissionChecker(29)]
    public class CreateBrandModel : PageModel
    {
        private IProductService _productService;

        public CreateBrandModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Brands Brand { get; set; }
        public void OnGet()
        {
            
        }

        public IActionResult OnPost(IFormFile imgbrand)
        {
            _productService.AddBrand(Brand, imgbrand);
            return RedirectToPage("index");


        }
    }
}