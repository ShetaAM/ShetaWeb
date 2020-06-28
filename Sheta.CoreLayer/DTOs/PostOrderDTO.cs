using System;
using System.Collections.Generic;
using System.Text;
using Sheta.Data.Models.Entities.Order;
using Sheta.Data.Models.Entities.Site;

namespace Sheta.CoreLayer.DTOs
{
    public class PostOrderDTO
    {
        public List<OrderDetail> OrderDetails { get; set; }
        public List<UserAddress> UserAddresses { get; set; }
        public List<OrderPostType> OrderPostTypes { get; set; }
        public int OrderId { get; set; }
        public int ordrsum { get; set; }

    }

    public class OrderInfoDTO
    {
        public List<OrderDetail> ordrsDetails { get; set; }
        public DateTime CreateDate { get; set; }
        public int OrderId { get; set; }
        public string PostType { get; set; }
        public int OrderSum { get; set; }
    }

    
}
