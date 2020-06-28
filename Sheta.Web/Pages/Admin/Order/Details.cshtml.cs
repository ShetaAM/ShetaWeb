using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Order;

namespace Sheta.Web.Pages.Admin.Order
{
    [PermissionChecker(27)]
    public class DetailsModel : PageModel
    {
        private IOrderService _orderService;

        public DetailsModel(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [BindProperty]
        public Data.Models.Entities.Order.Order Order { get; set; }
        [BindProperty] 
        public int OrderId { get; set; }
        public void OnGet(int id)
        {
            OrderId = id;
            Order = _orderService.GetOrderDetailsByOrderId(id);
        }
    }
}