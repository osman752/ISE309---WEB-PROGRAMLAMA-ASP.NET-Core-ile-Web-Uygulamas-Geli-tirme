using System;

namespace OnlineKursKayit.Models
{
    public class Enrollment
    {
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public string StudentId { get; set; } = string.Empty;
        public ApplicationUser? Student { get; set; }

        public DateTime EnrolledAt { get; set; } = DateTime.UtcNow;
    }
}
