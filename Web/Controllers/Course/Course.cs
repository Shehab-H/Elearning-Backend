using Application.Services.Course.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers.Course
{
    [ApiController]
    [Route("api/[controller]")]
    public class Course : Controller
    {
        private readonly IMediator _mediator;
        public Course(IMediator mediator)
        {
            _mediator  = mediator;
        }

        [Route("[action]")]
        [HttpGet]
        public async Task<IActionResult> GetMainCategories()
        {
            var categories = await _mediator.Send(new GetMainCourseCategories());
            return Ok(categories);
        }
    }
}
