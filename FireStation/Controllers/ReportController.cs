using FireStation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FireStation.Controllers
{
    public class ReportController : Controller
    {
        private FireStationEntities db = new FireStationEntities();
        
        public ActionResult ReportHadese()
        {
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ReportHadese(string Fname, string Lname, string Pname)
        {
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            return View();
        }


        public ActionResult ReportTafkikHadese()
        {
            ViewBag.material = db.tbl_Material.ToList();
            ViewBag.AccidentUsageId = db.tbl_Usage.ToList();
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ReportTafkikHadese(string Fname, string Lname, string Pname)
        {
            ViewBag.material = db.tbl_Material.ToList();
            ViewBag.AccidentUsageId = db.tbl_Usage.ToList();
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            return View();
        }

        public ActionResult ReportKhesarat()
        {
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            return View();
        }
        public ActionResult ReportIstgah()
        {
            ViewBag.Emp = db.tbl_Employee.ToList();
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            ViewBag.OpState = db.tbl_State.ToList();
            return View();
        }
        //report masdomin
        public ActionResult ReportMasdomin()
        {
            ViewBag.Injured = db.tbl_Injured.ToList();
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult ReportMasdomin(DateTime dateS,DateTime dateE,int typeid,List<int> injured)
        {
            ViewBag.Injured = db.tbl_Injured.ToList();
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            return View();
        }
        public ActionResult ReportMasdominPrint()
        {
            ViewBag.Injured = db.tbl_Injured.ToList();
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            return View();
        }
        public ActionResult ReportRozaneIstgah()
        {
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            ViewBag.OpState = db.tbl_State.ToList();
            return View();
        }
    }
}