using HelloWorld.Models;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Context
{
    public class PooContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        // Setting connection string
        protected override void OnConfiguring(DbContextOptionsBuilder options) =>
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=ucadb;Trusted_Connection=True;");

        // Model configuration for properties of objects
        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Student>()
                .Property(s => s.StudentId)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Course>()
                .Property(c => c.CourseId)
                .ValueGeneratedOnAdd();
        }
    }
}