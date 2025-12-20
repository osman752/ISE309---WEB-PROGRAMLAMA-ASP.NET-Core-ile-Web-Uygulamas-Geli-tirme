using Microsoft.EntityFrameworkCore;
using OnlineKursKayit.Data;
using OnlineKursKayit.Models;

namespace OnlineKursKayit.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _db.Categories
                .OrderBy(x => x.Name)
                .ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task CreateAsync(string name)
        {
            name = (name ?? "").Trim();

            var exists = await _db.Categories.AnyAsync(x => x.Name == name);
            if (exists) return;

            _db.Categories.Add(new Category { Name = name });
            await _db.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id, string name)
        {
            name = (name ?? "").Trim();

            var cat = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (cat == null) return;

            cat.Name = name;
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var cat = await _db.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if (cat == null) return;

            _db.Categories.Remove(cat);
            await _db.SaveChangesAsync();
        }
    }
}
