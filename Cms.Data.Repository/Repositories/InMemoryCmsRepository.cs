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
        readonly List<Student> students;
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
            students = new List<Student>
            {
                new Student()
                {
                    StudentId= 101,
                    FirstName ="abc",
                    LastName = "xyz",
                    PhoneNumber ="346436",
                    Course = courses.Where(x => x.CourseId == 1).SingleOrDefault()

                },
                 new Student()
                {
                      StudentId= 102,
                    FirstName ="qwer",
                    LastName = "dsx",
                    PhoneNumber ="6469",
                    Course = courses.Where(x => x.CourseId == 1).SingleOrDefault()
                },
                  new Student()
                {
                     StudentId=103,
                    FirstName ="hyhf",
                    LastName = "plj",
                    PhoneNumber ="8568",
                    Course = courses.Where(x => x.CourseId == 2).SingleOrDefault()
                }
            };

        }

        public Course AddCourse(Course newCourse)
        {
            var maxCourseId = courses.Max(c => c.CourseId);
            newCourse.CourseId = maxCourseId + 1;
            courses.Add(newCourse);
            return newCourse;
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return courses;
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync()
        {
            return await Task.Run(() => courses);
        }
        public bool IsCourseExists(int courseId)
        {
            return courses.Any(c => c.CourseId == courseId);
        }

        public Course GetCourse(int courseId)
        {
            return courses.SingleOrDefault(x => x.CourseId == courseId);
        }

        public Course UpdateCourse(Course updatedCourse, int courseId)
        {
            var course = courses.SingleOrDefault(c => c.CourseId == courseId);
            if (course != null)
            {
                course.CourseDuration = updatedCourse.CourseDuration;
                course.CourseName = updatedCourse.CourseName;
                course.CourseType = updatedCourse.CourseType;

            }

            return course;
        }

        public bool DeleteCourse(int courseId)
        {
            var courseToDelete = courses.SingleOrDefault(_ => _.CourseId == courseId);
            if (courseToDelete != null)
            {
                return courses.Remove(courseToDelete);
            }
            else
            {
                return false;
            }
        }

        public async Task<IEnumerable<Student>> GetStudentsAsync(int courseId)
        {
            return await Task.Run(() => {
                return students.Where(s => s.Course.CourseId == courseId);
                });
        }
        public Student AddStudent(Student newStudent)
        {
            var maxStudentId = students.Max(c => c.StudentId);
            newStudent.StudentId = maxStudentId + 1;
            students.Add(newStudent);
            return newStudent;
        }
    }
}
