-- Optional: Direct SQL seed (use if you don't want the C# DbInitializer)
-- Execute against GamePortalDb

BEGIN TRAN;

IF NOT EXISTS (SELECT 1 FROM dbo.Categories)
BEGIN
    INSERT INTO dbo.Categories (Name, Slug, Description, IconUrl, DisplayOrder, IsActive, IsDeleted, CreatedAt)
    VALUES
    (N'Puzzle', N'puzzle', NULL, NULL, 1, 1, 0, SYSUTCDATETIME()),
    (N'Action', N'action', NULL, NULL, 2, 1, 0, SYSUTCDATETIME()),
    (N'Arcade', N'arcade', NULL, NULL, 3, 1, 0, SYSUTCDATETIME());
END

IF NOT EXISTS (SELECT 1 FROM dbo.Games)
BEGIN
    DECLARE @puzzleId INT = (SELECT TOP (1) Id FROM dbo.Categories WHERE Slug = N'puzzle');
    DECLARE @actionId INT = (SELECT TOP (1) Id FROM dbo.Categories WHERE Slug = N'action');

    INSERT INTO dbo.Games (Title, Slug, ThumbnailUrl, Description, FullDescription, Rating, PlayCount, GameType, Platform, IsHot, IsFeatured, CategoryId, IsDeleted, CreatedAt)
    VALUES
    (N'Ball Sort', N'ball-sort', N'https://cdn.ngxfiles.com/image/1736483618723_drop_ball.webp', N'A challenging puzzle', N'Ball Sort is a challenging puzzle game.', 5, 3743, N'Online', N'Desktop, Tablet', 1, 1, @puzzleId, 0, SYSUTCDATETIME()),
    (N'Run Rush Puzzle', N'run-rush-puzzle', N'https://cdn.ngxfiles.com/image/1725445857694_fast_ball_puzzel.webp', N'Fast-paced puzzle', N'Run Rush Puzzle is fast-paced.', 4, 23423, N'Online', N'Desktop', 1, 1, @puzzleId, 0, SYSUTCDATETIME()),
    (N'Tricky Stick', N'tricky-stick', N'https://cdn.ngxfiles.com/image/1725446121048_trap_ball.webp', N'Precision timing', N'Test your precision.', 5, 9756, N'Online', N'Desktop, Mobile', 0, 1, @actionId, 0, SYSUTCDATETIME());
END

COMMIT TRAN;
