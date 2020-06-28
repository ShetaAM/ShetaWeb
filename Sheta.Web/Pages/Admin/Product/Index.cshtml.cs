using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Product
{
    [PermissionChecker(19)]
    public class IndexModel : PageModel
    {
        private IProductService productService;

        public IndexModel(IProductService productService)
        {
            this.productService = productService;
        }

        public ProductForAdminViewModel ProductForAdminViewModel { get; set; }
        public void OnGet(int pageid = 1, string filter = "")
        {
            ProductForAdminViewModel = productService.GetProductsForAdmin(pageid,filter);

        }
    }
}