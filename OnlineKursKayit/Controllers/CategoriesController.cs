using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineKursKayit.Models;
using OnlineKursKayit.Services;
using OnlineKursKayit.ViewModels;

namespace OnlineKursKayit.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _service;

        public CategoriesController(ICategoryService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var cats = await _service.GetAllAsync();
            return View(cats);
        }

        public IActionResult Create()
        {
            return View(new CategoryVM());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            await _service.CreateAsync(vm.Name);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var cat = await _service.GetByIdAsync(id);
            if (cat == null) return NotFound();

            return View(new CategoryVM { Id = cat.Id, Name = cat.Name });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryVM vm)
        {
            if (!ModelState.IsValid) return View(vm);

            await _service.UpdateAsync(vm.Id, vm.Name);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var cat = await _service.GetByIdAsync(id);
            if (cat == null) return NotFound();

            return View(cat);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
