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
        Repository repository = new Repository();
        public ActionResult Index()
        {
            var filename = Server.MapPath(@"~/App_Data/SampleData.json");
            
            var model = repository.PopulatePageModelFromJsonFile(filename);
            return View(model);
        }

        public ActionResult Add(string id)
        {
            var filename = Server.MapPath(@"~/App_Data/SampleData.json");            
            var model = repository.PopulatePageModelFromJsonFile(filename);
            model = repository.AddToSavedCars(id, model);
            var boolResult = repository.SavePageModelToJsonFile(filename, model);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            var filename = Server.MapPath(@"~/App_Data/SampleData.json");
            var model = repository.PopulatePageModelFromJsonFile(filename);
            model = repository.RemoveFromSavedCars(id, model);
            var boolResult = repository.SavePageModelToJsonFile(filename, model);
            return RedirectToAction("Index");
        }
    }
}