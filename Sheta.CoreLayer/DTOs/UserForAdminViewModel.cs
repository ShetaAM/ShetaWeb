using System;
using System.Collections.Generic;
using System.Text;
using Sheta.Data.Models.Entities.User;

namespace Sheta.CoreLayer.DTOs
{
    public class UserForAdminViewModel
    {
        public List<User> Users { get; set; }
        public int CurentPage  { get; set; }
        public int PageCount { get; set; }
    }
}
