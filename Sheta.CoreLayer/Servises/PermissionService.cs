using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Context;
using Sheta.Data.Models.Entities.Permission;
using Sheta.Data.Models.Entities.User;

namespace Sheta.CoreLayer.Servises
{
    public class PermissionService : IPermissionService
    {
        private DatabaseContext db;

        public PermissionService(DatabaseContext db)
        {
            this.db = db;
        }
        public List<Role> GetRoles()
        {
            return db.Roles.ToList();
        }

        public int AddRole(Role role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
            return role.RoleId;
        }

        public Role GetRoleById(int roleId)
        {
            return db.Roles.Find(roleId);
        }

        public void UpdateRole(Role role)
        {
            db.Roles.Update(role);
            db.SaveChanges();
        }

        public void DeleteRole(Role role)
        {
            role.isdelete = true;
            UpdateRole(role);
        }

        public void AddRolesToUser(List<int> roleIds, int userId)
        {
            foreach (int roleId in roleIds)
            {
                db.UserRoles.Add(new UserRole()
                {
                    RoleId = roleId,
                    UserId = userId
                });
            }

            db.SaveChanges();
        }

        public void EditRolesUser(int userId, List<int> rolesId)
        {
            //Delete All Roles User
            db.UserRoles.Where(r => r.UserId == userId).ToList().ForEach(r => db.UserRoles.Remove(r));
            db.SaveChanges();

            //Add New Roles
            AddRolesToUser(rolesId, userId);
        }

        public List<Permission> GetAllPermission()
        {
            return db.Permissions.ToList();
        }

        public void AddPermissionsToRole(int roleId, List<int> permission)
        {
            foreach (var p in permission)
            {
                db.RolePermissions.Add(new RolePermission()
                {
                    PermissionId = p,
                    RoleID = roleId
                });
            }

            db.SaveChanges();
        }

        public List<int> PermissionsRole(int roleId)
        {
            return db.RolePermissions
                .Where(r => r.RoleID == roleId)
                .Select(r => r.PermissionId).ToList();
        }

        public void UpdatePermissionsRole(int roleId, List<int> permissions)
        {
            db.RolePermissions.Where(p=>p.RoleID==roleId)
                .ToList().ForEach(p=> db.RolePermissions.Remove(p));

            AddPermissionsToRole(roleId,permissions);
        }

        public bool CheckPermission(int permissionid, string username)
        {
            int userid = db.Users.Single(u => u.UserName == username).UserId;
            List<int> UserRole = db.UserRoles.Where(u => u.UserId == userid).Select(u => u.RoleId).ToList();
            if (!UserRole.Any())
            {
                return false;
            }

            List<int> rolepermission = db.RolePermissions.Where(r => r.PermissionId == permissionid)
                .Select(r => r.RoleID).ToList();

            return rolepermission.Any(r => UserRole.Contains(r));
        }

        public List<int> GetUserRoles(int userid)
        {
            return db.UserRoles
                .Where(u => u.UserId == userid)
                .Select(u=>u.RoleId).ToList();
        }
    }
}
