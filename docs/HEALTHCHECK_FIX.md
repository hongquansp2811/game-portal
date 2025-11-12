# 🔧 Fix Healthcheck Failure

## Vấn đề
Healthcheck failure xảy ra khi:
1. App chưa start kịp (database migration chạy trong startup)
2. Không có healthcheck endpoint
3. Database connection fail khiến app crash

## Giải pháp đã áp dụng

### 1. Thêm Health Check Endpoint
- Thêm `services.AddHealthChecks()` trong `ConfigureServices`
- Map endpoint `/health` trong `Configure`
- Endpoint này không cần database, chỉ check app đã start chưa

### 2. Database Seeding Non-blocking
- Chuyển database seeding sang background task
- App sẽ start ngay lập tức, không đợi database
- Seeding chạy sau 5 giây trong background

### 3. Error Handling
- Wrap database operations trong try-catch
- App không crash nếu database chưa sẵn sàng
- Log errors nhưng vẫn cho phép app start

### 4. Platform Configuration
- **Railway**: Set `healthcheckPath: "/health"` và `healthcheckTimeout: 300`
- **Render**: Set `healthCheckPath: /health`

## Cấu hình Platform

### Railway
Trong Railway dashboard:
1. Vào Service Settings
2. Tìm "Healthcheck" section
3. Set:
   - **Path**: `/health`
   - **Timeout**: `300` seconds

Hoặc dùng `railway.json` (đã cấu hình sẵn)

### Render
Trong `render.yaml` (đã cấu hình sẵn):
```yaml
healthCheckPath: /health
```

## Test Healthcheck

Sau khi deploy, test endpoint:
```bash
curl https://your-app.railway.app/health
```

Kết quả mong đợi:
```json
{"status":"Healthy"}
```

## Troubleshooting

### Nếu vẫn bị healthcheck failure:

1. **Kiểm tra logs**:
   - Railway: Service → Logs
   - Render: Service → Logs

2. **Kiểm tra database connection**:
   - Đảm bảo connection string đúng
   - Database đã được tạo

3. **Kiểm tra port**:
   - App phải listen trên port được set bởi platform (thường là PORT env var)
   - Railway/Render tự động set PORT

4. **Tăng timeout**:
   - Railway: `healthcheckTimeout: 600` (10 phút)
   - Render: Thêm `healthCheckTimeout: 600` trong render.yaml

## Lưu ý

- Healthcheck endpoint `/health` không cần authentication
- Endpoint này chỉ check app đã start, không check database
- Database migration sẽ chạy tự động khi app start (nếu có connection string)

