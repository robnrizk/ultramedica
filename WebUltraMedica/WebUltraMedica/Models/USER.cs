using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using WebUltraMedica.Controllers;

namespace WebUltraMedica.Models
{
    public partial class USER
    {
        public string[] RolesList()
        {
            return string.IsNullOrEmpty(this.ROLES) ? new string[0] : this.ROLES.Split(',');
        }

        public List<string> MasterRoles()
        {
            var objreturn = new List<string>();

            using(var data = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                var roles = from f in data.ROLEs select f;

                if(roles.Any())
                {
                    foreach (var role in roles)
                    {
                        objreturn.Add(role.ROLE_NAME);
                    }
                }
            }
            return objreturn;
        }
    }

    public class USER_VALIDATION
    {
        [Required(ErrorMessage = "NIK harus diisi.")]
        public string NIK { get; set; }
    }
}