using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using WebUltraMedica.Controllers;
using System.Web;

namespace WebUltraMedica.Models
{
    public partial class EKG
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

        public HttpPostedFileBase FileEKG { get; set; }
    }

    public class EKG_INDEX
    {
        public int LabId { get; set; }
        public string EMPLOYEE_ID { get; set; }
        public string YEAR_CHECKUP { get; set; }
        public int EKG_ID { get; set; }

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

    }
}