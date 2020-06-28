using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Order;

namespace Sheta.Web.Pages.Admin.PostOrder
{
    [PermissionChecker(46)]
    public class DetailPostModel : PageModel
    {
        private ISiteService _siteService;

        public DetailPostModel(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [BindProperty]
        public OrderPost OrderPost { get; set; }
        public void OnGet(int id)
        {
            OrderPost = _siteService.GetDetailOrderPost(id);
        }
    }
}