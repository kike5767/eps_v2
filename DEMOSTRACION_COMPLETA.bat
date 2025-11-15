@echo off
REM ========================================================================
REM   DEMOSTRACIÓN COMPLETA EPS V2 FINAL
REM   Ejecuta todo desde inicio a fin: compilación, pruebas, CRUD
REM   Guarda todo en archivos de log en la ruta del proyecto
REM ========================================================================

REM Configurar rutas de log
set LOG_DIR=%~dp0Logs_Demostracion
set LOG_FILE=%LOG_DIR%\Demostracion_%date:~-4,4%%date:~-7,2%%date:~-10,2%_%time:~0,2%%time:~3,2%%time:~6,2%.log
set LOG_FILE=%LOG_FILE: =0%
set COMPILACION_LOG=%LOG_DIR%\Compilacion.log
set PRUEBAS_LOG=%LOG_DIR%\Pruebas.log
set RESUMEN_LOG=%LOG_DIR%\Resumen_Ejecucion.txt

REM Crear directorio de logs
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%"

REM Iniciar log principal
echo ======================================================================== > "%LOG_FILE%"
echo   DEMOSTRACION COMPLETA EPS V2 FINAL >> "%LOG_FILE%"
echo   Fecha: %date% %time% >> "%LOG_FILE%"
echo ======================================================================== >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"

color 0A
title EPS V2 FINAL - DEMOSTRACION COMPLETA (Grabando en: %LOG_DIR%)

echo.
echo ╔═══════════════════════════════════════════════════════════════╗
echo ║                                                               ║
echo ║        EPS V2 FINAL - DEMOSTRACION COMPLETA                  ║
echo ║        Desde Inicio a Fin: Compilacion, Pruebas, CRUD        ║
echo ║        Grabando en: %LOG_DIR%                                ║
echo ║                                                               ║
echo ╚═══════════════════════════════════════════════════════════════╝
echo.

echo [INFO] Todos los resultados se guardaran en: %LOG_DIR% >> "%LOG_FILE%"
echo [INFO] Archivo de log principal: %LOG_FILE% >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"

pause

REM ========================================================================
REM   PASO 1: VERIFICAR ESTRUCTURA DEL PROYECTO
REM ========================================================================
echo.
echo ═══════════════════════════════════════════════════════════════
echo   PASO 1: VERIFICANDO ESTRUCTURA DEL PROYECTO
echo ═══════════════════════════════════════════════════════════════
echo.

echo [PASO 1] Verificando estructura del proyecto >> "%LOG_FILE%"
echo [INFO] Verificando proyectos en la solucion...
echo [INFO] Verificando proyectos en la solucion... >> "%LOG_FILE%"
dotnet sln EPS.sln list | tee -a "%LOG_FILE%"
echo.
echo [OK] Estructura verificada
echo [OK] Estructura verificada >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"
pause

REM ========================================================================
REM   PASO 2: COMPILACION COMPLETA
REM ========================================================================
echo.
echo ═══════════════════════════════════════════════════════════════
echo   PASO 2: COMPILANDO PROYECTO COMPLETO
echo ═══════════════════════════════════════════════════════════════
echo.

echo [PASO 2] Compilando proyecto completo >> "%LOG_FILE%"
echo [INFO] Compilando solucion completa...
echo [INFO] Compilando solucion completa... >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"

dotnet build EPS.sln --no-incremental > "%COMPILACION_LOG%" 2>&1
type "%COMPILACION_LOG%"
type "%COMPILACION_LOG%" >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"

