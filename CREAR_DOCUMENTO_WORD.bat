@echo off
REM Script para crear documento Word desde HTML
REM EPS V2 Final

echo ========================================
echo   CREAR DOCUMENTO WORD DESDE HTML
echo   EPS V2 Final
echo ========================================
echo.

set HTML_FILE=RESUMEN_CAMBIOS_EPS_V2.html
set WORD_FILE=RESUMEN_CAMBIOS_EPS_V2.docx

echo Abriendo %HTML_FILE% en el navegador predeterminado...
echo.
echo INSTRUCCIONES:
echo 1. El archivo HTML se abrirá en su navegador
echo 2. Presione Ctrl+P (Imprimir)
echo 3. Seleccione "Guardar como PDF" o "Microsoft Print to PDF"
echo 4. O copie todo (Ctrl+A, Ctrl+C) y péguelo en Word
echo.
echo Alternativamente:
echo - Abra el archivo HTML directamente en Microsoft Word
echo - Word lo convertirá automáticamente
echo - Guarde como .docx
echo.

start %HTML_FILE%

echo.
echo Presione cualquier tecla para continuar...
pause >nul

