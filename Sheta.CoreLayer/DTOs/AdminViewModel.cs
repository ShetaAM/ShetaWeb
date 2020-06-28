using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Sheta.Data.Models.Entities.Brands;
using Sheta.Data.Models.Entities.Order;
using Sheta.Data.Models.Entities.Product;
using Sheta.Data.Models.Entities.Site;
using Sheta.Data.Models.Entities.User;

namespace Sheta.CoreLayer.DTOs
{
    public class ProductForAdminViewModel
    {
        public List<Product> Products { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class ProductGroupForAdminModel
    {
        public List<ProductGroup> ProductGroups { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }
    public class BrandForAdminViewModel
    {
        public List<Brands> Brandses { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class PasswordViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [Compare("NewPassword")]
        public string ReNewPassword { get; set; }
    }

    public class TamashaViewModel
    {
        public List<ContactUs> ContactUses { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class SocViewModel
    {
        public List<Social> Socials { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }
    }

    public class PostOrdersDto
    {
        public List<OrderPost> OrderPosts { get; set; }
        public int CurrentPage { get; set; }
        public int PageCount { get; set; }  
    }

    public class ControlPanelDto
    {
        public List<User> Users { get; set; }
        public List<ProductGroup> ProductGroups { get; set; }
        public List<Product> Products { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderPost> OrderPosts { get; set; }
        public List<Brands> Brandses { get; set; }
        public List<Social> Socials { get; set; }
    }
}
