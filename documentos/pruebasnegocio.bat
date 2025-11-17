@echo off
REM Ejecutar pruebas de negocio del proyecto EPS.Tests

cd /d C:\EPS_v2\Tests\EPS.Tests

echo ================================
echo Ejecutando pruebas de negocio...
echo ================================

dotnet test --filter Category=Negocio --logger "trx;LogFileName=TestResults\NegocioTests.trx"

echo ================================
echo Pruebas completadas.
echo Archivo generado: TestResults\NegocioTests.trx
echo ================================

pause