using System;
using System.Globalization;
using System.Collections.Generic;
namespace TestWork.lib
{
    public class Functions
    {
        // get Year formate yyyy en-US
        public string GetYear(DateTime _date){
            string result = "";
                string th = CultureInfo.CurrentCulture.Calendar.ToString();
                if (th == "System.Globalization.ThaiBuddhistCalendar")
                {
                    result = _date.ToString("yyyy", new CultureInfo("en-US"));
                }
                else
                {
                    result = _date.ToString("yyyy");

                }

            return result;
        }
        public string ConcatRunning(string year,string code   , string prefix , int Runno ){
            string result="";
            try{
                if(prefix=="HN"){
                result=prefix + year +code + ConcatRunNo(Runno);
                }else{
                    result="def"+ year +code + ConcatRunNo(Runno); 
                }
            }catch(Exception ex) {
                
                result="";
            }

            return result;
        }
         public string ConcatRunNo(int Runno ){
            string result="";
            try{
               if (Runno<= 9)
                {
                result = "0000" + Runno.ToString();
               }else if(Runno<= 99){
                result = "000" + Runno.ToString();
               }else if(Runno<= 999){
                result = "00" + Runno.ToString();
               }else if(Runno<= 9999){
                result = "0" + Runno.ToString();
               }else {
                result = Runno.ToString();
               }
            }catch(Exception ex) {
                
                result="";
            }

            return result;
        }
       public bool IsValidEmail(string email)
        {
            try {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch {
                return false;
            }
        }
    }
}