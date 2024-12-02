using System.Collections.Generic;
namespace AdvisingAssistant.Models
{
    public class DegreePlan
    {
        public int Id { get; set; }
        public string Major { get; set; }
        public ICollection<Course> Courses { get; set; }
    }

}
