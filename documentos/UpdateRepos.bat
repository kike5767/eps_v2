@echo off
echo ================================================
echo   SINCRONIZANDO EPS_v2 CON GITHUB
echo ================================================
cd /d C:\EPS_v2

:: Asegurar rama main
git branch -M main

:: Subir al repositorio bueno (eps_v2)
echo Subiendo a eps_v2...
git remote set-url origin https://github.com/kike5767/eps_v2.git
git add .
git commit -m "Actualizacion EPS_v2: version estable con pruebas"
git push -u origin main --force

echo ================================================
echo   AHORA ACTUALIZANDO REPO VIEJO EPS
echo ================================================
:: Enviar el mismo código al repo viejo eps
git remote add eps https://github.com/kike5767/eps.git
git push eps main --force

echo ================================================
echo   PROCESO TERMINADO: ambos repos sincronizados
echo ================================================
pause
