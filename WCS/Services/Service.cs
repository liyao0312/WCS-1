using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WCS.PageModels;

namespace WCS.Services
{
    public class Service
    {
        public PageModel AddToSavedCars(string carId, PageModel model)
        {   //check if the car already saved, then return 
            if (model.SavedCars.Where(c => c.Id == carId).Count() > 0) return model;
            var selectedCarModel = model.Results.Where(c => c.Id == carId).FirstOrDefault();
            if (selectedCarModel != null)
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