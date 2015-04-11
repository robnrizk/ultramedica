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

                List<SPIRO_INDEX> listSpiro = new List<SPIRO_INDEX>();
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    var q = (from fo in dc.GetSpiroIndex()
                             select new SPIRO_INDEX() { EMPLOYEE_ID = fo.EMPLOYEE_ID, SPIRO_ID = fo.SPIRO_ID ?? 0, LabId = fo.LAB_ID, YEAR_CHECKUP = fo.YEAR_CHECKUP }).ToList();
                    if (q.Any())
                        listSpiro.AddRange(q);
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
        public ActionResult Create(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";

                var Objreturn = new SPIRO();
               
                Objreturn.YEAR_CHECKUP = YEAR_CHECKUP;
                Objreturn.EMPLOYEE_ID = EMPLOYEE_ID;
               
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
            SPIRO spiro = new SPIRO();
            try
            {
                if (ModelState.IsValid)
                {
                    USER user = (USER)Session["user"];
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        spiro = new SPIRO()
                        {
                            EMPLOYEE_ID = form["EMPLOYEE_ID"],
                            YEAR_CHECKUP = form["YEAR_CHECKUP"],
                            SPIROMETRY_RESULT = form["SPIROMETRY_RESULT"],
                            CHECKED_BY = user.NIK
                        };

                        HttpPostedFileBase file = Request.Files["FileSPIRO"];

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

                            spiro.SPIROMETRY_FILE_NAME = Path.GetFileName(file.FileName);
                        }

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
                return View(spiro);
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
                SPIRO spiro = new SPIRO();
                try
                {
                   ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        spiro = dc.SPIROs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                    }
                    return View(spiro);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(spiro);
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
                var spiro = dc.SPIROs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                try
                {
                    if (spiro != null)
                    {
                        if (ModelState.IsValid)
                        {

                            USER user = (USER)Session["user"];

                            HttpPostedFileBase file = Request.Files["FileSPIRO"];

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

                                spiro.SPIROMETRY_FILE_NAME = Path.GetFileName(file.FileName);
                            }

                            spiro.SPIROMETRY_RESULT = form["SPIROMETRY_RESULT"];
                            spiro.CHECKED_BY = user.NIK;

                            dc.SubmitChanges();
                        }
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
