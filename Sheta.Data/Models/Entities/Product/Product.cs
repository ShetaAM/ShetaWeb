using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Sheta.Data.Models.Entities.User;

namespace Sheta.Data.Models.Entities.Product
{
    public class Product
    {
        public Product()
        {
            
        }
        [Key]
        public int ProductId { get; set; }

        [Required]
        public int GroupId { get; set; }

        public int? BrandId { get; set; }
        public int? SubGroup { get; set; }

        [Required]
        public int StatusId { get; set; }

        [Display(Name = "عنوان محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(450, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string ProductTitle { get; set; }

        [Display(Name = "شرح محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string ProductDescription { get; set; }

        [Display(Name = "قیمت محصول")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int ProductPrice { get; set; }

        [MaxLength(600)]
        public string Tags { get; set; }

        [MaxLength(50)]
        public string ProductImageName { get; set; }

        [Required]
        public DateTime CreateDate { get; set; }

        
        public int ProductDiscount { get; set; }

        #region Relations

        [ForeignKey("GroupId")]
        public ProductGroup CourseG1 { get; set; }

        [ForeignKey("SubGroup")]
        public ProductGroup CourseG2 { get; set; }

        public ProductStatus ProductStatus { get; set; }
        public Brands.Brands Brands { get; set; }

        public List<ProductDetail> ProductDetail { get; set; }
        public virtual List<UserProduct> UserProducts { get; set; }

        #endregion
    }
}
