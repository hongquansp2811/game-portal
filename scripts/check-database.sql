-- Script để kiểm tra database trên PostgreSQL
-- Chạy qua Railway CLI: railway connect postgres
-- Hoặc dùng pgAdmin/DBeaver với connection string từ Railway

-- 1. Kiểm tra tables đã được tạo chưa
SELECT table_name 
FROM information_schema.tables 
WHERE table_schema = 'public'
ORDER BY table_name;

-- 2. Kiểm tra migrations đã chạy chưa
SELECT * FROM "__EFMigrationsHistory"
ORDER BY "MigrationId";

-- 3. Kiểm tra admin user
SELECT "Id", "UserName", "Email", "EmailConfirmed", "FullName"
FROM "AspNetUsers"
WHERE "Email" = 'admin@gameportal.com';

-- 4. Kiểm tra roles
SELECT "Id", "Name" FROM "AspNetRoles";

-- 5. Kiểm tra user có role Admin không
SELECT u."UserName", u."Email", r."Name" as "Role"
FROM "AspNetUsers" u
LEFT JOIN "AspNetUserRoles" ur ON u."Id" = ur."UserId"
LEFT JOIN "AspNetRoles" r ON ur."RoleId" = r."Id"
WHERE u."Email" = 'admin@gameportal.com';

-- 6. Kiểm tra Categories
SELECT COUNT(*) as "CategoryCount" FROM "Categories";

-- 7. Kiểm tra Games
SELECT COUNT(*) as "GameCount" FROM "Games";

-- 8. Kiểm tra Banners
SELECT COUNT(*) as "BannerCount" FROM "Banners";

-- 9. Kiểm tra SiteSettings
SELECT COUNT(*) as "SiteSettingsCount" FROM "SiteSettings";

