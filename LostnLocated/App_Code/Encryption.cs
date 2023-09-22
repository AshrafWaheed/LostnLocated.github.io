using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LostnLocated.App_Code
{
    public class Encryption
    {
        public string EncryptMyPassword(string PlainText)
        {
            string CypherText=string.Empty;
            int ASCII;
            char  NewCH;


            foreach (char ch in PlainText)
            {
                ASCII = ch;
                if(ASCII>=65 && ASCII<=122)
                {
                    ASCII = 65 - ASCII + 90;

                }
                else if(ASCII>=97 && ASCII <= 122)
                {
                    ASCII = 65 - ASCII + 122;
                }
                else if(ASCII>=48 &&  ASCII<=57)
                {  
                    ASCII = ASCII + 1;
                }

                NewCH = (char)ASCII;
                CypherText = CypherText + NewCH;
            }
            return CypherText;
        }
    }
}