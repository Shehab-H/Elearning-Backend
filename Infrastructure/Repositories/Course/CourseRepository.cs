using Core.Interfaces.Repositories.Course;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Course
{
    internal sealed class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _dbContext;
        public CourseRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<Core.Entities.Course.Course>> GetCoursesByCategoryID(Guid categoryId)
        {
            var courses = await _dbContext.Courses
                .Where(i=>i.CourseCategories
                .Any(c=>c.Id == categoryId)).ToListAsync();
            return courses;
        }
    }
}
