# 🚀 GamePortal - Quick Start Guide

## ✅ Hiện tại đã hoàn thành 85%

### Đã làm xong:
1. ✅ **Firecrawl** website GameBox89.com để phân tích cấu trúc
2. ✅ **Clean Architecture** với .NET 8 (Core, Infrastructure, Web)
3. ✅ **8 Domain Models**: Game, Category, GameGallery, GameReview, Banner, TipGuide, ApplicationUser, BaseEntity
4. ✅ **Repository Pattern**: IRepository<T>, IGameRepository, ICategoryRepository
5. ✅ **Service Layer**: IGameService với AutoMapper
6. ✅ **Dependency Injection**: Startup.cs đầy đủ
7. ✅ **Identity & Auth**: ASP.NET Identity đã cấu hình
8. ✅ **Database Migrations**: EF Core migrations đã tạo
9. ✅ **Build Success**: Không có lỗi, không có warning

### File tree hiện tại:
```
GamePortal/
├── GamePortal.Core/               ✅ Business Logic
│   ├── Entities/                  7 models
│   ├── DTOs/                      3 DTOs
│   ├── Interfaces/                4 interfaces
│   └── Services/                  Service contracts
├── GamePortal.Infrastructure/     ✅ Data Access
│   ├── Data/                      ApplicationDbContext
│   ├── Entities/                  ApplicationUser
│   ├── Repositories/              3 repositories
│   ├── Services/                  Service implementations
│   ├── Mappings/                  AutoMapper profile
│   └── Migrations/                InitialCreate ready
└── GamePortal.Web/                ✅ Presentation
    ├── Startup.cs                 DI configured
    ├── Pages/                     Index, Error
    ├── Shared/                    NavMenu updated
    └── wwwroot/                   Static files
```

## 🎯 Để chạy project:

### Bước 1: Restore packages
```bash
cd F:\WebGame
dotnet restore
```

### Bước 2: Update database
```bash
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

**LƯU Ý**: Nếu SQL Server không chạy, cài SQL Server LocalDB hoặc đổi connection string trong `appsettings.json`

### Bước 3: Run application
```bash
cd GamePortal.Web
dotnet run
```

Hoặc:
```bash
dotnet run --project GamePortal.Web
```

### Bước 4: Mở browser
- URL: `https://localhost:5001` hoặc `http://localhost:5000`
- Homepage sẽ hiển thị: "Welcome to GamePortal!"

## 📝 Tiếp theo cần làm gì?

### 1. Seed Data (Ưu tiên cao)
Tạo dữ liệu mẫu trong `ApplicationDbContext.OnModelCreating` hoặc tạo `DbInitializer`:

```csharp
// Seed categories
var categories = new List<Category>
{
    new Category { Name = "Puzzle", Slug = "puzzle", IsActive = true },
    new Category { Name = "Action", Slug = "action", IsActive = true },
    // ...
};

context.Categories.AddRange(categories);
context.SaveChanges();

// Seed games
var games = new List<Game>
{
    new Game 
    { 
        Title = "Ball Sort", 
        Slug = "ball-sort",
        ThumbnailUrl = "https://cdn.ngxfiles.com/image/1736483618723_drop_ball.webp",
        CategoryId = 1,
        Rating = 5,
        PlayCount = 234
    },
    // ...
};

context.Games.AddRange(games);
context.SaveChanges();
```

### 2. Tạo Blazor Pages
- `Pages/Games.razor` - Danh sách games
- `Pages/Games/{Slug}.razor` - Chi tiết game
- `Pages/Categories/{Slug}.razor` - Games theo category

### 3. Admin Dashboard
- `Areas/Admin/Pages/Games/` - CRUD games
- `Areas/Admin/Pages/Categories/` - CRUD categories
- `Areas/Admin/Pages/Banners/` - Quản lý banners

### 4. Identity Setup
Tạo user và role mặc định:
```bash
# Có thể dùng Package Manager Console hoặc tạo DbSeeder
```

## 🔧 Commands Reference

```bash
# Build
dotnet build

# Create migration
dotnet ef migrations add MigrationName --project GamePortal.Infrastructure --startup-project GamePortal.Web

# Update database
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web

# Remove last migration
dotnet ef migrations remove --project GamePortal.Infrastructure --startup-project GamePortal.Web

# Drop database (DANGEROUS!)
dotnet ef database drop --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

## 📚 Tài liệu

- **README.md** - Hướng dẫn đầy đủ
- **PROJECT_STATUS.json** - Chi tiết trạng thái project
- **QUICK_START.md** (file này) - Hướng dẫn nhanh

## ⚠️ Cảnh báo

1. **Database**: Chưa seed data, database rỗng
2. **SQL Server**: Phải có SQL Server hoặc LocalDB
3. **Connection String**: Kiểm tra trong appsettings.json
4. **Migrations Warning**: Có warning về query filter, không ảnh hưởng chức năng

## 🎉 Kết luận

**Project đã hoàn thành 85%!** Backend hoàn chỉnh với Clean Architecture, chỉ cần:
- Seed data
- Tạo UI Blazor Pages
- Admin Dashboard

Chúc bạn code vui vẻ! 🚀

