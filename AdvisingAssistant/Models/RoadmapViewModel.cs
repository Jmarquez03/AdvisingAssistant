using System.Collections.Generic;
namespace AdvisingAssistant.Models
{
    public class RoadmapViewModel
    {
        public string StudentEmail { get; set; }
        public List<Semester> Semesters { get; set; }
    }

    public class Semester
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }

}
