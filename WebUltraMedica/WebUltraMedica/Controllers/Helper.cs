using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using WebUltraMedica.Models;
using System.Web.Configuration;

namespace WebUltraMedica.Controllers
{
    public static class Helper
    {
        public static USER SetSession(HttpCookie cookie)
        {
            string username = FormsAuthentication.Decrypt(cookie.Value).Name;
            string roles = string.Empty;

            using (var data = new db_ultramedicaDataContext(Helper.ConnectionString()))
            {
                var user = data.USERs.SingleOrDefault(u => u.USERNAME == username);

                if (user != null) return user;
            }
           
            return null;
        }

        public static string ConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["DB_ULTRAMEDICAConnectionString"].ConnectionString; ;
        }

        public static int MaxRequestLength() 
        {
            int maxrequestlength = 0;
            HttpRuntimeSection section = ConfigurationManager.GetSection("system.web/httpRuntime") as HttpRuntimeSection;
            if (section != null)
                maxrequestlength = section.MaxRequestLength;

            return maxrequestlength;
        }
    }

}