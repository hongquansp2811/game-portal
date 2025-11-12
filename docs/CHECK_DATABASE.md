# 🔍 Kiểm tra Database và Migration

## Cách 1: Kiểm tra qua Railway Dashboard (Dễ nhất)

### Bước 1: Xem Logs
1. Vào Railway Dashboard: https://railway.app
2. Chọn project `gameportal-production`
3. Click vào service
4. Vào tab **"Logs"**
5. Tìm các dòng quan trọng:

**✅ Nếu thấy những dòng này → Database OK:**
```
Database migrations applied successfully.
```

**❌ Nếu thấy lỗi:**
```
Migration error: ...
Database initialization error: ...
Connection failed: ...
```

### Bước 2: Kiểm tra Connection String
1. Vào tab **"Variables"**
2. Tìm biến: `ConnectionStrings__DefaultConnection`
3. Đảm bảo có giá trị (không rỗng)
4. Format PostgreSQL: `postgresql://user:pass@host:port/dbname`

### Bước 3: Kiểm tra Database đã được tạo
1. Trong project, tìm service **PostgreSQL**
2. Click vào PostgreSQL service
3. Vào tab **"Data"** hoặc **"Connect"**
4. Xem connection string và đảm bảo database đã được tạo

---

## Cách 2: Chạy Migration thủ công qua Railway CLI

### Bước 1: Cài Railway CLI
```bash
npm i -g @railway/cli
```

### Bước 2: Đăng nhập và Link
```bash
railway login
railway link
```
Chọn project `gameportal-production`

### Bước 3: Chạy Migration
```bash
railway run dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

### Bước 4: Kiểm tra kết quả
Nếu thành công, sẽ thấy:
```
Done.
```

---

## Cách 3: Kiểm tra Database trực tiếp

### Qua Railway Dashboard
1. Vào PostgreSQL service
2. Tab **"Connect"** → Copy connection string
3. Dùng tool như pgAdmin, DBeaver, hoặc Railway CLI để connect

### Qua Railway CLI
```bash
railway connect postgres
```

Sau đó chạy SQL:
```sql
-- Kiểm tra tables đã được tạo chưa
SELECT table_name 
FROM information_schema.tables 
WHERE table_schema = 'public';

-- Kiểm tra admin user
SELECT * FROM "AspNetUsers" WHERE "Email" = 'admin@gameportal.com';

-- Kiểm tra roles
SELECT * FROM "AspNetRoles";
```

---

## Cách 4: Test Connection String

Tạo file test tạm thời để kiểm tra connection:

```bash
railway run dotnet ef dbcontext info --project GamePortal.Infrastructure --startup-project GamePortal.Web
```

Nếu connection OK, sẽ thấy thông tin về database context.

---

## Troubleshooting

### Lỗi: "Connection string is empty"
**Giải pháp:**
1. Vào Railway → Service → Variables
2. Thêm hoặc cập nhật: `ConnectionStrings__DefaultConnection`
3. Lấy connection string từ PostgreSQL service
4. Redeploy

### Lỗi: "Database does not exist"
**Giải pháp:**
1. Vào PostgreSQL service trong Railway
2. Đảm bảo database đã được tạo
3. Nếu chưa, Railway sẽ tự tạo khi bạn add PostgreSQL service

### Lỗi: "Migration already applied"
**Giải pháp:**
- Không sao, migration đã chạy rồi
- Kiểm tra xem admin user đã được seed chưa

### Lỗi: "Cannot login"
**Giải pháp:**
1. Kiểm tra admin user đã được tạo:
   ```sql
   SELECT * FROM "AspNetUsers";
   ```
2. Nếu chưa có, seed lại database
3. Hoặc tạo user mới qua admin panel (nếu có)

---

## Checklist Debug

- [ ] Connection string có giá trị trong Variables
- [ ] PostgreSQL service đã được tạo
- [ ] Logs không có lỗi connection
- [ ] Migration đã chạy (check logs)
- [ ] Admin user đã được tạo (check database)
- [ ] App đã start thành công (check /health endpoint)

---

## Quick Fix: Chạy Migration + Seed lại

Nếu cần chạy lại từ đầu:

```bash
# 1. Link project
railway link

# 2. Chạy migration
railway run dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web

# 3. Seed database (sẽ tự động chạy khi app start, hoặc chạy thủ công)
# App sẽ tự động seed khi start nếu database rỗng
```

---

## Test nhanh

1. **Test health endpoint:**
   ```bash
   curl https://gameportal-production.up.railway.app/health
   ```
   Kết quả: `{"status":"Healthy"}`

2. **Test login:**
   - Vào: `https://gameportal-production.up.railway.app/login`
   - Email: `admin@gameportal.com`
   - Password: `Admin123!`

3. **Nếu không login được:**
   - Xem logs để tìm lỗi
   - Kiểm tra database có admin user không

