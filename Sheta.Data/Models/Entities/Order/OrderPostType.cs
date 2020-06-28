using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Sheta.Data.Models.Entities.Order
{
    public class OrderPostType
    {
        public OrderPostType()
        {
            
        }

        [Key]
        public int TypeId { get; set; }

        [Required]
        [MaxLength(150)]
        public string TypeTitle { get; set; }

        [Required]
        [MaxLength(50)]
        public string TypeIcon { get; set; }

        public List<OrderPost> OrderPosts { get; set; }
    }
}
