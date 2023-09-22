using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Net;
using System.Net.Mail;

namespace LostnLocated.App_Code
{
    public class EmailSender
    {
        string MyEmailId, MyEmailPassCode;
        public EmailSender()
        {
            MyEmailId = "ashraframnagar@gmail.com";
            MyEmailPassCode = "vmxgqvhzjkvbvfie";
        }

        internal bool SendMyEmail(string SendTo, string Subject, string Message)
        {
            try
            {
                //Setting protocol
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.UseDefaultCredentials = false;
                NetworkCredential nc = new NetworkCredential(MyEmailId, MyEmailPassCode);
                smtp.Credentials = nc;
                smtp.EnableSsl = true;
                //Setting up message
                MailMessage msg = new MailMessage();
                MailAddress maFrom = new MailAddress(MyEmailId);
                MailAddress maTo = new MailAddress(SendTo);
                msg.Sender = maFrom;
                msg.To.Add(maTo);
                msg.Subject = Subject;
                msg.From = maFrom;
                Message = Message + "Thanks and Regards\n- Team Lost&Found";
                msg.Body = Message;
                smtp.Send(msg);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}


