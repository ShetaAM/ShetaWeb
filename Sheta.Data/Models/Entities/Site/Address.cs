using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Sheta.Data.Models.Entities.Order;

namespace Sheta.Data.Models.Entities.Site
{
    public class Address
    {
        public Address()
        {
            
        }
        [Key]
        public int AddressId { get; set; }

        [Display(Name = "استان")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Ostan { get; set; }

        [Display(Name = "شهر")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string City { get; set; }

        [Display(Name = "شهرستان")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Shahrestan { get; set; }

        [Display(Name = "آدرس دقیق")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string Adres { get; set; }

        [Display(Name = "کد پستی")]
        [MaxLength(200, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد .")]
        public string CodePosty { get; set; }

        #region rel

        public virtual List<UserAddress> UserAddresses { get; set; }
        public virtual List<OrderPost> OrdrPosts { get; set; }

        #endregion
    }
}
