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
    public class AccidentMController : Controller
    {
        private FireStationEntities db = new FireStationEntities();


        // GET: AccidentM/Edit/5
        public ActionResult Edit(int? id, int? acid)
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
                    tbl_AccidentM tbl_AccidentM = db.tbl_AccidentM.FirstOrDefault(x => x.AccidentId == acid && x.MaterialId == id);
                    if (tbl_AccidentM == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.AccidentId = new SelectList(db.tbl_Accident, "AccidentId", "AccidentEventLocation", tbl_AccidentM.AccidentId);
                    ViewBag.MaterialId = new SelectList(db.tbl_Material, "MaterialId", "MaterialCode", tbl_AccidentM.MaterialId);
                    return View(tbl_AccidentM);
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

        // POST: AccidentM/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccidentMid,AccidentId,MaterialId,tedad")] tbl_AccidentM tbl_AccidentM)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (ModelState.IsValid)
                    {
                        db.Entry(tbl_AccidentM).State = EntityState.Modified;
                        db.SaveChanges();
                        return RedirectToAction("Edit", "Accident", new { id = tbl_AccidentM.AccidentId });
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
            ViewBag.AccidentId = new SelectList(db.tbl_Accident, "AccidentId", "AccidentEventLocation", tbl_AccidentM.AccidentId);
            ViewBag.MaterialId = new SelectList(db.tbl_Material, "MaterialId", "MaterialCode", tbl_AccidentM.MaterialId);
            return View(tbl_AccidentM);
        }

        // GET: AccidentM/Delete/5
        public ActionResult Delete(int? id, int? acid)
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
                    tbl_AccidentM tbl_AccidentM = db.tbl_AccidentM.FirstOrDefault(x => x.AccidentId == acid && x.MaterialId == id);
                    if (tbl_AccidentM == null)
                    {
                        return HttpNotFound();
                    }
                    return View(tbl_AccidentM);
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

        // POST: AccidentM/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, int acid)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    tbl_AccidentM tbl_AccidentM = db.tbl_AccidentM.FirstOrDefault(x => x.AccidentId == acid && x.MaterialId == id);
                    db.tbl_AccidentM.Remove(tbl_AccidentM);
                    db.SaveChanges();
                    return RedirectToAction("Edit", "Accident", new { id = tbl_AccidentM.AccidentId });
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
