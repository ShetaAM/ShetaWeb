using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.User;

namespace Sheta.Web.Pages.Admin.Wallets
{
    [PermissionChecker(10)]
    public class IndexModel : PageModel
    {
        private IUserService _userService;

        public IndexModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty] public List<Wallet> wallets { get; set; }   
        public void OnGet(int id)
        {
            wallets = _userService.GetAllWallets(id);
        }
    }
}