# 🎮 Nguồn Game Miễn Phí - Không Bản Quyền

Tài liệu này liệt kê các nguồn game HTML5 miễn phí, không có bản quyền mà bạn có thể tải về và thêm vào website GamePortal.

---

## 🌟 Nguồn Chính (Khuyến Nghị)

### 1. **Itch.io - HTML5 Games với Source Code**
- **URL**: https://itch.io/games/free/html5/tag-sourcecode
- **Đặc điểm**:
  - Nhiều game HTML5 miễn phí
  - Có tag "sourcecode" để tìm game có mã nguồn
  - Nhiều game sử dụng license MIT, CC0, hoặc Public Domain
  - Có thể tải về file HTML/JS/CSS
- **Cách sử dụng**:
  1. Tìm game HTML5
  2. Kiểm tra license (MIT, CC0, Public Domain = không bản quyền)
  3. Download file HTML/JS
  4. Upload vào `wwwroot/games/`
  5. Thêm vào Admin với GameUrl = `/games/tên-file.html`

### 2. **GitHub - Open Source Games**
- **URL**: 
  - https://github.com/bobeff/open-source-games
  - https://github.com/michelpereira/awesome-open-source-games
- **Đặc điểm**:
  - Nhiều game open source với license rõ ràng
  - Có thể clone repository
  - Thường có README với hướng dẫn
- **License phổ biến**: MIT, Apache 2.0, GPL (cần kiểm tra)

### 3. **CodeWithRandom - HTML Game Code**
- **URL**: https://www.codewithrandom.com/2024/02/25/html-game-code/
- **Đặc điểm**:
  - 25+ game HTML miễn phí với source code
  - Game đơn giản: Tetris, Tic Tac Toe, Car Game, Piano Tiles
  - Code sẵn sàng sử dụng
- **License**: Thường là free to use (kiểm tra từng game)

### 4. **HTML5GameDevs Community**
- **URL**: https://www.html5gamedevs.com/
- **Đặc điểm**:
  - Cộng đồng phát triển game HTML5
  - Nhiều game example và tutorial
  - Có thể tìm game với source code miễn phí

### 5. **SuperDevResources - Open Source HTML5 Games**
- **URL**: https://superdevresources.com/open-source-html5-games/
- **Đặc điểm**:
  - 15+ game open source
  - Game clone: Tetris, Pacman, Wordle
  - License rõ ràng

---

## 📦 Các Nguồn Khác

### 6. **OpenGameArt.org**
- **URL**: https://opengameart.org/
- **Đặc điểm**: Tài nguyên nghệ thuật và game assets (không phải game hoàn chỉnh)

### 7. **Phaser.io Examples**
- **URL**: https://phaser.io/examples
- **Đặc điểm**: 
  - Game examples sử dụng Phaser framework
  - Code mẫu miễn phí
  - Có thể tùy chỉnh

### 8. **CodePen Games**
- **URL**: https://codepen.io/tag/game
- **Đặc điểm**:
  - Nhiều game demo trên CodePen
  - Có thể xem source code
  - Cần kiểm tra license của từng pen

---

## ⚠️ Lưu Ý Quan Trọng

### 1. **Kiểm Tra License**
Trước khi sử dụng, **LUÔN** kiểm tra license:
- ✅ **MIT License**: Cho phép sử dụng tự do, kể cả thương mại
- ✅ **Apache 2.0**: Tương tự MIT
- ✅ **CC0 (Public Domain)**: Không có bản quyền
- ✅ **GPL v3**: Cho phép sử dụng nhưng phải giữ license
- ❌ **All Rights Reserved**: KHÔNG được sử dụng
- ❌ **Commercial License Required**: Cần mua license

### 2. **Cách Kiểm Tra License**
1. Xem file `LICENSE` hoặc `LICENSE.txt` trong repository
2. Xem README.md của project
3. Kiểm tra trong source code (thường có comment ở đầu file)
4. Nếu không rõ → **KHÔNG SỬ DỤNG**

