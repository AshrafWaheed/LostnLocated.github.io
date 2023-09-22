using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LostnLocated.Models;
using LostnLocated.App_Code;
using System.IO;

namespace LostnLocated.Controllers
{
    [AuthorizeSession] //LOCKING CONTROLLER THROUGH ATHORIZE SESISON
    public class UserController : Controller
    {
        LostnFoundDBEntities db = new LostnFoundDBEntities();
        static string UserId = string.Empty;


        [NonAction]
        void ShowCurrentUserDetails()
        {
            UserId = Session["UserId"].ToString();
            UserMaster um = db.UserMasters.Find(UserId);
            ViewBag.UserName = um.Name;
            ViewBag.userid = um.EmailId;
            
        }
        // GET: User

        //---------------------------POST LOST & FOUND---------------------------------------------------
        [HttpGet]
        public ActionResult Index()
        {
            ShowCurrentUserDetails();
            return View();
        }
        [HttpPost]
        public ActionResult Index(PostMaster pm)
        {   
            string msg= string.Empty;
            HttpPostedFileBase myfile = Request.Files["GoodsPicName"];
            if (myfile != null)
            {
                if (myfile.ContentLength > 0)
                {
                    string filepath = Server.MapPath("/Content/LostFoundItems");
                    if(!Directory.Exists(filepath))
                        Directory.CreateDirectory(filepath);
                    pm.GoodsPicName=Path.GetRandomFileName()+myfile.FileName;
                    myfile.SaveAs(filepath + "/" + pm.GoodsPicName);
                    //Saving VAlues in DAtabase
                    pm.CurrentDate = DateTime.Now;
                    pm.UserId= UserId;
                    db.PostMasters.Add(pm);
                    db.SaveChanges();
                    msg = "Item Posted Successfully";
                }
                else
                    msg = "Please Choose File";
            }
            else
                msg = "Please Choose a file";

            ViewBag.msg = msg;
           
            ShowCurrentUserDetails();
            return View();
        }
        //---------------------------------DASHBOARD-----------------------
        [HttpGet]
        public ActionResult Dashboard()
        {
            ShowCurrentUserDetails();
            return View();
        }


        //-----------------------------SEAARCH ----------------------------------------

        [HttpGet]
        public ActionResult Search()
        {
            ShowCurrentUserDetails();
            List<PostMaster> lstpm = db.PostMasters.OrderByDescending(x => x.LFId).ToList();
            return View(lstpm);
           
         
        }
        [HttpPost]
        public ActionResult Search(string SearchValue)
        {
            List<PostMaster> lst = db.PostMasters.Where(x=>x.Description.Contains(SearchValue) || x.Pincode.ToString().Contains(SearchValue)).OrderByDescending(x=>x.CurrentDate).ToList();

            return View(lst);
        }

        [HttpGet]
        public ActionResult Reward()
        {
            List<PostMaster> lstpm = db.PostMasters.OrderByDescending(x => x.LFId).ToList();
             // Filter the list to unique UserIds
            List<string> uniqueUserIds = lstpm .Select(x => x.UserId).Distinct().ToList();
             ViewBag.UniqueUserIds = uniqueUserIds;  // Store unique UserIds in ViewBag

            ShowCurrentUserDetails();
           
           
            return View();
        }
        [HttpPost]
        public ActionResult Reward(RewardMaster rm)
        {
            List<PostMaster> lstpm = db.PostMasters.OrderByDescending(x => x.LFId).ToList();
            // Filter the list to unique UserIds
            List<string> uniqueUserIds = lstpm.Select(x => x.UserId).Distinct().ToList();
            ViewBag.UniqueUserIds = uniqueUserIds;  // Store unique UserIds in ViewBag

            //-----------REWARDMASTER SAVING--------------
            string msg = string.Empty;
            HttpPostedFileBase myfile = Request.Files["DDFilePic"];
            if (myfile != null)
            {
                if (myfile.ContentLength > 0)
                {
                    string filepath = Server.MapPath("/Content/DDInfo");
                    if (!Directory.Exists(filepath))
                        Directory.CreateDirectory(filepath);
                    rm.DDFilePic = Path.GetRandomFileName() + myfile.FileName;
                    myfile.SaveAs(filepath + "/" + rm.DDFilePic);
                    //Saving VAlues in DAtabase
                    db.RewardMasters.Add(rm);
                    db.SaveChanges();
                    msg = "Reward Sent Successfully";
                }
                else
                    msg = "Please Choose File";
            }
            else
                msg = "Please Choose a file";

            ViewBag.Rsg = msg;
            ShowCurrentUserDetails();
              return View();
        }

