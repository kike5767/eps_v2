@echo off
REM ========================================================================
REM   CREAR DOCUMENTO WORD DESDE HTML
REM   Convierte GUIA_COMPLETA_ESTUDIO.html a Word
REM ========================================================================

echo.
echo ╔═══════════════════════════════════════════════════════════════╗
echo ║  CREANDO DOCUMENTO WORD DE ESTUDIO                            ║
echo ╚═══════════════════════════════════════════════════════════════╝
echo.

set HTML_FILE=GUIA_COMPLETA_ESTUDIO.html
set WORD_FILE=GUIA_COMPLETA_ESTUDIO.docx

if not exist "%HTML_FILE%" (
    echo [ERROR] No se encontro %HTML_FILE%
    pause
    exit /b 1
)

echo [INFO] Abriendo %HTML_FILE% en el navegador...
echo [INFO] INSTRUCCIONES:
echo.
echo 1. El archivo HTML se abrira en tu navegador
echo 2. Presiona Ctrl+P (Imprimir)
echo 3. Selecciona "Guardar como PDF" o "Microsoft Print to PDF"
echo.
echo O alternativamente:
echo - Abre el archivo HTML directamente en Microsoft Word
echo - Word lo convertira automaticamente
echo - Guarda como .docx
echo.

start %HTML_FILE%

echo.
echo [INFO] Si Word esta instalado, intentando conversion automatica...
echo.

REM Intentar abrir en Word si esta disponible
where winword >nul 2>&1
if %ERRORLEVEL% EQU 0 (
    echo [INFO] Word encontrado, abriendo HTML en Word...
    start winword "%HTML_FILE%"
    echo [INFO] En Word: Archivo ^> Guardar como ^> Documento Word (.docx)
) else (
    echo [INFO] Word no encontrado en PATH, usa el metodo manual arriba
)

echo.
echo [INFO] El documento Word se guardara en: %~dp0%WORD_FILE%
echo.
pause

