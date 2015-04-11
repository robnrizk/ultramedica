using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;
using System.Configuration;
using System.IO;

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

                List<RONTGEN_INDEX> listRontgen = new List<RONTGEN_INDEX>();
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    var q = (from fo in dc.GetRontgenIndex()
                             select new RONTGEN_INDEX() { EMPLOYEE_ID = fo.EMPLOYEE_ID, RONTGEN_ID = fo.RONTGEN_ID ?? 0, LabId = fo.LAB_ID, YEAR_CHECKUP = fo.YEAR_CHECKUP }).ToList();
                    if (q.Any())
                        listRontgen.AddRange(q);
                }

                return View(listRontgen);
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
        public ActionResult Create(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";

                var Objreturn = new RONTGEN();
                Objreturn.YEAR_CHECKUP = YEAR_CHECKUP;
                Objreturn.EMPLOYEE_ID = EMPLOYEE_ID;
               
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

            RONTGEN rontgen = new RONTGEN();
            try
            {
                if (ModelState.IsValid)
                {
                    USER user = (USER)Session["user"];
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        rontgen = new RONTGEN()
                        {
                            EMPLOYEE_ID = form["EMPLOYEE_ID"],
                            YEAR_CHECKUP = form["YEAR_CHECKUP"],
                            RONTGEN_RESULT = form["RONTGEN_RESULT"],
                            CHECKED_BY = user.NIK
                        };

                        HttpPostedFileBase file = Request.Files["FileRontgen"];

                        if (Request.ContentLength > Helper.MaxRequestLength() * 1024)
                        {
                            throw new Exception("Maximum request length exceeded. File allowed to be upload are " + (Helper.MaxRequestLength() / 1024).ToString() + " MB");
                        }

                        if (file.ContentLength > 0)
                        {
                            string fileDir = string.Format("{0}\\{1}_{2}", ConfigurationManager.AppSettings["FileUpload"], form["EMPLOYEE_ID"].ToString(), form["YEAR_CHECKUP"]);
                            string filePath = string.Format("{0}\\{1}", fileDir, Path.GetFileName(file.FileName));
                            if (!Directory.Exists(fileDir))
                                Directory.CreateDirectory(fileDir);

                            file.SaveAs(filePath);

                            rontgen.RONTGEN_FILE_NAME = Path.GetFileName(file.FileName);
                        }
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
                return View(rontgen);
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
                RONTGEN rontgen = new RONTGEN();
                try
                {
                   
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
                    return View(rontgen);
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
            RONTGEN rontgen = new RONTGEN();
            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                rontgen = dc.RONTGENs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                try
                {
                    if (rontgen != null)
                    {
                        if (ModelState.IsValid)
                        {
                            HttpPostedFileBase file = Request.Files["FileRontgen"];

                            if (Request.ContentLength > Helper.MaxRequestLength() * 1024)
                            {
                                throw new Exception("Maximum request length exceeded. File allowed to be upload are " + (Helper.MaxRequestLength() / 1024).ToString() + " MB");
                            }


                            if (file.ContentLength > 0)
                            {
                                string fileDir = string.Format("{0}\\{1}_{2}", ConfigurationManager.AppSettings["FileUpload"], EMPLOYEE_ID.ToString(), YEAR_CHECKUP);
                                string filePath = string.Format("{0}\\{1}", fileDir, Path.GetFileName(file.FileName));
                                if (!Directory.Exists(fileDir))
                                    Directory.CreateDirectory(fileDir);

                                file.SaveAs(filePath);

                                rontgen.RONTGEN_FILE_NAME = Path.GetFileName(file.FileName);
                            }

                            rontgen.RONTGEN_FILE_NAME = form["RONTGEN_FILE_NAME"];
                            rontgen.RONTGEN_RESULT = form["RONTGEN_RESULT"];
                            rontgen.CHECKED_BY = "";

                            dc.SubmitChanges();
                        }
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
