using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Profile
{
    [PermissionChecker(36)]
    public class IndexModel : PageModel
    {
        private ISiteService _siteService;

        public IndexModel(ISiteService siteService)
        {
            _siteService = siteService;
        }
        [BindProperty]
        public Data.Models.Entities.User.User user { get; set; }
        public void OnGet()
        {
            user = _siteService.GetUserForAdmin(User.Identity.Name);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _siteService.UpdateProfile(user);
            HttpContext.SignOutAsync();
            return Redirect("/login");
        }
    }
}