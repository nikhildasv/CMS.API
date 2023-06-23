using Cms.Data.Repository.Models;
using System.ComponentModel.DataAnnotations;

namespace CMS.API.DTOs
{
    public record CourseDTO
    {
        
        public int CourseIdentifier { get; init; }

        [Required(ErrorMessage ="Course name is required")]
        [MinLength(5,ErrorMessage ="Course Name must be minimum 5 characters")]
        [MaxLength(20, ErrorMessage = "Course Name cannot exceed 20 characters")]
        public string? CourseName { get; init; }

        [Required(ErrorMessage = "Course Duration is required")]
        [Range(1,6, ErrorMessage ="Invalid course duration")]
        public int Duration { get; init; }

        [Required(ErrorMessage = "Course type is required")]
        public string? CourseType { get; init; }
    }
    
}
