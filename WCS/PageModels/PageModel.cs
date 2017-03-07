using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Hosting;
using WCS.Models;

namespace WCS.PageModels
{
    public class PageModel
    {
        public List<Car> Results;
        public List<Car> SavedCars;
    }
}