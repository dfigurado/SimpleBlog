using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleBlog.Core;
using SimpleBlog.Core.Domain;
using SimpleBlog.Persistence;
using SimpleBlog.ViewModels;

namespace SimpleBlog.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;


        //Default Constructor
        public LoginController() { }

        public LoginController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = _unitOfWork.Users.GetAll().Where(u => u.Email == model.Email).Where(u => u.Password == model.Password);

            if(user != null)
            {
                Session["CurrentUser"] = user;
                return View("/Account/Dashboard");
            }
            else
            {
                ViewBag.NoValidUser = true;
            }

            return View("Login");
        }

        public ActionResult UserDashBoard()
        {
            return View();
        }
    }
}