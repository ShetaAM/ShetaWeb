using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Order
{
    [PermissionChecker(26)]
    public class IndexModel : PageModel
    {
        private IOrderService _orderService;

        public IndexModel(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [BindProperty] 
        public List<Data.Models.Entities.Order.Order> Orders { get; set; }  
        [BindProperty] public int CurrentPage { get; set; }
        [BindProperty] public int PageCount { get; set; }
        public void OnGet(int pageid = 1, string filter = "")
        {
            Orders = _orderService.GetAllOrder(pageid, filter, CurrentPage, PageCount);
        }
    }
}