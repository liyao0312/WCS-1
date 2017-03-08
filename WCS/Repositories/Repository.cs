using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using WCS.PageModels;

namespace WCS.Repositories
{
    public class Repository
    {
        public PageModel PopulatePageModelFromJsonFile(string filename)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var tempPageModel = ser.Deserialize<PageModel>(File.ReadAllText(filename));
            
            return tempPageModel;
        }
        public bool SavePageModelToJsonFile(string filename, PageModel model)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var stringJson = ser.Serialize(model);
            System.IO.File.WriteAllText(filename, stringJson);
            return true;
        }
        public PageModel AddToSavedCars(string carId, PageModel model)
        {   //check if the car already saved, then return 
            if (model.SavedCars.Where(c => c.Id == carId).Count() > 0) return model;
            var selectedCarModel = model.Results.Where(c => c.Id == carId).FirstOrDefault();
            if(selectedCarModel!=null)
            {
                model.SavedCars.Add(selectedCarModel);
            }
            return model;
        }
        public PageModel RemoveFromSavedCars(string carId, PageModel model)
        {   
            var selectedCarModel = model.SavedCars.Where(c => c.Id == carId).FirstOrDefault();
            if (selectedCarModel != null)
            {
                model.SavedCars.Remove(selectedCarModel);
            }
            return model;
        }
    }
}