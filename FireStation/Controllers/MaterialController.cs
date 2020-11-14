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
    public class MaterialController : Controller
    {
        private FireStationEntities db = new FireStationEntities();

        // GET: Material
        public ActionResult Index()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    return View(db.tbl_Material.ToList());
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

        // GET: Material/Details/5
        public ActionResult Details(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = " شناسه تجهیزات  وارد نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_Material tbl_Material = db.tbl_Material.Find(id);
                    if (tbl_Material == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ یک از تجهیزات با شناسه وارد شده ثبت نشده اند", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_Material);
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

        // GET: Material/Create
        public ActionResult Create()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.OpState = db.tbl_State.ToList();

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

        // POST: Material/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaterialId,MaterialCode,MaterialName,MaterialPic,MaterialType,MaterialVahed")] tbl_Material tbl_Material, HttpPostedFileBase pic)
        {
            Random rand = new Random();
            int ra;
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        ViewBag.OpState = db.tbl_State.ToList();
                        ra = rand.Next(1000000, 2000000);
                        while (db.tbl_Material.FirstOrDefault(f => f.MaterialId == ra) != null)
                        {
                            ra = rand.Next(1000000, 2000000);
                        }
                        tbl_Material.MaterialId = ra;
                        if (pic != null)
                        {
                            var Fi1 = Path.GetExtension(pic.FileName);
                            var Ri1 = Path.Combine(Server.MapPath("~/Documents/Pic/"), string.Format("{0}{1}", ra.ToString(), Fi1));
                            pic.SaveAs(Ri1);
                            tbl_Material.MaterialPic = string.Format("Documents/Pic/{0}{1}", ra.ToString(), Fi1);
                        }
                        else
                        {
                            tbl_Material.MaterialPic = "No Image Yet";
                        }
                        db.tbl_Material.Add(tbl_Material);
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
            return View(tbl_Material);
        }

        // GET: Material/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.OpState = db.tbl_State.ToList();
                    if (id == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = " شناسه تجهیزات  وارد نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_Material tbl_Material = db.tbl_Material.Find(id);
                    if (tbl_Material == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ یک از تجهیزات با شناسه وارد شده ثبت نشده اند", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_Material);
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

        // POST: Material/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaterialId,MaterialCode,MaterialName,MaterialPic,MaterialType,MaterialVahed")] tbl_Material tbl_Material, HttpPostedFileBase Fdoc)
        {
            Random rand = new Random();
            int ra;
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN"))
                    {

                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        ra = rand.Next(111111, 999999);
                        while (db.tbl_Material.FirstOrDefault(f => f.MaterialId == ra) != null)
                        {
                            ra = rand.Next(111111, 999999);
                        }
                        if (Fdoc != null)
                        {
                            var Fi1 = Path.GetExtension(Fdoc.FileName);
                            var Ri1 = Path.Combine(Server.MapPath("~/Documents/Pic/"), string.Format("{0}{1}", ra.ToString(), Fi1));
                            Fdoc.SaveAs(Ri1);
                            tbl_Material.MaterialPic = string.Format("Documents/Pic/{0}{1}", ra.ToString(), Fi1);
                        }
                        else
                        {
                            tbl_Material.MaterialPic = "No Image Yet";
                        }
                        db.Entry(tbl_Material).State = EntityState.Modified;
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
            return View(tbl_Material);
        }

        // GET: Material/Delete/5
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
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_Material tbl_Material = db.tbl_Material.Find(id);
                    if (tbl_Material == null)
                    {
                        return HttpNotFound();
                    }
                    return View(tbl_Material);
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
        // POST: Material/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                tbl_Material tbl_Material = db.tbl_Material.Find(id);
                db.tbl_Material.Remove(tbl_Material);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Err", "Home", new { code = "E-1133", text = "ارور بررسی نشده", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                throw;
            }

        }
        public FileResult Download(string file)
        {
            byte[] fileBytes = System.IO.File.ReadAllBytes(file);
            var response = new FileContentResult(fileBytes, "application/octet-stream");
            response.FileDownloadName = "loremIpsum.pdf";
            return response;
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
