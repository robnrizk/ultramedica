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
            InitializeSession();
            var listfo = new List<FO>();


            using (var dc = new db_ultramedicaDataContext())
            {
                listfo = dc.FOs.ToList();
            }


            return View(listfo);
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
            InitializeSession();
            ViewData["Action"] = "Create";
            ViewData["ErrorMessage"] = "";
            return View(new FO());
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
                    using (var dc = new db_ultramedicaDataContext())
                    {
                        var fo = new FO
                                     {
                                         LAB_ID = int.Parse(form["LAB_ID"]),
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
        public ActionResult Edit(int labId)
        {
            InitializeSession();
            ViewData["Action"] = "Edit";

            try
            {
                FO fo;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext())
                {
                    fo = dc.FOs.SingleOrDefault(o => o.LAB_ID == labId);
                }
                return View(fo);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(new FO());
            }
        }

        //
        // POST: /FO/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admin,FO")]
        public ActionResult Edit(FormCollection form)
        {

            ViewData["Action"] = "Edit";
            var lab_id = int.Parse(form["LAB_ID"]);
            using (var dc = new db_ultramedicaDataContext())
            {
                var fo = dc.FOs.SingleOrDefault(o => o.LAB_ID == lab_id);
                try
                {
                     if (fo != null)
                    {
                        fo.EMPLOYEE_ID = form["EMPLOYEE_ID"];
                        fo.YEAR_CHECKUP = form["YEAR_CHECKUP"];
                        fo.DATE = new DateTime(int.Parse(form["DATE"].Substring(6,4)), int.Parse(form["DATE"].Substring(3,2)), int.Parse(form["DATE"].Substring(0,2)));
                        fo.DISTRICT = form["DISTRICT"];

                        dc.SubmitChanges();
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
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
