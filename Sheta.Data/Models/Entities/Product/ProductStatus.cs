using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sheta.Data.Models.Entities.Product
{
   public class ProductStatus
    {
        public ProductStatus()
        {
            
        }
        [Key]
        public int StatusId { get; set; }

        [Required]
        [MaxLength(150)]
        public string StatusTitle { get; set; }

        public List<Product> Products { get; set; }

    }
}
