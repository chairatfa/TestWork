using Microsoft.EntityFrameworkCore;
namespace TestWork.Models
{
    
     public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Running> Running { get; set; }
        DbSet<Users> Users { get; set; }
    }
    
}