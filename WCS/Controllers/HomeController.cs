using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WCS.Models;
using WCS.PageModels;
using WCS.Repositories;
using WCS.Services;

namespace WCS.Controllers
{
    public class HomeController : Controller
    {        
        Repository repository = new Repository(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/SampleData.json"));
        Service service = new Service();

        // GET: Home
        public ActionResult Index()
        {            
            var model = repository.LoadPageModelFromJsonFile();
            return View(model);
        }

        public ActionResult Add(string id)
        {          
            var model = repository.LoadPageModelFromJsonFile();
            model = service.AddToSavedCars(id, model);
            var boolResult = repository.SavePageModelToJsonFile(model);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(string id)
        {
            var model = repository.LoadPageModelFromJsonFile();
            model = service.RemoveFromSavedCars(id, model);
            var boolResult = repository.SavePageModelToJsonFile(model);
            return RedirectToAction("Index");
        }
    }
}