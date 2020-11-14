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
    public class AccidentTypeController : Controller
    {
        private FireStationEntities db = new FireStationEntities();

        // GET: AccidentType
        public ActionResult Index()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    return View(db.tbl_AccidentType.ToList());
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
        //GET:AccidentType/Create
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
        [HttpPost]
        public ActionResult Create([Bind(Include = "AccidentTypeId,AccidentTypeTitel")] tbl_AccidentType tbl_AccidentType)
        {
            int itemid = 0;
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        Random ra = new Random();
                        itemid = ra.Next(1000, 9999);
                        while (db.tbl_AccidentType.FirstOrDefault(x => x.AccidentTypeId == itemid) != null)
                        {
                            itemid = ra.Next(1000, 9999);
                        }
                        tbl_AccidentType.AccidentTypeId = itemid;
                        db.tbl_AccidentType.Add(tbl_AccidentType);
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
            return View(tbl_AccidentType);
        }
        // GET: AccidentType/Details/5
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
                        return RedirectToAction("Err", "Home", new { code = "E-3022", text = "هیچ حادثه ای انتخاب نشده است", url = Request.Url.Scheme });
                    }
                    tbl_Accident tbl_Accident = db.tbl_Accident.Find(id);
                    if (tbl_Accident == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-3022", text = "شناسه حادثه وارد شده معتبر نیست انتخاب نشده است", url = Request.Url.Scheme });
                    }
                    return View(tbl_Accident);
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
        // GET: AccidentType/Edit/5
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
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ نوع داده ای انتخاب نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_AccidentType tbl_AccidentType = db.tbl_AccidentType.Find(id);
                    if (tbl_AccidentType == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ داده ای باشماره مورد نظر وجود ندارد", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_AccidentType);
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

        // POST: AccidentType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccidentTypeId,AccidentTypeTitel")] tbl_AccidentType tbl_AccidentType)
        {
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        db.Entry(tbl_AccidentType).State = EntityState.Modified;
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
            return View(tbl_AccidentType);
        }

        // GET: AccidentType/Delete/5
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
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ نوع حادثه ای انتخاب نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_AccidentType tbl_AccidentType = db.tbl_AccidentType.Find(id);
                    if (tbl_AccidentType == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ حادثه ای باشماره مورد نظر وجود ندارد", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_AccidentType);
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

        // POST: AccidentType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbl_AccidentType tbl_AccidentType = db.tbl_AccidentType.Find(id);
                db.tbl_AccidentType.Remove(tbl_AccidentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Err", "Home", new { code = "E-1133", text = "ارور بررسی نشده", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                throw;
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
