using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SimpleBlog.Controllers
{
    public class DashboardController : Controller
    {
        public DashboardController() { }

        // GET: Dashboard
        public ActionResult Index()
        {
            return View();
        }
    }
}