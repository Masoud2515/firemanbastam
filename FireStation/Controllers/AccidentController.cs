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
using FireStation.Models.ViewModel;


namespace FireStation.Controllers
{
    public class AccidentController : Controller
    {
        private FireStationEntities db = new FireStationEntities();

        // GET: Accident
        public ActionResult Index()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    var tbl_Accident = db.tbl_Accident.Include(t => t.tbl_AccidentType).Include(t => t.tbl_Usage).Include(t => t.tbl_weather).Include(t => t.tbl_User);
                    return View(tbl_Accident.Where(x => x.Isdelete == false).ToList());
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
        public ActionResult Reporthadece(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN") || Session["UserRole"].Equals("OPRATOR"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    string dateprint = string.Format("{0}/{1}/{2}", pc.GetYear(DateTime.Now), pc.GetMonth(DateTime.Now), pc.GetDayOfMonth(DateTime.Now));
                    ViewBag.dateprint = dateprint;
                    ViewBag.ACMA = (from i in db.tbl_AccidentM
                                    where i.AccidentId == id
                                    join ai in db.tbl_Accident on i.AccidentId equals ai.AccidentId
                                    join f in db.tbl_Material on i.MaterialId equals f.MaterialId
                                    orderby f.MaterialId
                                    select new TaVM() { Name = f.MaterialName, Vahed = f.MaterialVahed, Te = i.tedad, Id = f.MaterialCode }).ToList();
                    ViewBag.fireman = (from i in db.tbl_Employee
                                       join ai in db.tbl_AccidentEmplyoee on i.EmployeeId equals ai.EmployeeId
                                       join a in db.tbl_Accident on ai.AccidentId equals a.AccidentId
                                       where ai.AccidentId == id
                                       orderby a.AccidentId
                                       select i).ToList();
                    ViewBag.station = (from i in db.tbl_State
                                       join ai in db.tbl_AccidentStation on i.StateId equals ai.StationId
                                       join a in db.tbl_Accident on ai.AccidentId equals a.AccidentId
                                       where ai.AccidentId == id
                                       orderby a.AccidentId
                                       select i).ToList();

                    var Ostate = db.tbl_AccidentStation.Where(x => x.AccidentId == id);
                    foreach (var item in Ostate)
                    {
                        ViewBag.State = db.tbl_State.Where(x => x.StateId == item.StationId);
                    }

                    if (id == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-3022", text = "هیچ حادثه ای انتخاب نشده است", url = Request.Url.Scheme });
                    }
                    tbl_Accident tbl_Accident = db.tbl_Accident.Find(id);
                    if (tbl_Accident == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-3022", text = "شناسه حادثه وارد شده معتبر نیست انتخاب نشده است", url = Request.Url.Scheme });
                    }
                    return View(tbl_Accident);
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

        // GET: Accident/Details/5
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
                        return RedirectToAction("Err", "Home", new { code = "E-3022", text = "هیچ حادثه ای انتخاب نشده است", url = Request.Url.Scheme });
                    }
                    tbl_Accident tbl_Accident = db.tbl_Accident.Find(id);
                    if (tbl_Accident == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-3022", text = "شناسه حادثه وارد شده معتبر نیست انتخاب نشده است", url = Request.Url.Scheme });
                    }
                    return View(tbl_Accident);
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
        public ActionResult Addinjured(int? id, int? Acid, int? mat)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.number = id / 9763;
                    ViewBag.Ac = Acid / 25438;
                    ViewBag.mat = mat;
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addinjured(string[] InjuredName, string[] InjuredLastName, int[] InjuredSex, int[] InjuredType, int[] InjuredTypeinjury, string[] InjuredDescription, string[] InjuredLocation, int Acid, int mat)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (InjuredName != null)
                    {
                        for (int i = 0; i < InjuredName.Count(); i++)
                        {
                            tbl_Injured tbl_Injured = new tbl_Injured();
                            Random rand = new Random();
                            int random = 0;
                            random = rand.Next(11111111, 99999999);
                            while (db.tbl_Injured.FirstOrDefault(x => x.InjuredID == random) != null)
                            {
                                random = rand.Next(11111111, 99999999);
                            }
                            tbl_Injured.InjuredID = random;
                            tbl_Injured.InjuredName = InjuredName[i];
                            tbl_Injured.InjuredLastName = InjuredLastName[i];
                            tbl_Injured.InjuredDescription = InjuredDescription[i];
                            tbl_Injured.InjuredLocation = InjuredLocation[i];
                            //sex
                            if (InjuredSex[i] == 1)
                            {
                                tbl_Injured.InjuredSex = true;
                            }
                            else if (InjuredSex[i] == 0)
                            {
                                tbl_Injured.InjuredSex = false;
                            }
                            //type
                            if (InjuredType[i] == 1)
                            {
                                tbl_Injured.InjuredType = true;
                            }
                            else if (InjuredType[i] == 0)
                            {
                                tbl_Injured.InjuredType = false;
                            }
                            //masdoumiat
                            if (InjuredTypeinjury[i] == 1)
                            {
                                tbl_Injured.InjuredTypeinjury = true;
                            }
                            else if (InjuredTypeinjury[i] == 0)
                            {
                                tbl_Injured.InjuredTypeinjury = false;
                            }
                            db.tbl_Injured.Add(tbl_Injured);
                            tbl_AccidentInjured tbl_AccidentInjured = new tbl_AccidentInjured();
                            Random rand1 = new Random();
                            int random1 = 0;
                            random1 = rand.Next(11111111, 99999999);
                            while (db.tbl_AccidentInjured.FirstOrDefault(x => x.AccidentInjuredid == random1) != null)
                            {
                                random1 = rand.Next(11111111, 99999999);
                            }
                            tbl_AccidentInjured.AccidentInjuredid = random1;
                            tbl_AccidentInjured.AccidentId = Acid;
                            tbl_AccidentInjured.InjuredId = random;
                            db.tbl_AccidentInjured.Add(tbl_AccidentInjured);
                            db.SaveChanges();
                            return RedirectToAction("Addmaterial", new { id = mat * 3220, Acid = Acid * 3221 });
                        }
                    }
                    else
                    {
                        return RedirectToAction("Addmaterial", new { id = mat * 3220, Acid = Acid * 3221 });
                    }

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
        // GET: Accident/Create
        public ActionResult Addmaterial(int? id, int? Acid)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.number = id / 3220;
                    ViewBag.Ac = Acid / 3221;
                    ViewBag.material = db.tbl_Material.ToList();
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Addmaterial(int[] MaterialId, int[] tedad, int Acid)
        {
            Random rand = new Random();
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.material = db.tbl_Material.ToList();
                    if (MaterialId != null)
                    {
                        for (int i = 0; i < MaterialId.Count(); i++)
                        {
                            tbl_AccidentM tbl_AccidentM = new tbl_AccidentM();
                            Random rand1 = new Random();
                            int random1 = 0;
                            random1 = rand.Next(11111111, 99999999);
                            while (db.tbl_AccidentM.FirstOrDefault(x => x.AccidentMid == random1) != null)
                            {
                                random1 = rand.Next(11111111, 99999999);
                            }
                            tbl_AccidentM.AccidentMid = random1;
                            tbl_AccidentM.AccidentId = Acid;
                            tbl_AccidentM.MaterialId = MaterialId[i];
                            tbl_AccidentM.tedad = tedad[i];
                            db.tbl_AccidentM.Add(tbl_AccidentM);
                            db.SaveChanges();
                        }
                        return RedirectToAction("Index");
                    }
                    else
                    {
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
        }
        // GET: Accident/Create
        public ActionResult Create()
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
                    ViewBag.AccidentUsageId = db.tbl_Usage.ToList();
                    ViewBag.AccidentWid = db.tbl_weather.ToList();
                    ViewBag.AccidentUserId = db.tbl_User.ToList();
                    ViewBag.OpState = db.tbl_State.ToList();
                    ViewBag.Organization = db.tbl_Organizations.ToList();
                    ViewBag.Emp = db.tbl_Employee.ToList();
                    ViewBag.material = db.tbl_Material.ToList();
                    ViewBag.Cause = db.tbl_Cause.ToList();
                    //id genrator
                    int ra, te, dateint;
                    System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                    dateint = Convert.ToInt32(pc.GetYear(DateTime.Now));
                    te = db.tbl_Accident.Where(x => x.AccidentId.Equals(dateint)).Count();
                    if (te == 0)
                    {
                        te++;
                    }
                    ra = Convert.ToInt32(string.Format("{0}{1}", dateint, te));
                    while (db.tbl_Accident.FirstOrDefault(f => f.AccidentId == ra) != null)
                    {
                        ra++;
                    }
                    //End id genrator
                    ViewBag.number = ra;
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

        // POST: Accident/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccidentId,AccidentEventLocation,AccidentDescrption,AccidentTime,AccidentDate,AccidentReportUrl,AccidentWid,AccidentTypeId,AccidentZone,AccidentUserId,AccidentUsageId,AccidentTimeStartOperation,AccidentTimeEndOperation,AccidentTimeToClear,AccidentReporter,AccidentReportReciver,AccidentReportType,AccidentSiteFloors,AccidentBuildingType,AccidentBuildingOwner,AccidentBuildingTel,AccidentBuildingTenant,AccidentOtherType,AccidentPreliminaryMeasures,AccidentDescriptionOperation,AccidentDamageDescriptionO,AccidentDamageDescriptionL,AccidentReportProducer,AccidentOperationsCommander,DateAdd,AccidentOperationProblems,AccidentCause")] tbl_Accident tbl_Accident, HttpPostedFileBase pic, List<int> OperatingStation, List<int> Employee, List<int> Organisation, int injured, int materialnumber)
        {
            Random rand = new Random();
            int ra, te, dateint;
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                    {
                        System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
                        dateint = Convert.ToInt32(pc.GetYear(DateTime.Now));
                        te = db.tbl_Accident.Where(x => x.AccidentId.Equals(dateint)).Count();
                        if (te == 0)
                        {
                            te++;
                        }
                        ra = Convert.ToInt32(string.Format("{0}{1}", dateint, te));
                        while (db.tbl_Accident.FirstOrDefault(f => f.AccidentId == ra) != null)
                        {
                            ra++;
                        }
                        if (pic != null)
                        {
                            var Fi1 = Path.GetExtension(pic.FileName);
                            var Ri1 = Path.Combine(Server.MapPath("~/Documents/Doc/"), string.Format("{0}{1}", ra.ToString(), Fi1));
                            pic.SaveAs(Ri1);
                            tbl_Accident.AccidentReportUrl = string.Format("Documents/Doc/{0}{1}", ra.ToString(), Fi1);
                        }
                        tbl_Accident.AccidentId = ra;
                        tbl_Accident.AccidentUserId = Convert.ToInt32(Session["OnlineUser"].ToString());
                        tbl_Accident.DateAdd = DateTime.Now;
                        tbl_Accident.Isdelete = false;
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        db.tbl_Accident.Add(tbl_Accident);
                        db.SaveChanges();
                        int rs, re, rf;
                        foreach (int item in OperatingStation)
                        {
                            tbl_AccidentStation oState = new tbl_AccidentStation();
                            rs = rand.Next(111111, 999999);
                            while (db.tbl_AccidentStation.FirstOrDefault(f => f.AccidentStationId == rs) != null)
                            {
                                rs = rand.Next(111111, 999999);
                            }
                            oState.AccidentStationId = rs;
                            oState.StationId = item;
                            oState.AccidentId = ra;
                            db.tbl_AccidentStation.Add(oState);
                            db.SaveChanges();
                        }
                        foreach (int item in Employee)
                        {
                            tbl_AccidentEmplyoee oEmployee = new tbl_AccidentEmplyoee();
                            re = rand.Next(111111, 999999);
                            while (db.tbl_AccidentEmplyoee.FirstOrDefault(f => f.AEId == re) != null)
                            {
                                re = rand.Next(111111, 999999);
                            }
                            oEmployee.AEId = re;
                            oEmployee.EmployeeId = item;
                            oEmployee.AccidentId = ra;
                            db.tbl_AccidentEmplyoee.Add(oEmployee);
                            db.SaveChanges();
                        }
                        foreach (int item in Organisation)
                        {
                            tbl_AccidentO dll = new tbl_AccidentO();
                            rf = rand.Next(111111, 999999);
                            while (db.tbl_AccidentO.FirstOrDefault(f => f.AccidentOid == rf) != null)
                            {
                                rf = rand.Next(111111, 999999);
                            }
                            dll.AccidentOid = rf;
                            dll.OrganizationsId = item;
                            dll.AccidentId = ra;
                            db.tbl_AccidentO.Add(dll);
                            db.SaveChanges();
                        }
                        if (injured > 0)
                        {
                            return RedirectToAction("Addinjured", new { id = injured * 9763, Acid = ra * 25438, mat = materialnumber });
                        }
                        else if (materialnumber > 0)
                        {
                            return RedirectToAction("Addmaterial", new { id = materialnumber * 3220, Acid = ra * 3221 });
                        }
                        else
                        {
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
            }
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            ViewBag.AccidentUsageId = db.tbl_Usage.ToList();
            ViewBag.AccidentWid = db.tbl_weather.ToList();
            ViewBag.AccidentUserId = db.tbl_User.ToList();
            ViewBag.OpState = db.tbl_State.ToList();
            ViewBag.Organization = db.tbl_Organizations.ToList();
            ViewBag.Emp = db.tbl_Employee.ToList();
            ViewBag.material = db.tbl_Material.ToList();
            ViewBag.Cause = db.tbl_Cause.ToList();
            return View(tbl_Accident);
        }

        // GET: Accident/Edit/5
        public ActionResult Edit(int? id)
        {
            if (Session["OnlineUser"] != null)
            {
                if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                {
                    ViewBag.OnlineUser = Session["UserName"].ToString();
                    ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                    if (id == null)
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                    tbl_Accident tbl_Accident = db.tbl_Accident.Find(id);
                    if (tbl_Accident == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.ACIN = (from i in db.tbl_Injured
                                    join ai in db.tbl_AccidentInjured on i.InjuredID equals ai.InjuredId
                                    join a in db.tbl_Accident on ai.AccidentId equals a.AccidentId
                                    where ai.AccidentId == id
                                    orderby a.AccidentId
                                    select i).ToList();
                    ViewBag.ACMA = (from i in db.tbl_Material
                                    join ai in db.tbl_AccidentM on i.MaterialId equals ai.MaterialId
                                    join a in db.tbl_Accident on ai.AccidentId equals a.AccidentId
                                    where ai.AccidentId == id
                                    orderby a.AccidentId
                                    select i).ToList();
                    ViewBag.fireman = (from i in db.tbl_Employee
                                       join ai in db.tbl_AccidentEmplyoee on i.EmployeeId equals ai.EmployeeId
                                       join a in db.tbl_Accident on ai.AccidentId equals a.AccidentId
                                       where ai.AccidentId == id
                                       orderby a.AccidentId
                                       select i).ToList();
                    ViewBag.station = (from i in db.tbl_State
                                       join ai in db.tbl_AccidentStation on i.StateId equals ai.StationId
                                       join a in db.tbl_Accident on ai.AccidentId equals a.AccidentId
                                       where ai.AccidentId == id
                                       orderby a.AccidentId
                                       select i).ToList();
                    ViewBag.Organization = (from i in db.tbl_Organizations
                                       join ai in db.tbl_AccidentO on i.OrId equals ai.OrganizationsId
                                       join a in db.tbl_Accident on ai.AccidentId equals a.AccidentId
                                       where ai.AccidentId == id
                                       orderby a.AccidentId
                                       select i).ToList();
                    ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
                    ViewBag.AccidentUsageId = db.tbl_Usage.ToList();
                    ViewBag.AccidentWid = db.tbl_weather.ToList();
                    ViewBag.AccidentUserId = db.tbl_User.ToList();
                    ViewBag.OpState = db.tbl_State.ToList();
                    ViewBag.Organization = db.tbl_Organizations.ToList();
                    ViewBag.Emp = db.tbl_Employee.ToList();
                    ViewBag.material = db.tbl_Material.ToList();
                    ViewBag.Cause = db.tbl_Cause.ToList();
                    return View(tbl_Accident);
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

        // POST: Accident/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccidentId,AccidentEventLocation,AccidentDescrption,AccidentTime,AccidentDate,AccidentReportUrl,AccidentWid,AccidentTypeId,AccidentZone,AccidentUserId,AccidentUsageId,AccidentTimeStartOperation,AccidentTimeEndOperation,AccidentTimeToClear,AccidentReporter,AccidentReportReciver,AccidentReportType,AccidentSiteFloors,AccidentBuildingType,AccidentBuildingOwner,AccidentBuildingTel,AccidentBuildingTenant,AccidentOtherType,AccidentPreliminaryMeasures,AccidentDescriptionOperation,AccidentDamageDescriptionO,AccidentDamageDescriptionL,AccidentReportProducer,AccidentOperationsCommander,DateAdd,AccidentOperationProblems,AccidentCause")] tbl_Accident tbl_Accident, HttpPostedFileBase pic, int[] OperatingStation, int injured)
        {
            if (ModelState.IsValid)
            {
                if (Session["OnlineUser"] != null)
                {
                    if (Session["UserRole"].Equals("SUPERADMIN") || Session["UserRole"].Equals("ADMIN") || Session["UserRole"].Equals("SUBADMIN"))
                    {
                        ViewBag.OnlineUser = Session["UserName"].ToString();
                        ViewBag.OnlineUserRole = Session["UserRole"].ToString();
                        db.Entry(tbl_Accident).State = EntityState.Modified;
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
            ViewBag.AccidentTypeId = db.tbl_AccidentType.ToList();
            ViewBag.AccidentUsageId = db.tbl_Usage.ToList();
            ViewBag.AccidentWid = db.tbl_weather.ToList();
            ViewBag.AccidentUserId = db.tbl_User.ToList();
            ViewBag.OpState = db.tbl_State.ToList();
            ViewBag.Organization = db.tbl_Organizations.ToList();
            ViewBag.Emp = db.tbl_Employee.ToList();
            ViewBag.material = db.tbl_Material.ToList();
            ViewBag.Cause = db.tbl_Cause.ToList();

            return View(tbl_Accident);
        }

        // GET: Accident/Delete/5
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
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ  حادثه ای انتخاب نشده است", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    tbl_Accident tbl_Accident = db.tbl_Accident.Find(id);
                    if (tbl_Accident == null)
                    {
                        return RedirectToAction("Err", "Home", new { code = "E-1133", text = "هیچ  حادثه ای با این شماره ثبت نشده", url = string.Format("{0}/", RouteData.Values["controller"].ToString()) });
                    }
                    return View(tbl_Accident);
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

        // POST: Accident/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (FireStationEntities db = new FireStationEntities())
            {
                tbl_Accident tbl = db.tbl_Accident.Where(x => x.AccidentId == id).FirstOrDefault();
                tbl.Isdelete = true;
                db.SaveChanges();
                db.Dispose();
                return RedirectToAction("Index");
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