        [HttpGet]
        public ActionResult GetItemsByUserEmail(string email)
        {
            // Retrieve the EmailId corresponding to the selected email
            string emailId = db.UserMasters
                .Where(u => u.EmailId == email)
                .Select(u => u.EmailId)
                .FirstOrDefault();

            if (emailId != null)
            {
                // Fetch items posted by the user with the specified EmailId
                List<string> itemsPosted = db.PostMasters
                    .Where(p => p.UserId == emailId)
                    .Select(p => p.Description)
                    .ToList();

                // Create HTML options for the second dropdown
                var options = itemsPosted.Select(item => $"<option>{item}</option>");

                return Content(string.Join("", options), "text/html");
            }

            // Return an empty response if no user is found
            return Content("", "text/html");
        }



        public ActionResult MyUploads()
        {
            ShowCurrentUserDetails();
            List<PostMaster> lstpm = db.PostMasters.Where(x => x.UserId == UserId).OrderBy(x => x.LFId).ToList();
            return View(lstpm);

        }
        //-------------------------------MY PROFILE--------------------------------------------------------//
        [HttpGet]
        public ActionResult MyProfile()
        {
            ShowCurrentUserDetails();
            UserMaster um = db.UserMasters.Find(UserId);
            return View(um);
        }

        [HttpPost]
        public ActionResult MyProfile(UserMaster ub)
        {
            //Getting user original data
            UserMaster umd = db.UserMasters.Find(UserId);
            string msg = string.Empty;
            //To check for file updation
            try
            {
                umd.Name = ub.Name;
                umd.FatherName = ub.FatherName;
                umd.Gender = ub.Gender;
                umd.CurrAddress = ub.CurrAddress;
                umd.PerAddress = ub.PerAddress;
                umd.MobileNo = ub.MobileNo;
                umd.DOB = ub.DOB;
                db.Entry(umd);
                db.SaveChanges();
                msg = "Your profile updated successfully";
            }
            catch
            {
                msg = "Sorry! Unable to update profile";
            }
            ShowCurrentUserDetails();
            ViewBag.Message = msg;
            return View(ub);
        }

        [HttpGet]
        public ActionResult Feedback()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Feedback(FeedbackMaster fm)
        {
            string msg = "";
            try
            {
                fm.UserId = Session["userid"].ToString();
                fm.FeedDate = DateTime.Now;
                db.FeedbackMasters.Add(fm);
                db.SaveChanges();
                msg = "Feedback saved successfully";
            }
            catch
            {
                msg = "Sorry ! Unable to save your feedback";
            }
            ViewBag.Msg = msg;
            ShowCurrentUserDetails();
            return View();
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {
            ShowCurrentUserDetails();
            return View();
        }
        [HttpPost]
        public ActionResult ChangePassword(string Pass, string NewPass, string ConfPass)
        {
            string msg = "";
            if (NewPass == ConfPass)
            {
                string uid = Session["UserId"].ToString();
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
            ShowCurrentUserDetails();
            return View();
        }
    
        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            Session.Remove("UserId");
            return View();
        }

        public ActionResult Developers()
        {

            return View();
        }



    }
}