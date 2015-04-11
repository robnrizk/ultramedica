using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public class LabController : Controller
    {
        //
        // GET: /Labs/
        [Authorize(Roles = "Admin,Lab")]
        public ActionResult Index(int? year)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["ErrorMessage"] = "";
                if (year == null)
                {
                    year = DateTime.Now.Year;
                }

                List<LAB_INDEX> listLab = new List<LAB_INDEX>();
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    var q = (from fo in dc.GetLabIndex()
                             select new LAB_INDEX() { EMPLOYEE_ID = fo.EMPLOYEE_ID,LABORATORIUM_ID = fo.LABORATORIUM_ID ?? 0, LabId = fo.LAB_ID, YEAR_CHECKUP = fo.YEAR_CHECKUP }).ToList();
                    if (q.Any())
                        listLab.AddRange(q);
                }

                return View(listLab);
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // GET: /Labs/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Labs/Create
        [Authorize(Roles = "Admin,Lab")]
        public ActionResult Create(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";

                var Objreturn = new LAB();
                Objreturn.YEAR_CHECKUP = DateTime.Now.Year.ToString();

                 Objreturn.YEAR_CHECKUP = YEAR_CHECKUP;
                Objreturn.EMPLOYEE_ID = EMPLOYEE_ID;
               
                return View(Objreturn);
            }
            return RedirectToAction("LogOut", "Account");
        } 

        //
        // POST: /Labs/Create

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            ViewData["Action"] = "Create";
            var user = (USER)Session["user"];
            LAB lab = new LAB();
            try
            {
                if (ModelState.IsValid)
                {
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        lab = new LAB();
                        lab.EMPLOYEE_ID = form["EMPLOYEE_ID"];
                        lab.YEAR_CHECKUP = form["YEAR_CHECKUP"];
                        lab.HB = string.IsNullOrEmpty(form["HB"]) ? 0 : Convert.ToDecimal(form["HB"]);
                        lab.HCT = string.IsNullOrEmpty(form["HCT"]) ? 0 : Convert.ToInt32(form["HCT"]);
                        lab.LEUKOSIT = string.IsNullOrEmpty(form["LEUKOSIT"]) ? 0 : Convert.ToInt32(form["LEUKOSIT"]);
                        lab.TROMBOSIT = string.IsNullOrEmpty(form["TROMBOSIT"]) ? 0 : Convert.ToInt32(form["TROMBOSIT"]);
                        lab.ERITROSIT = string.IsNullOrEmpty(form["ERITROSIT"]) ? 0 : Convert.ToDecimal(form["ERITROSIT"]);
                        lab.LED = string.IsNullOrEmpty(form["LED"]) ? 0 : Convert.ToInt32(form["LED"]);
                        lab.DIFLIM = string.IsNullOrEmpty(form["DIFLIM"]) ? 0 : Convert.ToInt32(form["DIFLIM"]);
                        lab.DIFMON = string.IsNullOrEmpty(form["DIFMON"]) ? 0 : Convert.ToInt32(form["DIFMON"]);
                        lab.DIFGRAN = string.IsNullOrEmpty(form["DIFGRAN"]) ? 0 : Convert.ToInt32(form["DIFGRAN"]);
                        lab.HBSAG = form["HBSAG"] == "true";
                        lab.AHBS = string.IsNullOrEmpty(form["AHBS"]) ? 0 : Convert.ToInt32(form["AHBS"]);
                        lab.VDRL = form["VDRL"] == "true";
                        lab.CHOLESTEROL = string.IsNullOrEmpty(form["CHOLESTEROL"]) ? 0 : Convert.ToInt32(form["CHOLESTEROL"]);
                        lab.TRIGLISERIN = string.IsNullOrEmpty(form["TRIGLISERIN"]) ? 0 : Convert.ToInt32(form["TRIGLISERIN"]);
                        lab.HDL = string.IsNullOrEmpty(form["HDL"]) ? 0 : Convert.ToInt32(form["HDL"]);
                        lab.LDL = string.IsNullOrEmpty(form["LDL"]) ? 0 : Convert.ToInt32(form["LDL"]);
                        lab.BUN = string.IsNullOrEmpty(form["BUN"]) ? 0 : Convert.ToInt32(form["BUN"]);
                        lab.CREATINE = string.IsNullOrEmpty(form["CREATINE"]) ? 0 : Convert.ToInt32(form["CREATINE"]);
                        lab.UA = string.IsNullOrEmpty(form["UA"]) ? 0 : Convert.ToInt32(form["UA"]);
                        lab.BSN = string.IsNullOrEmpty(form["BSN"]) ? 0 : Convert.ToInt32(form["BSN"]);
                        lab._2JPP = string.IsNullOrEmpty(form["_2JPP"]) ? 0 : Convert.ToInt32(form["_2JPP"]);
                        lab.OT = string.IsNullOrEmpty(form["OT"]) ? 0 : Convert.ToInt32(form["OT"]);
                        lab.PT = string.IsNullOrEmpty(form["PT"]) ? 0 : Convert.ToInt32(form["PT"]);
                        lab.REDUKSI_PUASA = form["REDUKSI_PUASA"] == "true";
                        lab.REDUKSI_2JPP = form["REDUKSI_2JPP"] == "true";
                        lab.WARNA_URINE = form["WARNA_URINE"];
                        lab.BJ = string.IsNullOrEmpty(form["BJ"]) ? 0 : Convert.ToInt32(form["BJ"]);
                        lab.PH = string.IsNullOrEmpty(form["PH"]) ? 0 : Convert.ToInt32(form["PH"]);
                        lab.KETON = form["KETON"] == "true";
                        lab.BIL = form["BIL"] == "true";
                        lab.NITRIT = form["NITRIT"] == "true";
                        lab.EPITEL = string.IsNullOrEmpty(form["EPITEL"]) ? 0 : Convert.ToInt32(form["EPITEL"]);
                        lab.URINE_ERITROSIT = string.IsNullOrEmpty(form["URINE_ERITROSIT"]) ? 0 : Convert.ToInt32(form["URINE_ERITROSIT"]);
                        lab.URINE_LEKOSIT = string.IsNullOrEmpty(form["URINE_LEKOSIT"]) ? 0 : Convert.ToInt32(form["URINE_LEKOSIT"]);
                        lab.BAKTERI = form["BAKTERI"] == "true";
                        lab.SIL = form["SIL"] == "true";
                        lab.KRISTAL = form["KRISTAL"] == "true";
                        lab.LAB_RESUME = form["LAB_RESUME"];
                        lab.CHECKED_BY = user.NIK;

                        dc.LABs.InsertOnSubmit(lab);
                        dc.SubmitChanges();
                    }
                    // TODO: Add insert logic here
                    return RedirectToAction("Index");
                }
                return View();
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(lab);
            }
        }
        
        //
        // GET: /Labs/Edit/5
        [Authorize(Roles = "Admin,Lab")]
        public ActionResult Edit(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Edit";
                LAB lab = new LAB();

                try
                {
                    ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        lab =
                            dc.LABs.SingleOrDefault(
                                o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                    }
                    return View(lab);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(lab);
                }
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /Labs/Edit/5
        [Authorize(Roles = "Admin,Lab")]
        [HttpPost]
        public ActionResult Edit(FormCollection form)
        {
            ViewData["Action"] = "Edit";
            var user = (USER)Session["user"];
            var EMPLOYEE_ID = form["EMPLOYEE_ID"];
            var YEAR_CHECKUP = form["YEAR_CHECKUP"];

            LAB lab = new LAB();
            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                lab = dc.LABs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                try
                {
                    if (lab != null)
                    {
                        if (ModelState.IsValid)
                        {
                            lab.HB = string.IsNullOrEmpty(form["HB"]) ? 0 : Convert.ToDecimal(form["HB"]);
                            lab.HCT = string.IsNullOrEmpty(form["HCT"]) ? 0 : Convert.ToInt32(form["HCT"]);
                            lab.LEUKOSIT = string.IsNullOrEmpty(form["LEUKOSIT"]) ? 0 : Convert.ToInt32(form["LEUKOSIT"]);
                            lab.TROMBOSIT = string.IsNullOrEmpty(form["TROMBOSIT"]) ? 0 : Convert.ToInt32(form["TROMBOSIT"]);
                            lab.ERITROSIT = string.IsNullOrEmpty(form["ERITROSIT"]) ? 0 : Convert.ToDecimal(form["ERITROSIT"]);
                            lab.LED = string.IsNullOrEmpty(form["LED"]) ? 0 : Convert.ToInt32(form["LED"]);
                            lab.DIFLIM = string.IsNullOrEmpty(form["DIFLIM"]) ? 0 : Convert.ToInt32(form["DIFLIM"]);
                            lab.DIFMON = string.IsNullOrEmpty(form["DIFMON"]) ? 0 : Convert.ToInt32(form["DIFMON"]);
                            lab.DIFGRAN = string.IsNullOrEmpty(form["DIFGRAN"]) ? 0 : Convert.ToInt32(form["DIFGRAN"]);
                            lab.HBSAG = form["HBSAG"] == "true";
                            lab.AHBS = string.IsNullOrEmpty(form["AHBS"]) ? 0 : Convert.ToInt32(form["AHBS"]);
                            lab.VDRL = form["VDRL"] == "true";
                            lab.CHOLESTEROL = string.IsNullOrEmpty(form["CHOLESTEROL"]) ? 0 : Convert.ToInt32(form["CHOLESTEROL"]);
                            lab.TRIGLISERIN = string.IsNullOrEmpty(form["TRIGLISERIN"]) ? 0 : Convert.ToInt32(form["TRIGLISERIN"]);
                            lab.HDL = string.IsNullOrEmpty(form["HDL"]) ? 0 : Convert.ToInt32(form["HDL"]);
                            lab.LDL = string.IsNullOrEmpty(form["LDL"]) ? 0 : Convert.ToInt32(form["LDL"]);
                            lab.BUN = string.IsNullOrEmpty(form["BUN"]) ? 0 : Convert.ToInt32(form["BUN"]);
                            lab.CREATINE = string.IsNullOrEmpty(form["CREATINE"]) ? 0 : Convert.ToInt32(form["CREATINE"]);
                            lab.UA = string.IsNullOrEmpty(form["UA"]) ? 0 : Convert.ToInt32(form["UA"]);
                            lab.BSN = string.IsNullOrEmpty(form["BSN"]) ? 0 : Convert.ToInt32(form["BSN"]);
                            lab._2JPP = string.IsNullOrEmpty(form["_2JPP"]) ? 0 : Convert.ToInt32(form["_2JPP"]);
                            lab.OT = string.IsNullOrEmpty(form["OT"]) ? 0 : Convert.ToInt32(form["OT"]);
                            lab.PT = string.IsNullOrEmpty(form["PT"]) ? 0 : Convert.ToInt32(form["PT"]);
                            lab.REDUKSI_PUASA = form["REDUKSI_PUASA"] == "true";
                            lab.REDUKSI_2JPP = form["REDUKSI_2JPP"] == "true";
                            lab.WARNA_URINE = form["WARNA_URINE"];
                            lab.BJ = string.IsNullOrEmpty(form["BJ"]) ? 0 : Convert.ToInt32(form["BJ"]);
                            lab.PH = string.IsNullOrEmpty(form["PH"]) ? 0 : Convert.ToInt32(form["PH"]);
                            lab.KETON = form["KETON"] == "true";
                            lab.BIL = form["BIL"] == "true";
                            lab.NITRIT = form["NITRIT"] == "true";
                            lab.EPITEL = string.IsNullOrEmpty(form["EPITEL"]) ? 0 : Convert.ToInt32(form["EPITEL"]);
                            lab.URINE_ERITROSIT = string.IsNullOrEmpty(form["URINE_ERITROSIT"]) ? 0 : Convert.ToInt32(form["URINE_ERITROSIT"]);
                            lab.URINE_LEKOSIT = string.IsNullOrEmpty(form["URINE_LEKOSIT"]) ? 0 : Convert.ToInt32(form["URINE_LEKOSIT"]);
                            lab.BAKTERI = form["BAKTERI"] == "true";
                            lab.SIL = form["SIL"] == "true";
                            lab.KRISTAL = form["KRISTAL"] == "true";
                            lab.LAB_RESUME = form["LAB_RESUME"];
                            lab.CHECKED_BY = user.NIK;

                            dc.SubmitChanges();
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(lab);
                }
            }
        }

        //
        // GET: /Labs/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Labs/Delete/5
        [HttpPost]
        public ActionResult Delete(string employee_id, string year_checkup)
        {
            try
            {
                LAB lab;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    lab =
                        dc.LABs.SingleOrDefault(
                            o => o.EMPLOYEE_ID.Equals(employee_id) && o.YEAR_CHECKUP.Equals(year_checkup));

                    if (lab != null)
                    {
                        dc.LABs.DeleteOnSubmit(lab);
                        dc.SubmitChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("Index");
        }

        private void InitializeSession()
        {
            if (Session["user"] != null)
            {
                var user = Helper.SetSession(Request.Cookies[FormsAuthentication.FormsCookieName]);
                Session["user"] = user;
                Session["roles"] = user.ROLES;
            }
        }
    }
}
