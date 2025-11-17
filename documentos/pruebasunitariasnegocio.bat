@echo off
echo ============================================================
echo   INICIANDO PRUEBAS DE LOGICA DE NEGOCIO - EPS_v2
echo ============================================================
echo.

:: 1. Verificar carpeta del proyecto
IF NOT EXIST "C:\EPS_v2" (
    echo ERROR: La carpeta C:\EPS_v2 no existe.
    pause
    exit /b 1
)

cd /d C:\EPS_v2

:: 2. Compilar solucion completa
echo Compilando proyecto EPS_v2...
dotnet build > TestResults\build_log_business.txt

IF %ERRORLEVEL% NEQ 0 (
    echo ERROR: Fallo la compilacion. Revise TestResults\build_log_business.txt
    pause
    exit /b %ERRORLEVEL%
)

echo Compilacion correcta. Revisar TestResults\build_log_business.txt para advertencias.
echo.

:: 3. Verificar carpeta de pruebas
IF NOT EXIST "Tests\EPS.Tests" (
    echo ERROR: La carpeta Tests\EPS.Tests no existe.
    pause
    exit /b 1
)

cd Tests\EPS.Tests

:: 4. Ejecutar pruebas de logica de negocio
echo Ejecutando pruebas de logica de negocio...
dotnet test --filter "TestCategory=BusinessLogic" --logger "console;verbosity=normal" --logger "trx;LogFileName=TestResults_Business.trx" > TestResults\TestResults_Business.txt

IF %ERRORLEVEL% NEQ 0 (
    echo ERROR: Algunas pruebas de logica de negocio fallaron. Revise TestResults\TestResults_Business.txt y TestResults_Business.trx
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo ============================================================
echo TODAS LAS PRUEBAS DE LOGICA DE NEGOCIO FINALIZARON CORRECTAMENTE
echo Archivos generados:
echo   - TestResults\build_log_business.txt
echo   - TestResults\TestResults_Business.txt
echo   - TestResults_Business.trx
echo ============================================================

pause