# 🎮 GamePortal - WebGame Management System

> Clone của website GameBox89.com - Hệ thống quản lý webgame hoàn chỉnh

## 📋 Mô tả

GamePortal là hệ thống quản lý webgame được xây dựng dựa trên cấu trúc và nội dung từ GameBox89.com. Hệ thống hỗ trợ quản lý game, danh mục, banner, tip guides, reviews và bảng điều khiển admin.

## 🏗️ Kiến trúc

Hệ thống sử dụng **Clean Architecture** với .NET 8:
- **GamePortal.Core**: Domain models, interfaces, DTOs, services
- **GamePortal.Infrastructure**: Data access, repositories, mappings
- **GamePortal.Web**: Blazor Server UI, Controllers, Pages

```
┌─────────────────────┐
│   GamePortal.Web    │  ← Presentation Layer (Blazor Server)
├─────────────────────┤
│  GamePortal.Core    │  ← Business Logic & Entities
├─────────────────────┤
│ GamePortal.Infrastructure│  ← Data Access (EF Core)
└─────────────────────┘
```

## 🚀 Công nghệ

- **.NET 8** - Framework chính
- **Blazor Server** - Frontend UI
- **Entity Framework Core 9.0** - ORM
- **SQL Server** - Database
- **ASP.NET Identity** - Authentication & Authorization
- **AutoMapper** - Object mapping
- **Serilog** - Logging
- **Bootstrap 5** - UI Framework

## 📦 Cài đặt

### Yêu cầu
- .NET 8 SDK
- SQL Server (LocalDB hoặc SQL Server Express)
- Visual Studio 2022 hoặc VS Code

### Bước 1: Clone repository
```bash
git clone <repository-url>
cd WebGame
```

### Bước 2: Restore packages
```bash
dotnet restore
```

### Bước 3: Cấu hình Database
Thêm connection string vào `GamePortal.Web/appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=GamePortalDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

### Bước 4: Tạo Migrations
```bash
dotnet ef migrations add InitialCreate --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

### Bước 5: Update Database
```bash
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

### Bước 6: Run Application
```bash
cd GamePortal.Web
dotnet run
```

Truy cập: `https://localhost:5001` hoặc `http://localhost:5000`

## 📁 Cấu trúc thư mục

```
WebGame/
├── GamePortal.Core/                # Business Logic Layer
│   ├── Entities/                   # Domain Models
│   │   ├── BaseEntity.cs
│   │   ├── Category.cs
│   │   ├── Game.cs
│   │   └── ...
│   ├── DTOs/                       # Data Transfer Objects
│   │   ├── GameDTO.cs
│   │   └── CategoryDTO.cs
│   ├── Interfaces/                 # Repository & Service Contracts
│   │   ├── IRepository.cs
│   │   ├── IGameRepository.cs
│   │   └── ...
│   └── Services/                   # Business Services
│       └── IGameService.cs
│
├── GamePortal.Infrastructure/      # Data Access Layer
│   ├── Data/
│   │   └── ApplicationDbContext.cs
│   ├── Repositories/               # Repository Implementations
│   │   ├── Repository.cs
│   │   ├── GameRepository.cs
│   │   └── CategoryRepository.cs
│   ├── Services/                   # Service Implementations
│   │   └── GameService.cs
│   └── Mappings/                   # AutoMapper Profiles
│       └── MappingProfile.cs
│
├── GamePortal.Web/                 # Presentation Layer
│   ├── Pages/                      # Blazor Pages
│   ├── Shared/                     # Layout Components
│   ├── Areas/
│   │   └── Admin/                  # Admin Dashboard
│   └── wwwroot/                    # Static Files
│
└── GamePortal.sln                  # Solution File
```

## 🎯 Tính năng

### Frontend (Portal)
- ✅ Danh sách game theo danh mục
- ✅ Chi tiết game với gallery
- ✅ Tìm kiếm game
- ✅ Hiển thị game hot/featured
- ✅ Tip & Guides
- ✅ Reviews
- ✅ Banner quảng cáo

### Backend (Admin)
- ⏳ CRUD Game
- ⏳ CRUD Category
- ⏳ Quản lý Banner
- ⏳ Quản lý Tip Guides
- ⏳ Thống kê (views, plays)
- ⏳ Quản lý User & Roles

## 🗄️ Database Schema

### Entities
- **Category**: Danh mục game
- **Game**: Thông tin game
- **GameGallery**: Ảnh screenshots
- **GameReview**: Reviews từ người chơi
- **Banner**: Banner quảng cáo
- **TipGuide**: Hướng dẫn chơi game
- **ApplicationUser**: Người dùng hệ thống

## 🔧 Development Commands

```bash
# Build solution
dotnet build

# Run tests (nếu có)
dotnet test

# Create migration
dotnet ef migrations add MigrationName --project GamePortal.Infrastructure --startup-project GamePortal.Web

# Update database
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web

# Drop database (DANGEROUS!)
dotnet ef database drop --project GamePortal.Infrastructure --startup-project GamePortal.Web

# Remove migration
dotnet ef migrations remove --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

## 📊 Trạng thái project

Xem chi tiết trong `PROJECT_STATUS.json`

- ✅ 60% Complete
- ⏳ Đang phát triển: UI, Admin Dashboard, Seed Data

## 🤝 Contributing

Chưa có quy định contribution cụ thể. Mọi đóng góp đều được hoan nghênh!

## 📝 License

MIT License - Tự do sử dụng và phát triển

## 👤 Author

**GamePortal Team**
- Website: https://www.gamebox89.com
- Clone Project: GamePortal WebGame Management System

## 🙏 Acknowledgments

- Website gốc: GameBox89.com
- .NET Community
- Blazor & EF Core Documentation

---

**Built with ❤️ using .NET 8 & Blazor Server**

