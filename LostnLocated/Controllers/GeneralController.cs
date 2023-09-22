using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LostnLocated.App_Code;
using LostnLocated.Models;

namespace LostnLocated.Controllers
{
    public class GeneralController : Controller
    {
        static string[] codeAndImage = new string[2];
        LostnFoundDBEntities db= new LostnFoundDBEntities();

        [NonAction]
        void LoadNotification()
        {
            List<NotificationMaster> lstnm = db.NotificationMasters.OrderByDescending(x=>x.NotificationId).Take(5).ToList();
            ViewBag.Notification = lstnm;
        }
        // GET: General
        [HttpGet]
        public ActionResult Index()
        {
            LoadNotification();
            List<PostMaster> lst = db.PostMasters.OrderByDescending(x=>x.CurrentDate).ToList();
            return View(lst);
      
        }
        [HttpPost]
        public ActionResult Index(string s)
        {
            LoadNotification();
            List<PostMaster> lst = db.PostMasters.OrderByDescending(x => x.CurrentDate).ToList();
            return View(lst);

        }
        public ActionResult AboutUs()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
        // -------------- LOGIN PAGE METhODS-----------------------------------------------//
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginMaster lm)
        {
            Encryption ec= new Encryption();
            lm.Pass = ec.EncryptMyPassword(lm.Pass);
            LoginMaster lgdb = db.LoginMasters.SingleOrDefault(x => x.UserId == lm.UserId && x.Pass == lm.Pass && x.UserType == lm.UserType);
            if (lgdb != null)
            {
                //SESSION
                if (lm.UserType == "USER")
                {
                    Session["UserId"] = lm.UserId;
                    // REDIRECT TO USER ZONE 
                    return RedirectToAction("Dashboard", "User");
                }
                else
                {
                    Session["AdminId"] = lm.UserId;
                    return RedirectToAction("Dashboard", "Admin");
                }
            }
            else
            {
                ViewBag.Res = "INVALID USER ID OR PASSWORD";
            }
            return View();
        }

        // --------------------------REGISTER POST AND GET-----------------------------------------
        [HttpGet]
        public ActionResult Register()
        {
            ShowNewCaptcha();
            return View();
        }

        [HttpPost]
        public ActionResult Register(UserMaster um, string TxtCaptcha)
        {
            string msg = string.Empty;
            if (TxtCaptcha == codeAndImage[0])
            {
                string pass, cpass;
                pass = Request["Pass"];
                cpass = Request["ConfPass"];
                if(pass == cpass)
                {
                    //---------------------SAVING DATA IN REGISTER-------------------
                    try
                    {
                        um.RegDate = DateTime.Now;
                        db.UserMasters.Add(um);
                       
                        //-------------------sAVEING IN LOGIN MASTER
                        LoginMaster lm = new LoginMaster();
                        Encryption ec = new Encryption();
                       lm.Pass = ec.EncryptMyPassword(pass);
                        lm.UserType = "USER";
                        lm.UserId = um.EmailId;
                        db.LoginMasters.Add(lm);
                        db.SaveChanges();
                        msg = " CONGRATULATIONS ! REGISTERED SUCCESSFULLY";
                        //------------------SENDING MAIL----------------------
                        EmailSender es = new EmailSender();
                        string emsg = "Hello, " + um.Name + ",\n\nThanks for Signing up on LOST&Found. Your account has been created successfully";
                        es.SendMyEmail(um.EmailId, "Welcome to Lost&Found", emsg);

                    }
                    catch
                    {
                        msg = "Unable to register";
                    }
                }
                else
                {
                    msg = "Password and Confirm Password Must be Same.";
                }
            }
            else
            {
                msg = "Invalid Captcha Code.";
            }

            ViewBag.msg= msg;
            ShowNewCaptcha();
            return View();
        }
        public ActionResult FandQ()
        {
            return View();
        }
        public ActionResult PrivacyPolicy()
        {
            return View();
        }
        public ActionResult Terms()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SaveEnquiry(EnquiryMaster em)
        {

            string msg = string.Empty;
            try
            {
                em.EnquityDT = DateTime.Now;
                db.EnquiryMasters.Add(em);
                db.SaveChanges();
                msg = "Thank You for Enquiring We will get back to you soon";
            }
            catch
            {
                msg = "Some error occured";
            }
            TempData["EnqMsg"]= msg;
            return RedirectToAction("Index");
        }

      //------------------------------UDF FOR CAPTCHA------------------------------------------
        [NonAction]
        void ShowNewCaptcha()
        {
            CaptchaManager cp = new CaptchaManager();
            codeAndImage = cp.GetRandomCodeAndImage();
            ViewBag.img = codeAndImage[1];
        }

        //-----------------------------------AJAX REFRESHING FOR CAPTCHA-------------------------------
        public JsonResult GetCaptcha()
        {
            ShowNewCaptcha();
            return Json(codeAndImage[1], JsonRequestBehavior.AllowGet);
        }

        public ActionResult Developers()
        {

            return View();
        }
        [HttpGet]
        public ActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ForgotPassword(string Email)
        {string msg = string.Empty;
            UserMaster um = db.UserMasters.SingleOrDefault(x=>x.EmailId==Email);
            if ( um != null)
            {
                OtpSender os = new OtpSender();
                string otp = os.GenerateRandomOtp();
                EmailSender es = new EmailSender();
                string emsg = "Hello, " + um.Name + ",\n\nThe OTP for resetting your password is: " + otp;
                es.SendMyEmail(um.EmailId, "OTP for Reset", emsg);
            }
            else
            {
                msg = "Email Not Registered";
            }
            return View();
        }

        /* 
         [NonAction]

         internal void AddState()
         {
             string[] arr = new string[] { };
             List<SelectListItem> list = new List<SelectListItem>();
             foreach (string s in arr)
             {
                 SelectListItem sli = new SelectListItem();
                 sli.Text = s;
                 list.Add(sli);
             }
             ViewBag.States = list;
         }




         @Html.DropDownList("CatID",null,"Select Category",new{ @class="form-control"}
        */

    }
}