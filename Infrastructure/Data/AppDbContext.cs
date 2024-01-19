using Core.Entities.Course;
using Core.Entities.User;
using Infrastructure.Database_Configurations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace Infrastructure.Data
{
    public class AppDbContext : IdentityDbContext<ElearningUser>
    {
        public DbSet<CourseCategory> Categories { get; set; }
        public DbSet<CourseEnrollments> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CourseCategory>().ConfigureCourseCategoryEntity();

            builder.Entity<Course>().ConfigureCourseEntity();

            builder.Entity<CourseEnrollments>().ConfigureCourseEnrollmentEntity();

            base.OnModelCreating(builder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
