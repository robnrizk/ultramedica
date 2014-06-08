using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web.Mvc;
using WebUltraMedica.Controllers;

namespace WebUltraMedica.Models
{
    [MetadataType(typeof(FO_VALIDATION))]
    public partial class FO
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

        
        public List<SelectListItem> EMPLOYEE_LIST
        {
            get
            {
                var objReturn = new List<SelectListItem>();

                using (var dc = new db_ultramedicaDataContext(Helper.ConnectionString()))
                {
                    var employees = dc.EMPLOYEEs.ToList();
                    if (employees.Any())
                        objReturn.AddRange(employees.Select(employee => new SelectListItem() {Value = employee.EMPLOYEE_ID, Text = employee.NAME}));
                }

                return objReturn;
            }
        }

        public List<SelectListItem> YEAR_LIST
        {
            get
            {
                var objReturn = new List<SelectListItem>();

                for (int i = 2014; i < 2014 + 10;i++) objReturn.Add(new SelectListItem(){Value = i.ToString(), Text = i.ToString()});
                    return objReturn;
            }
        } 
    }

    public class FO_VALIDATION
    {
        [Required(ErrorMessage = "Laboratorium ID harus diisi.")]
        public int LAB_ID { get; set; }

        [Required(ErrorMessage = "Pegawai harus diisi.")]
        public int EMPLOYEE_ID { get; set; }

        [Required(ErrorMessage = "Tahun Check Up harus diisi.")]
        public int YEAR_CHECKUP { get; set; }
    }

}