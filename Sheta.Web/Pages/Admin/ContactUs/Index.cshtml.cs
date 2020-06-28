using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.ContactUs
{
    [PermissionChecker(37)]
    public class IndexModel : PageModel
    {
        private ISiteService _siteService;

        public IndexModel(ISiteService siteService)
        {
            _siteService = siteService;
        }
        [BindProperty]
        public TamashaViewModel ViewModel { get; set; }
        public void OnGet(int pageid = 1, string filter = "")
        {
            ViewModel = _siteService.GetAllTamas(pageid, filter);
        }
    }
}