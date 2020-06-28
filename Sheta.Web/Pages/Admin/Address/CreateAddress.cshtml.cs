using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Address
{
    [PermissionChecker(33)]
    public class CreateAddressModel : PageModel
    {
        private ISiteService _siteService;

        public CreateAddressModel(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [BindProperty]
        public Data.Models.Entities.Site.Address Addresses { get; set; }
        [BindProperty]
        public int Userid { get; set; }
        public void OnGet(int id)
        {
            Userid = id;
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _siteService.AddAddress(Addresses,Userid);
            return Redirect("/admin/address/"+Userid);

        }
    }
}