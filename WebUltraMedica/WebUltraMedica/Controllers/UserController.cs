﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/

        [Authorize]
        public ActionResult Index()
        {
            InitializeSession();
            var listUser = new List<USER>();
            var user = (USER)Session["user"];
            var roles = user.ROLES.Split(',');

            if (!roles.Any(m => m.Equals("Admin")))
            {
                listUser.Add(user);
            }
            else
            {
                using (var dc = new db_ultramedicaDataContext())
                {
                    listUser = dc.USERs.ToList();
                }
            }

            return View(listUser);

        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            InitializeSession();
            ViewData["Action"] = "Create";
            ViewData["ErrorMessage"] = "";
            return View(new USER());
        }

        //
        // POST: /User/Create

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(FormCollection formCollection)
        {
            ViewData["Action"] = "Create";
            try
            {
                if (ModelState.IsValid)
                {
                    using (var dc = new db_ultramedicaDataContext())
                    {
                        var user = new USER();
                        user.NIK = formCollection["NIK"];
                        user.NAMA = formCollection["NAMA"];
                        user.POSISI = formCollection["POSISI"];
                        user.USERNAME = formCollection["USERNAME"];
                        if (!string.IsNullOrEmpty(formCollection["PASSWORD"])) user.PASSWORD = formCollection["PASSWORD"];
                        user.ROLES = formCollection["ROLES"];

                        dc.USERs.InsertOnSubmit(user);
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
                return View(new USER());
            }
        }

        //
        // GET: /User/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string userNik)
        {
            InitializeSession();
            ViewData["Action"] = "Edit";

            try
            {
                USER user;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext())
                {
                    user = dc.USERs.SingleOrDefault(o => o.NIK.Equals(userNik));
                }
                return View(user);
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(new USER());
            }
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(FormCollection formCollection)
        {
            ViewData["Action"] = "Edit";
            using (var dc = new db_ultramedicaDataContext())
            {
                var userdb = dc.USERs.SingleOrDefault(o => o.NIK.Equals(formCollection["NIK"]));
                try
                {
                     if (userdb != null)
                    {
                        userdb.NAMA = formCollection["NAMA"];
                        userdb.POSISI = formCollection["POSISI"];
                        userdb.USERNAME = formCollection["USERNAME"];
                        if (!string.IsNullOrEmpty(formCollection["PASSWORD"])) userdb.PASSWORD = formCollection["PASSWORD"];
                        userdb.ROLES = formCollection["ROLES"];
                        dc.SubmitChanges();
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(userdb);
                }
            }
        }

        //
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

        [HttpPost]
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