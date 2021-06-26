using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using FireStation.Models.ViewModel;
using FireStation.Models;

namespace FireStation.Controllers
{
    public class AccountController : Controller
    {
        private Context db = new Context();

        public ActionResult Login()
        {
            Session.RemoveAll();
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                Context _context = new Context();
                List<tbl_User> _user = _context.tbl_User.ToList();
                foreach (var item in _user)
                {
                    //hashPassword.Equals(item.WHU4)
                    //string hashPassword = new Functions().CreateHashPass(model.Password);
                    if (item.UserUserName.Contains(model.UserName) && item.UserPassword.Contains(model.Password))
                    {
                        var user = _context.tbl_User.Single(u => u.UserUserName == model.UserName && u.UserPassword == model.Password);
                        if (user != null)
                        {
                            Session["OnlineUser"] = user.UserId.ToString();
                            Session["UserName"] = user.UserUserName.ToString();
                            Session["UserRole"] = user.UserRole.ToString();
                            Session["nafa"] = string.Format("{0} {1}", user.tbl_Employee.EmployeeName, user.tbl_Employee.EmployeeLastName);
                            Session["Pic"] = user.tbl_Employee.EmployeePicUrl;
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            ModelState.AddModelError("", "نام کاربری یا کلمه عبور وارد شده صحیح نیست");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError("", "نام کاربری یا کلمه عبور وارد شده وجود ندارد");
                    }
                }

            }
            return View(model);
        }
        public ActionResult AdminPannel()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                {
                    ViewBag.back = db.tbl_Accident.ToList();
                    return View();
                }
                else
                {
                    return RedirectToAction("Accessdenied");

                }
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
        public ActionResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login");
        }
        public ActionResult Detail()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Detail(UserViewModel user)
        {
            return View();
        }
        public ActionResult Chengepasword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Chengepasword(UserViewModel user)
        {
            return View();
        }
        public ActionResult Message()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Message(UserViewModel user)
        {
            return View();
        }
    }
}