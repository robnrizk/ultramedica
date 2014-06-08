using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public class AudioController : Controller
    {
        //
        // GET: /Audio/
        [Authorize(Roles = "Admin,Audio")]
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

                List<AUDIO> listAudio;
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    listAudio = dc.AUDIOs.Where(m => m.YEAR_CHECKUP.Equals(year)).ToList();
                }

                return View(listAudio);
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // GET: /Audio/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Audio/Create
        [Authorize(Roles = "Admin,Audio")]
        public ActionResult Create(Nullable<int> LAB_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";

                var Objreturn = new AUDIO();
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
        // POST: /Audio/Create

        [HttpPost]
        [Authorize(Roles = "Admin,Audio")]
        public ActionResult Create(FormCollection form)
        {
            ViewData["Action"] = "Create";

            try
            {
                if (ModelState.IsValid)
                {
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        var audio = new AUDIO()
                        {
                            EMPLOYEE_ID = form["EMPLOYEE_ID"],
                            YEAR_CHECKUP = form["YEAR_CHECKUP"],
                            AUDIOMETRY_FILE_NAME = form["AUDIOMETRY_FILE_NAME"],
                            AUDIOMETRY_RESULT = form["AUDIOMETRY_RESULT"],
                            CHECKED_BY = ""
                        };
                        dc.AUDIOs.InsertOnSubmit(audio);
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
                return View(new AUDIO());
            }
        }

        //
        // GET: /Audio/Edit/5
        [Authorize(Roles = "Admin,Audio")]
        public ActionResult Edit(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Edit";

                try
                {
                    AUDIO audio;

                    ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        audio = dc.AUDIOs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && YEAR_CHECKUP == YEAR_CHECKUP);
                    }
                    return View(audio);
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
        // POST: /Audio/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admin,Audio")]
        public ActionResult Edit(FormCollection form)
        {
            ViewData["Action"] = "Edit";
            var EMPLOYEE_ID = form["EMPLOYEE_ID"];
            var YEAR_CHECKUP = form["YEAR_CHECKUP"];
            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                var audio =
                    dc.AUDIOs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && YEAR_CHECKUP == YEAR_CHECKUP);
                try
                {
                    if (audio != null)
                    {
                        audio.AUDIOMETRY_FILE_NAME = form["AUDIOMETRY_FILE_NAME"];
                        audio.AUDIOMETRY_RESULT = form["AUDIOMETRY_RESULT"];
                        audio.CHECKED_BY = "";

                        dc.SubmitChanges();
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(audio);
                }
            }
        }

        //
        // GET: /Audio/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Audio/Delete/5

        [HttpPost]
        public ActionResult Delete(string employee_id, string year_checkup)
        {
            try
            {
                AUDIO audio;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    audio =
                        dc.AUDIOs.SingleOrDefault(
                            o => o.EMPLOYEE_ID.Equals(employee_id) && o.YEAR_CHECKUP.Equals(year_checkup));

                    if (audio != null)
                    {
                        dc.AUDIOs.DeleteOnSubmit(audio);
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
