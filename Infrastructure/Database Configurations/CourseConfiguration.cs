using Core.Entities.Course;
using Core.Entities.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Database_Configurations
{
    public static class CourseConfiguration
    {
        public static EntityTypeBuilder<Course> ConfigureCourseEntity(this EntityTypeBuilder<Course> course)
        {
            course.HasMany(i => i.CourseEnrollments).WithOne();

            course.HasMany(i => i.CourseCategories).WithMany();

            return course;
        }

        public static EntityTypeBuilder<CourseCategory> ConfigureCourseCategoryEntity(this EntityTypeBuilder<CourseCategory> courseCategory)
        {
            courseCategory
                .HasOne(i => i.ParentCategory)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            return courseCategory;
        }

        public static EntityTypeBuilder<CourseEnrollments> ConfigureCourseEnrollmentEntity(this EntityTypeBuilder<CourseEnrollments> CourseEnrollments)
        {
            CourseEnrollments.HasOne(i=>i.EnrolledStudent).WithMany();

            return CourseEnrollments;
        }
    }
}
