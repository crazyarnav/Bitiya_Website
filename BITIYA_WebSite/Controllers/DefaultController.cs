using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BITIYA_WebSite.Controllers
{
    //This is the main controller for bitiya

    public class DefaultController : Controller
    {
        //
        // GET: /Default/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Bitiya_Paypal()
        {
            
            return View();
        }

    }
}
