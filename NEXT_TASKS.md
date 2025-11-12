# 🎯 Công Việc Tiếp Theo - GamePortal

**Ngày**: 2025-01-28  
**Trạng thái hiện tại**: 80% hoàn thành

---

## ✅ VỪA HOÀN THÀNH (Hôm nay)

1. ✅ **Frontend Banners Display** - Hiển thị banners trên trang chủ và trang Games
2. ✅ **BannerService** - Tạo service layer với IServiceScopeFactory để tránh DbContext conflict
3. ✅ **Fix Create Game** - Thêm validation, error handling, success messages
4. ✅ **Cải thiện iframe** - Thêm permissions cho WebGL, service workers
5. ✅ **Tài liệu** - FREE_GAMES_SOURCES.md, HOW_TO_ADD_GAME.md

---

## 🎯 CÔNG VIỆC TIẾP THEO (Theo Ưu Tiên)

### 🔴 ƯU TIÊN CAO (Làm ngay)

#### 1. File Upload System ⭐⭐⭐
**Mục tiêu**: Cho phép upload ảnh thay vì chỉ nhập URL

**Công việc**:
- [ ] Tạo file upload controller/endpoint
- [ ] Thêm file upload cho Games (ThumbnailUrl)
- [ ] Thêm file upload cho Banners (ImageUrl)
- [ ] Lưu file vào `wwwroot/uploads/` hoặc cloud storage
- [ ] Tạo thumbnail/resize ảnh tự động
- [ ] Validate file type và size

**Lý do ưu tiên**: Hiện tại phải nhập URL ảnh thủ công, không tiện

---

#### 2. UI/UX Improvements - Pagination ⭐⭐⭐
**Mục tiêu**: Cải thiện trải nghiệm người dùng

**Công việc**:
- [ ] Pagination cho danh sách games (`/games`)
- [ ] Pagination cho Admin Games list
- [ ] Pagination cho Admin Banners list
- [ ] Items per page selector (10, 20, 50, 100)

**Lý do ưu tiên**: Khi có nhiều games, danh sách sẽ rất dài

---

#### 3. Toast Notifications ⭐⭐
**Mục tiêu**: Hiển thị thông báo đẹp hơn

**Công việc**:
- [ ] Tích hợp toast library (Blazored.Toast hoặc tự tạo)
- [ ] Success notifications (Create/Update/Delete thành công)
- [ ] Error notifications (Validation errors, exceptions)
- [ ] Info notifications (Tips, hints)

**Lý do ưu tiên**: Hiện tại chỉ có alert đơn giản, cần cải thiện UX

---

### 🟡 ƯU TIÊN TRUNG BÌNH

#### 4. Game Reviews UI ⭐⭐
**Mục tiêu**: Cho users có thể review games

**Công việc**:
- [ ] Review form trên Game Detail page (chỉ cho authenticated users)
- [ ] Hiển thị danh sách reviews
- [ ] Admin có thể quản lý reviews (approve/delete)
- [ ] Tính average rating từ reviews
- [ ] Sort reviews (newest, highest rating, etc.)

---

#### 5. Users & Roles Management ⭐⭐
**Mục tiêu**: Cho admin quản lý users

**Công việc**:
- [ ] Admin Users page (`/admin/users`)
  - [ ] List all users với pagination
  - [ ] Edit user (FullName, Email)
  - [ ] Assign/Remove roles
  - [ ] Disable/Enable user account
  - [ ] Delete user (soft delete)
- [ ] Admin Roles page (`/admin/roles`)
  - [ ] Create/Delete roles
  - [ ] List users trong từng role

---

#### 6. Game Gallery Management ⭐⭐
**Mục tiêu**: Upload và hiển thị screenshots

**Công việc**:
- [ ] Admin: Upload screenshots cho games (trong Edit Game form)
- [ ] Frontend: Hiển thị gallery trên Game Detail page
- [ ] Image carousel/lightbox cho gallery
- [ ] Image optimization/thumbnails

---

### 🟢 ƯU TIÊN THẤP

#### 7. Tip Guides UI ⭐
- [ ] Admin Tip Guides CRUD page
- [ ] Hiển thị guides trên Game Detail page
- [ ] Search/filter guides

#### 8. Site Settings ⭐
- [ ] SiteSettings entity
- [ ] Admin Settings page
- [ ] Apply settings to frontend (title, logo, meta tags)

#### 9. SEO Optimization
- [ ] Meta tags cho từng trang
- [ ] Open Graph tags
- [ ] Structured data (JSON-LD)
- [ ] Sitemap.xml

#### 10. Performance Improvements
- [ ] Image lazy loading
- [ ] Caching (memory cache cho games, categories)
- [ ] CDN support (nếu cần)

---

## 📊 Đề Xuất Làm Tiếp Theo

### Option 1: File Upload System (Khuyến nghị)
**Lý do**: 
- Rất cần thiết cho việc quản lý games
- Hiện tại phải tìm URL ảnh trên internet, không tiện
- Sẽ giúp workflow nhanh hơn

**Thời gian ước tính**: 2-3 giờ

### Option 2: Pagination
**Lý do**:
- Cải thiện UX rõ ràng
- Dễ implement
- Cần thiết khi có nhiều games

**Thời gian ước tính**: 1-2 giờ

### Option 3: Toast Notifications
**Lý do**:
- Cải thiện UX
- Dễ implement
- Làm cho app trông chuyên nghiệp hơn

**Thời gian ước tính**: 1 giờ

---

## 💡 Gợi Ý

Nếu muốn làm nhanh và thấy kết quả ngay:
1. **Toast Notifications** (1 giờ) - Cải thiện UX ngay lập tức
2. **Pagination** (1-2 giờ) - Cải thiện performance và UX

Nếu muốn làm tính năng quan trọng:
1. **File Upload System** (2-3 giờ) - Giải quyết vấn đề thực tế

---

## 📝 Notes

- Hiện tại hệ thống đã hoạt động tốt với các tính năng cơ bản
- Có thể tiếp tục thêm games từ các nguồn miễn phí
- Cần test kỹ các game mới thêm vào để đảm bảo chạy được trong iframe

---

**Bạn muốn làm tính năng nào tiếp theo?**

