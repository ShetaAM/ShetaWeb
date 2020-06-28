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
    [PermissionChecker(34)]
    public class EditAddressModel : PageModel
    {
        private IUserService _userService;
        private ISiteService _siteService;

        public EditAddressModel(IUserService userService, ISiteService siteService)
        {
            _userService = userService;
            _siteService = siteService;
        }

        [BindProperty]
        public Data.Models.Entities.Site.Address Addresses { get; set; }

        public UserAddress UserAddress { get; set; }
        public void OnGet(int id)
        {
            Addresses = _userService.GetAddressInfo(id);
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _userService.UpdateAddress(Addresses);
            return Redirect("/Admin/Address/" + _siteService.GetUserIdByAddressId(Addresses.AddressId));
        }
    }
}