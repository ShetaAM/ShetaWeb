using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Product;

namespace Sheta.Web.Pages.Admin.Group
{
    [PermissionChecker(18)]
    public class DeleteGroupModel : PageModel
    {
        private IProductService _productService;

        public DeleteGroupModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductGroup ProductGroup { get; set; }  
        public void OnGet(int id)
        {
            ProductGroup = _productService.GetGroupForDelete(id);
        }

        public IActionResult OnPost(int id)
        {
            _productService.DeleteGroupAndProduct(id);
            return RedirectToPage("Index");
        }
    }
}