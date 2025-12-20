using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace OnlineKursKayit.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Course> InstructorCourses { get; set; } = new List<Course>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
