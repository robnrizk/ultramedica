﻿using System;
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

                List<AUDIO_INDEX> listAudio = new List<AUDIO_INDEX>();
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    var q = (from fo in dc.GetAudioIndex()
                             select new AUDIO_INDEX() { EMPLOYEE_ID = fo.EMPLOYEE_ID, AUDIO_ID = fo.AUDIO_ID ?? 0, LabId = fo.LAB_ID, YEAR_CHECKUP = fo.YEAR_CHECKUP }).ToList();
                    if (q.Any())
                        listAudio.AddRange(q);
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
        public ActionResult Create(string EMPLOYEE_ID, string YEAR_CHECKUP)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";

                var Objreturn = new AUDIO();
              
                Objreturn.YEAR_CHECKUP = YEAR_CHECKUP;
                Objreturn.EMPLOYEE_ID = EMPLOYEE_ID;
               
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
            AUDIO audio = new AUDIO();
            try
            {
                if (ModelState.IsValid)
                {
                    USER user = (USER)Session["user"];
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        audio = new AUDIO()
                        {
                            EMPLOYEE_ID = form["EMPLOYEE_ID"],
                            YEAR_CHECKUP = form["YEAR_CHECKUP"],
                            AUDIOMETRY_RESULT = form["AUDIOMETRY_RESULT"],
                            CHECKED_BY = user.NIK
                        };

                        HttpPostedFileBase file = Request.Files["FileAUDIO"];

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

                            audio.AUDIOMETRY_FILE_NAME = Path.GetFileName(file.FileName);
                        }

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
                return View(audio);
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
                AUDIO audio = new AUDIO();
                try
                {
                    ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        audio = dc.AUDIOs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                    }
                    return View(audio);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(audio);
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

            AUDIO audio = new AUDIO();
            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                audio = dc.AUDIOs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(EMPLOYEE_ID) && o.YEAR_CHECKUP == YEAR_CHECKUP);
                try
                {
                    if (audio != null)
                    {
                        if (ModelState.IsValid)
                        {
                            USER user = (USER)Session["user"];
                            HttpPostedFileBase file = Request.Files["FileAUDIO"];

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

                                audio.AUDIOMETRY_FILE_NAME = Path.GetFileName(file.FileName);
                            }

                            audio.AUDIOMETRY_RESULT = form["AUDIOMETRY_RESULT"];
                            audio.CHECKED_BY = user.NIK;
                            
                            dc.SubmitChanges();
                        }
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
