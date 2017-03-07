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
        public List<CarModel> results;
        public List<CarModel> savedCars;

        public void PopulateDataFromJsonFile(string filename)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var tempPageModel = ser.Deserialize<PageModel>(File.ReadAllText(filename));
            results = tempPageModel.results;
            savedCars = tempPageModel.savedCars;
                
                
        }
    }
}