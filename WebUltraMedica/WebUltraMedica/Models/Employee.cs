using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUltraMedica.Models
{
    [MetadataType(typeof(EMPLOYEE_VALIDATION))]
    public partial class EMPLOYEE
    {
        public string COMPANY_NAME
        {
            get
            {
                var objreturn = string.Empty;
                using (var dc = new db_ultramedicaDataContext())
                {
                    var company = dc.COMPANies.SingleOrDefault(o => o.COMPANY_ID == this.COMPANY_ID);
                    if (company != null) objreturn = company.COMPANY_NAME;
                }
                return objreturn;
            }
        }

        public List<SelectListItem> SEX_LIST
        {
            get 
            { 
                var objReturn = new List<SelectListItem>
                                      {
                                          new SelectListItem() {Text = "L", Value = "L"},
                                          new SelectListItem() {Text = "P", Value = "P"}
                                      };

                return objReturn;
            }
        }

        public List<SelectListItem> STATUS_LIST
        {
            get
            {
                var objReturn = new List<SelectListItem>
                                      {
                                          new SelectListItem() {Text = "Aktif", Value = "true"},
                                          new SelectListItem() {Text = "Resign", Value = "false"}
                                      };

                return objReturn;
            }
        }

        public List<SelectListItem> MESS_LIST
        {
            get
            {
                var objReturn = new List<SelectListItem>
                                      {
                                          new SelectListItem() {Text = "Mes", Value = "true"},
                                          new SelectListItem() {Text = "Non Mess", Value = "false"}
                                      };

                return objReturn;
            }
        }

        public List<SelectListItem> COMPANY_LIST
        {
            get
            {
                var objreturn = new List<SelectListItem>();
                using (var dc = new db_ultramedicaDataContext())
                {
                    var company = dc.COMPANies.OrderBy(m => m.COMPANY_NAME).ToList();
                    if (company.Any())
                    {
                        objreturn.AddRange(company.Select(com => new SelectListItem() {Text = com.COMPANY_NAME, Value = com.COMPANY_ID.ToString(CultureInfo.InvariantCulture)}));
                    }
                }
                return objreturn;
            }
        }
    }

    public class EMPLOYEE_VALIDATION
    {
       [Required(ErrorMessage = "NRP harus diisi.")]
       public string EMPLOYEE_ID { get; set; }
    }
}