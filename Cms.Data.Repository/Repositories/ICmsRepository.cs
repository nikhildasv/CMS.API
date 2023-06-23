using Cms.Data.Repository.Models;

namespace Cms.Data.Repository.Repositories
{
    public interface ICmsRepository
    {
        //collections
        IEnumerable<Course> GetAllCourses();
        Task<IEnumerable<Course>> GetAllCoursesAsync();

        //Individual
        Course AddCourse(Course newCourse);
        bool IsCourseExists(int courseId);
        Course GetCourse(int courseId);
        Course UpdateCourse(Course updatedCourse, int courseId);

        bool DeleteCourse(int courseId);

        //Students

        Task<IEnumerable<Student>> GetStudentsAsync(int courseId);

        Student AddStudent(Student newStudent);
    }
}
