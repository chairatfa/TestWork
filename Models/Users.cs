
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestWork.Models
{
     [Table("Users")]
    public class Users
    {
        #region 
        //  รหัส User
        #endregion    
        [Key]
        [Column(TypeName = "varchar(20)")]
        public string UserCode { get; set; } 

        #region 
        //  ชื่อ
        #endregion
        [Column(TypeName = "varchar(50)")]
        public string FirstName { get; set; }

        #region 
        //  นามสกุล
        #endregion
        [Column(TypeName = "varchar(50)")]
        public string LastName { get; set; }

        #region 
        // ชื่อเต็ม
        #endregion
        [Column(TypeName = "varchar(100)")]
        public string Fullname { get; set; } 
        
        
        #region 
        // เบอร์โทร
        #endregion
        [Column(TypeName = "varchar(20)")]
        public string TelNumber { get; set; } 
      
        #region 
        // email
        #endregion
        [Column(TypeName = "varchar(50)")]
        public string Email { get; set; } 

        #region 
        //  สถานะ 1=ใช้งานอยู่ , 0=ไม่ใช้งาน
        #endregion
        [Column(TypeName = "char(2)")]  
        public string Status { get; set; } 
       
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