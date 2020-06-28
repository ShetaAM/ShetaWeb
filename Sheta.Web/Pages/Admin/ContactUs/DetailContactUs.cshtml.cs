using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.ContactUs
{
    [PermissionChecker(38)]
    public class DetailContactUsModel : PageModel
    {
        private ISiteService _siteService;

        public DetailContactUsModel(ISiteService siteService)
        {
            _siteService = siteService;
        }
        [BindProperty]
        public Data.Models.Entities.Site.ContactUs Tamas { get; set; }
        public void OnGet(int id)
        {
            Tamas = _siteService.GetInfoTamas(id);
        }
    }
}