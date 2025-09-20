@echo off
echo ============================================
echo   EXTRAYENDO TABLAS Y RELACIONES DEL EPS
echo ============================================
setlocal enabledelayedexpansion

REM Archivo de salida
set OUTPUT=esquema.txt
if exist %OUTPUT% del %OUTPUT%

REM Recorre todos los .sql y filtra
for /r %%f in (*.sql) do (
    echo ===== Archivo: %%~nxf ===== >> %OUTPUT%
    for /f "usebackq delims=" %%l in ("%%f") do (
        echo %%l | findstr /I /R /C:"CREATE TABLE" /C:"PRIMARY KEY" /C:"FOREIGN KEY" /C:"CONSTRAINT" /C:" int " /C:" varchar" /C:" date" /C:" decimal" >> %OUTPUT%
    )
    echo. >> %OUTPUT%
)

echo ============================================
echo   PROCESO TERMINADO
echo   Revisa el archivo esquema.txt generado
echo ============================================
pause
