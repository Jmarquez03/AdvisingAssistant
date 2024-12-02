using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisingAssistant.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Display(Name = "Student's Email")]
        [Required]
        public required string StudentEmail { get; set; }
        [Display(Name = "Course ID")]
        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }

        [Required]
        public string? Location { get; set; }

        [Required]
        public string? Time { get; set; }

        public string? FinalGrade { get; set; } // Nullable to handle in-progress courses
    }
}
