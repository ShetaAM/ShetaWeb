using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Sheta.Data.Models.Entities.Product
{
    public class ProductDetail
    {
        public ProductDetail()
        {
            
        }

        [Key]
        public int PdId { get; set; }
        public int ProductId { get; set; }

        [Display(Name = "عنوان مشخصه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string DetailCaption { get; set; }

        [Display(Name = "مقدار مشخصه")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string DetailDec { get; set; }

        public Product Product { get; set; }
    }
}
