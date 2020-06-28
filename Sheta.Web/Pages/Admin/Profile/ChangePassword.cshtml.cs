using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Profile
{
    [PermissionChecker(36)]
    public class ChangePasswordModel : PageModel
    {
        private ISiteService _siteService;

        public ChangePasswordModel(ISiteService siteService)
        {
            _siteService = siteService;
        }
        [BindProperty]
        public PasswordViewModel PasswordViewModel { get; set; }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            if (_siteService.isexistUser(PasswordViewModel.OldPassword,User.Identity.Name))
            {
                _siteService.UpdataPassword(User.Identity.Name, PasswordViewModel.NewPassword);
            }
            else
            {
                ModelState.AddModelError("oldpasswor", "رمز عبور فعلی اشتباست");
            }

            HttpContext.SignOutAsync();
            return Redirect("/admin");
        }
    }
}