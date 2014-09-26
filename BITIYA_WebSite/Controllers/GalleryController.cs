using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using System.Web.UI.HtmlControls;
using System.IO;
using System.Web.UI;
using BITIYA_WebSite.Models;

namespace BITIYA_WebSite.Controllers
{
    public class GalleryController : Controller
    {
        //
        // GET: /Gallery/

        public ActionResult Index()
        {
            string imagesPath = "Wowslider/Events/HolmdelWalkathon/data1/images";
            string ttPath = "Wowslider/Events/HolmdelWalkathon/data1/tooltips";

            string MappedPath = Server.MapPath("~/" + imagesPath);

            DirectoryInfo imagesDirectory = new DirectoryInfo(MappedPath);

            FileInfo[] imagesInfo = imagesDirectory.GetFiles();

            IEnumerable<string> imgFiles = imagesInfo.Select(f => f.Name);
            ViewBag.imagePath = "../../" + imagesPath + "/";
            ViewBag.ttPath = "../../" + ttPath + "/";

            List<WowSliderClass> fc = new List<WowSliderClass>();
            foreach (string str in imgFiles)
            {
                WowSliderClass f = new WowSliderClass();
                f.imageName = str;
                f.ttName = str.ToLower();
                fc.Add(f);
            }

            ViewBag.tts = imgFiles.ToString().ToLower();
            return View("Gallery",fc);
            //return View(fc);

        }
 
        
    }

    
}
