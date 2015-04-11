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

                List<EKG_INDEX> listEkg = new List<EKG_INDEX>();
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    var q = (from fo in dc.GetEkgIndex()
                             select new EKG_INDEX() { EMPLOYEE_ID = fo.EMPLOYEE_ID, EKG_ID = fo.EKG_ID ?? 0, LabId = fo.LAB_ID, YEAR_CHECKUP = fo.YEAR_CHECKUP }).ToList();
                    if (q.Any())
                        listEkg.AddRange(q);
                }

                return View(listEkg);
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
        public ActionResult Create(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";

                var Objreturn = new EKG();
                Objreturn.YEAR_CHECKUP = YEAR_CHECKUP;
                Objreturn.EMPLOYEE_ID = EMPLOYEE_ID;

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
            EKG ekg = new EKG();
            try
            {
                if (ModelState.IsValid)
                {
                    USER user = (USER)Session["user"];
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        ekg = new EKG()
                        {
                            EMPLOYEE_ID = form["EMPLOYEE_ID"],
                            YEAR_CHECKUP = form["YEAR_CHECKUP"],
                            EKG_RESULT = form["EKG_RESULT"],
                            CHECKED_BY = user.NIK
                        };

                        HttpPostedFileBase file = Request.Files["FileEKG"];
                       
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

                            ekg.EKG_FILE_NAME = Path.GetFileName(file.FileName);
                        }

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
                return View(ekg);
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

                EKG ekg = new EKG();

                try
                {
                    ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        ekg = dc.EKGs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                    }
                    return View(ekg);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(ekg);
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

            EKG ekg = new EKG();

            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                
                ekg = dc.EKGs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                try
                {
                    if (ekg != null)
                    {
                        if (ModelState.IsValid)
                        {
                            USER user = (USER)Session["user"];
                            HttpPostedFileBase file = Request.Files["FileEKG"];

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

                                ekg.EKG_FILE_NAME = Path.GetFileName(file.FileName);
                            }

                            ekg.EKG_RESULT = form["EKG_RESULT"];
                            ekg.CHECKED_BY = user.NIK;

                            dc.SubmitChanges();
                        }
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
