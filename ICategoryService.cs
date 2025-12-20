using OnlineKursKayit.Models;

namespace OnlineKursKayit.Services
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task CreateAsync(string name);
        Task UpdateAsync(int id, string name);
        Task DeleteAsync(int id);
    }
}
