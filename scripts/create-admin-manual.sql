-- Script tạo admin user thủ công nếu seed không chạy
-- CHÚ Ý: Password đã được hash, cần dùng ASP.NET Identity để hash đúng cách
-- Script này chỉ để tham khảo, tốt nhất là chạy lại seed

-- 1. Tạo Admin role (nếu chưa có)
INSERT INTO "AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp")
VALUES 
    ('admin-role-id', 'Admin', 'ADMIN', NEWID())
ON CONFLICT ("Id") DO NOTHING;

-- 2. Tạo User role (nếu chưa có)
INSERT INTO "AspNetRoles" ("Id", "Name", "NormalizedName", "ConcurrencyStamp")
VALUES 
    ('user-role-id', 'User', 'USER', NEWID())
ON CONFLICT ("Id") DO NOTHING;

-- 3. Tạo admin user (CẦN HASH PASSWORD ĐÚNG CÁCH)
-- Password: Admin123!
-- CHÚ Ý: Cần hash password bằng ASP.NET Identity PasswordHasher
-- Không thể tạo user trực tiếp qua SQL vì cần hash password

-- Cách đúng: Chạy lại DbInitializer hoặc dùng Railway CLI:
-- railway run dotnet run --project GamePortal.Web

