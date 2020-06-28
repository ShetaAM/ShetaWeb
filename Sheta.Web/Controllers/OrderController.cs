using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Controllers
{
    public class OrderController : Controller
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [Route("order/{id}")]
        public IActionResult Index(int id)
        {
            return View(_orderService.AddOrder(User.Identity.Name,id));
        }
    }
}