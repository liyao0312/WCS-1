using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Models;
using WCS.PageModels;
using WCS.Repositories;
namespace WCS.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var filename = Server.MapPath(@"~/App_Data/SampleData.json");
            var repository = new Repository();
            var model = repository.PopulatePageModelFromJsonFile(filename);
            return View(model);
        }
        
    }
}