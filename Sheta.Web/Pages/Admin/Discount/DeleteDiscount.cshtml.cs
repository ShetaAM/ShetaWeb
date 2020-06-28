using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Discount
{
    [PermissionChecker(14)]
    public class DeleteDiscountModel : PageModel
    {
        private IOrderService _orderService;

        public DeleteDiscountModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
        public Data.Models.Entities.Discount.Discount Discount { get; set; }
        public void OnGet(int id)
        {
            Discount = _orderService.GetDiscountForUpdate(id);
        }

        public IActionResult OnPost(int id)
        {
            _orderService.DeleteDiscount(id);
            return RedirectToPage("Index");
        }
    }
}