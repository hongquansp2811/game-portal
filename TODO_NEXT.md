# 📋 TODO - Công việc tiếp theo

**Ngày**: 2025-01-28  
**Trạng thái hiện tại**: 75% hoàn thành

---

## 🎯 ƯU TIÊN CAO (Làm trước)

### 1. Hiển thị Banners trên Frontend ⭐⭐⭐
**Mục tiêu**: Hiển thị banner "Happy New Year 2025" trên website cho users

**Công việc**:
- [ ] Tạo Banner component/service để load banners từ database
- [ ] Hiển thị Top banners trên trang chủ (`/`)
- [ ] Hiển thị Top banners trên các trang khác (nếu cần)
- [ ] Hiển thị Sidebar banners (nếu có layout sidebar)
- [ ] Implement banner click tracking (nếu có LinkUrl)
- [ ] Test với banner "Happy New Year 2025" (hiện tại IsActive = false)

**Files cần tạo/sửa**:
- `GamePortal.Web/Pages/Shared/BannerDisplay.razor` (component)
- `GamePortal.Web/Pages/Index.razor` (trang chủ)
- Có thể cần inject `IBannerRepository` hoặc tạo `BannerService`

---

## 🟡 ƯU TIÊN TRUNG BÌNH

### 2. Game Reviews UI ⭐⭐
**Mục tiêu**: Cho users có thể review games

**Công việc**:
- [ ] Review form trên Game Detail page
- [ ] Hiển thị danh sách reviews
- [ ] Admin có thể quản lý reviews (approve/delete)
- [ ] Tính average rating từ reviews

### 3. Tip Guides UI ⭐⭐
**Mục tiêu**: Admin thêm tip guides, Frontend hiển thị

**Công việc**:
- [ ] Admin Tip Guides CRUD page
- [ ] Hiển thị guides trên Game Detail page
- [ ] Search/filter guides

### 4. Game Gallery Management ⭐⭐
**Mục tiêu**: Upload và hiển thị screenshots

**Công việc**:
- [ ] File upload system (images)
- [ ] Admin: Upload screenshots cho games
- [ ] Frontend: Hiển thị gallery trên Game Detail page
- [ ] Image optimization/thumbnails

---

## 🟢 ƯU TIÊN THẤP

### 5. Users & Roles Management ⭐
- [ ] Admin Users page (`/admin/users`)
- [ ] Admin Roles page (`/admin/roles`)
- [ ] User profile page (nếu cần)

### 6. Site Settings ⭐
- [ ] SiteSettings entity
- [ ] Admin Settings page
- [ ] Apply settings to frontend

### 7. File Upload System ⭐
- [ ] Image upload cho Games
- [ ] Image upload cho Banners
- [ ] File storage (local hoặc cloud)

### 8. UI/UX Improvements
- [ ] Pagination cho danh sách games
- [ ] Toast notifications
- [ ] Image lazy loading
- [ ] SEO meta tags

---

## 📝 GHI CHÚ

### Banner hiện tại trong DB
- **Title**: "Happy New Year 2025"
- **Position**: Top
- **IsActive**: false (cần set = true sau khi implement display)
- **ImageUrl**: Unsplash image URL

### Để test banner
1. Hoàn thành task #1 (Hiển thị Banners)
2. Vào Admin → Banners
3. Edit banner "Happy New Year 2025"
4. Set IsActive = true
5. Refresh trang chủ để xem banner

### Notes kỹ thuật
- Banner component nên load banners async
- Chỉ hiển thị banners với IsActive = true
- Sort theo DisplayOrder
- Có thể dùng carousel nếu nhiều banners cùng position

---

## 🔗 Links hữu ích
- Admin Banners: `/admin/banners`
- Admin Dashboard: `/admin`
- Frontend Home: `/`
