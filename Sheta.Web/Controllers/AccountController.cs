using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Utils;
using Sheta.CoreLayer.Convertor;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Generator;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Sender;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.User;

namespace Sheta.Web.Controllers
{
    public class AccountController : Controller
    {
        SendEmail sendEmail=new SendEmail();
        private IUserService userService;

        public AccountController(IUserService userService)
        {
            this.userService = userService;
        }

        #region register

        [Route("register")]
        public IActionResult Register()
        {
            return View();
        }

        [Route("register")]
        [HttpPost]
        public IActionResult Register(RegisterViewModel register)
        {
            if (!ModelState.IsValid)
            {
                return View(register);
            }

            if (userService.IsExistUserName(register.UserName))
            {
                ModelState.AddModelError("UserName", "این نام کاربری نمیتواند استفاده شود");
                return View(register);
            }

            if (userService.IsExistEmail(register.Email))
            {
                ModelState.AddModelError("Email", "ایمیل وارد شده معتبر نمیباشد");
            }

            User user = new User()
            {
                ActiveCode = NameGenerator.GenerateUniqCode(),
                UserName = register.UserName,
                Email = FixedText.FixEmail(register.Email),
                Password = PasswordHelper.EncodePasswordMd5(register.Password),
                UserAvatar = "avatar.png",
                RegisterDate = DateTime.Now,
                IsActive = false,

            };
            userService.AddUser(user);

            UserRole userRole = new UserRole()
            {
                UserId = user.UserId,
                RoleId = 2,
            };
            userService.AddUserRole(userRole);

            #region SEND EMAIL

            string subject = "فعالسازی حساب";
            string body = string.Format(
                @"<h1>SHETAweb</h1>
<h4>{0}عزیز ممنون از ثبت نام شما در سایت ما </h4>
<table><h4>اطلاعات حساب کاربری شما:</h4><ul><li><p> ایمیل:{1}</p></li><li> نام کاربری: {2}</li><li> زمان ثبت نام {3}</li></ul></table>
<hr/>
<h3> جهت فعالسازی حساب خود وارد لینک زیر شوید </h3>
<a href='https://shetacom.ir/Account/ActiveAccount/{4}'>فعالسازی اکانت</a>", user.UserName, user.Email, user.UserName, user.RegisterDate, user.ActiveCode);

            sendEmail.Send(user,subject,body);

            #endregion

            return View("SuccessRegister", user);
        }

        #endregion

        #region login

        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }

        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = userService.LoginUser(login);
            if (user != null)
            {
                if (user.IsActive)
                {
                    var claims = new List<Claim>()
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                        new Claim(ClaimTypes.Name, user.UserName)
                    };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties
                    {
                        IsPersistent = login.RememberMe
                    };
                    HttpContext.SignInAsync(principal, properties);
                    ViewBag.issuccess = true;
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError("UserName", "حساب کاربری شما فعال نیست");
                }
            }
            else
            {
                ModelState.AddModelError("UserName", "کاربری با مشخصات وارد شده یافت نشد");
            }

            return View();
        }

        #endregion

        #region Active

        public IActionResult ActiveAccount(string id)
        {
            ViewBag.IsActive = userService.ActiveAccount(id);
            return View();
        }

        #endregion

        #region Logout

        [Route("logout")]
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("login");
        }

        #endregion

        #region ForgetPass

        [Route("forgetpassword")]
        public IActionResult ForgetPass()
        {
            return View();
        }
        [Route("forgetpassword")]
        [HttpPost]
        public IActionResult ForgetPass(ForgetViewModel forget)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            User user = userService.isExistEmail(forget.Email);
            if (user != null)
            {
                string subject = "بازیابی کلمه عبور";
                string Body = string.Format(
            @"<h1>SHETAweb</h1>
<h4>عزیز جهت بازیابی کلمه عبور دکمه زیر را فشار دهید{0} </h4>
<a href='https://shetacom.ir:44303/Account/ResetPassword/{1}'> بازیابی کلمه عبور</a>", user.UserName,user.ActiveCode);

                sendEmail.Send(user,subject,Body);
            }
            else
            {
                ModelState.AddModelError("Email","ایمیلی با مشخصات زیر یافت نشد!");
            }

            ViewBag.success = true;
            return View();
        }


        #endregion

        #region Reset Password

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(string id, ResetViewModel reset)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            User user = userService.GetUserByActiveCode(id);
            if (user!=null)
            {
                userService.EditUser(user,reset.Password);
            }
            else
            {
                ModelState.AddModelError("Password","کاربری یافت نشد!");
            }
            return Redirect("/login");
        }

        #endregion

    }
}