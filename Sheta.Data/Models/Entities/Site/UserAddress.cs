using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Sheta.Data.Models.Entities.Order;

namespace Sheta.Data.Models.Entities.Site
{
    public class UserAddress
    {
        public UserAddress()
        {
            
        }
        [Key]
        public int UserAddressId { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }

        #region rel

        [ForeignKey("UserId")]
        public virtual User.User User { get; set; }
        public virtual Address Address { get; set; }

        #endregion
    }
}
