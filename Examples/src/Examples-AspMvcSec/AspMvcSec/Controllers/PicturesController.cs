using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspMvcSec.Controllers
{
    public class PicturesController : Controller
    {
        // GET: File
        public ActionResult Index(string fileName)
        {
            return File(System.IO.File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory+"\\App_Data\\Pictures\\"+fileName), "application");
        }
    }
}