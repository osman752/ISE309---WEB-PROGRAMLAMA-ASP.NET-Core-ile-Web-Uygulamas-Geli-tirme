using System.ComponentModel.DataAnnotations;

namespace OnlineKursKayit.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Kategori adı zorunludur.")]
        [StringLength(80, ErrorMessage = "Kategori adı en fazla 80 karakter olabilir.")]
        public string Name { get; set; } = string.Empty;
    }
}
