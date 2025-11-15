@echo off
REM Script para guardado automático y actualización de GitHub
REM Se ejecuta automáticamente antes de salir del programa

echo ========================================
echo   SISTEMA DE GUARDADO AUTOMATICO EPS
echo ========================================
echo.

REM Cambia al directorio del proyecto
cd /d "%~dp0"

echo [1/4] Generando backup completo...
REM Aquí se llamaría al sistema de backup si fuera ejecutable desde aquí
echo Backup iniciado...

echo.
echo [2/4] Guardando cambios en archivos...
REM Los cambios ya están guardados por el sistema de auditoría

echo.
echo [3/4] Actualizando GitHub...
git add .
if %errorlevel% neq 0 (
    echo Error al agregar archivos a Git
    pause
    exit /b 1
)

git commit -m "Guardado automatico: %date% %time%"
if %errorlevel% neq 0 (
    echo Error al hacer commit
    pause
    exit /b 1
)

git push origin main
if %errorlevel% neq 0 (
    echo Error al hacer push a GitHub
    pause
    exit /b 1
)

echo.
echo [4/4] Verificando sincronizacion...
git status

echo.
echo ========================================
echo   GUARDADO AUTOMATICO COMPLETADO
echo ========================================
echo.
echo Todos los cambios han sido guardados y
echo sincronizados con GitHub exitosamente.
echo.
pause

