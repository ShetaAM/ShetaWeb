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
    [PermissionChecker(11)]
    public class IndexModel : PageModel
    {
        private IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty]
        public List<Data.Models.Entities.Discount.Discount> Discounts { get; set; }

        [BindProperty]
        public int pagecount  { get; set; }
        [BindProperty]
        public int currentpage  { get; set; }
        public void OnGet(int pageid = 1, string filter = "")
        {
            Discounts = _orderService.DiscountsForAdmin(pageid, filter,pagecount,currentpage);
        }
    }
}