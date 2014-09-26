using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BITIYA_WebSite.Models;
using System.IO;

namespace BITIYA_WebSite.Controllers
{
    public class ProjectsController : Controller
    {
        //
        // GET: /Projects/

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Past()
        {
            return View();
        }

        public ActionResult ppes()
        {
            string ppesimagesPath = "Wowslider/Projects/PPES/data1/images";
            string ppesttPath = "Wowslider/Projects/PPES/data1/tooltips";
            List<WowSliderClass> wsclist = GetImages(ppesimagesPath, ppesttPath);
            return View(wsclist);
        }

        public ActionResult bvk()
        {
            string bvkimagesPath = "Wowslider/Projects/BVK/data1/images";
            string bvkttPath = "Wowslider/Projects/BVK/data1/tooltips";
            List<WowSliderClass> wsclist = GetImages(bvkimagesPath, bvkttPath);
            
            return View(wsclist);
        }

        public List<WowSliderClass> GetImages(string imagesPath, string ttPath)
        {
            

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

            return fc;
        }

    }
}
