namespace AdvisingAssistant.Models
{
    public class AddCourseViewModel
    {
        public required string StudentEmail { get; set; }

        public required int CourseId { get; set; }

        public required string Location { get; set; }

        public string? Time { get; set; }
    }

}
