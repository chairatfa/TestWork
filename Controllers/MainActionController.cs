using System;
using System.Globalization;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TestWork.Models;
using System.IO;
using Newtonsoft.Json;
using TestWork.Responses;
using TestWork.lib;
namespace TestWork.Controllers
{

    
    public class MainActionController:Controller
    {
        #region Global lib Function
        Functions _fnc = new Functions();
        #endregion

        #region GetRunning Function   
        public string GetRunning(string _RunningYear,string _RunningCode ,string _des,string _prefix)
        {
            string result="";
            DBContext db_context = new DBContext();            
            var _p_runnig =  db_context.Running.Where(r=>r.RunningCode==_RunningCode.ToString()&&r.RunningYear==_RunningYear.ToString()).FirstOrDefault();
            
            var transaction = db_context.Database.BeginTransaction();
                    try{ 
                           if(_p_runnig==null)
                            {//insert
                                
                                        db_context.Running.Add(new Running{
                                            RunningCode=_RunningCode.ToString(),
                                            RunningDes=_des.ToString(),
                                            RunningPrefix=_prefix.ToString(),
                                            RunningYear=_RunningYear.ToString(),
                                            RunningPrevious=0,
                                            RunningLast=1,
                                            RunningNext=2,
                                            CreateBy="ADMIN",
                                            CreateDate=DateTime.Now,
                                            UpdateBy="ADMIN",
                                            UpdateDate=DateTime.Now     
                                        });
                            result=_fnc.ConcatRunning(_RunningYear.ToString(),_RunningCode.ToString(),_prefix.ToString(),1);    
                            }else{//update
                                        _p_runnig.RunningPrevious=_p_runnig.RunningLast;
                                        _p_runnig.RunningLast=_p_runnig.RunningNext;
                                        _p_runnig.RunningNext=_p_runnig.RunningNext+1;
                                        _p_runnig.UpdateBy="ADMIN";
                                        _p_runnig.UpdateDate=DateTime.Now; 
                            
                            result=_fnc.ConcatRunning(_RunningYear.ToString(),_RunningCode.ToString(),_prefix.ToString(),_p_runnig.RunningLast);           
                            }
                            db_context.SaveChanges();
                            transaction.Commit();
                            
                    }
                    catch (Exception ex){
                            result="";
                            transaction.Rollback();
                    }
         
                   
            return result;
        }
        #endregion

        #region Check validate of Input       
        public String CheckInput(Users _user)
        {
            string result ="";
            if (String.IsNullOrEmpty(_user.FirstName)){throw new CustomException("FirstName-"+"กรุณากรอกชื่อ");}
            if (String.IsNullOrEmpty(_user.LastName)){throw new CustomException("LastName-"+"กรุณากรอกนามสกุล");}
            if (String.IsNullOrEmpty(_user.TelNumber)){throw new CustomException("TelNumber-"+"กรุณากรอกเบอร์โทร");}
            if (String.IsNullOrEmpty(_user.Email)){ throw new CustomException("Email-"+"กรุณากรอกอีเมลล์");}else{if(_fnc.IsValidEmail(_user.Email.ToString())==false){throw new CustomException("Email-"+"รูปแบบอีเมลล์ไม่ถูกต้อง");}; };
            return result;
        }       
        #endregion


        #region Get data Set to View        
        [HttpPost]
        public JsonResult load_User(string usercode)
        {
            DBContext db_context = new DBContext();
          string output="";
            if(string.IsNullOrEmpty(usercode)){
                 var lst= db_context.Users.ToList();
                 var _response = lst.Cast<Users>().ToArray();
                 output= JsonConvert.SerializeObject(_response);
            } else{
                 var lst= db_context.Users.Where(u=>u.UserCode==usercode.ToString()).ToList();
                 var _response = lst.Cast<Users>().ToArray();
                 output= JsonConvert.SerializeObject(_response);
            }
           
           
           return Json(output);      

        }
        #endregion Get data Set to View


