@echo off
setlocal enabledelayedexpansion

REM Usage: scripts\migrate.bat [MigrationName]
set MIGRATION=%1

if not "%MIGRATION%"=="" (
  echo Adding migration %MIGRATION%...
  dotnet ef migrations add %MIGRATION% --project GamePortal.Infrastructure --startup-project GamePortal.Web || goto :error
)

echo Updating database...
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web || goto :error

echo Done.
exit /b 0

:error
echo Migration failed.
exit /b 1
