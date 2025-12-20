using OnlineKursKayit.ViewModels;

namespace OnlineKursKayit.Services
{
    public interface ICourseService
    {
        List<CourseVM> GetAll();
        void Add(CourseVM model);
    }
}