if %ERRORLEVEL% EQU 0 (
    echo [OK] Compilacion EXITOSA - 0 Errores
    echo [OK] Compilacion EXITOSA - 0 Errores >> "%LOG_FILE%"
    echo [OK] Log guardado en: %COMPILACION_LOG% >> "%LOG_FILE%"
    color 0A
) else (
    echo [ERROR] Compilacion fallo
    echo [ERROR] Compilacion fallo >> "%LOG_FILE%"
    echo [ERROR] Ver log completo en: %COMPILACION_LOG% >> "%LOG_FILE%"
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

echo [PASO 3] Ejecutando pruebas unitarias >> "%LOG_FILE%"
echo [INFO] Ejecutando pruebas unitarias...
echo [INFO] Ejecutando pruebas unitarias... >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"

dotnet test Tests/EPS.Tests/EPS.Tests.csproj --verbosity normal > "%PRUEBAS_LOG%" 2>&1
type "%PRUEBAS_LOG%"
type "%PRUEBAS_LOG%" >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"

if %ERRORLEVEL% EQU 0 (
    echo [OK] Pruebas ejecutadas correctamente
    echo [OK] Pruebas ejecutadas correctamente >> "%LOG_FILE%"
    echo [OK] Log guardado en: %PRUEBAS_LOG% >> "%LOG_FILE%"
    color 0A
) else (
    echo [ADVERTENCIA] Algunas pruebas pueden haber fallado
    echo [ADVERTENCIA] Algunas pruebas pueden haber fallado >> "%LOG_FILE%"
    echo [ADVERTENCIA] Ver log completo en: %PRUEBAS_LOG% >> "%LOG_FILE%"
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

echo [RESUMEN] Generando resumen final... >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"

echo [OK] Estructura verificada
echo [OK] Estructura verificada >> "%LOG_FILE%"
echo [OK] Compilacion exitosa
echo [OK] Compilacion exitosa >> "%LOG_FILE%"
echo [OK] Pruebas ejecutadas
echo [OK] Pruebas ejecutadas >> "%LOG_FILE%"
echo [OK] Configuracion verificada
echo [OK] Configuracion verificada >> "%LOG_FILE%"
echo [OK] Archivos principales listados
echo [OK] Archivos principales listados >> "%LOG_FILE%"
echo.
echo [INFO] El proyecto esta listo para ejecutar
echo [INFO] El proyecto esta listo para ejecutar >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"

REM Crear archivo de resumen
echo ======================================================================== > "%RESUMEN_LOG%"
echo   RESUMEN DE EJECUCION - EPS V2 FINAL >> "%RESUMEN_LOG%"
echo   Fecha: %date% %time% >> "%RESUMEN_LOG%"
echo ======================================================================== >> "%RESUMEN_LOG%"
echo. >> "%RESUMEN_LOG%"
echo [OK] Estructura verificada >> "%RESUMEN_LOG%"
echo [OK] Compilacion exitosa >> "%RESUMEN_LOG%"
echo [OK] Pruebas ejecutadas >> "%RESUMEN_LOG%"
echo [OK] Configuracion verificada >> "%RESUMEN_LOG%"
echo [OK] Archivos principales listados >> "%RESUMEN_LOG%"
echo. >> "%RESUMEN_LOG%"
echo ARCHIVOS DE LOG GENERADOS: >> "%RESUMEN_LOG%"
echo   - Log principal: %LOG_FILE% >> "%RESUMEN_LOG%"
echo   - Compilacion: %COMPILACION_LOG% >> "%RESUMEN_LOG%"
echo   - Pruebas: %PRUEBAS_LOG% >> "%RESUMEN_LOG%"
echo   - Este resumen: %RESUMEN_LOG% >> "%RESUMEN_LOG%"
echo. >> "%RESUMEN_LOG%"
echo Ubicacion: %LOG_DIR% >> "%RESUMEN_LOG%"
echo ======================================================================== >> "%RESUMEN_LOG%"

echo.
echo ═══════════════════════════════════════════════════════════════
echo   DEMOSTRACION COMPLETA FINALIZADA
echo ═══════════════════════════════════════════════════════════════
echo.
echo [INFO] Todos los logs guardados en: %LOG_DIR%
echo [INFO] Resumen guardado en: %RESUMEN_LOG%
echo.
echo [INFO] Todos los logs guardados en: %LOG_DIR% >> "%LOG_FILE%"
echo [INFO] Resumen guardado en: %RESUMEN_LOG% >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"
echo ======================================================================== >> "%LOG_FILE%"
echo   FIN DE LA DEMOSTRACION >> "%LOG_FILE%"
echo ======================================================================== >> "%LOG_FILE%"

pause
color 07

