@echo off
REM ========================================================================
REM   ACTUALIZAR REPOSITORIO EN GITHUB
REM   Este script actualiza la nube (GitHub) con todos los cambios
REM ========================================================================

echo.
echo ╔═══════════════════════════════════════════════════════════════╗
echo ║  ACTUALIZANDO REPOSITORIO EN GITHUB                           ║
echo ╚═══════════════════════════════════════════════════════════════╝
echo.

REM Verificar que estamos en un repositorio Git
git status >nul 2>&1
if %ERRORLEVEL% NEQ 0 (
    echo [ERROR] No se encontró un repositorio Git en esta carpeta.
    echo Asegúrate de estar en la carpeta del proyecto.
    pause
    exit /b 1
)

echo [PASO 1/5] Verificando estado del repositorio...
echo.
git status
echo.

echo [PASO 2/5] Agregando archivos nuevos y modificados...
echo.
git add CONFIGURAR_PROYECTO_AUTOMATICO.bat
git add documentos/GUIA_COMPLETA_ESTUDIO.html
git add documentos/INSTRUCCIONES_INSTALACION_COMPLETA.txt
git add documentos/GUIA_DESPLIEGUE_NUBE.md
git add azure-deploy.yml
git add .github/workflows/azure-deploy.yml
echo [OK] Archivos agregados al staging
echo.

echo [PASO 3/5] Creando commit...
echo.
set /p COMMIT_MSG="Ingresa el mensaje del commit (o presiona Enter para usar mensaje por defecto): "
if "!COMMIT_MSG!"=="" (
    set COMMIT_MSG=Actualización: Script de configuración automática y guía de despliegue en la nube
)

git commit -m "!COMMIT_MSG!"
if %ERRORLEVEL% NEQ 0 (
    echo [ADVERTENCIA] No hay cambios para commitear o el commit falló.
    echo Continuando con el siguiente paso...
)
echo.

echo [PASO 4/5] Verificando remoto...
echo.
git remote -v
echo.

echo [PASO 5/5] Subiendo cambios a GitHub...
echo.
echo [INFO] Esto subirá los cambios a: origin/main
echo.
set /p CONFIRM="¿Deseas continuar con el push? (S/N): "
if /i not "!CONFIRM!"=="S" (
    echo [INFO] Push cancelado por el usuario.
    pause
    exit /b 0
)

git push origin main
if %ERRORLEVEL% NEQ 0 (
    echo.
    echo [ERROR] Error al hacer push. Posibles causas:
    echo - No tienes permisos en el repositorio
    echo - No estás autenticado en GitHub
    echo - Hay conflictos que necesitan resolverse
    echo.
    echo [SOLUCIÓN] Ejecuta manualmente:
    echo   git push origin main
    pause
    exit /b 1
)

echo.
echo ╔═══════════════════════════════════════════════════════════════╗
echo ║  ✅ REPOSITORIO ACTUALIZADO EXITOSAMENTE                      ║
echo ╚═══════════════════════════════════════════════════════════════╝
echo.
echo [RESUMEN]
echo.
echo ✅ Archivos agregados al repositorio
echo ✅ Commit creado
echo ✅ Cambios subidos a GitHub
echo.
echo [PRÓXIMOS PASOS]
echo.
echo 1. Verifica los cambios en GitHub:
echo    https://github.com/kike5767/eps_v2
echo.
echo 2. Si configuraste despliegue automático en Azure, los cambios
echo    se desplegarán automáticamente.
echo.
echo 3. Para desplegar manualmente, sigue la guía:
echo    documentos\GUIA_DESPLIEGUE_NUBE.md
echo.
pause

