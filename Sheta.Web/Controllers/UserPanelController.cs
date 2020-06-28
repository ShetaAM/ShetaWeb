using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sheta.CoreLayer.Discount;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Order;
using Sheta.Data.Models.Entities.Site;
using Sheta.Data.Models.Entities.User;

namespace Sheta.Web.Controllers
{
    [Authorize]
    public class UserPanelController : Controller
    {
        private IUserService userService;
        private IOrderService _orderService;
        private ISiteService _siteService;

        public UserPanelController(IUserService userService, IOrderService orderService, ISiteService siteService)
        {
            this.userService = userService;
            _orderService = orderService;
            _siteService = siteService;
        }

        [Route("panel")]
        public IActionResult Index()
        {
            ViewBag.product = _orderService.GetUserProducts(User.Identity.Name);
            return View(userService.GetUserInformation(User.Identity.Name));
        }

        [Route("wallet")]
        public IActionResult Wallet()
        {
            ViewBag.wallet = userService.GetWallets(User.Identity.Name);
            return View();
        }
        [Route("wallet")]
        [HttpPost]
        public IActionResult Wallet(ChargeViewModel charge)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.wallet = userService.GetWallets(User.Identity.Name);
                return View(charge);
            }

            int walletId = userService.ChargeWalet(User.Identity.Name, charge.Amount, "شارژ حساب");

            #region Online Payment

            var payment = new ZarinpalSandbox.Payment(charge.Amount);

            var res = payment.PaymentRequest("شارژ کیف پول", "https://shetacom.ir/OnlinePayment/" + walletId);

            if (res.Result.Status == 100)
            {
                return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
            }

            #endregion
            return null;
        }

        [Route("editprofile")]
        public IActionResult EditProfile()
        {
            return View(userService.GetUserData(User.Identity.Name));
        }
        [Route("editprofile")]
        [HttpPost]
        public IActionResult EditProfile(User user, IFormFile imgAvatar)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            userService.EditUserPanel(User.Identity.Name, imgAvatar);
            return Redirect("/panel");
        }
        [Route("ChangePassword")]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Route("ChangePassword")]
        [HttpPost]
        public IActionResult ChangePassword(ChangePassViewModel change)
        {
            if (!ModelState.IsValid)
            {
                return View(change);
            }

            if (userService.CompareOldPass(change.OldPassword, User.Identity.Name))
            {
                userService.ChangePassword(User.Identity.Name, change.Password);
            }
            else
            {
                ModelState.AddModelError("OldPassword", "رمز وارد شده صحیح نمیباشد");
            }
            return Redirect("/login");
        }

        [Route("showorder")]
        public IActionResult ShowOrder(string type = "")
        {
            var order = _orderService.GetOrderForUserPanel(User.Identity.Name);
            if (order == null)
            {
                ViewBag.empty = true;
            }

            ViewBag.discounttype = type;
            return View(order);
        }


        [Route("finalyorder/{id}")]
        public IActionResult FinalyOrder(int id)
        {
            return View(_orderService.FinalyOrder(User.Identity.Name, id));
        }
        [Route("Factor")]
        public IActionResult SuratHesab()
        {
            return View(_orderService.SuratHesab(User.Identity.Name));
        }

        public IActionResult UseDiscount(string code)
        {
            DiscountUseType type = _orderService.UseDiscount(User.Identity.Name, code);
            return Redirect("/showorder" + "?type=" + type.ToString());
        }

        public IActionResult DeleteOrderDetail(int id)
        {
            _orderService.DeleteOrderDetal(id);
            return Redirect("/showorder");
        }

        #region Address

        [Route("useraddress")]
        public IActionResult Address()
        {
            return View(userService.GetAdressInfo(User.Identity.Name));
        }

        [Route("createaddress")]
        public IActionResult CreateAddress()
        {
            return View();
        }
        [HttpPost]
        [Route("createaddress")]
        public IActionResult CreateAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            userService.AddAdress(address, User.Identity.Name);
            return Redirect("/useraddress");
        }



        [Route("editaddress/{id}")]
        public IActionResult EditAddress(int id)
        {
            return View(userService.GetAddressInfo(id));
        }
        [HttpPost]
        [Route("editaddress/{id}")]
        public IActionResult EditAddress(Address address)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            userService.UpdateAddress(address);
            return Redirect("/useraddress");
        }

        public IActionResult DeleteAddress(int id)
        {
            userService.DeleteAddress(id);
            return Redirect("/useraddress");
        }
        public IActionResult DeleteAddressAdmin(int id)
        {
            userService.DeleteAddress(id);
            return Redirect("/admin/user/");
        }

        #endregion

        #region PostBuy
        public IActionResult Wizard()
        {
            return View(_orderService.GetWizardInfo(User.Identity.Name));
        }


        [HttpPost]
        public IActionResult Wizard(int orderid, int PayType, int SelectedAddress)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (PayType==0||SelectedAddress==0)
            {
                return NotFound();
            }

            var orderPost = _orderService.AddOrderPost(orderid, PayType, SelectedAddress);
            switch (orderPost.TypeId)
            {
                case 4:
                    {
                        _orderService.FinalyOrder(User.Identity.Name, orderid);
                        break;
                    }
                case 3:
                    {
                        int amount = _orderService.GetAmountByOrderid(orderid);
                        int walletId = userService.ChargeWalet(User.Identity.Name, amount, "خرید محصول");

                        #region Online Payment

                        var payment = new ZarinpalSandbox.Payment(amount);

                        var res = payment.PaymentRequest("خرید محصول", "https://shetacom.ir/OnlinePaymentOrder/" + orderid);

                        if (res.Result.Status == 100)
                        {
                            return Redirect("https://sandbox.zarinpal.com/pg/StartPay/" + res.Result.Authority);
                        }
                        #endregion

                        break;
                    }
                case 1:
                    {
                        return Redirect("/SuccessOrderPost/" + orderid);
                    }
            }
            return Redirect("/panel");
        }
        public IActionResult SuccessPostOrder(int id)
        {
            _siteService.SuccessPostOrder(id);
            return Redirect("/admin/postorder");
        }
        #endregion


    }
}