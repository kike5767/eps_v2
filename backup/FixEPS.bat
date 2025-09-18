param(
    [string]$Base = "C:\EPS\Entities",
    [string]$Proj = "C:\EPS\EPS.csproj"
)

Write-Host "============================================"
Write-Host "  INICIANDO CORRECCION DE ENTIDADES EPS"
Write-Host "============================================"

# Buscar todos los .cs
$files = Get-ChildItem -Path $Base -Recurse -Include *.cs

foreach ($file in $files) {
    Write-Host "Corrigiendo: $($file.FullName)"
    $c = Get-Content $file.FullName -Raw

    # Reemplazos básicos de tipos
    $c = $c -replace "INT", "int"
    $c = $c -replace "BIGINT", "long"
    $c = $c -replace "DECIMAL", "decimal"
    $c = $c -replace "DATE", "DateTime"
    $c = $c -replace "DATETIME", "DateTime"

    # NVARCHAR(x) o VARCHAR(x) → string
    $c = $c -replace "NVARCHAR\(\d+\)", "string"
    $c = $c -replace "VARCHAR\(\d+\)", "string"

    Set-Content -Path $file.FullName -Value $c -Encoding UTF8
}

Write-Host "============================================"
Write-Host "  CORRECCION TERMINADA"
Write-Host "============================================"

Write-Host "Compilando proyecto en $Proj ..."
dotnet build $Proj
