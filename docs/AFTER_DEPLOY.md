# 🎉 Sau khi Deploy thành công - Hướng dẫn sử dụng

## 🌐 Link Website của bạn

**URL Production**: `https://gameportal-production.up.railway.app`

Hoặc URL từ Railway dashboard của bạn.

---

## ✅ Các bước tiếp theo

### 1. Truy cập Website
Mở trình duyệt và truy cập: `https://gameportal-production.up.railway.app`

### 2. Đăng nhập Admin
- **URL**: `https://gameportal-production.up.railway.app/login`
- **Email**: `admin@gameportal.com`
- **Password**: `Admin123!`

### 3. Kiểm tra Database Migration
Migration sẽ tự động chạy khi app start lần đầu. Nếu có lỗi:
- Vào Railway Dashboard → Service → Logs
- Tìm dòng "Database migrations applied successfully"
- Nếu thấy lỗi, xem phần Troubleshooting bên dưới

### 4. Quản lý nội dung
Sau khi đăng nhập, bạn có thể:
- **Games**: `/admin/games` - Quản lý games
- **Categories**: `/admin/categories` - Quản lý categories
- **Banners**: `/admin/banners` - Quản lý banners
- **Site Settings**: `/admin/site-settings` - Cấu hình website
- **Statistics**: `/admin/statistics` - Xem thống kê

---

## 🔧 Cấu hình quan trọng

### 1. Cập nhật Site Settings
1. Đăng nhập Admin
2. Vào `/admin/site-settings`
3. Cập nhật:
   - Site Name
   - Email, Phone, Address
   - Social Media Links
   - Footer Description
   - Copyright Text

### 2. Thêm Games
1. Vào `/admin/games`
2. Click "Create New Game"
3. Điền thông tin:
   - Title, Slug
   - Category
   - Thumbnail URL
   - Game URL (ví dụ: `/games/game-name/index.html`)
   - Rating, Description
4. Save

### 3. Thêm Banners
1. Vào `/admin/banners`
2. Tạo banner mới
3. Set Position (Top, Sidebar, Bottom)
4. Set IsActive = true để hiển thị

---

## 🎮 Test Website

### Frontend
- **Home**: `https://gameportal-production.up.railway.app/`
- **Games List**: `https://gameportal-production.up.railway.app/games`
- **Game Detail**: `https://gameportal-production.up.railway.app/games/{slug}`

### Admin
- **Dashboard**: `https://gameportal-production.up.railway.app/admin`
- **Games**: `https://gameportal-production.up.railway.app/admin/games`
- **Categories**: `https://gameportal-production.up.railway.app/admin/categories`
- **Banners**: `https://gameportal-production.up.railway.app/admin/banners`
- **Site Settings**: `https://gameportal-production.up.railway.app/admin/site-settings`

---

## 🐛 Troubleshooting

### Lỗi: "Database connection failed"
**Giải pháp**:
1. Vào Railway Dashboard
2. Service → Variables
3. Kiểm tra `ConnectionStrings__DefaultConnection`
4. Đảm bảo PostgreSQL database đã được tạo

### Lỗi: "Migration failed"
**Giải pháp**:
Migration tự động chạy khi app start. Nếu lỗi:
1. Vào Railway Dashboard → Service → Logs
2. Tìm lỗi migration
3. Hoặc chạy thủ công qua Railway CLI (xem `docs/RUN_MIGRATION.md`)

### Lỗi: "Cannot login"
**Giải pháp**:
1. Kiểm tra database đã được seed chưa
2. Xem logs để kiểm tra admin user đã được tạo
3. Thử reset password hoặc tạo user mới

### Website chậm
**Giải pháp**:
- Railway free tier có thể chậm khi không dùng
- Upgrade lên paid plan để có performance tốt hơn

---

## 📊 Monitoring

### Xem Logs
1. Railway Dashboard → Service → Logs
2. Xem real-time logs của ứng dụng

### Xem Metrics
1. Railway Dashboard → Service → Metrics
2. Xem CPU, Memory, Network usage

---

## 🔄 Update Website

Mỗi khi bạn push code lên GitHub:
1. Railway tự động detect commit mới
2. Tự động build và deploy
3. Website sẽ được update trong vài phút

---

## 🌍 Custom Domain (Tùy chọn)

Nếu muốn dùng domain riêng:

### Railway
1. Vào Service → Settings → Domains
2. Click "Generate Domain" hoặc "Add Custom Domain"
3. Follow instructions để setup DNS

### Render
1. Vào Service → Settings → Custom Domain
2. Add domain và follow DNS instructions

---

## 💡 Tips

1. **Backup Database**: Railway có thể backup database tự động
2. **Environment Variables**: Cấu hình trong Railway Dashboard → Variables
3. **Auto Deploy**: Mỗi commit lên `main` branch sẽ tự động deploy
4. **Rollback**: Có thể rollback về deployment trước trong Railway Dashboard

---

## 📝 Checklist sau khi deploy

- [ ] Truy cập website thành công
- [ ] Đăng nhập admin được
- [ ] Database migration đã chạy (check logs)
- [ ] Cập nhật Site Settings
- [ ] Thêm ít nhất 1 game để test
- [ ] Test frontend hiển thị đúng
- [ ] Test admin CRUD hoạt động

---

## 🎊 Chúc mừng!

Website của bạn đã live! Bây giờ bạn có thể:
- Thêm games
- Quản lý nội dung
- Chia sẻ với bạn bè
- Tiếp tục phát triển tính năng mới

