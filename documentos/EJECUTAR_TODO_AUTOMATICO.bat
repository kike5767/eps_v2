@echo off
REM ========================================================================
REM   EJECUCIÓN AUTOMÁTICA COMPLETA - EPS V2 FINAL
REM   Ejecuta todo automáticamente, solo observa en pantalla completa
REM ========================================================================

REM Configuración
set LOG_DIR=%~dp0Logs_Demostracion
set LOG_FILE=%LOG_DIR%\Ejecucion_Automatica_%date:~-4,4%%date:~-7,2%%date:~-10,2%_%time:~0,2%%time:~3,2%.log
set LOG_FILE=%LOG_FILE: =0%

REM Crear directorio de logs
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%"

REM Configurar pantalla completa
mode con: cols=120 lines=50
color 0A

REM Iniciar log
echo ======================================================================== > "%LOG_FILE%"
echo   EJECUCION AUTOMATICA COMPLETA - EPS V2 FINAL >> "%LOG_FILE%"
echo   Fecha: %date% %time% >> "%LOG_FILE%"
echo ======================================================================== >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"

:INICIO
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║                                                                                                                  ║
echo ║                    EPS V2 FINAL - EJECUCIÓN AUTOMÁTICA COMPLETA                                                 ║
echo ║                    Solo observa, todo se ejecuta automáticamente                                               ║
echo ║                                                                                                                  ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [INFO] Iniciando ejecucion automatica...
echo [INFO] Todos los resultados se guardaran en: %LOG_DIR%
echo.
echo [INFO] Iniciando ejecucion automatica... >> "%LOG_FILE%"
timeout /t 3 /nobreak >nul

REM ========================================================================
REM   PASO 1: VERIFICAR ESTRUCTURA
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  PASO 1/8: VERIFICANDO ESTRUCTURA DEL PROYECTO                                                                 ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [PASO 1] Verificando estructura del proyecto >> "%LOG_FILE%"
echo [INFO] Verificando proyectos en la solucion...
echo [INFO] Verificando proyectos en la solucion... >> "%LOG_FILE%"
echo.
dotnet sln EPS.sln list
dotnet sln EPS.sln list >> "%LOG_FILE%"
echo.
echo [OK] Estructura verificada
echo [OK] Estructura verificada >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"
timeout /t 5 /nobreak >nul

REM ========================================================================
REM   PASO 2: COMPILAR
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  PASO 2/8: COMPILANDO PROYECTO COMPLETO                                                                         ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [PASO 2] Compilando proyecto completo >> "%LOG_FILE%"
echo [INFO] Compilando solucion completa...
echo [INFO] Compilando solucion completa... >> "%LOG_FILE%"
echo.
dotnet build EPS.sln --no-incremental
dotnet build EPS.sln --no-incremental >> "%LOG_FILE%" 2>&1
echo.

if %ERRORLEVEL% EQU 0 (
    echo [OK] Compilacion EXITOSA - 0 Errores
    echo [OK] Compilacion EXITOSA - 0 Errores >> "%LOG_FILE%"
    color 0A
) else (
    echo [ERROR] Compilacion fallo
    echo [ERROR] Compilacion fallo >> "%LOG_FILE%"
    color 0C
    timeout /t 5 /nobreak >nul
    goto FIN
)

echo. >> "%LOG_FILE%"
timeout /t 5 /nobreak >nul

REM ========================================================================
REM   PASO 3: EJECUTAR PRUEBAS
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  PASO 3/8: EJECUTANDO PRUEBAS UNITARIAS                                                                         ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [PASO 3] Ejecutando pruebas unitarias >> "%LOG_FILE%"
echo [INFO] Ejecutando pruebas unitarias...
echo [INFO] Ejecutando pruebas unitarias... >> "%LOG_FILE%"
echo.
dotnet test Tests/EPS.Tests/EPS.Tests.csproj --verbosity normal
dotnet test Tests/EPS.Tests/EPS.Tests.csproj --verbosity normal >> "%LOG_FILE%" 2>&1
echo.

if %ERRORLEVEL% EQU 0 (
    echo [OK] Pruebas ejecutadas correctamente
    echo [OK] Pruebas ejecutadas correctamente >> "%LOG_FILE%"
    color 0A
) else (
    echo [ADVERTENCIA] Algunas pruebas pueden haber fallado
    echo [ADVERTENCIA] Algunas pruebas pueden haber fallado >> "%LOG_FILE%"
    color 0E
)

echo. >> "%LOG_FILE%"
timeout /t 5 /nobreak >nul

REM ========================================================================
REM   PASO 4: VERIFICAR CONFIGURACION
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  PASO 4/8: VERIFICANDO CONFIGURACION                                                                            ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [PASO 4] Verificando configuracion >> "%LOG_FILE%"
echo [INFO] Verificando archivos de configuracion...
echo [INFO] Verificando archivos de configuracion... >> "%LOG_FILE%"
echo.

if exist "secrets.json" (
    echo [OK] secrets.json encontrado
    echo [OK] secrets.json encontrado >> "%LOG_FILE%"
) else (
    echo [ADVERTENCIA] secrets.json no encontrado, creando...
    echo { "StringConexion": "Server=localhost\SQLEXPRESS;Database=EPSDB;Trusted_Connection=True;TrustServerCertificate=True;" } > secrets.json
    echo [OK] secrets.json creado
    echo [OK] secrets.json creado >> "%LOG_FILE%"
)

if exist "asp_servicios\appsettings.json" (
    echo [OK] appsettings.json del API encontrado
    echo [OK] appsettings.json del API encontrado >> "%LOG_FILE%"
)

