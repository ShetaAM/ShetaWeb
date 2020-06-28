using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Sheta.CoreLayer.Servises.Interface;
using Sheta.Data.Models.Entities.Site;

namespace Sheta.Web.Controllers
{
    public class ContactController : Controller
    {
        private ISiteService _siteService;

        public ContactController(ISiteService siteService)
        {
            _siteService = siteService;
        }

        [Route("ContactUs")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("ContactUs")]
        public IActionResult Index(ContactUs contact)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            _siteService.AddContact(contact);
            return Redirect("/Contact/SucessSend");

        }

        public IActionResult SucessSend()
        {
            return View();
        }

        [Route("aboutus")]
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}
