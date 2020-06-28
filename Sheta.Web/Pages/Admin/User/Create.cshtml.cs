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
    [PermissionChecker(3)]
    public class CreateModel : PageModel
    {
        private IUserService _userService;
        private IPermissionService _permissionService;

        public CreateModel(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        [BindProperty]
        public CreateUserViewModel CreateUserViewModel { get; set; }

        public void OnGet()
        {
            ViewData["Roles"] = _permissionService.GetRoles();
        }

        public IActionResult OnPost(List<int> SelectedRoles)
        {
            if (!ModelState.IsValid)
                return Page();

            int userId = _userService.AddUserFromAdmin(CreateUserViewModel);

            //Add Roles
            _permissionService.AddRolesToUser(SelectedRoles, userId);


            return Redirect("/Admin/Users");

        }
    }
}