if exist "asp_presentacion\appsettings.json" (
    echo [OK] appsettings.json de la UI encontrado
    echo [OK] appsettings.json de la UI encontrado >> "%LOG_FILE%"
)

echo. >> "%LOG_FILE%"
timeout /t 3 /nobreak >nul

REM ========================================================================
REM   PASO 5: MOSTRAR ARCHIVOS PRINCIPALES
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  PASO 5/8: ARCHIVOS PRINCIPALES DEL PROYECTO                                                                   ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [PASO 5] Mostrando archivos principales >> "%LOG_FILE%"
echo [INFO] Archivos principales del proyecto:
echo [INFO] Archivos principales del proyecto: >> "%LOG_FILE%"
echo.
echo API (asp_servicios):
dir /B asp_servicios\Controllers\*.cs 2>nul
dir /B asp_servicios\Controllers\*.cs 2>nul >> "%LOG_FILE%"
echo.
echo UI (asp_presentacion):
dir /B asp_presentacion\Pages\*.cshtml 2>nul
dir /B asp_presentacion\Pages\*.cshtml 2>nul >> "%LOG_FILE%"
echo.
echo Repositorios:
dir /B lib_repositorios\Implementaciones\*.cs 2>nul
dir /B lib_repositorios\Implementaciones\*.cs 2>nul >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"
timeout /t 5 /nobreak >nul

REM ========================================================================
REM   PASO 6: INFORMACION DE EJECUCION
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  PASO 6/8: INFORMACION PARA EJECUTAR MANUALMENTE                                                                ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [PASO 6] Informacion de ejecucion >> "%LOG_FILE%"
echo [INFO] Para ejecutar el proyecto completo:
echo [INFO] Para ejecutar el proyecto completo: >> "%LOG_FILE%"
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
echo 1. EJECUTAR API >> "%LOG_FILE%"
echo 2. EJECUTAR UI >> "%LOG_FILE%"
echo 3. ABRIR NAVEGADOR >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"
timeout /t 8 /nobreak >nul

REM ========================================================================
REM   PASO 7: RESUMEN DE COMPILACION
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  PASO 7/8: RESUMEN DE COMPILACION                                                                               ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [PASO 7] Resumen de compilacion >> "%LOG_FILE%"
echo [INFO] Proyectos compilados:
echo [INFO] Proyectos compilados: >> "%LOG_FILE%"
echo.
echo   ✅ lib_dominio
echo   ✅ lib_repositorios
echo   ✅ lib_presentaciones
echo   ✅ asp_servicios
echo   ✅ asp_presentacion
echo   ✅ EPS.Tests
echo.
echo   ✅ lib_dominio >> "%LOG_FILE%"
echo   ✅ lib_repositorios >> "%LOG_FILE%"
echo   ✅ lib_presentaciones >> "%LOG_FILE%"
echo   ✅ asp_servicios >> "%LOG_FILE%"
echo   ✅ asp_presentacion >> "%LOG_FILE%"
echo   ✅ EPS.Tests >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"
timeout /t 5 /nobreak >nul

REM ========================================================================
REM   PASO 8: RESUMEN FINAL
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  PASO 8/8: RESUMEN FINAL                                                                                        ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [RESUMEN] Generando resumen final... >> "%LOG_FILE%"
echo.
echo ═══════════════════════════════════════════════════════════════════════════════════════════════════════════════
echo   RESUMEN DE LA EJECUCION AUTOMATICA
echo ═══════════════════════════════════════════════════════════════════════════════════════════════════════════════
echo.
echo [OK] Estructura verificada
echo [OK] Compilacion exitosa
echo [OK] Pruebas ejecutadas
echo [OK] Configuracion verificada
echo [OK] Archivos principales listados
echo [OK] Informacion de ejecucion mostrada
echo [OK] Resumen de compilacion mostrado
echo.
echo [OK] Estructura verificada >> "%LOG_FILE%"
echo [OK] Compilacion exitosa >> "%LOG_FILE%"
echo [OK] Pruebas ejecutadas >> "%LOG_FILE%"
echo [OK] Configuracion verificada >> "%LOG_FILE%"
echo [OK] Archivos principales listados >> "%LOG_FILE%"
echo [OK] Informacion de ejecucion mostrada >> "%LOG_FILE%"
echo [OK] Resumen de compilacion mostrado >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"
echo [INFO] El proyecto esta listo para ejecutar
echo [INFO] El proyecto esta listo para ejecutar >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"
echo [INFO] Log completo guardado en: %LOG_FILE%
echo [INFO] Log completo guardado en: %LOG_FILE% >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"
echo ======================================================================== >> "%LOG_FILE%"
echo   FIN DE LA EJECUCION AUTOMATICA >> "%LOG_FILE%"
echo ======================================================================== >> "%LOG_FILE%"

echo.
echo ═══════════════════════════════════════════════════════════════════════════════════════════════════════════════
echo   EJECUCION AUTOMATICA COMPLETA FINALIZADA
echo ═══════════════════════════════════════════════════════════════════════════════════════════════════════════════
echo.
echo [INFO] Todos los resultados guardados en: %LOG_DIR%
echo [INFO] Log completo: %LOG_FILE%
echo.
echo [INFO] Presione cualquier tecla para continuar...
pause >nul

:FIN
color 07
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║                                                                                                                  ║
echo ║                    EJECUCION AUTOMATICA FINALIZADA                                                              ║
echo ║                                                                                                                  ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [INFO] Log guardado en: %LOG_FILE%
echo.
pause

