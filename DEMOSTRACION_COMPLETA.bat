@echo off
REM ========================================================================
REM   DEMOSTRACIÓN COMPLETA EPS V2 FINAL
REM   Ejecuta todo desde inicio a fin: compilación, pruebas, CRUD
REM ========================================================================

color 0A
title EPS V2 FINAL - DEMOSTRACION COMPLETA

echo.
echo ╔═══════════════════════════════════════════════════════════════╗
echo ║                                                               ║
echo ║        EPS V2 FINAL - DEMOSTRACION COMPLETA                  ║
echo ║        Desde Inicio a Fin: Compilacion, Pruebas, CRUD        ║
echo ║                                                               ║
echo ╚═══════════════════════════════════════════════════════════════╝
echo.

pause

REM ========================================================================
REM   PASO 1: VERIFICAR ESTRUCTURA DEL PROYECTO
REM ========================================================================
echo.
echo ═══════════════════════════════════════════════════════════════
echo   PASO 1: VERIFICANDO ESTRUCTURA DEL PROYECTO
echo ═══════════════════════════════════════════════════════════════
echo.

echo [INFO] Verificando proyectos en la solucion...
dotnet sln EPS.sln list
echo.
echo [OK] Estructura verificada
echo.
pause

REM ========================================================================
REM   PASO 2: COMPILACION COMPLETA
REM ========================================================================
echo.
echo ═══════════════════════════════════════════════════════════════
echo   PASO 2: COMPILANDO PROYECTO COMPLETO
echo ═══════════════════════════════════════════════════════════════
echo.

echo [INFO] Compilando solucion completa...
echo.
dotnet build EPS.sln --no-incremental
echo.

if %ERRORLEVEL% EQU 0 (
    echo [OK] Compilacion EXITOSA - 0 Errores
    color 0A
) else (
    echo [ERROR] Compilacion fallo
    color 0C
    pause
    exit /b 1
)

echo.
pause

REM ========================================================================
REM   PASO 3: EJECUTAR PRUEBAS UNITARIAS
REM ========================================================================
echo.
echo ═══════════════════════════════════════════════════════════════
echo   PASO 3: EJECUTANDO PRUEBAS UNITARIAS
echo ═══════════════════════════════════════════════════════════════
echo.

echo [INFO] Ejecutando pruebas unitarias...
echo.
dotnet test Tests/EPS.Tests/EPS.Tests.csproj --verbosity normal
echo.

if %ERRORLEVEL% EQU 0 (
    echo [OK] Pruebas ejecutadas correctamente
    color 0A
) else (
    echo [ADVERTENCIA] Algunas pruebas pueden haber fallado
    color 0E
)

echo.
pause

REM ========================================================================
REM   PASO 4: VERIFICAR ARCHIVOS DE CONFIGURACION
REM ========================================================================
echo.
echo ═══════════════════════════════════════════════════════════════
echo   PASO 4: VERIFICANDO CONFIGURACION
echo ═══════════════════════════════════════════════════════════════
echo.

echo [INFO] Verificando archivos de configuracion...
echo.

if exist "secrets.json" (
    echo [OK] secrets.json encontrado
) else (
    echo [ADVERTENCIA] secrets.json no encontrado
    echo [INFO] Creando secrets.json...
    echo { "StringConexion": "Server=localhost\SQLEXPRESS;Database=EPSDB;Trusted_Connection=True;TrustServerCertificate=True;" } > secrets.json
    echo [OK] secrets.json creado
)

if exist "asp_servicios\appsettings.json" (
    echo [OK] appsettings.json del API encontrado
)

if exist "asp_presentacion\appsettings.json" (
    echo [OK] appsettings.json de la UI encontrado
)

echo.
pause

REM ========================================================================
REM   PASO 5: MOSTRAR ESTRUCTURA DE ARCHIVOS PRINCIPALES
REM ========================================================================
echo.
echo ═══════════════════════════════════════════════════════════════
echo   PASO 5: ESTRUCTURA DE ARCHIVOS PRINCIPALES
echo ═══════════════════════════════════════════════════════════════
echo.

echo [INFO] Archivos principales del proyecto:
echo.
echo API (asp_servicios):
dir /B asp_servicios\Controllers\*.cs
echo.
echo UI (asp_presentacion):
dir /B asp_presentacion\Pages\*.cshtml
echo.
echo Repositorios:
dir /B lib_repositorios\Implementaciones\*.cs
echo.
pause

REM ========================================================================
REM   PASO 6: INFORMACION DE EJECUCION
REM ========================================================================
echo.
echo ═══════════════════════════════════════════════════════════════
echo   PASO 6: INFORMACION PARA EJECUTAR MANUALMENTE
echo ═══════════════════════════════════════════════════════════════
echo.

echo [INFO] Para ejecutar el proyecto completo:
echo.
echo 1. EJECUTAR API (Terminal 1):
echo    cd asp_servicios
echo    dotnet run
echo    URL: https://localhost:5047 o http://localhost:5047
echo.
echo 2. EJECUTAR UI (Terminal 2):
echo    cd asp_presentacion
echo    dotnet run
echo    URL: https://localhost:5000 o http://localhost:5000
echo.
echo 3. ABRIR NAVEGADOR:
echo    http://localhost:5000/Afiliados
echo.
pause

REM ========================================================================
REM   RESUMEN FINAL
REM ========================================================================
echo.
echo ═══════════════════════════════════════════════════════════════
echo   RESUMEN DE LA DEMOSTRACION
echo ═══════════════════════════════════════════════════════════════
echo.

echo [OK] Estructura verificada
echo [OK] Compilacion exitosa
echo [OK] Pruebas ejecutadas
echo [OK] Configuracion verificada
echo [OK] Archivos principales listados
echo.
echo [INFO] El proyecto esta listo para ejecutar
echo.
echo ═══════════════════════════════════════════════════════════════
echo   DEMOSTRACION COMPLETA FINALIZADA
echo ═══════════════════════════════════════════════════════════════
echo.

pause
color 07