        #region ADD User from view        
        [HttpPost]
        public JsonResult Ins_User([FromBody] Users _user)
        {
            
            
            
            // Start get Year formate yyyy en-US          
            string _year= _fnc.GetYear(DateTime.Now);
            // Start get Year formate yyyy en-US          

            DBContext db_context = new DBContext();
            var transaction = db_context.Database.BeginTransaction();
            BaseResponse _response = new BaseResponse(); 
            try
            {
                // CheckInput
                CheckInput(_user);

                 db_context.Users.Add(
                    new Users {  
                                 UserCode =GetRunning(_year,"0001","RunningUser","HN").ToString(),
                                 FirstName=_user.FirstName,
                                 LastName=_user.LastName,
                                 Fullname=_user.FirstName+" "+_user.LastName,
                                 TelNumber=_user.TelNumber,
                                 Email=_user.Email,
                                 Status="1",
                                 CreateBy="ADMIN",
                                 CreateDate=DateTime.Now,
                                 UpdateBy="ADMIN",
                                 UpdateDate=DateTime.Now                               

                            }); 
               db_context.SaveChanges();    
                //commit
                transaction.Commit();
                _response.ResponseCode="1";
                _response.ResponseMessage="OK";

            } 
            catch (CustomException cex)
            {
                transaction.Rollback();
                _response.ResponseCode="0";
                _response.ResponseMessage=cex.Message.ToString();
            }catch(Exception ex ){
                 transaction.Rollback();
                _response.ResponseCode="0";
                _response.ResponseMessage=ex.Message.ToString();
            }

             string output = JsonConvert.SerializeObject(_response);
           return Json(output);           
        }
        #endregion Edit User from view

        #region Edit User from view       
        [HttpPost]
        public JsonResult Edit_User([FromBody] Users _user)
        {
            DBContext db_context = new DBContext();
            var transaction = db_context.Database.BeginTransaction();
            BaseResponse _response = new BaseResponse(); 
            try
            {
                // CheckInput
                CheckInput(_user);
                var _p_User =  db_context.Users.Where(r=>r.UserCode==_user.UserCode.ToString()).FirstOrDefault();
                                _p_User.FirstName =_user.FirstName;
                                _p_User.LastName=_user.LastName;
                                _p_User.Fullname=_user.FirstName+" "+_user.LastName;
                                _p_User.TelNumber=_user.TelNumber;
                                _p_User.Email=_user.Email;
                                _p_User.Status="1";                                  
                                _p_User.UpdateBy="ADMIN";
                                _p_User.UpdateDate=DateTime.Now; 

               
               db_context.SaveChanges();
    
                //commit
                transaction.Commit();
                _response.ResponseCode="1";
                _response.ResponseMessage="OK";

            } 
            catch (CustomException cex)
            {
                transaction.Rollback();
                _response.ResponseCode="0";
                _response.ResponseMessage=cex.Message.ToString();
            }catch(Exception ex ){
                 transaction.Rollback();
                _response.ResponseCode="0";
                _response.ResponseMessage=ex.Message.ToString();
            }

             string output = JsonConvert.SerializeObject(_response);
           return Json(output);           
        }
        #endregion Edit User from view


        #region Delete User from view       
        [HttpPost]
        public JsonResult Dlt_User([FromBody] Users _user)
        {
            DBContext db_context = new DBContext();
            var transaction = db_context.Database.BeginTransaction();
            BaseResponse _response = new BaseResponse(); 
            try
            {
              var orderLine = db_context.Users.SingleOrDefault(item=>item.UserCode == _user.UserCode.ToString());
              
               if(orderLine!=null)
                {
                    db_context.Users.Remove(orderLine);
                    db_context.SaveChanges();
                   
                    //commit
                    transaction.Commit();
                    _response.ResponseCode="1";
                    _response.ResponseMessage="OK";
                 }else{
                    throw new CustomException("ขออภัยขอมูลผิดพลาด ไม่พบรายการ");
                 }
            } 
            catch (CustomException cex)
            {
                transaction.Rollback();
                _response.ResponseCode="0";
                _response.ResponseMessage=cex.Message.ToString();
            }catch(Exception ex ){
                 transaction.Rollback();
                _response.ResponseCode="0";
                _response.ResponseMessage=ex.Message.ToString();
            }

             string output = JsonConvert.SerializeObject(_response);
           return Json(output);           
        }
         #endregion Delete User from view  

    }
    
}