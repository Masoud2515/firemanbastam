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
    public class InjuredController : Controller
    {
        private Context db = new Context();

        // GET: Injured
        public ActionResult Index()
        {
            try
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        return View(db.tbl_Injured.ToList());
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
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // GET: Injured/Details/5
        public ActionResult Details(int? id)
        {
            try
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
                        tbl_Injured tbl_Injured = db.tbl_Injured.Find(id);
                        if (tbl_Injured == null)
                        {
                            return HttpNotFound();
                        }
                        return View(tbl_Injured);
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
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // GET: Injured/Create
        public ActionResult Create()
        {
            try
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
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
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // POST: Injured/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InjuredID,InjuredName,InjuredLastName,InjuredSex,InjuredType,InjuredTypeinjury,InjuredDescription,InjuredLocation")] tbl_Injured tbl_Injured)
        {
            try
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        if (ModelState.IsValid)
                        {
                            db.tbl_Injured.Add(tbl_Injured);
                            db.SaveChanges();
                            return RedirectToAction("Index");
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
                return View(tbl_Injured);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // GET: Injured/Edit/5
        public ActionResult Edit(int? id)
        {
            try
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
                        tbl_Injured tbl_Injured = db.tbl_Injured.Find(id);
                        if (tbl_Injured == null)
                        {
                            return HttpNotFound();
                        }
                        return View(tbl_Injured);
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
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // POST: Injured/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InjuredID,InjuredName,InjuredLastName,InjuredSex,InjuredType,InjuredTypeinjury,InjuredDescription,InjuredLocation")] tbl_Injured tbl_Injured)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(tbl_Injured).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(tbl_Injured);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // GET: Injured/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                tbl_Injured tbl_Injured = db.tbl_Injured.Find(id);
                if (tbl_Injured == null)
                {
                    return HttpNotFound();
                }
                return View(tbl_Injured);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // POST: Injured/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbl_Injured tbl_Injured = db.tbl_Injured.Find(id);
                db.tbl_Injured.Remove(tbl_Injured);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
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
