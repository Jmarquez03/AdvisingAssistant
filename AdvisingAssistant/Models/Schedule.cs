namespace AdvisingAssistant.Models
{
    using Microsoft.Identity;
    public class Schedule : Course
    {
        public Course previousClass { get; set; }
        public Course currentClass { get; set; }
        public Course futureClass1 { get; set; }
        public Course futureClass2 { get; set; }
        public Course futureClass3 { get; set; }
        public string studentName { get; set; }

        public Schedule() { }

    }
}
