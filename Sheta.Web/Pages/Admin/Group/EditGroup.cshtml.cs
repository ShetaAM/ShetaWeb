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
    [PermissionChecker(17)]
    public class EditGroupModel : PageModel
    {
        private IProductService _productService;

        public EditGroupModel(IProductService productService)
        {
            _productService = productService;
        }

        [BindProperty]
        public ProductGroup ProductGroup { get; set; }  
        public void OnGet(int id)
        {
            ProductGroup = _productService.GetGroupById(id);
            var groups = _productService.GetBaseGroupsbybase();
            ViewData["BaseGroup"] = new SelectList(groups, "Value", "Text",ProductGroup.ParentId);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();

            _productService.UpdateGroup(ProductGroup);
            return RedirectToPage("Index");
        }
    }
}