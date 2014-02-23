using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public class FisikController : Controller
    {
        //
        // GET: /Fisik/
        [Authorize(Roles = "Admin,Fisik")]
        public ActionResult Index(int? year)
        {
            InitializeSession();
            if(year == null)
            {
                year = DateTime.Now.Year;
            }

            List<FISIK> listfisik;
            using (var dc = new db_ultramedicaDataContext())
            {
                listfisik = dc.FISIKs.Where(m => m.YEAR_CHECKUP.Equals(year)).ToList();
            }


            return View(listfisik);
        }

        //
        // GET: /Fisik/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Fisik/Create
        [Authorize(Roles = "Admin,Fisik")]
        public ActionResult Create()
        {
            InitializeSession();
            ViewData["Action"] = "Create";
            ViewData["ErrorMessage"] = "";
            return View(new FISIK());
        } 

        //
        // POST: /Fisik/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //
        // GET: /Fisik/Edit/5
 
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Fisik/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
 
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Fisik/Delete/5
 
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Fisik/Delete/5

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
