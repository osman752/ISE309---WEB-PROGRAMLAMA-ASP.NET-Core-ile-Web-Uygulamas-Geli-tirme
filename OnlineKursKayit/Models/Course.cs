using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineKursKayit.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required, StringLength(120)]
        public string Title { get; set; } = string.Empty;

        [StringLength(2000)]
        public string? Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int CategoryId { get; set; }
        public Category? Category { get; set; }

        [Required]
        public string InstructorId { get; set; } = string.Empty;
        public ApplicationUser? Instructor { get; set; }

        public ICollection<CourseModule> Modules { get; set; } = new List<CourseModule>();
        public ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
    }
}
