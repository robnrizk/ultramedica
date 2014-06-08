using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WebUltraMedica.Controllers;

namespace WebUltraMedica.Models
{
    public partial class LAB
    {
        public string EMPLOYEE_NAME
        {
            get
            {
                var objreturn = string.Empty;
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    var employee = dc.EMPLOYEEs.SingleOrDefault(o => o.EMPLOYEE_ID == this.EMPLOYEE_ID);
                    if (employee != null) objreturn = employee.NAME;
                }
                return objreturn;
            }
        }

        public int LabId
        {
            get
            {
                var objreturn = 0;
                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    var fo = dc.FOs.SingleOrDefault(o => o.EMPLOYEE_ID == EMPLOYEE_ID && o.YEAR_CHECKUP.Equals(YEAR_CHECKUP));
                    if (fo != null)
                    {
                        objreturn = fo.LAB_ID;
                    }
                }

                return objreturn;
            }
        }

        public List<SelectListItem> LABID_LIST
        {
            get
            {
                var objreturn = new List<SelectListItem>();
                using (var db = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    objreturn.AddRange(
                        db.FOs.Where(m => m.YEAR_CHECKUP.Equals(DateTime.Now.Year)).Select(
                            masterSelect => new SelectListItem() { Text = masterSelect.LAB_ID.ToString(CultureInfo.InvariantCulture), Value = masterSelect.LAB_ID.ToString(CultureInfo.InvariantCulture) }));
                }

                return objreturn;
            }
        }

        public decimal RCHOLESTEROL_HDL
        {
            get
            {
                var hdl = this.HDL;
                if (hdl != null && hdl > 0)
                {
                    return this.CHOLESTEROL.Value/hdl.Value;
                }
                else
                {
                    return 0;
                }
            }
        }

        public List<SelectListItem> POSITIVE_NEGATIVE_LIST
        {
            get
            {
                return GetSelectListItems("POSITIVE_NEGATIVE");
            }
        }

        private List<SelectListItem> GetSelectListItems(string key)
        {
            var objReturn = new List<SelectListItem>();

            using (var db = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                var listItems = db.MASTER_SELECTs.Where(m => m.KEY_SELECT.Equals(key));
                if (listItems.Any())
                {
                    objReturn.AddRange(listItems.Select(masterSelect => new SelectListItem() { Text = masterSelect.TEXT, Value = masterSelect.VALUE }));
                }
            }

            return objReturn;
        }
    }
}