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
        UnitOfWork _unitOfWork =  new UnitOfWork(new SimpleBlogContext());

        //Default Constructor
        public LoginController() { }

        public LoginController(UnitOfWork unitOfWork)
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
            var user = _unitOfWork.Users.GetUserByEmailAndPassword(model.Email, model.Password);

            if(user != null)
            {
                Session["CurrentUser"] = user;
                return RedirectToAction("Index", "Dashboard");
            }
            else
            {
                ViewBag.NoValidUser = true;
            }

            return View("Login");
        }
    }
}