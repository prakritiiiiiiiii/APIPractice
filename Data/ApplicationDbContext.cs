using Microsoft.EntityFrameworkCore;
using StudentWebApi.Model;

namespace StudentWebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        DbSet<Student> Students { get; set; }   
    }
}
