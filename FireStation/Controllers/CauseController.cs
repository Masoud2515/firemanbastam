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
    public class CauseController : Controller
    {
        private Context db = new Context();

        // GET: Cause
        public ActionResult Index()
        {
            try
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        return View(db.tbl_Cause.ToList());
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

        // GET: Cause/Details/5
        public ActionResult Details(int? id)
        {
            try
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        if (id == null)
                        {
                            return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ علت حادثه ای انتخاب نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        }
                        tbl_Cause tbl_Cause = db.tbl_Cause.Find(id);
                        if (tbl_Cause == null)
                        {
                            return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ علت حادثه ای با شماره وارد شده وجود ندارد", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        }
                        return View(tbl_Cause);
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

        // GET: Cause/Create
        public ActionResult Create()
        {
            try
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
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // POST: Cause/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CauseId,CauseTitel")] tbl_Cause tbl_Cause)
        {
            try
            {
                Random ra = new Random();
                int id;
                if (ModelState.IsValid)
                {
                    if (Session["OnlineUser"] != null)
                    {
                        if (Session["UserRole"].Equals("SUPERADMIN"))
                        {
                            id = ra.Next(1111, 9999);
                            while (db.tbl_Cause.FirstOrDefault(x => x.CauseId.Equals(id)) != null)
                            {
                                id = ra.Next(1111, 9999);
                            }
                            ViewBag.OnlineUser = Session["UserName"].ToString();
                            ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                            tbl_Cause.CauseId = id;
                            db.tbl_Cause.Add(tbl_Cause);
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
                return View(tbl_Cause);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // GET: Cause/Edit/5
        public ActionResult Edit(int? id)
        {
            try
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        if (id == null)
                        {
                            return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ علت حادثه ای انتخاب نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        }
                        tbl_Cause tbl_Cause = db.tbl_Cause.Find(id);
                        if (tbl_Cause == null)
                        {
                            return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ علت حادثه ای با شماره وارد شده وجود ندارد", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        }
                        return View(tbl_Cause);
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

        // POST: Cause/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CauseId,CauseTitel")] tbl_Cause tbl_Cause)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Session["OnlineUser"] != null)
                    {
                        if (Session["UserRole"].Equals("SUPERADMIN"))
                        {
                            ViewBag.OnlineUser = Session["UserName"].ToString();
                            ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                            db.Entry(tbl_Cause).State = EntityState.Modified;
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
                return View(tbl_Cause);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // GET: Cause/Delete/5
        public ActionResult Delete(int? id)
        {
            try
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
                        tbl_Cause tbl_Cause = db.tbl_Cause.Find(id);
                        if (tbl_Cause == null)
                        {
                            return HttpNotFound();
                        }
                        return View(tbl_Cause);
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

        // POST: Cause/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbl_Cause tbl_Cause = db.tbl_Cause.Find(id);
                db.tbl_Cause.Remove(tbl_Cause);
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
