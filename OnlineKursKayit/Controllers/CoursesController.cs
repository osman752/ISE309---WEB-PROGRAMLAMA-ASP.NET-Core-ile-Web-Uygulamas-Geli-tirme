using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineKursKayit.Services;
using OnlineKursKayit.ViewModels;

[Authorize(Roles = "Admin")]
public class CoursesController : Controller
{
    private readonly ICourseService _service;

    public CoursesController(ICourseService service)
    {
        _service = service;
    }

    public IActionResult Index()
    {
        var courses = _service.GetAll();
        return View(courses);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(CourseVM model)
    {
        if (!ModelState.IsValid)
            return View(model);

        _service.Add(model);
        return RedirectToAction(nameof(Index));
    }
}
