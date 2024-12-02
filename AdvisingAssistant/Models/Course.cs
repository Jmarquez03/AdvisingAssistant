using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AdvisingAssistant.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Display(Name = "Course Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        public string Subject { get; set; }
        [Display(Name = "Course Number")]
        public string CourseNumber { get; set; }
        [Display(Name = "Prerequisite 1")]
        public string Prerequisite1 { get; set; }
        [Display(Name = "Prerequisite 2")]
        public string Prerequisite2 { get; set; }
        [ForeignKey("DegreePlanId")]
        public DegreePlan? DegreePlan { get; set; }
        public Course() 
        { 
        
        } 
    }
}

