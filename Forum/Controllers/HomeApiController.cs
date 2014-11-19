using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Forum.Controllers
{
    public class HomeApiController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}
