using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FireStation.Models;
using System.IO;

namespace FireStation.Controllers
{
    public class MissivesController : Controller
    {
        private FireStationEntities db = new FireStationEntities();

        // GET: Missives
        public ActionResult Index()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    var tbl_Missives = db.tbl_Missives.Include(t => t.tbl_User);
                    return View(tbl_Missives.ToList());
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

        // GET: Missives/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_Missives tbl_Missives = db.tbl_Missives.Find(id);
                    if (tbl_Missives == null)
                    {
                        return HttpNotFound();
                    }
                    return View(tbl_Missives);
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
        public FilePathResult DownloadExampleFiles(string fileName)
        {
            return new FilePathResult(string.Format(@"~/{0}", fileName), "text/plain");
        }
        // GET: Missives/Create
        public ActionResult Create()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.MissiveUserId = new SelectList(db.tbl_User, "UserId", "UserUserName");
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

        // POST: Missives/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MissiveId,MissiveTitel,MissiveText,MissiveFileUrl,MissiveDate,MissiveNumber,MissiveUserId")] tbl_Missives tbl_Missives, HttpPostedFileBase Fdoc)
        {
            Random rand = new Random();
            int ra;
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                    {
                        ra = rand.Next(1000000, 2000000);
                        while (db.tbl_Missives.FirstOrDefault(f => f.MissiveId == ra) != null)
                        {
                            ra = rand.Next(1000000, 2000000);
                        }
                        tbl_Missives.MissiveId = ra;
                        var Fi1 = Path.GetExtension(Fdoc.FileName);
                        var Ri1 = Path.Combine(Server.MapPath("~/Documents/Doc/"), string.Format("{0}{1}", ra.ToString(), Fi1));
                        Fdoc.SaveAs(Ri1);
                        tbl_Missives.MissiveFileUrl = string.Format("Documents/Doc/{0}{1}", ra.ToString(), Fi1);
                        tbl_Missives.MissiveUserId = Convert.ToInt32(Session["OnlineUser"]);
                        db.tbl_Missives.Add(tbl_Missives);
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

            ViewBag.MissiveUserId = new SelectList(db.tbl_User, "UserId", "UserUserName", tbl_Missives.MissiveUserId);
            return View(tbl_Missives);
        }

        // GET: Missives/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ شناسه ای وارد نشده", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_Missives tbl_Missives = db.tbl_Missives.Find(id);
                    if (tbl_Missives == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ بخشنامه ای با شناسه وارد شده ثبت نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    ViewBag.MissiveUserId = new SelectList(db.tbl_User, "UserId", "UserUserName", tbl_Missives.MissiveUserId);
                    return View(tbl_Missives);
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

        // POST: Missives/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MissiveId,MissiveTitel,MissiveText,MissiveFileUrl,MissiveDate,MissiveNumber,MissiveUserId")] tbl_Missives tbl_Missives, HttpPostedFileBase Fdoc)
        {
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                    {
                        if (Fdoc != null)
                        {
                            var Fi1 = Path.GetExtension(Fdoc.FileName);
                            var Ri1 = Path.Combine(Server.MapPath("~/Documents/Doc/"), string.Format("{0}{1}", tbl_Missives.MissiveId.ToString(), Fi1));
                            Fdoc.SaveAs(Ri1);
                            tbl_Missives.MissiveFileUrl = string.Format("Documents/Doc/{0}{1}", tbl_Missives.MissiveId.ToString(), Fi1);
                        }

                        db.Entry(tbl_Missives).State = EntityState.Modified;
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
            ViewBag.MissiveUserId = new SelectList(db.tbl_User, "UserId", "UserUserName", tbl_Missives.MissiveUserId);
            return View(tbl_Missives);
        }

        // GET: Missives/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ شناسه ای وارد نشده", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_Missives tbl_Missives = db.tbl_Missives.Find(id);
                    if (tbl_Missives == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ بخشنامه ای با شناسه وارد شده ثبت نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_Missives);
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
        // POST: Missives/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    try
                    {
                        tbl_Missives tbl_Missives = db.tbl_Missives.Find(id);
                        db.tbl_Missives.Remove(tbl_Missives);
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    catch (Exception)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "ارور بررسی نشده", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        throw;
                    }
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
