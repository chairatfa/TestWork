
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace TestWork.Models
{
    
     public class DBContext : DbContext
    {
        
        public DBContext()
        {
        }

        public DBContext(DbContextOptions<DBContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-1B3L9H0F\\SQLEXPRESS; database=TestWork;User Id=sa; Password=123456;Trusted_Connection=True;");

                
            }
        }       
       
       public  DbSet<Running> Running { get; set; }
       public  DbSet<Users> Users { get; set; }
    }
    
}