param(
	[string]$MigrationName = ""
)

Write-Host "EF Core migration utility" -ForegroundColor Cyan
if ($MigrationName -ne "") {
	Write-Host "Adding migration '$MigrationName'..." -ForegroundColor Yellow
	dotnet ef migrations add $MigrationName --project GamePortal.Infrastructure --startup-project GamePortal.Web || exit 1
}

Write-Host "Updating database..." -ForegroundColor Yellow
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web || exit 1

Write-Host "Done." -ForegroundColor Green
