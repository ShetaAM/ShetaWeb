using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.User
{
    [PermissionChecker(2)]
    public class IndexModel : PageModel
    {
        private IUserService userService;

        public IndexModel(IUserService userService)
        {
            this.userService = userService;
        }

        public UserForAdminViewModel UserForAdminViewModel { get; set; }
        public void OnGet(int pageid=1,string filter="")
        {
            UserForAdminViewModel=userService.GetUsers(pageid, filter);

        }
    }
}