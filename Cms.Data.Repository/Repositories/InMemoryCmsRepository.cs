using Cms.Data.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cms.Data.Repository.Repositories
{
    public class InMemoryCmsRepository : ICmsRepository
    {
        readonly List<Course> courses;
        public InMemoryCmsRepository()
        {
            courses = new List<Course>
            {
                new Course()
                {
                    CourseId=1,
                    CourseName= "Computer Science",
                    CourseDuration = 4,
                    CourseType = COURSE_TYPE.Engineering
                },
                new Course()
                {
                     CourseId=2,
                    CourseName= "Information Technology",
                    CourseDuration = 4,
                    CourseType = COURSE_TYPE.Engineering
                }
            };

        }
        public IEnumerable<Course> GetAllCourses()
        {
            return courses;
        }
    }
}
