using System;
using System.Collections.Generic;
using System.Text;
using Sheta.Data.Models.Entities.Permission;
using Sheta.Data.Models.Entities.User;

namespace Sheta.CoreLayer.Servises.Interface
{
    public interface IPermissionService
    {
        #region Roles

        List<Role> GetRoles();
        int AddRole(Role role);
        Role GetRoleById(int roleId);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        void AddRolesToUser(List<int> roleIds, int userId);
        void EditRolesUser(int userId, List<int> rolesId);

        #endregion

        #region Permission

        List<Permission> GetAllPermission();
        void AddPermissionsToRole(int roleId, List<int> permission);
        List<int> PermissionsRole(int roleId);
        void UpdatePermissionsRole(int roleId, List<int> permissions);
        bool CheckPermission(int permissionid, string username);

        List<int> GetUserRoles(int userid);


        #endregion
    }
}
