using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Controllers
{
    public class SubController : Controller
    {
        private IProductService _productService;

        public SubController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult GetSubGroups(int id)
        {
            List<SelectListItem> list = new List<SelectListItem>()
            {
                new SelectListItem(){Text = "انتخاب کنید",Value = ""}
            };
            list.AddRange(_productService.GetSubGroupForAdmin(id));
            return Json(new SelectList(list, "Value", "Text"));
        }
    }
}