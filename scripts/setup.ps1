param(
	[string]$ConnectionString = "Server=localhost;Database=GamePortalDb;Trusted_Connection=True;TrustServerCertificate=True;"
)

Write-Host "[1/3] Restoring packages..." -ForegroundColor Cyan
dotnet restore || exit 1

# Ensure connection string exists in Web appsettings.json
$appSettings = "GamePortal.Web/appsettings.json"
if (Test-Path $appSettings) {
	$json = Get-Content $appSettings -Raw | ConvertFrom-Json
	if (-not $json.ConnectionStrings) { $json | Add-Member -NotePropertyName ConnectionStrings -NotePropertyValue (@{}) }
	$json.ConnectionStrings.DefaultConnection = $ConnectionString
	$json | ConvertTo-Json -Depth 5 | Out-File $appSettings -Encoding utf8
	Write-Host "Set DefaultConnection in $appSettings" -ForegroundColor Green
}

Write-Host "[2/3] Applying EF Core migrations..." -ForegroundColor Cyan
# Requires Microsoft.EntityFrameworkCore.Design in startup project (already added)
dotnet ef database update --project GamePortal.Infrastructure --startup-project GamePortal.Web || exit 1

Write-Host "[3/3] Starting app (Ctrl+C to stop)..." -ForegroundColor Cyan
Push-Location GamePortal.Web
try {
	dotnet run
} finally {
	Pop-Location
}
