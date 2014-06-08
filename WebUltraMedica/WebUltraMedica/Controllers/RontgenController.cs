using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public class RontgenController : Controller
    {
        //
        // GET: /Rontgen/
        [Authorize(Roles = "Admin,Rontgen")]
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

                List<RONTGEN> listrontgen;
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    listrontgen = dc.RONTGENs.Where(m => m.YEAR_CHECKUP.Equals(year)).ToList();
                }

                return View(listrontgen);
            }
            return RedirectToAction("LogOut", "Account");

        }

        //
        // GET: /Rontgen/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Rontgen/Create
        [Authorize(Roles = "Admin,Rontgen")]
        public ActionResult Create(Nullable<int> LAB_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";

                var Objreturn = new RONTGEN();
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
        // POST: /Rontgen/Create

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
                        var rontgen = new RONTGEN()
                        {
                            EMPLOYEE_ID = form["EMPLOYEE_ID"],
                            YEAR_CHECKUP = form["YEAR_CHECKUP"],
                            RONTGEN_FILE_NAME = form["RONTGEN_FILE_NAME"],
                            RONTGEN_RESULT = form["RONTGEN_RESULT"],
                            CHECKED_BY = ""
                        };
                        dc.RONTGENs.InsertOnSubmit(rontgen);
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
                return View(new RONTGEN());
            }
        }

        //
        // GET: /Rontgen/Edit/5
        [Authorize(Roles = "Admin,Rontgen")]
        public ActionResult Edit(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Edit";

                try
                {
                    RONTGEN rontgen;

                    ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        rontgen = dc.RONTGENs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && YEAR_CHECKUP == YEAR_CHECKUP);
                    }
                    return View(rontgen);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(new RONTGEN());
                }
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /Rontgen/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admin,Rontgen")]
        public ActionResult Edit(FormCollection form)
        {
            ViewData["Action"] = "Edit";
            var EMPLOYEE_ID = form["EMPLOYEE_ID"];
            var YEAR_CHECKUP = form["YEAR_CHECKUP"];
            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                var rontgen = dc.RONTGENs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && YEAR_CHECKUP == YEAR_CHECKUP);
                try
                {
                    if (rontgen != null)
                    {
                        rontgen.RONTGEN_FILE_NAME = form["RONTGEN_FILE_NAME"];
                        rontgen.RONTGEN_RESULT = form["RONTGEN_RESULT"];
                        rontgen.CHECKED_BY = "";

                        dc.SubmitChanges();
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(rontgen);
                }
            }
        }

        //
        // GET: /Rontgen/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Rontgen/Delete/5

        [HttpPost]
        public ActionResult Delete(string employee_id, string year_checkup)
        {
            try
            {
                RONTGEN rontgen;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    rontgen =
                        dc.RONTGENs.SingleOrDefault(
                            o => o.EMPLOYEE_ID.Equals(employee_id) && o.YEAR_CHECKUP.Equals(year_checkup));

                    if (rontgen != null)
                    {
                        dc.RONTGENs.DeleteOnSubmit(rontgen);
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
