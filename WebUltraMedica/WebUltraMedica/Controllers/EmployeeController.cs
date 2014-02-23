using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/

        [Authorize]
        public ActionResult Index()
        {
            InitializeSession();
            var listEmployee = new List<EMPLOYEE>();
            using (var dc = new db_ultramedicaDataContext())
            {
                listEmployee = dc.EMPLOYEEs.ToList();
            }
           
            return View(listEmployee);
        }

        //
        // GET: /Employee/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Employee/Create

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            InitializeSession();
            ViewData["Action"] = "Create";
            ViewData["ErrorMessage"] = "";
            return View(new EMPLOYEE());
        }

        //
        // POST: /Employee/Create

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(EMPLOYEE employee)
        {
            ViewData["Action"] = "Create";
            
            try
            {
                if (ModelState.IsValid)
                {
                    using (var dc = new db_ultramedicaDataContext())
                    {
                        dc.EMPLOYEEs.InsertOnSubmit(employee);
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
                return View(new EMPLOYEE());
            }
        }
        
        //
        // GET: /Employee/Edit/5

        [Authorize]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string employeeId)
        {
            InitializeSession();
            ViewData["Action"] = "Edit";
            
            try
            {
                EMPLOYEE employee;
               
                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext())
                {
                    employee = dc.EMPLOYEEs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(employeeId));
                }
                return View(employee);
            }
            catch(Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(new EMPLOYEE());
            }
        }

        //
        // POST: /Employee/Edit/5

        [HttpPost]
        [Authorize(Roles = "Admin")]    
        public ActionResult Edit(EMPLOYEE employee)
        {
            ViewData["Action"] = "Edit";
            
            try
            {
                using (var dc = new db_ultramedicaDataContext())
                {
                    var employeedb = dc.EMPLOYEEs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(employee.EMPLOYEE_ID));

                    if (employeedb != null)
                    {
                        employeedb.NAME = employee.NAME;
                        employeedb.COMPANY_ID = employee.COMPANY_ID;
                        employeedb.DISTRICT = employee.DISTRICT;
                        employeedb.AGE = employee.AGE;
                        employeedb.DEPARTMENT = employee.DEPARTMENT;
                        employeedb.MESS_STATUS = employee.MESS_STATUS;
                        employeedb.POSITION = employee.POSITION;
                        employeedb.SEX = employee.SEX;
                        employeedb.STATUS = employee.STATUS;
                        dc.SubmitChanges();
                    }
                     
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(employee);
            }
        }

        //
        // GET: /Employee/Delete/5

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Delete/5

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(string id, FormCollection collection)
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
