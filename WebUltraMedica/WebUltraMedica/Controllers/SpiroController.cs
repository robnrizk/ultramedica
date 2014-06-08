using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public class SpiroController : Controller
    {
        //
        // GET: /Spiro/
        [Authorize(Roles = "Admin,SPIRO")]
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

                List<SPIRO> listSpiro;
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    listSpiro = dc.SPIROs.Where(m => m.YEAR_CHECKUP.Equals(year)).ToList();
                }

                return View(listSpiro);
            }

            return RedirectToAction("LogOut", "Account");
        }

        //
        // GET: /Spiro/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Spiro/Create
        [Authorize(Roles = "Admin,SPIRO")]
        public ActionResult Create(Nullable<int> LAB_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";

                var Objreturn = new SPIRO();
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
        // POST: /Spiro/Create

        [HttpPost]
        [Authorize(Roles = "Admin,SPIRO")]
        public ActionResult Create(FormCollection form)
        {
            ViewData["Action"] = "Create";

            try
            {
                if (ModelState.IsValid)
                {
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        var spiro = new SPIRO()
                        {
                            EMPLOYEE_ID = form["EMPLOYEE_ID"],
                            YEAR_CHECKUP = form["YEAR_CHECKUP"],
                            SPIROMETRY_FILE_NAME = form["SPIROMETRY_FILE_NAME"],
                            SPIROMETRY_RESULT = form["SPIROMETRY_RESULT"],
                            CHECKED_BY = ""
                        };
                        dc.SPIROs.InsertOnSubmit(spiro);
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
                return View(new SPIRO());
            }
        }

        //
        // GET: /Spiro/Edit/5
        [Authorize(Roles = "Admin,AUDIO")]
        public ActionResult Edit(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Edit";

                try
                {
                    SPIRO spiro;

                    ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        spiro = dc.SPIROs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && YEAR_CHECKUP == YEAR_CHECKUP);
                    }
                    return View(spiro);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(new SPIRO());
                }
            }

            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /Spiro/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admin,SPIRO")]
        public ActionResult Edit(FormCollection form)
        {
            ViewData["Action"] = "Edit";
            var EMPLOYEE_ID = form["EMPLOYEE_ID"];
            var YEAR_CHECKUP = form["YEAR_CHECKUP"];
            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                var spiro = dc.SPIROs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && YEAR_CHECKUP == YEAR_CHECKUP);
                try
                {
                    if (spiro != null)
                    {
                        spiro.SPIROMETRY_FILE_NAME = form["SPIROMETRY_FILE_NAME"];
                        spiro.SPIROMETRY_RESULT = form["SPIROMETRY_RESULT"];
                        spiro.CHECKED_BY = "";

                        dc.SubmitChanges();
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(spiro);
                }
            }
        }

        //
        // GET: /Spiro/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Spiro/Delete/5

        [HttpPost]
        public ActionResult Delete(string employee_id, string year_checkup)
        {
            try
            {
                SPIRO spiro;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    spiro =
                        dc.SPIROs.SingleOrDefault(
                            o => o.EMPLOYEE_ID.Equals(employee_id) && o.YEAR_CHECKUP.Equals(year_checkup));

                    if (spiro != null)
                    {
                        dc.SPIROs.DeleteOnSubmit(spiro);
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
