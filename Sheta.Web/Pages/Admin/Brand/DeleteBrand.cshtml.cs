using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Brands;

namespace Sheta.Web.Pages.Admin.Brand
{
    [PermissionChecker(31)]
    public class DeleteBrandModel : PageModel
    {
        private IProductService _productService;

        public DeleteBrandModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public Brands Brands { get; set; }
        public void OnGet(int id)
        {
            Brands = _productService.GetBrandById(id);
        }

        public IActionResult OnPost()
        {
            _productService.DeleteBrands(Brands.BrandId);
            return RedirectToPage("index");
        }
    }
}