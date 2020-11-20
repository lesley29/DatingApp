$migration_name = $args[0]

if ($migration_name -eq $null) {
    write-host "provide name for migration"
    return
}

dotnet ef migrations add $migration_name `
    --project ./Infrastructure/Infrastructure.csproj  `
    --startup-project ./API/API.csproj
