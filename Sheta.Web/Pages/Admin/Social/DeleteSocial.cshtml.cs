using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Social
{
    [PermissionChecker(43)]
    public class DeleteSocialModel : PageModel
    {
        private ISiteService _siteService;

        public DeleteSocialModel(ISiteService siteService)
        {
            _siteService = siteService;
        }
        [BindProperty]
        public Data.Models.Entities.Site.Social Social { get; set; }
        public void OnGet(int id)
        {
            Social = _siteService
                .GetInfoSocial(id);
            ViewData["socialid"] = id;
        }

        public IActionResult OnPost(int socialid)
        {
            _siteService.DeleteSocial(socialid);
            return RedirectToPage("index");
        }
    }
}