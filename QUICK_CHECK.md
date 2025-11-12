# ⚡ Quick Check - Database và Migration

## 🔍 Bước 1: Kiểm tra Logs trong Railway

1. **Vào Railway Dashboard**: https://railway.app
2. **Chọn project**: `gameportal-production`
3. **Click vào service** (web service)
4. **Vào tab "Logs"**
5. **Tìm các dòng sau:**

### ✅ Nếu thấy → Database OK:
```
Database migrations applied successfully.
```

### ❌ Nếu thấy lỗi:
```
Migration error: ...
Database initialization error: ...
Connection failed: ...
```

**Copy toàn bộ log và gửi cho tôi để phân tích!**

---

## 🔍 Bước 2: Kiểm tra Connection String

1. **Vào tab "Variables"** trong Railway
2. **Tìm biến**: `ConnectionStrings__DefaultConnection`
3. **Kiểm tra:**
   - ✅ Có giá trị (không rỗng)
   - ✅ Format: `postgresql://user:pass@host:port/dbname`
   - ❌ Nếu rỗng → Cần thêm connection string từ PostgreSQL service

---

## 🔍 Bước 3: Kiểm tra PostgreSQL Service

1. **Trong project**, tìm service **PostgreSQL**
2. **Click vào PostgreSQL service**
3. **Vào tab "Variables"** → Copy connection string
4. **Đảm bảo** connection string này đã được set trong web service

---

## 🚀 Bước 4: Chạy Migration thủ công (Nếu cần)

### Cách 1: Qua Railway CLI (Khuyến nghị)

```bash
# 1. Cài Railway CLI (nếu chưa có)
npm i -g @railway/cli

# 2. Đăng nhập
railway login

# 3. Link project
railway link
# Chọn project: gameportal-production

# 4. Chạy migration
railway run dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

### Cách 2: Qua Railway Dashboard

1. Vào **Service Settings** → **Deploy**
2. Tìm **"Start Command"**
3. Thay đổi thành:
   ```
   dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web && dotnet GamePortal.Web.dll
   ```
4. **Save** và **Redeploy**

---

## 🧪 Bước 5: Test Database

### Test qua Railway CLI:
```bash
railway connect postgres
```

Sau đó chạy:
```sql
-- Kiểm tra tables
SELECT table_name FROM information_schema.tables WHERE table_schema = 'public';

-- Kiểm tra admin user
SELECT "Email", "UserName" FROM "AspNetUsers" WHERE "Email" = 'admin@gameportal.com';

-- Kiểm tra roles
SELECT "Name" FROM "AspNetRoles";
```

---

## 📋 Checklist nhanh

- [ ] Connection string có trong Variables
- [ ] PostgreSQL service đã được tạo
- [ ] Logs không có lỗi connection
- [ ] Migration đã chạy (check logs)
- [ ] Admin user đã được tạo

---

## 🆘 Nếu vẫn không được

**Gửi cho tôi:**
1. Screenshot hoặc copy logs từ Railway
2. Connection string (ẩn password)
3. Lỗi cụ thể khi đăng nhập

Tôi sẽ giúp bạn fix!

