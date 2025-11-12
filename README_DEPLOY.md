# 🚀 Quick Deploy Guide - GamePortal

## Deploy lên Railway (Khuyến nghị - Dễ nhất)

### Bước 1: Đăng ký Railway
1. Truy cập: https://railway.app
2. Đăng nhập bằng GitHub
3. Click "New Project" → "Deploy from GitHub repo"
4. Chọn repository: `hongquansp2811/game-portal`

### Bước 2: Thêm PostgreSQL Database
1. Trong project, click "New" → "Database" → "Add PostgreSQL"
2. Railway sẽ tự động tạo database
3. Copy connection string từ tab "Variables"

### Bước 3: Cấu hình Environment Variables
Vào tab "Variables" và thêm:
```
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__DefaultConnection=<PostgreSQL connection string từ Railway>
```

### Bước 4: Deploy
1. Railway sẽ tự động build từ Dockerfile
2. Chờ 3-5 phút để build xong
3. Vào "Settings" → "Generate Domain" để lấy URL

### Bước 5: Chạy Migration
Sau khi deploy, SSH vào container:
```bash
railway run bash
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

Hoặc thêm vào startup command trong Railway Settings:
```
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web && dotnet GamePortal.Web.dll
```

---

## Deploy lên Render.com (Thay thế)

### Bước 1: Đăng ký Render
1. Truy cập: https://render.com
2. Đăng nhập bằng GitHub

### Bước 2: Tạo Web Service
1. "New" → "Web Service"
2. Connect GitHub repo: `hongquansp2811/game-portal`
3. Cấu hình:
   - **Name**: `gameportal`
   - **Environment**: `Docker`
   - **Dockerfile Path**: `Dockerfile`
   - **Build Command**: (để trống)
   - **Start Command**: (để trống)

### Bước 3: Thêm PostgreSQL
1. "New" → "PostgreSQL"
2. Chọn "Free" plan
3. Copy connection string

### Bước 4: Environment Variables
Thêm trong Web Service settings:
```
ASPNETCORE_ENVIRONMENT=Production
ConnectionStrings__DefaultConnection=<PostgreSQL connection string>
```

### Bước 5: Deploy
Click "Create Web Service" và chờ deploy xong.

---

## ⚠️ Lưu ý quan trọng

1. **Database Migration**: Phải chạy migration sau khi deploy lần đầu
2. **Connection String**: Platform sẽ tự động cung cấp
3. **HTTPS**: Tự động được cung cấp
4. **Free Tier**: 
   - Railway: $5 credit/tháng
   - Render: Free nhưng có thể sleep sau 15 phút không dùng

---

## 🔗 Xem hướng dẫn chi tiết

Xem file `docs/DEPLOY_GUIDE.md` để biết thêm chi tiết và troubleshooting.

