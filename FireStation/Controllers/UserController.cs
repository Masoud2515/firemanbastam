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
    public class UserController : Controller
    {
        private Context db = new Context();

        // GET: User
        public ActionResult Index()
        {
            try
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        var tbl_User = db.tbl_User.Include(t => t.tbl_Employee);
                        return View(tbl_User.ToList());
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

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            try
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
                        tbl_User tbl_User = db.tbl_User.Find(id);
                        if (tbl_User == null)
                        {
                            return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ  کاربری  با شناسه وارد شده ثبت نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        }
                        return View(tbl_User);
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

        // GET: User/Create
        public ActionResult Create()
        {
            try
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        ViewBag.EmployeeId = new SelectList(db.tbl_Employee, "EmployeeId", "EmployeeCode");
                        ViewBag.Emp = db.tbl_Employee.ToList();
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

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserId,UserUserName,UserPassword,EmployeeId,UserRole")] tbl_User tbl_User)
        {
            try
            {
                Random rand = new Random();
                int ra;
                if (ModelState.IsValid)
                {
                    if (Session["OnlineUser"] != null)
                    {
                        if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                        {
                            ra = rand.Next(111, 999);
                            while (db.tbl_User.FirstOrDefault(x => x.UserId.Equals(ra)) != null)
                            {
                                ra = rand.Next(111, 999);
                            }
                            ViewBag.OnlineUser = Session["UserName"].ToString();
                            ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                            tbl_User.UserId = ra;
                            db.tbl_User.Add(tbl_User);
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
                ViewBag.Emp = db.tbl_Employee.ToList();
                ViewBag.EmployeeId = new SelectList(db.tbl_Employee, "EmployeeId", "EmployeeCode", tbl_User.EmployeeId);
                return View(tbl_User);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            try
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
                        tbl_User tbl_User = db.tbl_User.Find(id);
                        if (tbl_User == null)
                        {
                            return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ  کاربری  با شناسه وارد شده ثبت نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        }
                        ViewBag.EmployeeId = new SelectList(db.tbl_Employee, "EmployeeId", "EmployeeCode", tbl_User.EmployeeId);
                        return View(tbl_User);
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

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,UserUserName,UserPassword,EmployeeId,UserRole")] tbl_User tbl_User)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Session["OnlineUser"] != null)
                    {
                        if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                        {
                            ViewBag.OnlineUser = Session["UserName"].ToString();
                            ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                            db.Entry(tbl_User).State = EntityState.Modified;
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
                ViewBag.EmployeeId = new SelectList(db.tbl_Employee, "EmployeeId", "EmployeeCode", tbl_User.EmployeeId);
                return View(tbl_User);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            try
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        if (id == null)
                        {
                            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                        }
                        tbl_User tbl_User = db.tbl_User.Find(id);
                        if (tbl_User == null)
                        {
                            return HttpNotFound();
                        }
                        return View(tbl_User);
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

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbl_User tbl_User = db.tbl_User.Find(id);
                db.tbl_User.Remove(tbl_User);
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
