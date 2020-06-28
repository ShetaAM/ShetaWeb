using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Social
{
    [PermissionChecker(41)]
    public class CreateSocialModel : PageModel
    {
        private ISiteService _siteService;

        public CreateSocialModel(ISiteService siteService)
        {
            _siteService = siteService;
        }
        [BindProperty]
        public Data.Models.Entities.Site.Social Social { get; set; }
        public void OnGet()
        {

        }

        public IActionResult Onpost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _siteService.CreateSocial(Social);
            return RedirectToPage("index");
        }
    }
}