using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BITIYA_WebSite.Models;
using BITIYA_WebSite.DAO;
using System.Net.Mail;
using System.Configuration;
using System.Net.Configuration;
using System.Web.Configuration;
using System.Reflection;
using System.Text;

namespace BITIYA_WebSite.Controllers
{
    public class GetinvolvedController : Controller
    {
        //
        // GET: /Getinvolved/
        [HttpGet]
        public ActionResult Index()
        {
            ViewBag.ErrMsg = string.Empty;
            ViewBag.Msg = "Thank you for Visiting us! Please fill in the information below, We will definitely get back to you.";
            Person p = new Person();
            return View(p);
        }


        [HttpPost]
        public ActionResult Index(Person p)
        {
            ViewBag.ErrMsg = string.Empty;
            ViewBag.Msg = string.Empty;

            if (!ModelState.IsValid)
            {
                ViewBag.Msg = "Thank you for Visiting us! Please fill in the information below, We will definitely get back to you.";
                return View(p);
            }

            try
            {
                GetInvolvedDAO.Save(p);
            }
            catch(Exception e)
            {
                ViewBag.ErrMsg = "There is a connection problem, please resubmit.";
                return View(p);
            }

             //this will hold email of person
            string emailBody = getVolunteerInfo(p);
            try
            {
                sendGmail(emailBody);
            }
            catch (SmtpException e)
            {
                ViewBag.Msg = "Your information is saved, sorry the Email didnt go thru we will look into it! ";
            }
            ViewBag.Msg = ViewBag.Msg+"Thank you for showing interest in Bitiya, it means a lot to us. We will definitely get back to you!";
            return View(p);
        }

        protected void sendGmail(string body)
        {
            MailMessage myMail = new MailMessage();
            Configuration config = WebConfigurationManager.OpenWebConfiguration(System.Web.HttpContext.Current.Request.ApplicationPath);
            MailSettingsSectionGroup settings = config.GetSectionGroup("system.net").SectionGroups["mailSettings"] as MailSettingsSectionGroup;
            AppSettingsSection appSettings = config.GetSection("appSettings") as AppSettingsSection;
  
            MailAddress To = new MailAddress(appSettings.Settings["ToGetInvolved"].Value);
            MailAddress CC = new MailAddress(appSettings.Settings["CCGetInvolved"].Value);

            MailAddress From = new MailAddress(settings.Smtp.From);

            myMail.Subject = "Get Involved with Bitiya";
            myMail.IsBodyHtml = true;
            myMail.Body = body;
            myMail.From = From;
            myMail.To.Add(To);
            myMail.CC.Add(CC);

            SmtpClient client = new SmtpClient();
            client.DeliveryMethod = settings.Smtp.DeliveryMethod;
            client.Host = settings.Smtp.Network.Host; //"smtp.gmail.com";
            client.Credentials = new System.Net.NetworkCredential(settings.Smtp.Network.UserName, settings.Smtp.Network.Password);
            //client.EnableSsl = settings.Smtp.Network.EnableSsl;
            client.Port = settings.Smtp.Network.Port;

            try
            {
                client.Send(myMail);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            //The SMTP server requires a secure connection or the client was not authenticated. The server response was: 5.7.0 Must issue a STARTTLS command first. zx18sm2485769veb.3
        }//end gmail


        protected string getVolunteerInfo(Person p)
        {
            // create a string variable to generate message  
            StringBuilder messageTable = new StringBuilder();

            string[] cellValues = new string[3];

            Type myType = p.GetType();
            IList<PropertyInfo> props = new List<PropertyInfo>(myType.GetProperties());

            messageTable.Append("<h3>Get Involved Information</h3><br />");
            foreach (PropertyInfo prop in props)
            {
                object propValue = prop.GetValue(p, null);

                //prop.GetValue(p,null)
                string rowStr = string.Format("{0} : <span style=\" font-weight: bold;\">{1}</span><br />", prop.Name, prop.GetValue(p, null));
                // Do something with propValue
                messageTable.Append(rowStr);
            }

            return messageTable.ToString();
        }

    }
}
  