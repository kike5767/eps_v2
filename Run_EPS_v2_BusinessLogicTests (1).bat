@echo off
echo ============================================================
echo   INICIANDO PRUEBAS DE LOGICA DE NEGOCIO EPS_v2 (Business)  
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
echo Compilando proyecto...
dotnet build > build_log_business.txt

IF %ERRORLEVEL% NEQ 0 (
    echo ERROR: Fallo la compilacion. Revise build_log_business.txt
    pause
    exit /b %ERRORLEVEL%
)

echo Compilacion correcta. Revisar build_log_business.txt para advertencias.
echo.

:: 3. Ejecutar pruebas de logica de negocio
IF NOT EXIST "Tests\EPS.Tests" (
    echo ERROR: La carpeta de pruebas Tests\EPS.Tests no existe.
    pause
    exit /b 1
)

cd Tests\EPS.Tests

echo Ejecutando pruebas de logica de negocio...
dotnet test --filter "Category=BusinessLogic" --logger "console;verbosity=normal" --logger "trx;LogFileName=TestResults_Business.trx" > TestResults\TestResults_Business.txt

IF %ERRORLEVEL% NEQ 0 (
    echo ERROR: Algunas pruebas de negocio fallaron. Revise TestResults\TestResults_Business.txt
    pause
    exit /b %ERRORLEVEL%
)

echo.
echo ============================================================
echo TODAS LAS PRUEBAS DE LOGICA DE NEGOCIO FINALIZARON CORRECTAMENTE
echo Logs generados:
echo   - build_log_business.txt (compilacion)
echo   - TestResults\TestResults_Business.txt (resultado pruebas)
echo   - TestResults\TestResults_Business.trx (para VS Test Explorer)
echo ============================================================

pause
