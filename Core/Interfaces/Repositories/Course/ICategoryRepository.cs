using Core.DTO.Course;
using Core.Entities.Course;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories.Course
{
    public interface ICategoryRepository : IRepository
    {
        Task<ICollection<CategoryDTO>> GetMainCategories();
        Task<ICollection<CategoryDTO>> GetCategoryByParentId(Guid parentId);

    }
}
