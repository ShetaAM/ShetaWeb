using System;
using System.Collections.Generic;
using System.Text;
using Sheta.Data.Models.Entities.Site;

namespace Sheta.CoreLayer.DTOs
{
    public class ContactViewModel
    {
        public Address address { get; set; }
        public Setting Setting { get; set; }
    }
}
