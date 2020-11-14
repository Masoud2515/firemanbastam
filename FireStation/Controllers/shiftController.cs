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
    public class shiftController : Controller
    {
        private FireStationEntities db = new FireStationEntities();

        // GET: shift
        public ActionResult Index()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    var tbl_shift = db.tbl_shift.Include(t => t.tbl_State);
                    return View(tbl_shift.ToList());
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

        // GET: shift/Details/5
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
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_shift tbl_shift = db.tbl_shift.Find(id);
                    if (tbl_shift == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.fireman = (from i in db.tbl_Employee
                                       join ai in db.tbl_ShiftEmployee on i.EmployeeId equals ai.EmployeeId
                                       join a in db.tbl_shift on ai.Shiftid equals a.ShiftId
                                       where ai.Shiftid == id
                                       orderby a.ShiftId
                                       select i).ToList();
                    return View(tbl_shift);
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

        // GET: shift/Create
        public ActionResult Create()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.StateId = new SelectList(db.tbl_State, "StateId", "StateName");
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

        // POST: shift/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ShiftId,ShiftName,StateId")] tbl_shift tbl_shift, List<int> Employee)
        {
            Random rand = new Random();
            int ra = 0;
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        ra = rand.Next(1111, 9999);
                        while (db.tbl_shift.FirstOrDefault(x => x.StateId == ra) != null)
                        {
                            ra = rand.Next(1111, 9999);
                        }
                        tbl_shift.ShiftId = ra;
                        db.tbl_shift.Add(tbl_shift);
                        db.SaveChanges();
                        foreach (int item in Employee)
                        {
                            tbl_ShiftEmployee oEmployee = new tbl_ShiftEmployee();
                            int re = rand.Next(111111, 999999);
                            while (db.tbl_ShiftEmployee.FirstOrDefault(f => f.ShiftEmployeeId == re) != null)
                            {
                                re = rand.Next(111111, 999999);
                            }
                            oEmployee.ShiftEmployeeId = re;
                            oEmployee.EmployeeId = item;
                            oEmployee.Shiftid = ra;
                            db.tbl_ShiftEmployee.Add(oEmployee);
                            db.SaveChanges();
                        }
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
            ViewBag.StateId = new SelectList(db.tbl_State, "StateId", "StateName", tbl_shift.StateId);
            return View(tbl_shift);
        }

        // GET: shift/Edit/5
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
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_shift tbl_shift = db.tbl_shift.Find(id);
                    if (tbl_shift == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.StateId = new SelectList(db.tbl_State, "StateId", "StateName", tbl_shift.StateId);
                    return View(tbl_shift);
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

        // POST: shift/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ShiftId,ShiftName,StateId")] tbl_shift tbl_shift)
        {
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        db.Entry(tbl_shift).State = EntityState.Modified;
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
            ViewBag.StateId = new SelectList(db.tbl_State, "StateId", "StateName", tbl_shift.StateId);
            return View(tbl_shift);
        }

        // GET: shift/Delete/5
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
                    tbl_shift tbl_shift = db.tbl_shift.Find(id);
                    if (tbl_shift == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.fireman = (from i in db.tbl_Employee
                                       join ai in db.tbl_ShiftEmployee on i.EmployeeId equals ai.EmployeeId
                                       join a in db.tbl_shift on ai.Shiftid equals a.ShiftId
                                       where ai.Shiftid == id
                                       orderby a.ShiftId
                                       select i).ToList();
                    return View(tbl_shift);
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
        // POST: shift/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var em = db.tbl_ShiftEmployee.Where(x => x.Shiftid == id).ToList();
            foreach (var item in em)
            {
                tbl_ShiftEmployee tbl_ShiftEmployee = db.tbl_ShiftEmployee.Find(item.ShiftEmployeeId);
                db.tbl_ShiftEmployee.Remove(tbl_ShiftEmployee);
                db.SaveChanges();
            }
            tbl_shift tbl_shift = db.tbl_shift.Find(id);
            db.tbl_shift.Remove(tbl_shift);
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
