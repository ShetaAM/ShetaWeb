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
    [PermissionChecker(4)]
    public class EditUserModel : PageModel
    {
        private IUserService _userService;
        private IPermissionService _permissionService;

        public EditUserModel(IUserService userService, IPermissionService permissionService)
        {
            _userService = userService;
            _permissionService = permissionService;
        }

        [BindProperty] 
        public Data.Models.Entities.User.User User { get; set; }
        public void OnGet(int id)
        {
            User = _userService.GetUserForShowInEditMode(id);
            ViewData["Roles"] = _permissionService.GetRoles();
            ViewData["SelectedRoles"] = _permissionService.GetUserRoles(id);
        }

        public IActionResult OnPost(List<int> SelectedRoles,string password)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _userService.EditUserFromAdmin(User,password);

            //Edit Roles
            _permissionService.EditRolesUser(User.UserId, SelectedRoles);
            return RedirectToPage("Index");
        }
    }
}