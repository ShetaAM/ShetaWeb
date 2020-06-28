using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Brands;

namespace Sheta.Web.Pages.Admin.Brand
{
    [PermissionChecker(28)]
    public class IndexModel : PageModel
    {
        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public BrandForAdminViewModel Brands { get; set; }
        public void OnGet(int pageid=1,string filter="")
        {
            Brands = _productService.GetBrandForAdmin(pageid,filter);
        }
    }
}