using Cms.Data.Repository.Repositories;
using CMS.API.DTOs;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace CMS.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly ICmsRepository _cmsRepository;
        public CoursesController(ICmsRepository cmsRepository)
        {
            _cmsRepository = cmsRepository;
        }

        [HttpGet]
        public IEnumerable<CourseDTO> GetCourses()
        {
            var courses= _cmsRepository.GetAllCourses();
            var result = courses.AsQueryable().ProjectToType<CourseDTO>();
            return result;
        }
    }
}
