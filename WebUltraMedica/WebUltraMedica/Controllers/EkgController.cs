using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public class EkgController : Controller
    {
        //
        // GET: /Ekg/
        [Authorize(Roles = "Admin,EKG")]
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

                List<EKG> lisEKG;
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    lisEKG = dc.EKGs.Where(m => m.YEAR_CHECKUP.Equals(year)).ToList();
                }

                return View(lisEKG);
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // GET: /Ekg/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Ekg/Create
        [Authorize(Roles = "Admin,EKG")]
        public ActionResult Create(Nullable<int> LAB_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";

                var Objreturn = new EKG();
                Objreturn.YEAR_CHECKUP = DateTime.Now.Year.ToString();

                if ((LAB_ID != null) && (!string.IsNullOrEmpty(YEAR_CHECKUP)))
                {
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        var FO = dc.FOs.SingleOrDefault(o => o.LAB_ID == LAB_ID && o.YEAR_CHECKUP == YEAR_CHECKUP);
                        if (FO != null)
                        {
                            Objreturn.YEAR_CHECKUP = FO.YEAR_CHECKUP;
                            Objreturn.EMPLOYEE_ID = FO.EMPLOYEE_ID;
                        }
                    }
                }


                return View(Objreturn);
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /Ekg/Create

        [HttpPost]
        public ActionResult Create(FormCollection form)
        {
            ViewData["Action"] = "Create";

            try
            {
                if (ModelState.IsValid)
                {
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        var ekg = new EKG()
                        {
                            EMPLOYEE_ID = form["EMPLOYEE_ID"],
                            YEAR_CHECKUP = form["YEAR_CHECKUP"],
                            EKG_FILE_NAME = form["EKG_FILE_NAME"],
                            EKG_RESULT = form["EKG_RESULT"],
                            CHECKED_BY = ""
                        };
                        dc.EKGs.InsertOnSubmit(ekg);
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
                return View(new EKG());
            }
        }

        //
        // GET: /Ekg/Edit/5
        [Authorize(Roles = "Admin,EKG")]
        public ActionResult Edit(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Edit";

                try
                {
                    EKG ekg;

                    ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        ekg = dc.EKGs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && YEAR_CHECKUP == YEAR_CHECKUP);
                    }
                    return View(ekg);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(new EKG());
                }
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /Ekg/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admin,EKG")]
        public ActionResult Edit(FormCollection form)
        {
            ViewData["Action"] = "Edit";
            var EMPLOYEE_ID = form["EMPLOYEE_ID"];
            var YEAR_CHECKUP = form["YEAR_CHECKUP"];
            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                var ekg = dc.EKGs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && YEAR_CHECKUP == YEAR_CHECKUP);
                try
                {
                    if (ekg != null)
                    {
                        ekg.EKG_FILE_NAME = form["EKG_FILE_NAME"];
                        ekg.EKG_RESULT = form["EKG_RESULT"];
                        ekg.CHECKED_BY = "";

                        dc.SubmitChanges();
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(ekg);
                }
            }
        }

        //
        // GET: /Ekg/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Ekg/Delete/5

        [HttpPost]
        public ActionResult Delete(string employee_id, string year_checkup)
        {
            try
            {
                EKG ekg;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    ekg =
                        dc.EKGs.SingleOrDefault(
                            o => o.EMPLOYEE_ID.Equals(employee_id) && o.YEAR_CHECKUP.Equals(year_checkup));

                    if (ekg != null)
                    {
                        dc.EKGs.DeleteOnSubmit(ekg);
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
