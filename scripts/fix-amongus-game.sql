-- Script để sửa GameUrl và Slug cho game Among Us
-- Chạy script này trong SQL Server Management Studio hoặc dùng dotnet ef

-- Cách 1: Sửa trực tiếp trong Admin (Khuyến nghị)
-- 1. Đăng nhập Admin: /admin
-- 2. Vào Games → Tìm "Among Us"
-- 3. Click Edit
-- 4. Sửa:
--    - Slug: game-slug → amongus
--    - GameUrl: /games/tên-game/index.html → /games/amongus/index.html
-- 5. Click Update Game

-- Cách 2: Sửa trực tiếp trong database (Nếu cần)
UPDATE Games
SET 
    Slug = 'amongus',
    GameUrl = '/games/amongus/index.html'
WHERE Id = 4 AND Title = 'Among Us';

-- Kiểm tra kết quả
SELECT Id, Title, Slug, GameUrl FROM Games WHERE Id = 4;

