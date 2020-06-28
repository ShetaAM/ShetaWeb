using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.ViewComponent
{
    public class CourseGroupComponent:Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private IProductService productService;

        public CourseGroupComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("ProductGroup",productService.GetAllCourseGroups()));
        }
    }
}
