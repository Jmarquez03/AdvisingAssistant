namespace AdvisingAssistant.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        public string CourseNumber { get; set; }
        public string Prerequisite1 { get; set; }
        public string Prerequisite2 { get; set; }

        public Course() 
        { 
        
        } 
    }
}

