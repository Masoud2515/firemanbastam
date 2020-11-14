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
    public class UsageController : Controller
    {
        private FireStationEntities db = new FireStationEntities();

        // GET: Usage
        public ActionResult Index()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    return View(db.tbl_Usage.ToList());
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

        // GET: Usage/Details/5
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
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ شناسه ای وارد نشده", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_Usage tbl_Usage = db.tbl_Usage.Find(id);
                    if (tbl_Usage == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ نوع کاربری  با شناسه وارد شده ثبت نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_Usage);
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

        // GET: Usage/Create
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

        // POST: Usage/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UsageId,UsageTitel,UsageDescription")] tbl_Usage tbl_Usage)
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
                        while (db.tbl_Usage.FirstOrDefault(m => m.UsageId == randm) != null)
                        {
                            randm = random.Next(10000, 20000);

                        }
                        tbl_Usage.UsageId = Convert.ToInt32(randm);
                        db.tbl_Usage.Add(tbl_Usage);
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
            return View(tbl_Usage);
        }

        // GET: Usage/Edit/5
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
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ شناسه ای وارد نشده", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_Usage tbl_Usage = db.tbl_Usage.Find(id);
                    if (tbl_Usage == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ نوع کاربری  با شناسه وارد شده ثبت نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_Usage);
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

        // POST: Usage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UsageId,UsageTitel,UsageDescription")] tbl_Usage tbl_Usage)
        {
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        db.Entry(tbl_Usage).State = EntityState.Modified;
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
            return View(tbl_Usage);
        }

        // GET: Usage/Delete/5
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
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_Usage tbl_Usage = db.tbl_Usage.Find(id);
                    if (tbl_Usage == null)
                    {
                        return HttpNotFound();
                    }
                    return View(tbl_Usage);
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

        // POST: Usage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    tbl_Usage tbl_Usage = db.tbl_Usage.Find(id);
                    db.tbl_Usage.Remove(tbl_Usage);
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
