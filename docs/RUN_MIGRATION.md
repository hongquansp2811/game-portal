# 🗄️ Chạy Database Migration trên Railway

## Cách 1: Qua Railway CLI

### Bước 1: Cài đặt Railway CLI
```bash
npm i -g @railway/cli
```

### Bước 2: Đăng nhập
```bash
railway login
```

### Bước 3: Link project
```bash
railway link
```
Chọn project `gameportal-production`

### Bước 4: Chạy migration
```bash
railway run dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

---

## Cách 2: Qua Railway Dashboard

1. Vào Railway Dashboard
2. Chọn service `gameportal-production`
3. Vào tab **"Settings"**
4. Tìm section **"Deploy"**
5. Trong **"Start Command"**, thay đổi thành:
   ```
   dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web && dotnet GamePortal.Web.dll
   ```
6. Save và Redeploy

---

## Cách 3: Chạy migration tự động trong code

Migration sẽ tự động chạy khi app start nếu bạn thêm vào `Startup.cs`:

```csharp
// Trong Configure method, trước UseEndpoints
using (var scope = app.ApplicationServices.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    context.Database.Migrate(); // Tự động chạy migration
}
```

**Lưu ý**: Cách này có thể chậm nếu có nhiều migration.

---

## Kiểm tra Migration đã chạy

Sau khi chạy migration, kiểm tra:
1. Truy cập website
2. Đăng nhập với:
   - Email: `admin@gameportal.com`
   - Password: `Admin123!`
3. Nếu đăng nhập được → Database đã sẵn sàng!

---

## Troubleshooting

### Lỗi: "No migrations found"
- Đảm bảo migrations đã được commit lên Git
- Kiểm tra folder `GamePortal.Infrastructure/Migrations`

### Lỗi: "Connection failed"
- Kiểm tra connection string trong Railway Variables
- Đảm bảo PostgreSQL database đã được tạo

### Lỗi: "Migration already applied"
- Không sao, migration đã chạy rồi
- Tiếp tục sử dụng website

