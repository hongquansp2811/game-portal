# 📥 Hướng Dẫn Thêm Game Vào GamePortal

Hướng dẫn chi tiết cách thêm game từ folder đã tải về vào hệ thống GamePortal.

---

## 📁 Các Trường Hợp Folder Game

### Trường Hợp 1: Game có 1 file HTML duy nhất
```
game-folder/
  └── index.html (hoặc game.html)
```

### Trường Hợp 2: Game có nhiều file (HTML + JS + CSS)
```
game-folder/
  ├── index.html
  ├── game.js
  ├── style.css
  └── assets/
      ├── images/
      └── sounds/
```

### Trường Hợp 3: Game có cấu trúc phức tạp
```
game-folder/
  ├── index.html
  ├── js/
  │   ├── main.js
  │   └── utils.js
  ├── css/
  │   └── style.css
  └── assets/
      ├── images/
      └── sounds/
```

---

## 🚀 Cách Thêm Game (Theo Từng Trường Hợp)

### ✅ Trường Hợp 1: Game 1 file HTML

**Bước 1: Copy file vào wwwroot/games/**
```bash
# Copy file HTML vào thư mục games
copy "C:\path\to\game-folder\index.html" "F:\WebGame\GamePortal.Web\wwwroot\games\tên-game.html"
```

**Bước 2: Đổi tên file (nếu cần)**
- Đổi `index.html` → `tên-game.html` (ví dụ: `tetris.html`)
- Đảm bảo tên file không có khoảng trắng, dùng dấu gạch ngang

**Bước 3: Thêm vào Admin**
1. Đăng nhập Admin: `/admin`
2. Vào **Games** → **Create New Game**
3. Điền thông tin:
   - **Title**: Tên game (ví dụ: "Tetris Classic")
   - **Slug**: `tetris` (URL-friendly, không dấu, không khoảng trắng)
   - **GameUrl**: `/games/tetris.html`
   - **ThumbnailUrl**: URL ảnh thumbnail (hoặc upload sau)
   - **Category**: Chọn category phù hợp
   - **Description**: Mô tả game
   - **Rating**: 1-5
4. Click **Create Game**

---

### ✅ Trường Hợp 2: Game có nhiều file (HTML + JS + CSS)

**Bước 1: Tạo thư mục riêng cho game**
```bash
# Tạo thư mục cho game
mkdir "F:\WebGame\GamePortal.Web\wwwroot\games\tên-game"

# Copy toàn bộ file vào thư mục
xcopy "C:\path\to\game-folder\*" "F:\WebGame\GamePortal.Web\wwwroot\games\tên-game\" /E /I
```

**Bước 2: Kiểm tra file chính**
- Tìm file HTML chính (thường là `index.html` hoặc `game.html`)
- Đảm bảo các file JS/CSS được link đúng đường dẫn

**Bước 3: Sửa đường dẫn trong HTML (nếu cần)**
Mở file HTML và kiểm tra:
```html
<!-- Nếu game dùng đường dẫn tương đối, giữ nguyên -->
<link rel="stylesheet" href="style.css">
<script src="game.js"></script>

<!-- Nếu game dùng đường dẫn tuyệt đối, sửa thành tương đối -->
<!-- SAI: <script src="/js/game.js"></script> -->
<!-- ĐÚNG: <script src="js/game.js"></script> -->
```

**Bước 4: Thêm vào Admin**
1. Đăng nhập Admin: `/admin`
2. Vào **Games** → **Create New Game**
3. Điền thông tin:
   - **Title**: Tên game
   - **Slug**: `tên-game`
   - **GameUrl**: `/games/tên-game/index.html` (hoặc `/games/tên-game/game.html`)
   - **ThumbnailUrl**: URL ảnh thumbnail
   - **Category**: Chọn category
   - **Description**: Mô tả game
   - **Rating**: 1-5
4. Click **Create Game**

---

### ✅ Trường Hợp 3: Game có cấu trúc phức tạp

**Bước 1: Copy toàn bộ folder**
```bash
# Copy toàn bộ folder game vào wwwroot/games/
xcopy "C:\path\to\game-folder" "F:\WebGame\GamePortal.Web\wwwroot\games\tên-game\" /E /I
```

**Bước 2: Kiểm tra và sửa đường dẫn**
1. Mở file HTML chính (`index.html`)
2. Kiểm tra tất cả đường dẫn:
   - ✅ **Đúng**: `href="css/style.css"`, `src="js/main.js"`
   - ❌ **Sai**: `href="/css/style.css"`, `src="http://..."`
3. Sửa tất cả đường dẫn tuyệt đối thành tương đối

**Bước 3: Test game standalone**
1. Mở file HTML chính trong browser
2. Kiểm tra game có chạy không
3. Kiểm tra console (F12) xem có lỗi không

**Bước 4: Thêm vào Admin**
1. Đăng nhập Admin: `/admin`
2. Vào **Games** → **Create New Game**
3. Điền thông tin:
   - **Title**: Tên game
   - **Slug**: `tên-game`
   - **GameUrl**: `/games/tên-game/index.html`
   - **ThumbnailUrl**: URL ảnh thumbnail
   - **Category**: Chọn category
   - **Description**: Mô tả game
   - **Rating**: 1-5
4. Click **Create Game**

---

## 🔧 Xử Lý Các Vấn Đề Thường Gặp

### Vấn đề 1: Game không hiển thị trong iframe

**Nguyên nhân**: Game có X-Frame-Options hoặc Content Security Policy

**Giải pháp**:
1. Kiểm tra file HTML có meta tag:
   ```html
   <meta http-equiv="X-Frame-Options" content="SAMEORIGIN">
   ```
2. Xóa hoặc sửa thành:
   ```html
   <meta http-equiv="X-Frame-Options" content="ALLOWALL">
   ```

### Vấn đề 2: Game không load JS/CSS

**Nguyên nhân**: Đường dẫn file không đúng

**Giải pháp**:
1. Kiểm tra đường dẫn trong HTML
2. Đảm bảo dùng đường dẫn tương đối (không có `/` ở đầu)
3. Ví dụ:
   - ✅ `href="css/style.css"`
   - ❌ `href="/css/style.css"`

### Vấn đề 3: Game cần server-side (PHP, Node.js)

**Nguyên nhân**: Game không thể chạy standalone

**Giải pháp**:
- Game này **KHÔNG THỂ** chạy trong GamePortal
- Chỉ chọn game HTML5 thuần (client-side only)

### Vấn đề 4: Game có CORS issues

**Nguyên nhân**: Game cố gắng load resource từ domain khác

**Giải pháp**:
1. Download tất cả resources về local
2. Sửa đường dẫn trong code để dùng file local

---

## 📋 Checklist Trước Khi Thêm Game

- [ ] Đã kiểm tra license (MIT/CC0/Apache/GPL)
- [ ] Game có thể chạy standalone (mở HTML trực tiếp trong browser)
- [ ] Tất cả file JS/CSS/images đều có trong folder
- [ ] Đường dẫn trong HTML đã đúng (tương đối, không tuyệt đối)
- [ ] Game không có X-Frame-Options chặn iframe
- [ ] Đã test game trong browser trước
- [ ] Đã copy file vào `wwwroot/games/`
- [ ] Đã thêm game vào Admin với GameUrl đúng
- [ ] Đã test game trên website

---

## 🎯 Ví Dụ Cụ Thể

### Ví dụ 1: Game Tetris (1 file)
```
Folder tải về:
  tetris-game/
    └── index.html

Cách làm:
1. Copy: index.html → wwwroot/games/tetris.html
2. Admin: GameUrl = /games/tetris.html
```

### Ví dụ 2: Game Snake (nhiều file)
```
Folder tải về:
  snake-game/
    ├── index.html
    ├── snake.js
    ├── style.css
    └── assets/
        └── images/
            └── snake.png

Cách làm:
1. Copy toàn bộ: snake-game/ → wwwroot/games/snake/
2. Admin: GameUrl = /games/snake/index.html
```

### Ví dụ 3: Game Phaser (cấu trúc phức tạp)
```
Folder tải về:
  phaser-game/
    ├── index.html
    ├── js/
    │   ├── main.js
    │   └── phaser.min.js
    ├── css/
    │   └── style.css
    └── assets/
        ├── images/
        └── sounds/

Cách làm:
1. Copy toàn bộ: phaser-game/ → wwwroot/games/phaser-game/
2. Kiểm tra index.html: đảm bảo đường dẫn đúng
3. Admin: GameUrl = /games/phaser-game/index.html
```

---

## 💡 Tips

1. **Đặt tên folder/file rõ ràng**: Dùng tên không dấu, không khoảng trắng
2. **Test trước khi thêm**: Luôn test game trong browser trước
3. **Kiểm tra console**: Mở F12 để xem có lỗi không
4. **Backup**: Giữ bản gốc của game để có thể sửa lại
5. **Thumbnail**: Tạo screenshot làm thumbnail cho game

---

## 🔗 Cấu Trúc Thư Mục Mẫu

Sau khi thêm nhiều game, cấu trúc sẽ như sau:
```
wwwroot/
  └── games/
      ├── tetris.html                    (game 1 file)
      ├── snake/                         (game nhiều file)
      │   ├── index.html
      │   ├── snake.js
      │   └── style.css
      ├── phaser-game/                   (game phức tạp)
      │   ├── index.html
      │   ├── js/
      │   ├── css/
      │   └── assets/
      └── ...
```

---

## ❓ Câu Hỏi Thường Gặp

**Q: Game của tôi có file .exe, có dùng được không?**
A: Không. GamePortal chỉ hỗ trợ game HTML5 (HTML/JS/CSS). Game .exe cần chạy trên desktop.

**Q: Game của tôi cần database, có dùng được không?**
A: Không. GamePortal chỉ hỗ trợ game client-side (chạy trên browser). Game cần server-side không thể chạy.

**Q: Game của tôi có file .swf (Flash), có dùng được không?**
A: Không. Flash đã bị deprecated. Chỉ hỗ trợ HTML5.

**Q: Làm sao biết game có thể chạy trong iframe?**
A: Test bằng cách mở file HTML trong browser, sau đó thử embed vào iframe. Nếu không chạy, kiểm tra console (F12) để xem lỗi.

---

**Lưu ý**: Nếu bạn gặp vấn đề cụ thể với game của mình, hãy mô tả cấu trúc folder và lỗi gặp phải để được hỗ trợ tốt hơn.

