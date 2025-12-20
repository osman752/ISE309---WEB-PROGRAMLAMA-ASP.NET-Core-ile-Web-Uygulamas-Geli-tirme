using System.ComponentModel.DataAnnotations;

namespace OnlineKursKayit.Models
{
    public class CourseModule
    {
        public int Id { get; set; }

        public int CourseId { get; set; }
        public Course? Course { get; set; }

        [Required, StringLength(200)]
        public string Title { get; set; } = string.Empty;

        [Range(1, 9999)]
        public int OrderNo { get; set; }
    }
}
