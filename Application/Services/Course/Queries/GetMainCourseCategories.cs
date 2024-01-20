using Core.DTO.Course;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Course.Queries
{
    public record GetMainCourseCategories() : IRequest<ICollection<CategoryDTO>>;
}
