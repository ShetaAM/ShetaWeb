using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Setting
{
    [PermissionChecker(35)]
    public class IndexModel : PageModel
    {
        private ISiteService _siteService;

        public IndexModel(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [BindProperty]
        public Data.Models.Entities.Site.Setting Setting { get; set; }
        public void OnGet()
        {
            Setting = _siteService.GetSettingForAdmin();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _siteService.UpdateSetting(Setting);
            return Redirect("/admin");
        }
    }
}