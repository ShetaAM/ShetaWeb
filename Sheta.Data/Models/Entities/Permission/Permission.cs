using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Sheta.Data.Models.Entities.Permission
{
    public class Permission
    {
        public Permission()
        {
            
        }

        [Key]
        public int PermissionId { get; set; }

        [Display(Name = "عنوان نقش")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string PermisionTitle { get; set; }
        public int? ParentId { get; set; }


        [ForeignKey("ParentId")]
        public virtual List<Permission> Permissions { get; set; }
    }
}
