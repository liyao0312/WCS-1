using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Models;
using WCS.PageModels;

namespace WCS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var model = new PageModel();
            var filename = Server.MapPath(@"~/App_Data/SampleData.json");

            model.PopulateDataFromJsonFile(filename);
            return View(model);
        }
        
    }
}