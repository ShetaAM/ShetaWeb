using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Controllers
{
    public class ProductController : Controller
    {
        private IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        
        public IActionResult Index(int id,int pageid=1,string filter="",string type="all",string orderby="date")
        {
            ViewBag.type = type;
            ViewBag.orderby = orderby;
            return View(_productService.GetProductToShowArchive(id,pageid,filter,type,orderby));
        }

        [Route("offproducts")]
        public IActionResult OffProducts(int pageid = 1, string filter = "", string type = "all",
            string orderby = "date")
        {

            return View(_productService.GetProductoff(pageid, filter, type));
        }

        [Route("product/{id}")]
        public IActionResult ShowProduct(int id)
        {
            return View(_productService.GetProductForShow(id));
        }

    }
}