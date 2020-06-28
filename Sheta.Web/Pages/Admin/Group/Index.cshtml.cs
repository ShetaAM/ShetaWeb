using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Group
{
    [PermissionChecker(15)]
    public class IndexModel : PageModel
    {
        private IProductService _productService;

        public IndexModel(IProductService productService)
        {
            _productService = productService;
        }

        public ProductGroupForAdminModel ProductGroupForAdminModel { get; set; }
        public void OnGet(int pageid = 1, string filter = "")
        {
            ProductGroupForAdminModel = _productService.GetGroupsForAdmin(pageid,filter);
        }
    }
}