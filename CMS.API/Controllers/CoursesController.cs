using Cms.Data.Repository.Models;
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

        //use primitive/complex return type

        //[HttpGet()]
        //public IEnumerable<CourseDTO> GetCourses()
        //{

        //        var courses = _cmsRepository.GetAllCourses();
        //        var result = courses.AsQueryable().ProjectToType<CourseDTO>();
        //        return result;

        //}

        //Uses IActionResult as return type. then we have to wrap the return value in one of the ActionResultObject Type

        //[HttpGet]
        //public IActionResult GetCourses()
        //{
        //    try
        //    {
        //        var courses = _cmsRepository.GetAllCourses();
        //        var result = courses.AsQueryable().ProjectToType<CourseDTO>();
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }

        //}

        // Return ActionResult<T>, derrived  from actionresult or any type. this is the recommended
        //have to return type instead of interface eg, IEnumerable

        //[HttpGet]
        //public ActionResult<IEnumerable<CourseDTO>> GetCourses()
        //{
        //    try
        //    {
        //        var courses = _cmsRepository.GetAllCourses();
        //        var result = courses.AsQueryable().ProjectToType<CourseDTO>();
        //        return result.ToList();// convert  interface to its type and  return
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        //    }

        //}

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseDTO>>> GetCourses()
        {
            try
            {
                var courses = await _cmsRepository.GetAllCoursesAsync();
                var result = courses.AsQueryable().ProjectToType<CourseDTO>();
                return result.ToList();// convert  interface to its type and  return
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPost]
        public ActionResult<CourseDTO> AddCourse(CourseDTO course)
        {
            try
            {

                var newCourse = course.Adapt<Course>();
                newCourse = _cmsRepository?.AddCourse(newCourse);
                if (newCourse != null)
                {
                    return newCourse.Adapt<CourseDTO>();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Course not saved");
                }
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{courseId}")]
        public ActionResult<CourseDTO> GetCourse(int courseId)
        {
            try
            {
                if (!_cmsRepository.IsCourseExists(courseId))
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Course with course id {courseId} not found");
                }

                var course = _cmsRepository.GetCourse(courseId);
                if (course != null)
                {
                    return course.Adapt<CourseDTO>();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Course not returned");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

        }

        [HttpPut("{courseId}")]
        public ActionResult<CourseDTO> UpdateCourse(int courseId, CourseDTO course)
        {
            try
            {
                if (!_cmsRepository.IsCourseExists(courseId))
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Course with course id {courseId} not found");
                }
                var updatedCourse = course.Adapt<Course>();

                updatedCourse = _cmsRepository.UpdateCourse(updatedCourse, courseId);
                if (updatedCourse != null)
                {
                    return updatedCourse.Adapt<CourseDTO>();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Course not updated");
                }


            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{courseId}")]
        public ActionResult<string> DeleteCourse(int courseId)
        {
            try
            {
                if (!_cmsRepository.IsCourseExists(courseId))
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Course with course id {courseId} not found");
                }
                var result = _cmsRepository.DeleteCourse(courseId);

                return result ? Ok($"Course {courseId} Deleted") : BadRequest($"Course {courseId} not deleted");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet("{courseId}/students")]
        public async Task<ActionResult<IEnumerable<StudentDto>>> GetStudents(int courseId)
        {
            try
            {
                if (!_cmsRepository.IsCourseExists(courseId))
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Course with course id {courseId} not found");
                }

                var students = await _cmsRepository.GetStudentsAsync(courseId);
                if (students != null)
                {
                    var result = students.AsQueryable().ProjectToType<StudentDto>();
                    return result.ToList();
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Course not returned");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost("{courseid}/students")]
        public ActionResult<StudentDto> AddStudent(int courseId, StudentDto student)
        {
            try
            {
                if (!_cmsRepository.IsCourseExists(courseId))
                {
                    return StatusCode(StatusCodes.Status404NotFound, $"Course with course id {courseId} not found");
                }
                var newStudent = student.Adapt<Student>();
                var course = _cmsRepository.GetCourse(courseId);
                newStudent.Course = course;
                newStudent = _cmsRepository?.AddStudent(newStudent);
                if (newStudent != null)
                {
                    return StatusCode(StatusCodes.Status201Created, newStudent.Adapt<StudentDto>());
                }
                else
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Course not saved");
                }
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


    }
}
