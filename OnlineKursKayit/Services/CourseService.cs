using OnlineKursKayit.Data;
using OnlineKursKayit.Models;
using OnlineKursKayit.ViewModels;

namespace OnlineKursKayit.Services
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _context;

        public CourseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<CourseVM> GetAll()
        {
            return _context.Courses
                .Select(c => new CourseVM
                {
                    Id = c.Id,
                    Title = c.Title,
                    Description = c.Description,
                    CategoryId = c.CategoryId
                }).ToList();
        }

        public void Add(CourseVM model)
        {
            var course = new Course
            {
                Title = model.Title,
                Description = model.Description,
                CategoryId = model.CategoryId
            };

            _context.Courses.Add(course);
            _context.SaveChanges();
        }
    }
}
