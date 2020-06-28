using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Context;

namespace Sheta.CoreLayer.Servises
{
    public class StatsticService:IStatisticService
    {
        private DatabaseContext db;

        public StatsticService(DatabaseContext db)
        {
            this.db = db;
        }
        public int NumberOfUsers()
        {
            return db.Users.Count(u => !u.isdelete);
        }

        public int NumberOfDeleteUser()
        {
            return db.Users.Count(u => u.isdelete);
        }

        public int NumberOfGroups()
        {
            return db.ProductGroups.Count(u => !u.IsDelete);
        }

        public int NumberOfBrands()
        {
            return db.Brandses.Count(u => !u.IsDelete);
        }

        public int NumberOfProducts()
        {
            return db.Products.Count();
        }

        public int NumberOfSuccessFactors()
        {
            return db.Orders.Count(u => u.IsFinaly);
        }

        public int NumberOfUnpaidFactors()
        {
            return db.Orders.Count(u => !u.IsFinaly);
        }

        public int NumberOfPostFactors()
        {
            return db.OrderPosts.Count();
        }

        public int NumberOfSuccessPostOrder()
        {
            return db.OrderPosts.Count(o => o.IsSuccess);
        }
    }
}