### 3. **Attribution (Ghi Công)**
Một số license yêu cầu ghi công tác giả:
- Thêm credit vào game description
- Hoặc tạo trang "Credits" trên website

---

## 🚀 Cách Thêm Game Vào GamePortal

### Bước 1: Tải Game
1. Tải file HTML/JS/CSS của game
2. Đảm bảo game có thể chạy độc lập (standalone)

### Bước 2: Upload Game
1. Tạo thư mục `wwwroot/games/` (nếu chưa có)
2. Copy file game vào thư mục này
3. Đảm bảo file chính có tên rõ ràng (ví dụ: `tetris.html`)

### Bước 3: Thêm Vào Database
1. Đăng nhập Admin: `/admin`
2. Vào **Games** → **Create New Game**
3. Điền thông tin:
   - **Title**: Tên game
   - **Slug**: URL-friendly name (ví dụ: `tetris`)
   - **ThumbnailUrl**: URL ảnh thumbnail
   - **GameUrl**: `/games/tetris.html` (relative path)
   - **Category**: Chọn category phù hợp
   - **Description**: Mô tả game
   - **Rating**: Đánh giá (1-5)
4. Click **Create Game**

### Bước 4: Test
1. Vào trang chủ hoặc `/games`
2. Click vào game vừa tạo
3. Kiểm tra game có chạy trong iframe không

---

## 📋 Checklist Trước Khi Thêm Game

- [ ] Đã kiểm tra license (MIT/CC0/Apache/GPL)
- [ ] Game có thể chạy standalone (không cần server-side)
- [ ] Game tương thích với iframe
- [ ] Đã test game trên browser
- [ ] Đã upload file vào `wwwroot/games/`
- [ ] Đã thêm game vào Admin với GameUrl đúng
- [ ] Đã test game trên website

---

## 🎯 Game Mẫu Để Bắt Đầu

### 1. **Tetris** (Classic)
- Nguồn: CodeWithRandom, GitHub
- License: Thường là MIT hoặc Public Domain
- File: `tetris.html`

### 2. **Tic Tac Toe**
- Nguồn: CodeWithRandom, CodePen
- License: Thường là free to use
- File: `tic-tac-toe.html`

### 3. **Snake Game**
- Nguồn: GitHub, CodePen
- License: Thường là MIT
- File: `snake.html`

### 4. **Pong**
- Nguồn: Phaser.io examples, GitHub
- License: Thường là MIT
- File: `pong.html`

### 5. **Breakout/Brick Breaker**
- Nguồn: GitHub, HTML5GameDevs
- License: Thường là MIT
- File: `breakout.html`

---

## 🔗 Links Hữu Ích

- **Itch.io HTML5 Games**: https://itch.io/games/free/html5
- **GitHub Open Source Games**: https://github.com/bobeff/open-source-games
- **CodeWithRandom Games**: https://www.codewithrandom.com/2024/02/25/html-game-code/
- **Phaser Examples**: https://phaser.io/examples
- **HTML5GameDevs Forum**: https://www.html5gamedevs.com/

---

## 💡 Tips

1. **Tìm game đơn giản trước**: Bắt đầu với game nhỏ, đơn giản để test hệ thống
2. **Kiểm tra compatibility**: Một số game có thể không chạy trong iframe (do CORS hoặc security)
3. **Tối ưu hóa**: Nén file JS/CSS nếu có thể để tăng tốc độ tải
4. **Thumbnail**: Tạo hoặc tìm thumbnail đẹp cho game (có thể dùng screenshot)
5. **Description**: Viết mô tả hấp dẫn để thu hút người chơi

---

**Lưu ý cuối**: Luôn tôn trọng bản quyền và license của game. Nếu không chắc chắn về license, hãy liên hệ tác giả hoặc không sử dụng.

