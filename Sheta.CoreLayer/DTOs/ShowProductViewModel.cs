using System;
using System.Collections.Generic;
using System.Text;
using Sheta.Data.Models.Entities.Product;

namespace Sheta.CoreLayer.DTOs
{
   public class ShowProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string ProductImage { get; set; }
        public int ProductPrice { get; set; }
        public int ProductDiscount { get; set; }
    }

   public class ProductViewModel
   {
       public List<ProductDetail> ProductDetails { get; set; }
       public Product Product { get; set; }
       
   }
}
