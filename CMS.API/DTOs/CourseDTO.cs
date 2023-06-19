using Cms.Data.Repository.Models;

namespace CMS.API.DTOs
{
    public class CourseDTO
    {
        public int CourseId { get; set; }
        public string? CourseName { get; set; }
        public int CourseDuration { get; set; }
        public COURSE_TYPE CourseType { get; set; }
    }
    public enum COURSE_TYPE
    {
        None = 0,
        Engineering,
        Medical,
        Management
    }
}
