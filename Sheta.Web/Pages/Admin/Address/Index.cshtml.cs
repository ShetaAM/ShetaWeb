using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Site;

namespace Sheta.Web.Pages.Admin.Address
{
    [PermissionChecker(32)]
    public class IndexModel : PageModel
    {
        private ISiteService _siteService;

        public IndexModel(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [BindProperty]
        public List<UserAddress> UserAddresses { get; set; }
        [BindProperty]
        public int Userid { get; set; }
        public void OnGet(int id)
        {
            UserAddresses = _siteService.GetAddressesUser(id);
            Userid = id;
        }
    }
}