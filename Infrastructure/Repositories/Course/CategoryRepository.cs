using Core.DTO.Course;
using Core.Entities.Course;
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
    internal sealed class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;
        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ICollection<CategoryDTO>> GetCategoryByParentId(Guid parentId)
        {
            return await _dbContext.Categories
                .Where(i => i.ParentCategory.Id == parentId)
                .AsNoTracking()
                .Select(i=> new CategoryDTO(i.Id,i.Name))
                .ToListAsync();
        }

        public async Task<ICollection<CategoryDTO>> GetMainCategories()
        {
            return await _dbContext.Categories
                 .Where(i => i.ParentCategory==null)
                 .AsNoTracking()
                 .Select(i => new CategoryDTO(i.Id, i.Name)).ToListAsync() ;
        }
    }
}
