using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LostnLocated.App_Code
{
    public class OtpSender
    {
       internal string GenerateRandomOtp()
        {
            string code = string.Empty;
            char ch;
            Random r = new Random();
            ch = (char)r.Next(51, 56);
            code = code + ch;
            ch = (char)r.Next(49, 54);
            code = code + ch;
            ch = (char)r.Next(50, 55);
            code = code + ch;
            ch = (char)r.Next(48, 53);
            code = code + ch;
            ch = (char)r.Next(55, 57);
            code = code + ch;
            ch = (char)r.Next(48, 55);
            code = code + ch;
            int n = r.Next(49, 52);
            if (n % 2 == 0)
            {
                if (n > 25)
                    ch = (char)r.Next(52, 57);
                else
                    ch = (char)r.Next(50, 57);
            }
            return code;
        }
    }
}