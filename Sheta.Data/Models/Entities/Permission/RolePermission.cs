using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text;
using Sheta.Data.Models.Entities.User;

namespace Sheta.Data.Models.Entities.Permission
{
    public class RolePermission
    {
        public RolePermission()
        {
            
        }

        [Key]
        public int RPId { get; set; }
        public int RoleID { get; set; }
        public int PermissionId { get; set; }


        public virtual Role Role { get; set; }
        public virtual Permission Permission { get; set; }

    }
}
