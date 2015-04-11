using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public class FOController : Controller
    {
        //
        // GET: /FO/
        [Authorize(Roles = "Admin,FO")]
        public ActionResult Index()
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                List<FO> listfo;

                ViewData["ErrorMessage"] = "";
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    listfo = dc.FOs.ToList();
                }
                return View(listfo);
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // GET: /FO/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /FO/Create

        [Authorize(Roles = "Admin,FO")]
        public ActionResult Create()
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";
                return View(new FO());
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /FO/Create

        [HttpPost]
        [Authorize(Roles = "Admin,FO")]
        public ActionResult Create(FormCollection form)
        {
            ViewData["Action"] = "Create";

            try
            {
                if (ModelState.IsValid)
                {
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        var fo = new FO
                                     {
                                         LAB_ID = int.Parse(form["LAB_ID"] ?? "0"),
                                         EMPLOYEE_ID = form["EMPLOYEE_ID"],
                                         YEAR_CHECKUP = form["YEAR_CHECKUP"],
                                         DATE =
                                             new DateTime(int.Parse(form["DATE"].Substring(6, 4)),
                                                          int.Parse(form["DATE"].Substring(3, 2)),
                                                          int.Parse(form["DATE"].Substring(0, 2))),
                                         DISTRICT = form["DISTRICT"]
                                     };
                        dc.FOs.InsertOnSubmit(fo);
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
                return View(new FO());
            }
        }

        //
        // GET: /FO/Edit/5
        [Authorize(Roles = "Admin,FO")]
        public ActionResult Edit(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Edit";
                FO fo = new FO();
                try
                {
                    ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        fo = dc.FOs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                    }
                    return View(fo);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(fo);
                }
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /FO/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admin,FO")]
        public ActionResult Edit(FormCollection form)
        {

            ViewData["Action"] = "Edit";
            var EMPLOYEE_ID = form["EMPLOYEE_ID"];
            var YEAR_CHECKUP = form["YEAR_CHECKUP"];

            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                var fo = dc.FOs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                try
                {
                    if (fo != null)
                    {
                        if (ModelState.IsValid)
                        {
                            fo.LAB_ID = Int32.Parse(form["LAB_ID"]);
                            fo.EMPLOYEE_ID = form["EMPLOYEE_ID"];
                            fo.YEAR_CHECKUP = form["YEAR_CHECKUP"];
                            fo.DATE = new DateTime(int.Parse(form["DATE"].Substring(6, 4)), int.Parse(form["DATE"].Substring(3, 2)), int.Parse(form["DATE"].Substring(0, 2)));
                            fo.DISTRICT = form["DISTRICT"];

                            dc.SubmitChanges();
                        }
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(fo);
                }
            }
        }

        //
        // GET: /FO/Delete/5
        [Authorize(Roles = "Admin,FO")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /FO/Delete/5

        [HttpPost]
        [Authorize(Roles = "Admin,FO")]
        public ActionResult Delete(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            try
            {
                FO fo;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    fo =
                        dc.FOs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);

                    if (fo != null)
                    {
                        dc.FOs.DeleteOnSubmit(fo);
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
            if (Session["user"] == null)
            {
                var user = Helper.SetSession(Request.Cookies[FormsAuthentication.FormsCookieName]);
                Session["user"] = user;
                Session["roles"] = user.ROLES;
            }
        }
    }
}
