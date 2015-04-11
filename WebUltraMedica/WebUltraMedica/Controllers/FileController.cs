using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using System.IO;

namespace WebUltraMedica.Controllers
{
    public class FileController : Controller
    {
        //
        // GET: /File/

        public ActionResult Download(string EMPLOYEE_ID, string YEAR_CHECKUP, string FILE_NAME)
        {
            string filePath = string.Format("{0}\\{1}_{2}\\{3}", ConfigurationManager.AppSettings["FileUpload"], EMPLOYEE_ID, YEAR_CHECKUP, FILE_NAME);

            var cd = new System.Net.Mime.ContentDisposition
            {
                // for example foo.bak
                FileName = FILE_NAME,

                // always prompt the user for downloading, set to true if you want 
                // the browser to try to show the file inline
                Inline = false,
            };

            Response.AppendHeader("Content-Disposition", cd.ToString());
            return File(filePath, Path.GetExtension(filePath));
        } 


    }
}
