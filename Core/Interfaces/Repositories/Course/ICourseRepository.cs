using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities.Course;
namespace Core.Interfaces.Repositories.Course
{
    public interface ICourseRepository : IRepository
    {
        Task<ICollection<Core.Entities.Course.Course>> GetCoursesByCategoryID(Guid categoryId);
    }
}
