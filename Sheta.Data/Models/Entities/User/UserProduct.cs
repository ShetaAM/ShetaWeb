using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sheta.Data.Models.Entities.User
{
    public class UserProduct
    {
        public UserProduct()
        {
            
        }

        [Key]
        public int UPId { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }

        public virtual User User { get; set; }
        public virtual Product.Product Product { get; set; }
    }
}
