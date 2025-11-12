# 🚀 Hướng dẫn Deploy GamePortal lên Railway (Miễn phí)

## 📋 Tổng quan

Railway là một platform cloud miễn phí cho phép deploy ứng dụng .NET Blazor Server mà không cần server riêng. Bạn sẽ nhận được:
- **$5 credit miễn phí mỗi tháng** (đủ cho một ứng dụng nhỏ)
- **Domain miễn phí** (ví dụ: `your-app.railway.app`)
- **Deploy tự động từ GitHub**
- **Database PostgreSQL miễn phí**

## 🎯 Các bước Deploy

### Bước 1: Chuẩn bị Database

Railway hỗ trợ PostgreSQL. Bạn cần:
1. Tạo PostgreSQL database trên Railway
2. Lấy connection string

### Bước 2: Cập nhật Connection String

Connection string sẽ được cung cấp dưới dạng environment variable.

### Bước 3: Deploy lên Railway

#### Cách 1: Deploy từ GitHub (Khuyến nghị)

1. **Đăng ký tài khoản Railway**
   - Truy cập: https://railway.app
   - Đăng nhập bằng GitHub account

2. **Tạo Project mới**
   - Click "New Project"
   - Chọn "Deploy from GitHub repo"
   - Chọn repository `hongquansp2811/game-portal`

3. **Cấu hình Environment Variables**
   - Vào tab "Variables"
   - Thêm các biến sau:
     ```
     ASPNETCORE_ENVIRONMENT=Production
     ConnectionStrings__DefaultConnection=<PostgreSQL connection string từ Railway>
     ```

4. **Thêm PostgreSQL Database**
   - Click "New" → "Database" → "Add PostgreSQL"
   - Railway sẽ tự động tạo database và connection string
   - Copy connection string và thêm vào Environment Variables

5. **Deploy**
   - Railway sẽ tự động build và deploy từ Dockerfile
   - Chờ vài phút để build xong
   - Click "Settings" → "Generate Domain" để lấy URL công khai

#### Cách 2: Deploy bằng Railway CLI

```bash
# Cài đặt Railway CLI
npm i -g @railway/cli

# Đăng nhập
railway login

# Link project
railway link

# Deploy
railway up
```

### Bước 4: Chạy Migration Database

Sau khi deploy, bạn cần chạy migration:

```bash
# SSH vào container Railway
railway run bash

# Chạy migration
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

Hoặc thêm vào startup command trong Railway:
```
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web && dotnet GamePortal.Web.dll
```

## 🔧 Cấu hình Production

### 1. Cập nhật Startup.cs để sử dụng PostgreSQL

Bạn cần cài thêm package:
```xml
<PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="8.0.0" />
```

Và cập nhật `Startup.cs`:
```csharp
services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(
        Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("GamePortal.Infrastructure")));
```

### 2. Environment Variables cần thiết

- `ASPNETCORE_ENVIRONMENT=Production`
- `ConnectionStrings__DefaultConnection=<PostgreSQL connection string>`
- `ASPNETCORE_URLS=http://0.0.0.0:8080` (Railway tự động set PORT)

## 🌐 Các Platform khác (Thay thế)

### Render.com (Miễn phí)

1. Đăng ký: https://render.com
2. Tạo "New Web Service"
3. Connect GitHub repo
4. Chọn:
   - **Environment**: Docker
   - **Dockerfile Path**: `Dockerfile`
   - **Build Command**: (để trống, Dockerfile sẽ tự build)
   - **Start Command**: (để trống)

5. Thêm PostgreSQL database:
   - "New" → "PostgreSQL"
   - Copy connection string

6. Environment Variables:
   ```
   ASPNETCORE_ENVIRONMENT=Production
   ConnectionStrings__DefaultConnection=<PostgreSQL connection string>
   ```

### Fly.io (Miễn phí)

1. Cài đặt Fly CLI: https://fly.io/docs/getting-started/installing-flyctl/
2. Đăng ký: `fly auth signup`
3. Tạo app: `fly launch`
4. Deploy: `fly deploy`

## 📝 Lưu ý quan trọng

1. **Database Migration**: Cần chạy migration sau khi deploy lần đầu
2. **Connection String**: Railway/Render sẽ cung cấp connection string tự động
3. **Static Files**: Đảm bảo `wwwroot` folder được copy khi build
4. **Port**: Railway/Render tự động set PORT environment variable
5. **HTTPS**: Railway/Render tự động cung cấp HTTPS

## 🐛 Troubleshooting

### Lỗi: Database connection failed
- Kiểm tra connection string trong Environment Variables
- Đảm bảo database đã được tạo trên Railway

### Lỗi: Migration failed
- Chạy migration thủ công qua Railway CLI hoặc SSH

### Lỗi: Build failed
- Kiểm tra Dockerfile
- Xem logs trong Railway dashboard

## 💰 Chi phí

- **Railway**: $5 credit/tháng miễn phí (đủ cho 1 app nhỏ)
- **Render**: Free tier với giới hạn (có thể sleep sau 15 phút không dùng)
- **Fly.io**: Free tier với giới hạn

## 🔗 Links hữu ích

- Railway Docs: https://docs.railway.app
- Render Docs: https://render.com/docs
- Fly.io Docs: https://fly.io/docs

