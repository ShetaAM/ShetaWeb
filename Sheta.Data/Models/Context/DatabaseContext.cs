using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Sheta.Data.Models.Entities.Brands;
using Sheta.Data.Models.Entities.Discount;
using Sheta.Data.Models.Entities.Order;
using Sheta.Data.Models.Entities.Permission;
using Sheta.Data.Models.Entities.Product;
using Sheta.Data.Models.Entities.Site;
using Sheta.Data.Models.Entities.User;

namespace Sheta.Data.Models.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {

        }

        #region Users

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<WalletType> WalletTypes { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public DbSet<Permission> Permissions { get; set; }  
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserProduct> UserProducts { get; set; }

        #endregion
        #region Product

        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<ProductStatus> ProductStatuses { get; set; }
        public DbSet<ProductDetail> ProductDetails { get; set; }
        public DbSet<Brands> Brandses { get; set; }

        #endregion

        #region order

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderPost> OrderPosts { get; set; }
        public DbSet<OrderPostType> OrderPostTypes { get; set; }

        #endregion

        #region Discount

        public DbSet<UserDiscount> UserDiscounts { get; set; }
        public DbSet<Discount> Discounts { get; set; }

        #endregion

        #region Site

        public DbSet<Address> Addresses { get; set; }
        public DbSet<UserAddress> UserAddresses { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Social> Socials { get; set; }

        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.isdelete);
            modelBuilder.Entity<Role>()
                .HasQueryFilter(r => !r.isdelete);

            modelBuilder.Entity<ProductGroup>()
                .HasQueryFilter(c => !c.IsDelete);

            modelBuilder.Entity<Brands>()
                .HasQueryFilter(c => !c.IsDelete);
            base.OnModelCreating(modelBuilder);
        }
    }

}
