@echo off
REM ========================================================================
REM   CONFIGURACIÓN AUTOMÁTICA DEL PROYECTO EPS V2 FINAL
REM   Este script configura todo lo necesario para compilar y ejecutar
REM   el proyecto en cualquier computador después de descomprimir el ZIP
REM ========================================================================

setlocal enabledelayedexpansion

echo.
echo ╔═══════════════════════════════════════════════════════════════╗
echo ║  CONFIGURACIÓN AUTOMÁTICA - EPS V2 FINAL                      ║
echo ╚═══════════════════════════════════════════════════════════════╝
echo.

REM ========================================================================
REM   PASO 1: VERIFICAR .NET SDK 8.0
REM ========================================================================
echo [PASO 1/7] Verificando .NET SDK 8.0...
echo.

dotnet --version >nul 2>&1
if %ERRORLEVEL% NEQ 0 (
    echo [ERROR] .NET SDK no está instalado.
    echo.
    echo Por favor instala .NET 8.0 SDK desde:
    echo https://dotnet.microsoft.com/download/dotnet/8.0
    echo.
    echo Después de instalar, ejecuta este script nuevamente.
    pause
    exit /b 1
)

for /f "tokens=1 delims=." %%a in ('dotnet --version') do set DOTNET_MAJOR=%%a
if !DOTNET_MAJOR! LSS 8 (
    echo [ERROR] Se requiere .NET SDK 8.0 o superior.
    echo Versión actual: 
    dotnet --version
    echo.
    echo Por favor instala .NET 8.0 SDK desde:
    echo https://dotnet.microsoft.com/download/dotnet/8.0
    pause
    exit /b 1
)

echo [OK] .NET SDK encontrado:
dotnet --version
echo.

REM ========================================================================
REM   PASO 2: VERIFICAR SQL SERVER
REM ========================================================================
echo [PASO 2/7] Verificando SQL Server...
echo.

REM Intentar conectar a SQL Server Express
sqlcmd -S localhost\SQLEXPRESS -Q "SELECT @@VERSION" >nul 2>&1
if %ERRORLEVEL% EQU 0 (
    echo [OK] SQL Server Express encontrado en localhost\SQLEXPRESS
    set SQL_SERVER=localhost\SQLEXPRESS
    set SQL_FOUND=1
) else (
    REM Intentar con SQL Server Developer/Standard
    sqlcmd -S localhost -Q "SELECT @@VERSION" >nul 2>&1
    if %ERRORLEVEL% EQU 0 (
        echo [OK] SQL Server encontrado en localhost
        set SQL_SERVER=localhost
        set SQL_FOUND=1
    ) else (
        echo [ADVERTENCIA] No se pudo conectar a SQL Server automáticamente.
        echo.
        echo Por favor asegúrate de tener SQL Server instalado:
        echo - SQL Server Express (gratis): https://www.microsoft.com/sql-server/sql-server-downloads
        echo - O SQL Server Developer Edition (gratis para desarrollo)
        echo.
        echo Ingresa el nombre de tu servidor SQL (o presiona Enter para usar localhost\SQLEXPRESS):
        set /p SQL_SERVER_INPUT=
        if "!SQL_SERVER_INPUT!"=="" (
            set SQL_SERVER=localhost\SQLEXPRESS
        ) else (
            set SQL_SERVER=!SQL_SERVER_INPUT!
        )
        set SQL_FOUND=0
    )
)
echo.

REM ========================================================================
REM   PASO 3: CREAR ARCHIVO secrets.json
REM ========================================================================
echo [PASO 3/7] Configurando archivo secrets.json...
echo.

set SECRETS_FILE=secrets.json

if exist "%SECRETS_FILE%" (
    echo [INFO] El archivo secrets.json ya existe.
    echo ¿Deseas sobrescribirlo? (S/N)
    set /p OVERWRITE=
    if /i not "!OVERWRITE!"=="S" (
        echo [INFO] Manteniendo el archivo existente.
        goto :skip_secrets
    )
)

REM Crear el archivo secrets.json con la cadena de conexión
(
    echo {
    echo   "StringConexion": "Server=%SQL_SERVER%;Database=EPSDB;Trusted_Connection=True;TrustServerCertificate=True;"
    echo }
) > "%SECRETS_FILE%"

echo [OK] Archivo secrets.json creado en la raíz del proyecto.
echo [INFO] Ruta: %CD%\%SECRETS_FILE%
echo [INFO] Cadena de conexión configurada para: %SQL_SERVER%
echo.

:skip_secrets

REM ========================================================================
REM   PASO 4: VERIFICAR ESTRUCTURA DE PROYECTOS
REM ========================================================================
echo [PASO 4/7] Verificando estructura de proyectos...
echo.

set MISSING_PROJECTS=0

if not exist "lib_dominio\lib_dominio.csproj" (
    echo [ERROR] No se encuentra lib_dominio\lib_dominio.csproj
    set MISSING_PROJECTS=1
)

if not exist "lib_repositorios\lib_repositorios.csproj" (
    echo [ERROR] No se encuentra lib_repositorios\lib_repositorios.csproj
    set MISSING_PROJECTS=1
)

if not exist "lib_presentaciones\lib_presentaciones.csproj" (
    echo [ERROR] No se encuentra lib_presentaciones\lib_presentaciones.csproj
    set MISSING_PROJECTS=1
)

if not exist "asp_servicios\asp_servicios.csproj" (
    echo [ERROR] No se encuentra asp_servicios\asp_servicios.csproj
    set MISSING_PROJECTS=1
)

