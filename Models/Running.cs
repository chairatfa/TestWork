using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWork.Models
{
    public class Running
    {
        #region 
        // Key Auto
        #endregion  
        [Key]        
        public int RunningId { get; set; } 
        
        #region 
        // Code สำหรับนำไปใช้ check เงื่อนไขในการ where 
        #endregion  
        [Column(TypeName = "varchar(20)")]       
        public string RunningCode { get; set; }

        #region 
        // คำอธิบาย code
        #endregion  
        [Column(TypeName = "varchar(50)")]       
        public string RunningDes { get; set; } 

        #region 
        // คำนำหน้า เลข Running
        #endregion 
        [Column(TypeName = "varchar(50)")]        
        public string RunningPrefix { get; set; } 
        
        #region 
        // ปีที่มีการ Genarate
        #endregion 
        [Column(TypeName = "varchar(5)")]        
        public string RunningYear { get; set; } 

        #region 
        // ลำดับก่อนหน้า
        #endregion 
        public int RunningPrevious { get; set; }

        #region 
        // ลำดับล่าสุด
        #endregion         
        public int RunningLast { get; set; }    

        #region 
        // ลำดับถัดไป
        #endregion 
        public int RunningNext { get; set; }

        #region 
        //  User Crate
        #endregion 
        [Column(TypeName = "varchar(50)")]
        public string CreateBy { get; set; }
       
        #region 
        // Date Create
        #endregion 
        public DateTime CreateDate { get; set; }

        #region 
        // User   Update
        #endregion 
        [Column(TypeName = "varchar(50)")]               
        public string UpdateBy { get; set; }
        
        #region 
        // Date Update
        #endregion        
        [Display( Description="Emp Last Name")]       
        public DateTime UpdateDate { get; set; }
    }
}