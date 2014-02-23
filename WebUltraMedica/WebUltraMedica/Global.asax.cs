using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using WebUltraMedica.Models;

namespace WebUltraMedica
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Account", action = "LogOn", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);
        }

        protected void FormsAuthentication_OnAuthenticate(Object sender, FormsAuthenticationEventArgs e)
        {
            if (FormsAuthentication.CookiesSupported == true)
            {
                if (Request.Cookies[FormsAuthentication.FormsCookieName] != null)
                {
                    try
                    {
                        //let us take out the username now                
                        var httpCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
                        if (httpCookie != null)
                        {
                            string username =
                                FormsAuthentication.Decrypt(httpCookie.Value).Name;
                            string roles = string.Empty;

                            using (var data = new db_ultramedicaDataContext())
                            {
                                var user = data.USERs.SingleOrDefault(u => u.USERNAME == username);

                                if (user != null) roles = user.ROLES;
                            }
                            //let us extract the roles from our own custom cookie

                            //Let us set the Pricipal with our user specific details
                            e.User = new System.Security.Principal.GenericPrincipal(
                                new System.Security.Principal.GenericIdentity(username, "Forms"), roles.Split(','));
                        }
                    }
                    catch (Exception)
                    {
                        //somehting went wrong
                    }
                }
            }
        }
    }
}