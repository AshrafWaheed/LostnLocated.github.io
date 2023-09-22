using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Sql;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LostnLocated.App_Code;
using LostnLocated.Models;
namespace LostnLocated.Controllers
{
    [AuthorizeAdmin]
   
    public class AdminController : Controller
    {

        LostnFoundDBEntities db = new LostnFoundDBEntities();
        // GET: Admin
        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult UserManagement()
        {
            List<UserMaster> lstum = db.UserMasters.OrderByDescending(x=>x.RegDate).ToList();
            return View(lstum);
        }
      
        public ActionResult RemoveUser(string uid)
        {
            string s = string.Empty;
            try
            {
                UserMaster umdb = db.UserMasters.Find(uid);
                db.UserMasters.Remove(umdb);
                db.SaveChanges();
                s = "Removed SuccessFully";
            }
            catch
            {
                s = "SorryUnable to delete account";

            }
            TempData["msg"] = s;
            return RedirectToAction("UserManagement","Admin");
        }

        //----------------NOTIFICATION MANAGEMENT---------------------------//
        [NonAction]
        List<NotificationMaster> GetAllNotifications()
        {
            List<NotificationMaster> lst = db.NotificationMasters.OrderByDescending(x=>x.NotificationId).ToList();
            return lst;
        }

        [HttpGet]
        public ActionResult EventManagement()
        {
            List<NotificationMaster> lst = GetAllNotifications();
            return View(lst);
        }
        //SAVE NOTIFICAITON

        [HttpPost]
        public ActionResult EventManagement(NotificationMaster nm)
        {
            string msg = string.Empty;
            try
            {
                nm.NotificationDT = DateTime.Now;
                db.NotificationMasters.Add(nm);
                db.SaveChanges();
                msg = "Notification Saved";
            }
            catch
            {
                msg = "UNABLE TO SAVE NOTIFICATION";
            }
            ViewBag.Msg = msg;
            List<NotificationMaster> lst = GetAllNotifications();
            return View(lst);
        }

        //REMOVE NOTIFICATION
        public JsonResult RemoveNotif(int NotId)
        { 
            string msg= string.Empty;
            try { 
            NotificationMaster nmdb = db.NotificationMasters.Find(NotId);
                db.NotificationMasters.Remove(nmdb);
                db.SaveChanges();
                msg = "SUCCESS";
            }
            catch
            {
                msg = "FAIL";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
         //UPDATE NOTIFCATION
        public JsonResult UpdateNotif(int NotifId, string Message)
        {
            string msg = string.Empty;
            try
            {
                NotificationMaster nmdb = db.NotificationMasters.Find(NotifId);
                nmdb.NotificationText= Message;
                db.Entry(nmdb);
                db.SaveChanges();
                msg = "SUCCESS";
            }
            catch
            {
                msg = "FAIL";
            }
            return Json(msg, JsonRequestBehavior.AllowGet);
        }

        //-------------------ENQUIRY MANAGEMENT---------------/////////////
        [HttpGet]
        public ActionResult EnquiryManagement() 
        {
           List<EnquiryMaster> lst =  db.EnquiryMasters.OrderBy(x=>x.EnquiryId).ToList();
            return View(lst);
        }

        public ActionResult FeedbackManagement()
        {
            List<FeedbackMaster> lstfm = db.FeedbackMasters.OrderByDescending(x=>x.FeedbackId).ToList();
            return View(lstfm);
        }

        [HttpGet]
        public ActionResult ViewLF()
        {
            List<PostMaster> lstpm = db.PostMasters.OrderByDescending(x => x.LFId).ToList();
            return View(lstpm);
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
           
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string Pass, string NewPass, string ConfPass)
        {
            string msg = "";
            if (NewPass == ConfPass)
            {
                string uid = Session["AdminId"].ToString();
                Encryption e = new Encryption();
                Pass = e.EncryptMyPassword(Pass);
                NewPass = e.EncryptMyPassword(NewPass);
                LoginMaster lg = db.LoginMasters.SingleOrDefault(x => x.UserId == uid && x.Pass == Pass);
                if (lg != null)
                {
                    lg.Pass = NewPass;
                    db.Entry(lg);
                    db.SaveChanges();
                    msg = "Password Chaanged Successfully.";
                }
                else
                {
                    msg = "Old Password doesn't match";
                }
            }
            else
            {
                msg = "Password and confirm password is not same!!";
            }
            ViewBag.Message = msg;
          
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.Remove("AdminId");
            return View();
        }

        public ActionResult Developers()
        {

            return View();
        }
    }
}