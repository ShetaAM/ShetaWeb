using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Sheta.Data.Models.Entities.Site;

namespace Sheta.Data.Models.Entities.Order
{
    public class OrderPost
    {
        public OrderPost()
        {
            
        }

        [Key]
        public int OrderPostId { get; set; }

        [Required]
        public int OrderId { get; set; }

        [Required]
        public int AddressId { get; set; }

        [Required]
        public int TypeId { get; set; }

        [Required]
        public bool IsSuccess { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Orders{ get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        [ForeignKey("TypeId")]
        public virtual OrderPostType OrderPostType { get; set; }

    }
}
