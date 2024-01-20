using Application.Services.Course.Queries;
using Core.DTO.Course;
using Core.Interfaces.Repositories.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Course
{
    public class CourseService 
        : IRequestHandler<GetMainCourseCategories, ICollection<CategoryDTO>>
    {
        private readonly ICategoryRepository _categoryRepository;
        public CourseService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


       public async Task<ICollection<CategoryDTO>> Handle(GetMainCourseCategories request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetMainCategories();
        }
    }
}
