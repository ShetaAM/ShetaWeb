using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Order;
using Sheta.Data.Models.Entities.User;

namespace Sheta.Web.Controllers
{
    public class PaymentController : Controller
    {
        private IUserService userService;
        private IOrderService _orderService;

        public PaymentController(IUserService userService, IOrderService orderService)
        {
            this.userService = userService;
            _orderService = orderService;
        }


        [Route("OnlinePayment/{id}")]
        public IActionResult onlinePayment(int id)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                var wallet = userService.GetWalletByWalletId(id);

                var payment = new ZarinpalSandbox.Payment(wallet.Amount);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;
                    wallet.IsPay = true;
                    userService.UpdateWallet(wallet);
                }

            }

            return View();
        }


        [Route("OnlinePaymentOrder/{orderId}")]
        public IActionResult onlinePaymentOrder(int orderId)
        {
            if (HttpContext.Request.Query["Status"] != "" &&
                HttpContext.Request.Query["Status"].ToString().ToLower() == "ok"
                && HttpContext.Request.Query["Authority"] != "")
            {
                string authority = HttpContext.Request.Query["Authority"];

                var order = _orderService.GetOderById(orderId);

                var payment = new ZarinpalSandbox.Payment(order.OrderSum);
                var res = payment.Verification(authority).Result;
                if (res.Status == 100)
                {
                    ViewBag.code = res.RefId;
                    ViewBag.IsSuccess = true;
                    var wallet=new Wallet()
                    {
                        TypeId = 3,
                        IsPay = true,
                        UserId = userService.GetUserIdByUserName(User.Identity.Name),
                        Amount = order.OrderSum,
                        Description = "خرید محصول",
                        CreateDate = DateTime.Now
                    };
                    userService.AddWallet(wallet);
                    order.IsFinaly = true;
                    _orderService.UpdateOrder(order);
                    _orderService.AddProductToUser(order,userService.GetUserIdByUserName(User.Identity.Name));
                }

            }

            return View();
        }

        [Route("SuccessOrderPost/{orderId}")]
        public IActionResult PostSuccesOrder(int orderId)
        {
            return View(_orderService.GetFactor(orderId));
        }
    }
}