using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Hosting;

namespace WCS.Models
{
    public class PageModel
    {
        public List<Car> Results;
        public List<Car> SavedCars;

        public void PopulateDataFromJsonFile(string filename)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var tempPageModel = ser.Deserialize<PageModel>(File.ReadAllText(filename));
            Results = tempPageModel.Results;
            SavedCars = tempPageModel.SavedCars;
        }        
    }
}