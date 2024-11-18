using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Model
{
    public class SchoolContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Course { get; set; }
        public DbSet<Enrollment> Enrollment { get; set; }

        public SchoolContext(DbContextOptions options) : base(options)
        {

            
        }
    }
}
