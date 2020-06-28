using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Social
{
    [PermissionChecker(40)]
    public class IndexModel : PageModel
    {
        private ISiteService _siteService;

        public IndexModel(ISiteService siteService)
        {
            _siteService = siteService;
        }
        [BindProperty]
        public SocViewModel SocViewModel { get; set; }

        public void OnGet(int id, int pageid = 1, string filter = "")
        {
            SocViewModel = _siteService.GetAllSocials(pageid, filter);
        }
    }
}