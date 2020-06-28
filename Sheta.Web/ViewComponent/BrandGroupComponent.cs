using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.ViewComponent
{
    public class BrandGroupComponent : Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private IProductService productService;

        public BrandGroupComponent(IProductService productService)
        {
            this.productService = productService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("BrandGroup", productService.GetAllBrandses()));
        }
    }
}
