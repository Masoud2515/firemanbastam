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
    public class StateController : Controller
    {
        private Context db = new Context();

        // GET: State
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
                        return View(db.tbl_State.ToList());
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

        // GET: State/Details/5
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
                            return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ شناسه ای وارد نشده", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        }
                        tbl_State tbl_State = db.tbl_State.Find(id);
                        if (tbl_State == null)
                        {
                            return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ ایستگاهی  با شناسه وارد شده ثبت نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        }
                        return View(tbl_State);
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

        // GET: State/Create
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

        // POST: State/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StateId,StateName,StateAdress,StateTel")] tbl_State tbl_State)
        {
            try
            {
                Random ra = new Random();
                int rand1 = 0;
                rand1 = ra.Next(11, 99);
                if (ModelState.IsValid)
                {
                    if (Session["OnlineUser"] != null)
                    {
                        if (Session["UserRole"].Equals("SUPERADMIN"))
                        {
                            while (db.tbl_State.FirstOrDefault(m => m.StateId == rand1) != null)
                            {
                                rand1 = ra.Next(11, 99);
                            }
                            tbl_State.StateId = Convert.ToInt32(rand1);
                            db.tbl_State.Add(tbl_State);
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
                return View(tbl_State);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // GET: State/Edit/5
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
                            return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ شناسه ای وارد نشده", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        }
                        tbl_State tbl_State = db.tbl_State.Find(id);
                        if (tbl_State == null)
                        {
                            return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ ایستگاهی  با شناسه وارد شده ثبت نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                        }
                        return View(tbl_State);
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

        // POST: State/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StateId,StateName,StateAdress,StateTel")] tbl_State tbl_State)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (Session["OnlineUser"] != null)
                    {
                        if (Session["UserRole"].Equals("SUPERADMIN"))
                        {
                            db.Entry(tbl_State).State = EntityState.Modified;
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
                return View(tbl_State);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(ex.Message, ex.InnerException.ToString());
                return View();
            }

        }

        // GET: State/Delete/5
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
                        tbl_State tbl_State = db.tbl_State.Find(id);
                        if (tbl_State == null)
                        {
                            return HttpNotFound();
                        }
                        return View(tbl_State);
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

        // POST: State/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        tbl_State tbl_State = db.tbl_State.Find(id);
                        db.tbl_State.Remove(tbl_State);
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
