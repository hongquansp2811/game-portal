# 🎮 Hướng Dẫn Setup Games

## ✅ Đã Hoàn Thành

Tôi đã tạo **3 game HTML mẫu** và cập nhật database để các game có thể chơi được:

### Games đã có:

1. **Ball Sort** (`/games/ball-sort.html`)
   - Puzzle game sắp xếp bóng theo màu
   - File: `GamePortal.Web/wwwroot/games/ball-sort.html`

2. **Run Rush Puzzle** (`/games/run-rush-puzzle.html`)
   - Puzzle game 3x3 số
   - File: `GamePortal.Web/wwwroot/games/run-rush-puzzle.html`

3. **Tricky Stick** (`/games/tricky-stick.html`)
   - Game điều khiển độ dài thanh để rơi bóng vào target
   - File: `GamePortal.Web/wwwroot/games/tricky-stick.html`

## 🔄 Cập Nhật Database

### Tự động (Khi chạy app):
- `DbInitializer` sẽ tự động cập nhật `GameUrl` cho các game đã tồn tại khi app khởi động
- Các game mới seed cũng đã có `GameUrl` sẵn

### Thủ công (Nếu cần):
1. Truy cập Admin Dashboard: `http://localhost:5000/admin/games`
2. Click **Edit** (✏️) trên game cần update
3. Điền **Game URL** (ví dụ: `/games/ball-sort.html` hoặc URL external)
4. Click **Update Game**

## 📁 Cấu Trúc Thư Mục Games

```
GamePortal.Web/wwwroot/
└── games/
    ├── ball-sort.html
    ├── run-rush-puzzle.html
    └── tricky-stick.html
```

## 🎯 Cách Thêm Game Mới

### Cách 1: Upload Game HTML vào wwwroot/games/

1. Tạo file HTML game trong `GamePortal.Web/wwwroot/games/`
   - Ví dụ: `my-new-game.html`

2. Trong Admin Dashboard (`/admin/games`), tạo game mới:
   - **Title**: Tên game
   - **Slug**: `my-new-game`
   - **Game URL**: `/games/my-new-game.html`
   - Điền các thông tin khác
   - Click **Create Game**

### Cách 2: Dùng Game URL External

1. Trong Admin Dashboard, tạo/edit game
2. **Game URL**: Điền URL đầy đủ của game (ví dụ: `https://example.com/game/index.html`)
3. Lưu ý: Game phải cho phép embed trong iframe (không có X-Frame-Options DENY)

## 🔍 Kiểm Tra Games

1. **Trang chủ** (`/`): Xem Hot Games và Featured Games
2. **Danh sách Games** (`/games`): Xem tất cả games
3. **Chi tiết Game** (`/games/{slug}`): Chơi game trong iframe

## ⚙️ Lưu Ý Kỹ Thuật

### Game HTML Requirements:
- Game phải là standalone HTML (có thể có CSS/JS inline hoặc external)
- Nếu dùng external resources, đảm bảo CORS cho phép
- Responsive design khuyến khích (sử dụng viewport meta tag)

### Iframe Compatibility:
- Game nên có `viewport` meta tag cho mobile
- Tránh sử dụng `window.top.location` (có thể bị block)
- Test trên nhiều trình duyệt

### Performance:
- Tối ưu hóa assets (hình ảnh, JS, CSS)
- Sử dụng lazy loading nếu cần
- Game nên load nhanh trong iframe

## 📝 Example Game URL Formats:

✅ **Relative Paths (Recommended for local games):**
- `/games/ball-sort.html`
- `/games/subfolder/game.html`

✅ **Absolute URLs (For external games):**
- `https://cdn.example.com/games/awesome-game/index.html`
- `https://gameportal.com/games/my-game.html`

## 🚀 Testing

1. Chạy app: `dotnet run --project GamePortal.Web`
2. Truy cập: `http://localhost:5000`
3. Click vào game card
4. Game sẽ load trong iframe và có thể chơi ngay!

---

**Lưu ý:** Nếu app đang chạy, cần restart để `DbInitializer` cập nhật GameUrl cho các game hiện có.
