using System.Linq;
using System.Web;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica.Controllers
{
    public static class Helper
    {
        public static USER SetSession(HttpCookie cookie)
        {
            string username = FormsAuthentication.Decrypt(cookie.Value).Name;
            string roles = string.Empty;

            using (var data = new db_ultramedicaDataContext())
            {
                var user = data.USERs.SingleOrDefault(u => u.USERNAME == username);

                if (user != null) return user;
            }
           
            return null;
        }
    }
}