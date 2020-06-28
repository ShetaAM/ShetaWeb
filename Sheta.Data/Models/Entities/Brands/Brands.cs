using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Sheta.Data.Models.Entities.Brands
{
    public class Brands
    {
        public Brands()
        {
            
        }
        [Key]
        public int BrandId { get; set; }

        [Display(Name = "عنوان برند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string BrandTitle { get; set; }

        [Display(Name = "تصویر برند")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string BrandImage { get; set; }

        [Display(Name = "حذف شده")]
        public bool IsDelete { get; set; }

        public virtual List<Product.Product> Products { get; set; }

    }
}
