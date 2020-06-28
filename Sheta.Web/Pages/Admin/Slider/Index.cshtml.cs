using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Sheta.CoreLayer.Servises.Interface;

namespace Sheta.Web.Pages.Admin.Slider
{
    public class IndexModel : PageModel
    {
        private ISiteService _siteService;

        public IndexModel(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [BindProperty]
        public Data.Models.Entities.Site.Slider Slider { get; set; }
        public void OnGet()
        {
            Slider = _siteService.GetSliderForAdmin();
        }

        public IActionResult OnPost(IFormFile imgslider)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _siteService.UpdateSlider(Slider, imgslider);
           return Redirect("/admin");
        }
    }
}