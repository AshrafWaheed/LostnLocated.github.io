using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace LostnLocated.App_Code
{
    public class CaptchaManager
    {

        string GenerateRandomCode()
        {
            string code = string.Empty;
            char ch;
            Random r = new Random();
            ch = (char)r.Next(65, 90);
            code = code + ch;
            ch = (char)r.Next(70, 88);
            code = code + ch;
            ch = (char)r.Next(49, 57);
            code = code + ch;
            ch = (char)r.Next(100, 122);
            code = code + ch;
            ch = (char)r.Next(75, 90);
            code = code + ch;
            ch = (char)r.Next(97, 115);
            code = code + ch;
            int n = r.Next(1, 50);
            if (n % 2 == 0)
            {
                if (n > 25)
                    ch = (char)r.Next(70, 90);
                else
                    ch = (char)r.Next(50, 57);
            }
            return code;
        }

        internal string[] GetRandomCodeAndImage()
        {
            Bitmap bmp = new Bitmap(150, 40);
            SolidBrush greenBrush = new SolidBrush(Color.Green);
            Pen redPen = new Pen(Color.Red);
            Font f = new Font("Cursive", 22, FontStyle.Strikeout, GraphicsUnit.Pixel);
            Graphics g = Graphics.FromImage(bmp);
            g.Clear(Color.Gray);
            g.DrawRectangle(redPen, 1, 1, 146, 36);
            string code = GenerateRandomCode();
            g.DrawString(code, f, greenBrush, 15, 8);
            g.Flush();
            //SAVING IMAGE IN SERVER
            string fpath = HttpContext.Current.Server.MapPath("/Content/CaptchaImages");
            if (!Directory.Exists(fpath))
                Directory.CreateDirectory(fpath);
            string fName = Path.GetRandomFileName() + ".jpg";
            bmp.Save(fpath + "/" + fName, ImageFormat.Jpeg);
            //Arranging values to return
            string[] arr = new string[2];
            arr[0] = code;
            arr[1] = fName;
            return arr;
        }
        //set properties build action to compile

    }
}