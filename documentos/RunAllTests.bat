@echo off
echo ===========================================
echo   INICIANDO COMPILACION Y PRUEBAS EPS_v2
echo ===========================================
echo.

:: 1. Moverse a la carpeta del proyecto
cd /d C:\EPS_v2

:: 2. Compilar solucion completa
echo Compilando proyecto...
dotnet build > build_log.txt

IF %ERRORLEVEL% NEQ 0 (
    echo ERROR: Fallo la compilacion. Revise build_log.txt
    pause
    exit /b %ERRORLEVEL%
)

echo Compilacion correcta. Revisar build_log.txt para advertencias.
echo.

:: 3. Ejecutar pruebas unitarias
echo Ejecutando pruebas unitarias...
cd Tests\EPS.Tests

dotnet test --logger "console;verbosity=normal" --logger "trx;LogFileName=TestResults.trx" > test_log.txt

IF %ERRORLEVEL% NEQ 0 (
    echo ERROR: Algunas pruebas fallaron. Revise test_log.txt y TestResults.trx
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo ===========================================
echo TODAS LAS PRUEBAS FINALIZARON CORRECTAMENTE
echo Logs generados:
echo   - build_log.txt (compilacion)
echo   - test_log.txt  (resultado pruebas)
echo   - TestResults.trx (para VS Test Explorer)
echo ===========================================

pause
