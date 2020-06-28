using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sheta.Data.Models.Entities.Discount
{
    public class UserDiscount
    {
        public UserDiscount()
        {
            
        }

        [Key]
        public int UDId { get; set; }
        public int UserId { get; set; }
        public int DiscountId { get; set; }

        public User.User User { get; set; }
        public Discount Discount { get; set; }  
    }
}
