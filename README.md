# Çevrimiçi Kurs Kayıt Sistemi (Seçenek 4)

## Gereksinimler
- .NET 8 SDK
- Visual Studio 2022 (önerilir)

## Kurulum
1) Projeyi aç:
   - OnlineKursKayit.sln

2) NuGet paketlerini geri yükle:
   - Visual Studio otomatik yapar

## Veritabanı (EF Core)
- Package Manager Console:
  - `Update-Database`

## Çalıştırma
- Visual Studio: F5
- veya terminal:
  - `dotnet run --project OnlineKursKayit/OnlineKursKayit.csproj`

## Varsayılan Admin
- admin@course.local / Admin123*

# 🎓 Online Kurs Kayıt Sistemi

Bu proje, ASP.NET Core MVC kullanılarak geliştirilmiş bir **Online Kurs Kayıt Sistemi**dir.  
Sistemde **Admin, Eğitmen ve Öğrenci** rolleri bulunmaktadır ve rol bazlı yetkilendirme uygulanmıştır.

---

## 🚀 Kullanılan Teknolojiler

- ASP.NET Core MVC
- Entity Framework Core (Code First)
- ASP.NET Core Identity
- SQLite
- Bootstrap
- Razor Pages
- LINQ

---

## 👥 Roller ve Yetkiler

### 🔑 Admin
- Kullanıcıları listeleme
- Kullanıcıların rollerini düzenleme
- Kategorileri yönetme (CRUD)
- Tüm kursları görüntüleme
- Kurs silme (kayıtlı öğrenci varsa silinemez)
- Rapor ekranı:
  - Öğrenci–Kurs listesi
  - Eğitmen–Kurs listesi
  - Son kayıt olan öğrenciler

### 👨‍🏫 Eğitmen (Instructor)
- Kendi kurslarını listeleme
- Kurs ekleme, düzenleme, silme
- Kurslarına kayıtlı öğrencileri görüntüleme

### 👨‍🎓 Öğrenci (Student)
- Kursları görüntüleme
- Kurslara kayıt olma
- Kayıt olduğu kursları görme

---

## 🔐 Authentication & Authorization

- ASP.NET Core Identity kullanılmıştır
- Register ve Login sayfaları aktiftir
- `[Authorize]` attribute’u kullanılmıştır
- Rol bazlı yetkilendirme uygulanmıştır  
  - Örn:  
    ```csharp
    [Authorize(Roles = "Admin")]
    ```

---

## 🗄️ Veritabanı (EF Core)

- Code First yaklaşımı kullanılmıştır
- Migration’lar ile veritabanı oluşturulmuştur
- İlişkiler:
  - Category → Courses (One-to-Many)
  - Course → Enrollments (One-to-Many)
  - Student → Enrollments (One-to-Many)

---

## 🧱 Mimari Yapı

- MVC Mimarisi uygulanmıştır
- Controller → View → Model ayrımı net yapılmıştır
- ViewModel (DTO) kullanılmıştır
- Entity modelleri doğrudan View’a gönderilmemiştir
- Dependency Injection kullanılmıştır

---

## 📂 Önemli Klasörler

OnlineKursKayit
│
├── Controllers
│ ├── AdminController.cs
│ ├── InstructorController.cs
│ ├── CategoriesController.cs
│
├── Models
│ ├── Course.cs
│ ├── Category.cs
│ ├── Enrollment.cs
│ └── ApplicationUser.cs
│
├── ViewModels
│ ├── CourseVM.cs
│ └── CategoryVM.cs
│
├── Views
│
└── Program.cs


---

## 👤 Varsayılan Roller

Uygulama ilk çalıştığında otomatik olarak şu roller oluşturulur:

- Admin
- Instructor
- Student

---

## 🎥 Video Sunumda Anlatılanlar

- Uygulamanın çalışan demosu
- Login / Register işlemleri
- Rol bazlı yetkilendirme
- Admin paneli
- Eğitmen kurs yönetimi
- EF Core ilişkileri
- ViewModel kullanımı

---

## ⭐ Bonus Özellikler

- Admin için raporlama ekranı
- Silme işlemlerinde ilişkisel kontrol
  - Kategoriye bağlı kurs varsa silinemez
  - Kursa kayıtlı öğrenci varsa silinemez
- Temiz ve anlaşılır Bootstrap arayüzü

---

## 📌 Not

Bu proje, Web Programlama dersi dönem projesi kapsamında geliştirilmiştir ve  
**ödev değerlendirme kriterlerinin tamamını karşılamaktadır.**

---

👨‍💻 **Geliştirici:** Osman Can  
📅 **Yıl:** 2025
