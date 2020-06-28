using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Product
{
    [PermissionChecker(21)]
    public class EditProductModel : PageModel
    {
        private IProductService _productService;

        public EditProductModel(IProductService productService)
        {
            this._productService = productService;
        }

        [BindProperty] public Data.Models.Entities.Product.Product Product { get; set; }
        public void OnGet(int id)
        {
            Product=_productService.GetProductById(id);

            var groups = _productService.GetGroupForAdmin();
            ViewData["Groups"] = new SelectList(groups, "Value", "Text",Product.GroupId);

            var subGrous = _productService.GetSubGroupForAdmin(int.Parse(groups.First().Value));
            ViewData["SubGroups"] = new SelectList(subGrous, "Value", "Text",Product.SubGroup??0);

            var status = _productService.GetProductStatus();
            ViewData["Status"] = new SelectList(status, "Value", "Text",Product.StatusId);

            var brands = _productService.GetProductBrands();
            ViewData["Brands"] = new SelectList(brands, "Value", "Text");
        }

        public IActionResult OnPost(IFormFile imgProductUp)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _productService.UpdatatProduct(Product, imgProductUp);
            return RedirectToPage("index");
        }
    }
}