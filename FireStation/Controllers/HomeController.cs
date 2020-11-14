using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FireStation.Models;

namespace FireStation.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return RedirectToAction("AdminPannel", "Account");
        }
        public ActionResult Accessdenied()
        {
            if (Session["OnlineUser"] != null)
            {
                ViewBag.OnlineUser = Session["UserName"].ToString();
                ViewBag.OnlineUserRole = Session["UserRole"].ToString();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public ActionResult AboutUs()
        {
            if (Session["OnlineUser"] != null)
            {
                ViewBag.OnlineUser = Session["UserName"].ToString();
                ViewBag.OnlineUserRole = Session["UserRole"].ToString();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public ActionResult ContactUs()
        {

            return View();
        }
        public ActionResult Err(string code, string text, string url)
        {
            if (Session["OnlineUser"] != null)
            {
                ViewBag.OnlineUser = Session["UserName"].ToString();
                ViewBag.OnlineUserRole = Session["UserRole"].ToString();
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
            ViewBag.code = code;
            ViewBag.text = text;
            ViewBag.url = url;
            return View();
        }
    }

}