@echo off
REM ========================================================================
REM   EJECUTAR PROYECTO EPS V2 COMPLETO
REM   Inicia API y UI en ventanas separadas
REM ========================================================================

color 0B
title EPS V2 FINAL - Ejecutando Proyecto Completo

echo.
echo ╔═══════════════════════════════════════════════════════════════╗
echo ║                                                               ║
echo ║        INICIANDO EPS V2 FINAL - API Y UI                     ║
echo ║                                                               ║
echo ╚═══════════════════════════════════════════════════════════════╝
echo.

REM Verificar compilacion primero
echo [1/3] Compilando proyecto...
dotnet build EPS.sln --no-incremental >nul 2>&1

if %ERRORLEVEL% NEQ 0 (
    echo [ERROR] La compilacion fallo. Revise los errores.
    pause
    exit /b 1
)

echo [OK] Compilacion exitosa
echo.

REM Iniciar API en nueva ventana
echo [2/3] Iniciando API (asp_servicios)...
start "EPS V2 - API" cmd /k "cd /d %~dp0asp_servicios && echo ═══════════════════════════════════════════════════════════ && echo   EPS V2 - API REST (asp_servicios) && echo ═══════════════════════════════════════════════════════════ && echo. && dotnet run && pause"

timeout /t 3 /nobreak >nul

REM Iniciar UI en nueva ventana
echo [3/3] Iniciando UI (asp_presentacion)...
start "EPS V2 - UI" cmd /k "cd /d %~dp0asp_presentacion && echo ═══════════════════════════════════════════════════════════ && echo   EPS V2 - UI Razor Pages (asp_presentacion) && echo ═══════════════════════════════════════════════════════════ && echo. && dotnet run && pause"

timeout /t 3 /nobreak >nul

echo.
echo ═══════════════════════════════════════════════════════════════
echo   PROYECTO INICIADO
echo ═══════════════════════════════════════════════════════════════
echo.
echo [INFO] Se abrieron 2 ventanas:
echo.
echo   1. API REST - Puerto 5047
echo   2. UI Razor Pages - Puerto 5000
echo.
echo [INFO] Abriendo navegador en 5 segundos...
timeout /t 5 /nobreak >nul

REM Abrir navegador
start http://localhost:5000/Afiliados

echo.
echo [OK] Navegador abierto
echo.
echo [INFO] Para detener los servicios, cierre las ventanas de API y UI
echo.
pause

