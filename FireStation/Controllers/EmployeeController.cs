using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FireStation.Models;

namespace FireStation.Controllers
{
    public class EmployeeController : Controller
    {
        private FireStationEntities db = new FireStationEntities();

        // GET: Employee
        public ActionResult Index()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    var tbl_Employee = db.tbl_Employee.Include(t => t.tbl_State);
                    return View(tbl_Employee.ToList());
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

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
                    if (tbl_Employee == null)
                    {
                        return HttpNotFound();
                    }
                    return View(tbl_Employee);
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

        // GET: Employee/Create
        public ActionResult Create()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.StateId = new SelectList(db.tbl_State, "StateId", "StateName");
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

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeId,EmployeeCode,EmployeeName,EmployeeLastName,EmployeePhone,EmployeeAdress,EmployeePicUrl,StateId,EmployeeFName,EmployeeMCode,EmployeeBirthdate,EmployeeSex,EmployeeWork,EmployeeDateRegistered")] tbl_Employee tbl_Employee, HttpPostedFileBase pic)
        {
            Random rand = new Random();
            int ra;
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                    {
                        ra = rand.Next(11111, 99999);
                        while (db.tbl_Employee.FirstOrDefault(f => f.EmployeeId == ra) != null)
                        {
                            ra = rand.Next(1000000, 2000000);
                        }
                        if (pic != null)
                        {
                            var Fi1 = Path.GetExtension(pic.FileName);
                            var Ri1 = Path.Combine(Server.MapPath("~/Documents/Pic/"), string.Format("{0}{1}", ra.ToString(), Fi1));
                            pic.SaveAs(Ri1);
                            tbl_Employee.EmployeePicUrl = string.Format("Documents/Pic/{0}{1}", ra.ToString(), Fi1);
                        }
                        else
                        {
                            tbl_Employee.EmployeePicUrl = "no image yet";
                        }
                        tbl_Employee.EmployeeId = ra;
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        db.tbl_Employee.Add(tbl_Employee);
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
            ViewBag.StateId = new SelectList(db.tbl_State, "StateId", "StateName", tbl_Employee.StateId);
            ViewBag.Emp = db.tbl_Employee.ToList();
            return View(tbl_Employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
                    if (tbl_Employee == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.StateId = new SelectList(db.tbl_State, "StateId", "StateName", tbl_Employee.StateId);
                    return View(tbl_Employee);
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

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeId,EmployeeCode,EmployeeName,EmployeeLastName,EmployeePhone,EmployeeAdress,EmployeePicUrl,StateId,EmployeeFName,EmployeeMCode,EmployeeBirthdate,EmployeeSex,EmployeeWork,EmployeeDateRegistered")] tbl_Employee tbl_Employee, HttpPostedFileBase pic)
        {
            Random rand = new Random();
            int ra;
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        ra = rand.Next(111111, 999999);
                        while (db.tbl_Employee.FirstOrDefault(f => f.EmployeeId == ra) != null)
                        {
                            ra = rand.Next(111111, 999999);
                        }
                        if (pic != null)
                        {
                            var Fi1 = Path.GetExtension(pic.FileName);
                            var Ri1 = Path.Combine(Server.MapPath("~/Documents/Pic/"), string.Format("{0}{1}", ra.ToString(), Fi1));
                            pic.SaveAs(Ri1);
                            tbl_Employee.EmployeePicUrl = string.Format("Documents/Pic/{0}{1}", ra.ToString(), Fi1);
                        }
                        else
                        {
                            tbl_Employee.EmployeePicUrl = "no image yet";
                        }
                        db.Entry(tbl_Employee).State = EntityState.Modified;
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
            ViewBag.StateId = new SelectList(db.tbl_State, "StateId", "StateName", tbl_Employee.StateId);
            return View(tbl_Employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
                    if (tbl_Employee == null)
                    {
                        return HttpNotFound();
                    }
                    return View(tbl_Employee);
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

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_Employee tbl_Employee = db.tbl_Employee.Find(id);
            db.tbl_Employee.Remove(tbl_Employee);
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
