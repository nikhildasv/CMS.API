using System.ComponentModel.DataAnnotations;

namespace CMS.API.DTOs
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        [Required]
        [MaxLength(30, ErrorMessage = "Student Name cannot exceed 20 characters")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string PhoneNumber { get; set; } 

        [Required]
        public string CourseName { get; set; }

        [Required]
        public int CourseId { get; set; }
    }

}
