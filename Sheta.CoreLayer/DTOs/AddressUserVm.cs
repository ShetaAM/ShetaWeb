using System;
using System.Collections.Generic;
using System.Text;
using Sheta.Data.Models.Entities.Site;

namespace Sheta.CoreLayer.DTOs
{
    public class AddressUserVm
    {
        public Address Address { get; set; }
        public int UserId { get; set; }
    }
}
