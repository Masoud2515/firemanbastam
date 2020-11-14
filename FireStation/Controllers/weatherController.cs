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
    public class weatherController : Controller
    {
        private FireStationEntities db = new FireStationEntities();

        // GET: weather
        public ActionResult Index()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    return View(db.tbl_weather.ToList());
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: weather/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ نوع شرایط جوی انتخاب نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_weather tbl_weather = db.tbl_weather.Find(id);
                    if (tbl_weather == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ یک از شرایط جوی باشماره مورد نظر وجود ندارد", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_weather);
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // GET: weather/Create
        public ActionResult Create()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    return View();
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: weather/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "WeatherId,WeatherTitel,WeatherDec")] tbl_weather tbl_weather)
        {
            int randm = 0;
            Random random = new Random();
            randm = random.Next(10000, 20000);
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        while (db.tbl_weather.FirstOrDefault(m => m.WeatherId == randm) != null)
                        {
                            randm = random.Next(10000, 20000);
                        }
                        tbl_weather.WeatherId = Convert.ToInt32(randm);
                        db.tbl_weather.Add(tbl_weather);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {

                        return RedirectToAction("Accessdenied", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(tbl_weather);
        }

        // GET: weather/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ نوع شرایط جوی انتخاب نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_weather tbl_weather = db.tbl_weather.Find(id);
                    if (tbl_weather == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ یک از شرایط جوی باشماره مورد نظر وجود ندارد", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_weather);
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: weather/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WeatherId,WeatherTitel,WeatherDec")] tbl_weather tbl_weather)
        {
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        db.Entry(tbl_weather).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {

                        return RedirectToAction("Accessdenied", "Home");
                    }
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return View(tbl_weather);
        }

        // GET: weather/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ نوع داده ای انتخاب نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_weather tbl_weather = db.tbl_weather.Find(id);
                    if (tbl_weather == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ داده ای باشماره مورد نظر وجود ندارد", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_weather);
                }
                else
                {
                    return RedirectToAction("Accessdenied", "Home");
                }
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }

        // POST: weather/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_weather tbl_weather = db.tbl_weather.Find(id);
            db.tbl_weather.Remove(tbl_weather);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
