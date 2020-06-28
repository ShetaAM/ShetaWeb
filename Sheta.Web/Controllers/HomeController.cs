using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Sheta.CoreLayer.Servises.Interface;

//using Sheta.Web.Models;

namespace Sheta.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IProductService _productService;
        private ISiteService _siteService;

        public HomeController(ILogger<HomeController> logger, IProductService productService, ISiteService siteService)
        {
            _logger = logger;
            _productService = productService;
            _siteService = siteService;
        }

        public IActionResult Index(int pageid=1,string Filter="")
        {
            if (_siteService.SiteIsActive()==false)
            {
                return Redirect("/SiteNotFound");
            }
            return View(_productService.GetProductToShow(pageid,Filter));
        }

        public IActionResult GetSubGroup(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem()
                {
                    Text = "انتخاب کنید",
                    Value = "0",
                }
            };
            list.AddRange(_productService.GetSubGroupForAdmin(id));
            return Json(new SelectList(list, "value", "text"));
        }

        [Route("SiteNotFound")]
        public IActionResult SiteNotFound()
        {
            return View();
        }
        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
