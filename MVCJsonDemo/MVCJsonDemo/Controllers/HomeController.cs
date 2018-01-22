using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCJsonDemo.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetJson1()
        {
            var jsonData = new Person { Age = 1, Name = "MyName", Home = "MyHome" };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetJson2()
        {
            var jsonData = new Dictionary<int, Person>();
            jsonData.Add(1, new Person { Age = 1, Name = "MyName", Home = "MyHome" });
            jsonData.Add(2, new Person { Age = 1, Name = "MyName", Home = "MyHome" });
            jsonData.Add(3, new Person { Age = 1, Name = "MyName", Home = "MyHome" });
            //var jss = new System.Web.Script.Serialization.JavaScriptSerializer();
            //var table = jss.Serialize(jsonData);

            var table = Newtonsoft.Json.JsonConvert.SerializeObject(jsonData);
            //var d = Newtonsoft.Json.JsonConvert.DeserializeObject<Dictionary<int,Person>>(table);
            return Json(table, JsonRequestBehavior.AllowGet);
        }
    }

    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }
        public string Home { get; set; }
    }
}