@echo off
REM ========================================================================
REM   ABRIR PROYECTO EN VISUAL STUDIO
REM   Abre el proyecto EPS.sln en Visual Studio
REM ========================================================================

echo.
echo ╔═══════════════════════════════════════════════════════════════╗
echo ║                                                               ║
echo ║        ABRIENDO EPS V2 EN VISUAL STUDIO                      ║
echo ║                                                               ║
echo ╚═══════════════════════════════════════════════════════════════╝
echo.

set "SOLUTION_PATH=%~dp0EPS.sln"

if not exist "%SOLUTION_PATH%" (
    echo [ERROR] No se encontro EPS.sln en la ruta actual
    echo [INFO] Ruta buscada: %SOLUTION_PATH%
    pause
    exit /b 1
)

echo [INFO] Abriendo solucion en Visual Studio...
echo [INFO] Archivo: %SOLUTION_PATH%
echo.

REM Intentar abrir con Visual Studio
start "" "%SOLUTION_PATH%"

if %ERRORLEVEL% EQU 0 (
    echo [OK] Visual Studio se esta abriendo...
    echo.
    echo [INFO] Pasos siguientes en Visual Studio:
    echo    1. Esperar a que cargue la solucion
    echo    2. Build Solution (Ctrl+Shift+B)
    echo    3. Ejecutar pruebas (Test Explorer)
    echo    4. Ejecutar API o UI (F5)
    echo.
) else (
    echo [ADVERTENCIA] No se pudo abrir automaticamente
    echo [INFO] Abra Visual Studio manualmente y abra EPS.sln
    echo.
)

echo [INFO] Ver guia completa en: EJECUCION_VISUAL_STUDIO.md
echo.
pause

