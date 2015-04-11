using System;
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

            if (Session["user"] != null)
            {
                ViewData["ErrorMessage"] = "";
                var user = (USER)Session["user"];
                var roles = user.ROLES.Split(',');

                if (!roles.Any(m => m.Equals("Admin")))
                {
                    listUser.Add(user);
                }
                else
                {
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        listUser = dc.USERs.ToList();
                    }
                }

                return View(listUser);
            }
            return RedirectToAction("LogOut", "Account");
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
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";
                return View(new USER());
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /User/Create

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(FormCollection formCollection)
        {
            ViewData["Action"] = "Create";
            var user = new USER();
            try
            {
                if (ModelState.IsValid)
                {
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
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
                return View(user);
            }
        }

        //
        // GET: /User/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string userNik)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Edit";
                USER user = new USER();
                try
                {
                    ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        user = dc.USERs.SingleOrDefault(o => o.NIK.Equals(userNik));
                    }
                    return View(user);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(user);
                }
            }
            return RedirectToAction("LogOut", "Account");
        }

        //
        // POST: /User/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(FormCollection formCollection)
        {
            ViewData["Action"] = "Edit";
            var userdb = new USER();
            using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                userdb = dc.USERs.SingleOrDefault(o => o.NIK.Equals(formCollection["NIK"]));
                try
                {
                    if (userdb != null)
                    {
                        if (ModelState.IsValid)
                        {

                            userdb.NAMA = formCollection["NAMA"];
                            userdb.POSISI = formCollection["POSISI"];
                            userdb.USERNAME = formCollection["USERNAME"];
                            if (!string.IsNullOrEmpty(formCollection["PASSWORD"])) userdb.PASSWORD = formCollection["PASSWORD"];
                            userdb.ROLES = formCollection["ROLES"];
                            dc.SubmitChanges();
                        }
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
        public ActionResult Delete(string ID)
        {
            try
            {
                USER user;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    user =
                        dc.USERs.SingleOrDefault(
                            o => o.NIK.Equals(ID));

                    if (user != null)
                    {
                        dc.USERs.DeleteOnSubmit(user);
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
