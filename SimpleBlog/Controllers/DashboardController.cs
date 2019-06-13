using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using SimpleBlog.Core.Domain;
using SimpleBlog.Core.Repositories;

namespace SimpleBlog.Controllers
{
    public class DashboardController : Controller
    {
        private readonly IUserRepository _userRepository;

        public DashboardController() { }

        public DashboardController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: Dashboard
        public ActionResult Index()
        {
            //Get Logged In users data
            if (Session["CurrentUser"] != null)
            {
                return View();
            }
            else
            {
                return View("Login");
            }
        }
    }
}