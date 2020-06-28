using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.ViewComponent
{
    public class SocialGroupComponent:Microsoft.AspNetCore.Mvc.ViewComponent
    {
        private ISiteService _siteService;

        public SocialGroupComponent(ISiteService siteService)
        {
            _siteService = siteService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("SocialGroup", _siteService.GetSocialToShow()));
        }
    }
}
