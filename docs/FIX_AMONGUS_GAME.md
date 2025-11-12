# 🔧 Sửa Lỗi Game Among Us - Màn Hình Đen

## Vấn Đề

Game Among Us không chạy được, màn hình đen khi vào chơi.

## Nguyên Nhân

1. **GameUrl trong database sai**: Đang là `/games/tên-game/index.html` (placeholder) thay vì `/games/amongus/index.html`
2. **Iframe thiếu permissions**: Game cần các permissions đặc biệt để chạy service worker và WebGL

## Cách Sửa

### Bước 1: Sửa GameUrl trong Admin

1. Đăng nhập Admin: `/admin`
2. Vào **Games** → Tìm game "Among Us"
3. Click **Edit** (✏️)
4. Sửa **GameUrl** từ `/games/tên-game/index.html` thành `/games/amongus/index.html`
5. Click **Update Game**

### Bước 2: Kiểm Tra Game Có Chạy Standalone Không

1. Mở browser
2. Truy cập: `http://localhost:5000/games/amongus/index.html` (hoặc đường dẫn đầy đủ)
3. Kiểm tra game có chạy không
4. Mở Console (F12) xem có lỗi gì không

### Bước 3: Test Trên Website

1. Vào `/games/game-slug` (slug của game Among Us)
2. Kiểm tra game có chạy trong iframe không

## Nếu Vẫn Không Chạy

### Kiểm Tra Console (F12)

Mở Developer Tools (F12) và kiểm tra:
- **Console tab**: Xem có lỗi JavaScript không
- **Network tab**: Xem có file nào không load được không
- **Application tab**: Xem Service Worker có register được không

### Các Lỗi Thường Gặp

1. **CORS Error**: 
   - Nguyên nhân: Game cố gắng load resource từ domain khác
   - Giải pháp: Đảm bảo tất cả resources đều trong folder `amongus/`

2. **Service Worker Error**:
   - Nguyên nhân: Service Worker không thể register trong iframe
   - Giải pháp: Game có thể cần chạy trong tab mới thay vì iframe

3. **WebGL Error**:
   - Nguyên nhân: Browser không hỗ trợ WebGL hoặc bị chặn
   - Giải pháp: Kiểm tra browser có hỗ trợ WebGL không

## Giải Pháp Thay Thế

Nếu game không chạy được trong iframe, có thể:

1. **Mở game trong tab mới**:
   - Thay iframe bằng link mở tab mới
   - Hoặc thêm button "Play in New Tab"

2. **Kiểm tra game có cần server-side không**:
   - Một số game cần server để chạy
   - Game này có vẻ là client-side, nên nên chạy được

## Lưu Ý

- Game Among Us này có service worker (`sw.js`)
- Game cần WebGL và WebAssembly để chạy
- Game có thể không chạy được trong một số browser cũ

