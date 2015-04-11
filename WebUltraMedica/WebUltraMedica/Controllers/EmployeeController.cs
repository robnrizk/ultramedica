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
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["ErrorMessage"] = "";
                List<EMPLOYEE> listEmployee;
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    listEmployee = dc.EMPLOYEEs.ToList();
                }

                return View(listEmployee);
            }
            return RedirectToAction("LogOut", "Account");
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
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Create";
                ViewData["ErrorMessage"] = "";
                return View(new EMPLOYEE());
            }
            return RedirectToAction("LogOut", "Account");
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
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
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
                return View(employee);
            }
        }

        //
        // GET: /Employee/Edit/5

        [Authorize]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(string employeeId)
        {
            if (Session["user"] != null)
            {
                InitializeSession();
                ViewData["Action"] = "Edit";
                EMPLOYEE employee = new EMPLOYEE();
                try
                {
                    ViewData["ErrorMessage"] = "";

                    // TODO: Add insert logic here
                    using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                    {
                        employee = dc.EMPLOYEEs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(employeeId));
                    }
                    return View(employee);
                }
                catch (Exception ex)
                {
                    ViewData["ErrorMessage"] = ex.Message;
                    return View(employee);
                }
            }
            return RedirectToAction("LogOut", "Account");
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
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    var employeedb = dc.EMPLOYEEs.SingleOrDefault(o => o.EMPLOYEE_ID.Equals(employee.EMPLOYEE_ID));

                    if (employeedb != null)
                    {
                        if (ModelState.IsValid)
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
        public ActionResult Delete(string ID)
        {
            try
            {
                EMPLOYEE employee;

                ViewData["ErrorMessage"] = "";

                // TODO: Add insert logic here
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    employee =
                        dc.EMPLOYEEs.SingleOrDefault(
                            o => o.EMPLOYEE_ID.Equals(ID));

                    if (employee != null)
                    {
                        dc.EMPLOYEEs.DeleteOnSubmit(employee);
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
