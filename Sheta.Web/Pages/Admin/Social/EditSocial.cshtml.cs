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
    [PermissionChecker(42)]
    public class EditSocialModel : PageModel
    {
        private ISiteService _siteService;

        public EditSocialModel(ISiteService siteService)
        {
            _siteService = siteService;
        }
        [BindProperty]
        public Data.Models.Entities.Site.Social Social { get; set; }
        public void OnGet(int id)
        {
            Social = _siteService.GetInfoSocial(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _siteService.EditSocial(Social);
            return RedirectToPage("index");
        }
    }
}