using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisingAssistant.Models
{
    public class Schedule
    {
        public int Id { get; set; }
        [Required]
        public required string StudentEmail { get; set; }

        [Required]
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public required Course Course { get; set; }

        [Required]
        public required string Location { get; set; }

        [Required]
        public required string Time { get; set; }
    }
}
