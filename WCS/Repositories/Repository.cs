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
        public PageModel PopulateDataFromJsonFile(string filename)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var tempPageModel = ser.Deserialize<PageModel>(File.ReadAllText(filename));
            
            return tempPageModel;
        }
    }
}