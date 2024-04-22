using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Data
{
    public class StudentDbContext : DbContext
    {
        public StudentDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(
                new Student { Id = 1, Name = "Action", Age = 2 },
                new Student { Id = 2, Name = "Scifi", Age = 4 },
                new Student { Id = 3, Name = "History", Age = 5 },
                new Student { Id = 4, Name = "Migration", Age = 6 }
                );
            //base.OnModelCreating(modelBuilder);
        }
    }
}