if not exist "asp_presentacion\asp_presentacion.csproj" (
    echo [ERROR] No se encuentra asp_presentacion\asp_presentacion.csproj
    set MISSING_PROJECTS=1
)

if not exist "EPS.sln" (
    echo [ERROR] No se encuentra EPS.sln
    set MISSING_PROJECTS=1
)

if !MISSING_PROJECTS! EQU 1 (
    echo.
    echo [ERROR] Faltan archivos del proyecto. Asegúrate de descomprimir todo el ZIP.
    pause
    exit /b 1
)

echo [OK] Estructura de proyectos verificada correctamente.
echo.

REM ========================================================================
REM   PASO 5: RESTAURAR PAQUETES NUGET
REM ========================================================================
echo [PASO 5/7] Restaurando paquetes NuGet...
echo.

echo [INFO] Esto puede tardar varios minutos la primera vez...
dotnet restore EPS.sln
if %ERRORLEVEL% NEQ 0 (
    echo [ERROR] Error al restaurar paquetes NuGet.
    echo Verifica tu conexión a internet.
    pause
    exit /b 1
)

echo [OK] Paquetes NuGet restaurados correctamente.
echo.

REM ========================================================================
REM   PASO 6: COMPILAR PROYECTO
REM ========================================================================
echo [PASO 6/7] Compilando proyecto...
echo.

dotnet build EPS.sln --no-incremental
if %ERRORLEVEL% NEQ 0 (
    echo.
    echo [ERROR] Error al compilar el proyecto.
    echo Revisa los mensajes de error arriba.
    pause
    exit /b 1
)

echo [OK] Proyecto compilado exitosamente.
echo.

REM ========================================================================
REM   PASO 7: VERIFICAR BASE DE DATOS
REM ========================================================================
echo [PASO 7/7] Verificando base de datos...
echo.

echo [INFO] IMPORTANTE: Debes ejecutar el script SQL para crear la base de datos.
echo.
if exist "lib_repositorios\Script.sql" (
    echo [INFO] Script SQL encontrado en: lib_repositorios\Script.sql
) else if exist "SCRIPCORREGIDOULTIMO19092025.sql" (
    echo [INFO] Script SQL encontrado en: SCRIPCORREGIDOULTIMO19092025.sql
) else (
    echo [ADVERTENCIA] No se encontró el script SQL.
    echo Busca el archivo .sql en el proyecto y ejecútalo en SQL Server Management Studio.
)

echo.
echo [INSTRUCCIONES PARA EJECUTAR EL SCRIPT SQL:]
echo 1. Abre SQL Server Management Studio (SSMS)
echo 2. Conéctate a: %SQL_SERVER%
echo 3. Abre el archivo Script.sql o SCRIPCORREGIDOULTIMO19092025.sql
echo 4. Ejecuta el script (F5)
echo 5. Verifica que se creó la base de datos EPSDB
echo.

REM ========================================================================
REM   RESUMEN FINAL
REM ========================================================================
echo.
echo ╔═══════════════════════════════════════════════════════════════╗
echo ║  ✅ CONFIGURACIÓN COMPLETADA                                   ║
echo ╚═══════════════════════════════════════════════════════════════╝
echo.
echo [RESUMEN DE CONFIGURACIÓN:]
echo.
echo ✅ .NET SDK: Instalado y verificado
echo ✅ SQL Server: %SQL_SERVER%
echo ✅ secrets.json: Creado en %CD%\%SECRETS_FILE%
echo ✅ Paquetes NuGet: Restaurados
echo ✅ Proyecto: Compilado exitosamente
echo.
echo [PRÓXIMOS PASOS:]
echo.
echo 1. Ejecuta el script SQL para crear la base de datos EPSDB
echo 2. Para ejecutar el API:
echo    dotnet run --project asp_servicios\asp_servicios.csproj
echo.
echo 3. Para ejecutar la UI (en otra terminal):
echo    dotnet run --project asp_presentacion\asp_presentacion.csproj
echo.
echo [ARCHIVOS IMPORTANTES:]
echo.
echo - secrets.json: %CD%\%SECRETS_FILE%
echo    (Contiene la cadena de conexión a la base de datos)
echo.
echo - Ruta de secrets.json en código:
echo    lib_dominio\Nucleo\DatosGenerales.cs (línea 9)
echo.
echo [REFERENCIAS ENTRE PROYECTOS:]
echo.
echo lib_dominio (base)
echo   └─ lib_repositorios (depende de lib_dominio)
echo   └─ lib_presentaciones (depende de lib_dominio)
echo      └─ asp_servicios (depende de lib_dominio, lib_repositorios)
echo      └─ asp_presentacion (depende de lib_presentaciones)
echo.
echo [PAQUETES NUGET INSTALADOS:]
echo.
echo - Microsoft.EntityFrameworkCore (8.0.8)
echo - Microsoft.EntityFrameworkCore.SqlServer (8.0.8)
echo - Microsoft.EntityFrameworkCore.Tools (8.0.8)
echo - Microsoft.AspNetCore.OpenApi (8.0.15)
echo - Swashbuckle.AspNetCore (6.6.2)
echo - System.ComponentModel.Annotations (5.0.0)
echo - Newtonsoft.Json (13.0.3)
echo - xunit (2.5.3) - Solo en Tests
echo.
echo ════════════════════════════════════════════════════════════════
echo.
pause

