using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text;

namespace Sheta.Data.Models.Entities.Discount
{
    public class Discount
    {
        public Discount()
        {

        }

        [Key]
        public int DiscountId { get; set; }

        [Display(Name = "کد تخفیف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string DiscountCode { get; set; }

        [Display(Name = "درصد تخفبف")]
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public int DiscountPersent { get; set; }
        [Display(Name = "تعداد قابل استفاده")]
        public int? UsableCount { get; set; }
        [Display(Name = "تاریخ شروع تخفیف")]
        public DateTime? StartDate { get; set; }
        [Display(Name = "تاریخ پایان تخفیف")]
        public DateTime? EndTime { get; set; }



        public virtual List<UserDiscount> UserDiscounts { get; set; }
    }
}
