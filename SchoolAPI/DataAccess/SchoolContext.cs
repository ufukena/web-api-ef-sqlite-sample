using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;

namespace SchoolAPI.DataAccess
{
    public class SchoolContext : DbContext
    {

        public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
        {

            Database.EnsureCreated();

        }
        public DbSet<Student> Students { get; set; }

    }
}
