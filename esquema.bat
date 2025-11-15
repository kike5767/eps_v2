@echo off
echo ============================================
echo   EXTRAYENDO TABLAS Y RELACIONES DEL EPS
echo ============================================
setlocal enabledelayedexpansion

REM Archivo de salida
set OUTPUT=esquema.txt
if exist "%OUTPUT%" del "%OUTPUT%"

REM Recorre todos los .sql y saca lineas con CREATE TABLE, PK, FK y columnas
for /r %%f in (*.sql) do (
    echo ===== Archivo: %%~nxf ===== >> "%OUTPUT%"
    type "%%f" | findstr /I /C:"CREATE TABLE" /C:"PRIMARY KEY" /C:"FOREIGN KEY" /C:"CONSTRAINT" /C:"(" /C:"," >> "%OUTPUT%"
    echo. >> "%OUTPUT%"
)

echo ============================================
echo   PROCESO TERMINADO
echo   Revisa el archivo esquema.txt generado
echo ============================================
pause
