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
        private string FileName { get; set; }
        public Repository(string filename)
        {
            FileName = filename;
        }
        public PageModel LoadPageModelFromJsonFile()
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var tempPageModel = ser.Deserialize<PageModel>(File.ReadAllText(FileName));            
            return tempPageModel;
        }
        public bool SavePageModelToJsonFile(PageModel model)
        {
            JavaScriptSerializer ser = new JavaScriptSerializer();
            var stringJson = ser.Serialize(model);
            System.IO.File.WriteAllText(FileName, stringJson);
            return true;
        }
       
    }
}