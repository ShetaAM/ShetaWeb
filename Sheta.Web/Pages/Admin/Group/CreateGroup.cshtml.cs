using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Product;

namespace Sheta.Web.Pages.Admin.Group
{
    [PermissionChecker(16)]
    public class CreateGroupModel : PageModel
    {
        private IProductService _productService;

        public CreateGroupModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductGroup ProductGroup { get; set; }  
        public void OnGet()
        {
            var groups = _productService.GetBaseGroupsbybase();
            ViewData["BaseGroup"] = new SelectList(groups, "Value", "Text");
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.AddGroup(ProductGroup);
            return RedirectToPage("Index");
        }
    }
}