using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Bcpg.OpenPgp;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Brands;

namespace Sheta.Web.Pages.Admin.Brand
{
    [PermissionChecker(30)]
    public class EditBrandModel : PageModel
    {
        private IProductService _productService;

        public EditBrandModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Brands Brand { get; set; }
        public void OnGet(int id)
        {
            Brand = _productService.GetBrandById(id);
        }
        public IActionResult OnPost(IFormFile imgBrand)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.UpdatatBrand(Brand, imgBrand);
            return RedirectToPage("index");
        }
    }
}