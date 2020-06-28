using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin
{
   
    public class IndexModel : PageModel
    {
        private IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public LoginAdminViewModel LoginViewModel { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Redirect("/admin");
            }
            if (LoginViewModel.Email == null)
            {
                return Page();
            }

            if (LoginViewModel.Password == null)
            {
                return Page();
            }

            var user = _userService.LoginUserAdmin(LoginViewModel);
            if (user != null)
            {
                var Claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName),
                    new Claim(ClaimTypes.Email,user.Email)
                };
                var identity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = LoginViewModel.RememberMe
                };
                HttpContext.SignInAsync(principal, properties);
                return Redirect("/admin/ControlPanel");

            }
            else
            {
                ModelState.AddModelError("Email", "کاربری با مشخصات وارد شده یافت نشد!");
            }

            return Page();

        }
    }
}