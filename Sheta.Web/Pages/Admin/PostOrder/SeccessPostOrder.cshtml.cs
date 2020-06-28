using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.DTOs;
using Sheta.CoreLayer.Security;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.PostOrder
{
    [PermissionChecker(45)]
    public class SeccessPostOrderModel : PageModel
    {
        private ISiteService _siteService;

        public SeccessPostOrderModel(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [BindProperty]
        public PostOrdersDto PostOrdersDto { get; set; }
        public void OnGet(int pageid = 1, string Filter = "")
        {
            PostOrdersDto = _siteService.GetAllSuccessPostOrders(pageid, Filter);
        }
    }
}