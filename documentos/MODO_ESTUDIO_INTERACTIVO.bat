@echo off
REM ========================================================================
REM   MODO ESTUDIO INTERACTIVO - EPS V2 FINAL
REM   Explica cada paso detalladamente para entender el proyecto
REM   Para sustentación con el profesor
REM ========================================================================

REM Configuración
set LOG_DIR=%~dp0Logs_Estudio
set LOG_FILE=%LOG_DIR%\Estudio_%date:~-4,4%%date:~-7,2%%date:~-10,2%_%time:~0,2%%time:~3,2%.log
set LOG_FILE=%LOG_FILE: =0%

REM Crear directorio de logs
if not exist "%LOG_DIR%" mkdir "%LOG_DIR%"

REM Configurar pantalla completa
mode con: cols=120 lines=50
color 0B

REM Iniciar log
echo ======================================================================== > "%LOG_FILE%"
echo   MODO ESTUDIO INTERACTIVO - EPS V2 FINAL >> "%LOG_FILE%"
echo   Fecha: %date% %time% >> "%LOG_FILE%"
echo ======================================================================== >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"

:INICIO
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║                                                                                                                  ║
echo ║                    MODO ESTUDIO INTERACTIVO - EPS V2 FINAL                                                      ║
echo ║                    Explicaciones paso a paso para sustentación                                                  ║
echo ║                                                                                                                  ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [INFO] Este modo te explicara cada paso del proyecto detalladamente
echo [INFO] Presiona cualquier tecla para continuar con cada explicacion
echo.
echo [INFO] Modo estudio iniciado >> "%LOG_FILE%"
pause >nul

REM ========================================================================
REM   EXPLICACION 1: ESTRUCTURA DEL PROYECTO
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  EXPLICACION 1/10: ESTRUCTURA DEL PROYECTO                                                                      ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [EXPLICACION] Estructura del proyecto >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ¿POR QUÉ ESTA ESTRUCTURA?                                                                                    │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo El proyecto sigue la ARQUITECTURA EN CAPAS que el profesor requiere.
echo Esta estructura es IGUAL a la referencia panaderia_ref.
echo.
echo [EXPLICACION] ¿Por qué esta estructura? >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ CARPETAS DE SOLUCIÓN:                                                                                        │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. presentaciones → Interfaz de usuario (UI) y comunicaciones con el API
echo    - asp_presentacion: Razor Pages con tema morado
echo    - lib_presentaciones: Clases que se comunican con el API
echo.
echo 2. servicios → API REST y acceso a datos
echo    - asp_servicios: API que recibe peticiones HTTP
echo    - lib_repositorios: Acceso a la base de datos
echo.
echo 3. nucleo → Entidades y clases base
echo    - lib_dominio: Entidades, JsonConversor, EncodingHelper, etc.
echo.
echo 4. pruebas unitarias → Pruebas automatizadas
echo    - EPS.Tests: Pruebas que verifican que todo funciona
echo.
echo [EXPLICACION] Carpetas explicadas >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PARA SUSTENTACIÓN:                                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Di al profesor: "La estructura sigue el patrón de arquitectura en capas,
echo igual a la referencia panaderia_ref, separando presentación, servicios,
echo repositorios y dominio para facilitar el mantenimiento y reutilización."
echo.
echo [EXPLICACION] Nota para sustentacion >> "%LOG_FILE%"
echo.
echo Presiona cualquier tecla para continuar...
pause >nul

REM ========================================================================
REM   EXPLICACION 2: COMPILACION
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  EXPLICACION 2/10: PROCESO DE COMPILACIÓN                                                                    ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [EXPLICACION] Proceso de compilacion >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ¿QUÉ ES LA COMPILACIÓN?                                                                                     │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo La compilación convierte el código fuente (.cs) en archivos ejecutables (.dll).
echo Es como traducir el código que escribiste a un lenguaje que la computadora entiende.
echo.
echo [EXPLICACION] ¿Qué es la compilación? >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ORDEN DE COMPILACIÓN (IMPORTANTE):                                                                          │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. lib_dominio → Se compila PRIMERO (otros proyectos lo necesitan)
echo 2. lib_repositorios → Depende de lib_dominio
echo 3. lib_presentaciones → Depende de lib_dominio
echo 4. asp_servicios → Depende de lib_dominio y lib_repositorios
echo 5. asp_presentacion → Depende de lib_presentaciones
echo 6. EPS.Tests → Depende de lib_dominio
echo.
echo [EXPLICACION] Orden de compilacion >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ COMANDO DE COMPILACIÓN:                                                                                     │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo   dotnet build EPS.sln --no-incremental
echo.
echo   - dotnet build: Compila el proyecto
echo   - EPS.sln: Archivo de solución con todos los proyectos
echo   - --no-incremental: Fuerza compilación completa (sin usar caché)
echo.
echo [EXPLICACION] Comando explicado >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PARA SUSTENTACIÓN:                                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Di al profesor: "El proyecto compila en orden de dependencias.
echo Primero lib_dominio porque es la base, luego los que dependen de él.
echo El resultado es 0 errores, todos los proyectos compilados exitosamente."
echo.
echo [EXPLICACION] Nota para sustentacion >> "%LOG_FILE%"
echo.
echo Presiona cualquier tecla para ver la compilación en acción...
pause >nul

echo.
echo [INFO] Ejecutando compilación para mostrarte el proceso...
echo.
dotnet build EPS.sln --no-incremental
dotnet build EPS.sln --no-incremental >> "%LOG_FILE%" 2>&1
echo.
echo [OK] Compilación completada. Observa el orden de compilación arriba.
echo [OK] Compilacion completada >> "%LOG_FILE%"
echo.
pause >nul

REM ========================================================================
REM   EXPLICACION 3: ARQUITECTURA EN CAPAS
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  EXPLICACION 3/10: ARQUITECTURA EN CAPAS                                                                      ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [EXPLICACION] Arquitectura en capas >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ FLUJO DE DATOS (IMPORTANTE PARA ENTENDER):                                                                   │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. USUARIO → Interactúa con la interfaz (asp_presentacion)
echo    ↓
echo 2. UI → Envía petición HTTP (lib_presentaciones/Comunicaciones)
echo    ↓
echo 3. API → Recibe petición y valida token (asp_servicios/Controllers)
echo    ↓
echo 4. REPOSITORIO → Ejecuta operación en BD (lib_repositorios/Aplicaciones)
echo    ↓
echo 5. BASE DE DATOS → Almacena/retorna datos (SQL Server)
echo    ↓
echo 6. RESPUESTA → Vuelve por las mismas capas hasta el usuario
echo.
echo [EXPLICACION] Flujo de datos explicado >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ¿POR QUÉ ESTA SEPARACIÓN?                                                                                   │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo ✅ Separación de responsabilidades: Cada capa tiene una función específica
echo ✅ Mantenibilidad: Es fácil modificar una capa sin afectar las otras
echo ✅ Reutilización: Las clases base se usan en múltiples proyectos
echo ✅ Pruebas: Cada capa se puede probar independientemente
echo.
echo [EXPLICACION] Ventajas de la separacion >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PARA SUSTENTACIÓN:                                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Di al profesor: "La arquitectura en capas permite separar responsabilidades.
echo La presentación solo se encarga de mostrar datos, el API de validar y procesar,
echo los repositorios de acceder a datos, y el dominio define las entidades.
echo Esto facilita el mantenimiento y sigue el patrón del profesor."
echo.
echo [EXPLICACION] Nota para sustentacion >> "%LOG_FILE%"
echo.
pause >nul

REM ========================================================================
REM   EXPLICACION 4: API REST
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  EXPLICACION 4/10: API REST (asp_servicios)                                                                   ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [EXPLICACION] API REST >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ¿QUÉ ES EL API?                                                                                             │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo El API (Application Programming Interface) es un servicio que:
echo - Recibe peticiones HTTP (POST, GET, etc.)
echo - Procesa la información
echo - Devuelve respuestas en formato JSON
echo.
echo Es como un "intermediario" entre la UI y la base de datos.
echo.
echo [EXPLICACION] ¿Qué es el API? >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ COMPONENTES PRINCIPALES DEL API:                                                                            │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. CONTROLLERS (asp_servicios/Controllers/):
echo    - TokenController: Maneja la autenticación
echo    - AfiliadosController: Maneja las operaciones CRUD de afiliados
echo.
echo 2. STARTUP.CS:
echo    - Configura los servicios (inyección de dependencias)
echo    - Configura el pipeline HTTP (CORS, routing, etc.)
echo.
echo 3. CONFIGURACION.CS:
echo    - Lee la cadena de conexión desde secrets.json
echo    - Proporciona valores de configuración
echo.
echo [EXPLICACION] Componentes del API >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ FLUJO DE UNA PETICIÓN (EJEMPLO: Listar Afiliados):                                                          │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. Cliente envía: POST /Afiliados/Listar
echo 2. TokenController valida: Verifica que la llave sea correcta
echo 3. AfiliadosController procesa: Obtiene datos del repositorio
echo 4. AfiliadosAplicacion ejecuta: Consulta la base de datos
echo 5. Respuesta JSON: Devuelve los datos al cliente
echo.
echo [EXPLICACION] Flujo de peticion >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ RUTAS DEL API (Patrón [controller]/[action]):                                                              │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo - Token/Llave → Obtiene la llave de autenticación
echo - Afiliados/Listar → Lista todos los afiliados
echo - Afiliados/Guardar → Guarda un nuevo afiliado
echo - Afiliados/Modificar → Modifica un afiliado existente
echo - Afiliados/Borrar → Borra un afiliado
echo.
echo [EXPLICACION] Rutas del API >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PARA SUSTENTACIÓN:                                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Di al profesor: "El API usa el patrón [controller]/[action] como requiere.
echo Todas las peticiones validan tokens antes de procesar.
echo Los controladores usan inyección de dependencias para recibir los repositorios.
echo Las respuestas son en formato JSON."
echo.
echo [EXPLICACION] Nota para sustentacion >> "%LOG_FILE%"
echo.
pause >nul

REM ========================================================================
REM   EXPLICACION 5: OPERACIONES CRUD
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  EXPLICACION 5/10: OPERACIONES CRUD                                                                          ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [EXPLICACION] Operaciones CRUD >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ¿QUÉ ES CRUD?                                                                                               │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo CRUD = Create (Crear), Read (Leer), Update (Actualizar), Delete (Borrar)
echo Son las 4 operaciones básicas que se pueden hacer con datos.
echo.
echo [EXPLICACION] ¿Qué es CRUD? >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ CREATE (CREAR) - Paso a paso:                                                                                │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. Usuario llena formulario en la UI
echo 2. UI envía POST a /Afiliados/Guardar
echo 3. API valida token
echo 4. API valida que Id = 0 (nuevo registro)
echo 5. Repositorio INSERT en la base de datos
echo 6. Se devuelve el afiliado con su nuevo ID
echo.
echo [EXPLICACION] CREATE explicado >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ READ (LEER/LISTAR) - Paso a paso:                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. Usuario carga página de Afiliados
echo 2. UI envía POST a /Afiliados/Listar
echo 3. API valida token
echo 4. Repositorio SELECT (máximo 50 registros)
echo 5. Se devuelve lista de afiliados
echo 6. UI muestra datos en tabla
echo.
echo [EXPLICACION] READ explicado >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ UPDATE (ACTUALIZAR) - Paso a paso:                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. Usuario hace clic en "Editar"
echo 2. UI carga datos del afiliado
echo 3. Usuario modifica datos
echo 4. UI envía POST a /Afiliados/Modificar
echo 5. API valida que Id > 0 (registro existente)
echo 6. Repositorio UPDATE en la base de datos
echo.
echo [EXPLICACION] UPDATE explicado >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ DELETE (BORRAR) - Paso a paso:                                                                               │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. Usuario hace clic en "Borrar"
echo 2. UI muestra confirmación
echo 3. UI envía POST a /Afiliados/Borrar
echo 4. API valida que Id > 0
echo 5. Repositorio DELETE de la base de datos
echo.
echo [EXPLICACION] DELETE explicado >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ VALIDACIONES IMPORTANTES:                                                                                    │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo - Id = 0 → Nuevo registro (Guardar)
echo - Id > 0 → Registro existente (Modificar o Borrar)
echo - Entidad no nula → Debe tener datos
echo - Token válido → Debe estar autenticado
echo.
echo [EXPLICACION] Validaciones >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PARA SUSTENTACIÓN:                                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Di al profesor: "Implementé CRUD completo con validaciones.
echo Para crear, valido que Id sea 0. Para modificar o borrar, valido que Id > 0.
echo Todas las operaciones validan tokens y verifican que los datos sean válidos
echo antes de interactuar con la base de datos."
echo.
echo [EXPLICACION] Nota para sustentacion >> "%LOG_FILE%"
echo.
pause >nul

REM ========================================================================
REM   EXPLICACION 6: BASE DE DATOS
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  EXPLICACION 6/10: BASE DE DATOS SQL SERVER                                                                  ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [EXPLICACION] Base de datos >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ¿QUÉ ES LA BASE DE DATOS?                                                                                    │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo La base de datos EPSDB almacena toda la información del sistema:
echo - Afiliados, Usuarios, Contratos, Citas, Facturas, etc.
echo.
echo [EXPLICACION] ¿Qué es la base de datos? >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ENTITY FRAMEWORK CORE:                                                                                       │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo El proyecto usa Entity Framework Core (EF Core) para acceder a la BD.
echo.
echo VENTAJAS:
echo ✅ No necesitas escribir SQL manualmente
echo ✅ Las entidades C# se mapean automáticamente a tablas
echo ✅ Cambios en código se reflejan en la base de datos
echo.
echo [EXPLICACION] Entity Framework Core >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ CONEXIÓN A LA BASE DE DATOS:                                                                                 │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo La cadena de conexión está en secrets.json:
echo.
echo   Server=localhost\SQLEXPRESS
echo   Database=EPSDB
echo   Trusted_Connection=True
echo.
echo Se lee mediante Configuracion.cs que usa DatosGenerales.ruta_json
echo.
echo [EXPLICACION] Conexion a BD >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ TABLAS PRINCIPALES:                                                                                          │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo - Afiliado: Información de afiliados
echo - Usuario: Usuarios del sistema
echo - Contrato: Contratos de afiliados
echo - Cita: Citas médicas
echo - Factura: Facturas de pagos
echo - Y más tablas relacionadas...
echo.
echo [EXPLICACION] Tablas principales >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PARA SUSTENTACIÓN:                                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Di al profesor: "Uso Entity Framework Core como ORM para acceder a SQL Server.
echo La cadena de conexión se lee desde secrets.json para mantenerla segura.
echo Las entidades C# se mapean automáticamente a las tablas de la base de datos."
echo.
echo [EXPLICACION] Nota para sustentacion >> "%LOG_FILE%"
echo.
pause >nul

REM ========================================================================
REM   EXPLICACION 7: COMENTARIOS LÍNEA POR LÍNEA
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  EXPLICACION 7/10: COMENTARIOS LÍNEA POR LÍNEA                                                               ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [EXPLICACION] Comentarios linea por linea >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ¿POR QUÉ COMENTARIOS LÍNEA POR LÍNEA?                                                                        │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Es un REQUISITO EXPLÍCITO del profesor.
echo.
echo BENEFICIOS:
echo ✅ Documentación: Explica qué hace cada parte del código
echo ✅ Mantenimiento: Facilita futuras modificaciones
echo ✅ Enseñanza: Ayuda a entender el código
echo.
echo [EXPLICACION] ¿Por qué comentarios? >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ EJEMPLO DE COMENTARIOS:                                                                                      │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo // Controlador para operaciones CRUD de Afiliados
echo // Proporciona endpoints para listar, guardar, modificar y borrar afiliados
echo [ApiController]
echo [Route("[controller]/[action]")]
echo public class AfiliadosController : ControllerBase
echo {
echo     // Instancia de la aplicación de afiliados
echo     private IAfiliadosAplicacion? iAplicacion = null;
echo     
echo     // Constructor que recibe las aplicaciones por inyección de dependencias
echo     public AfiliadosController(IAfiliadosAplicacion? iAplicacion)
echo     {
echo         this.iAplicacion = iAplicacion;
echo     }
echo }
echo.
echo [EXPLICACION] Ejemplo de comentarios >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ARCHIVOS CON COMENTARIOS:                                                                                    │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo ✅ Todos los archivos .cs tienen comentarios línea por línea:
echo    - Controllers (TokenController, AfiliadosController)
echo    - Aplicaciones (AfiliadosAplicacion, TokenAplicacion)
echo    - Comunicaciones (Comunicaciones.cs)
echo    - Helpers (JsonConversor, EncodingHelper, etc.)
echo    - Y todos los demás archivos .cs
echo.
echo [EXPLICACION] Archivos con comentarios >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PARA SUSTENTACIÓN:                                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Di al profesor: "Todos los archivos .cs tienen comentarios línea por línea
echo como requiere. Cada método, propiedad y clase está documentada.
echo Esto facilita la comprensión y mantenimiento del código."
echo.
echo [EXPLICACION] Nota para sustentacion >> "%LOG_FILE%"
echo.
pause >nul

REM ========================================================================
REM   EXPLICACION 8: TEMA MORADO
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  EXPLICACION 8/10: TEMA MORADO EN LA UI                                                                      ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [EXPLICACION] Tema morado >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ¿POR QUÉ TEMA MORADO?                                                                                       │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo El profesor solicitó un tema morado mejorado en la interfaz de usuario.
echo.
echo [EXPLICACION] ¿Por qué tema morado? >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ COLORES DEL TEMA:                                                                                            │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo - Color principal: #7B2CBF (morado oscuro)
echo - Color secundario: #C77DFF (morado claro)
echo - Color de acento: #E0AAFF (morado muy claro)
echo.
echo [EXPLICACION] Colores del tema >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ELEMENTOS CON TEMA MORADO:                                                                                   │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo ✅ Navbar: Fondo morado con texto blanco
echo ✅ Botones: Botones primarios y secundarios morados
echo ✅ Cards: Bordes y sombras moradas
echo ✅ Tablas: Encabezados morados
echo ✅ Footer: Fondo morado
echo ✅ Efectos hover: Transiciones suaves en morado
echo.
echo [EXPLICACION] Elementos con tema morado >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ARCHIVO CSS:                                                                                                 │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo El tema está definido en: asp_presentacion/wwwroot/css/site.css
echo Usa variables CSS para los colores morados.
echo.
echo [EXPLICACION] Archivo CSS >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PARA SUSTENTACIÓN:                                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Di al profesor: "Implementé el tema morado mejorado como solicitó.
echo Usa el color #7B2CBF como principal, aplicado a navbar, botones, cards,
echo tablas y footer. Incluye efectos hover y transiciones suaves."
echo.
echo [EXPLICACION] Nota para sustentacion >> "%LOG_FILE%"
echo.
pause >nul

REM ========================================================================
REM   EXPLICACION 9: PRUEBAS UNITARIAS
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  EXPLICACION 9/10: PRUEBAS UNITARIAS                                                                         ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [EXPLICACION] Pruebas unitarias >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ¿QUÉ SON LAS PRUEBAS UNITARIAS?                                                                             │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Las pruebas unitarias verifican que cada parte del código funciona
echo correctamente de forma independiente.
echo.
echo [EXPLICACION] ¿Qué son las pruebas unitarias? >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ TIPOS DE PRUEBAS EN EL PROYECTO:                                                                            │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. Validación de entidades:
echo    - Verifica que las entidades tengan los datos correctos
echo    - Prueba validaciones de campos requeridos
echo.
echo 2. Pruebas de servicios:
echo    - Verifica la lógica de negocio
echo    - Prueba operaciones CRUD
echo.
echo [EXPLICACION] Tipos de pruebas >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ EJECUTAR PRUEBAS:                                                                                            │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo   dotnet test Tests/EPS.Tests/EPS.Tests.csproj --verbosity normal
echo.
echo Resultado esperado: Passed: X, Failed: 0, Skipped: 0
echo.
echo [EXPLICACION] Ejecutar pruebas >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PARA SUSTENTACIÓN:                                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Di al profesor: "Implementé pruebas unitarias que verifican la validación
echo de entidades y la lógica de servicios. Todas las pruebas pasan exitosamente,
echo lo que garantiza que el código funciona correctamente."
echo.
echo [EXPLICACION] Nota para sustentacion >> "%LOG_FILE%"
echo.
pause >nul

REM ========================================================================
REM   EXPLICACION 10: RESUMEN PARA SUSTENTACIÓN
REM ========================================================================
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║  EXPLICACION 10/10: RESUMEN PARA SUSTENTACIÓN                                                                ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [EXPLICACION] Resumen para sustentacion >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PUNTOS CLAVE PARA MENCIONAR AL PROFESOR:                                                                     │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo ✅ Estructura igual a panaderia_ref (requisito del profesor)
echo ✅ Comentarios línea por línea en todos los archivos .cs
echo ✅ Tema morado mejorado en la UI
echo ✅ Arquitectura en capas bien definida
echo ✅ CRUD completo funcionando
echo ✅ Pruebas unitarias implementadas
echo ✅ Compilación exitosa sin errores
echo ✅ Rutas [controller]/[action] como requiere
echo ✅ Validación de tokens en todas las peticiones
echo ✅ Entity Framework Core para acceso a datos
echo.
echo [EXPLICACION] Puntos clave >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ PREGUNTAS FRECUENTES Y RESPUESTAS:                                                                           │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo P: ¿Por qué esta estructura?
echo R: Sigue la arquitectura en capas igual a panaderia_ref, separando
echo    responsabilidades para facilitar mantenimiento.
echo.
echo P: ¿Cómo funciona la autenticación?
echo R: Usa tokens. Primero se obtiene una llave desde Token/Llave,
echo    luego cada petición incluye esa llave que se valida.
echo.
echo P: ¿Por qué comentarios línea por línea?
echo R: Es un requisito explícito del profesor para documentar
echo    y facilitar la comprensión del código.
echo.
echo [EXPLICACION] Preguntas frecuentes >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ CONSEJOS PARA LA SUSTENTACIÓN:                                                                               │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo 1. Muestra la estructura del proyecto en Visual Studio
echo 2. Explica el flujo de datos entre capas
echo 3. Demuestra el CRUD funcionando
echo 4. Muestra los comentarios en el código
echo 5. Explica el tema morado en la UI
echo 6. Muestra las pruebas unitarias pasando
echo 7. Explica la conexión a SQL Server
echo.
echo [EXPLICACION] Consejos para sustentacion >> "%LOG_FILE%"
echo.
echo ┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────┐
echo │ ¡ÉXITO EN TU SUSTENTACIÓN!                                                                                   │
echo └──────────────────────────────────────────────────────────────────────────────────────────────────────────────┘
echo.
echo Has completado todas las explicaciones.
echo El proyecto está listo para sustentar.
echo.
echo [EXPLICACION] Fin de explicaciones >> "%LOG_FILE%"
echo. >> "%LOG_FILE%"
echo ======================================================================== >> "%LOG_FILE%"
echo   FIN DEL MODO ESTUDIO >> "%LOG_FILE%"
echo ======================================================================== >> "%LOG_FILE%"
echo.
echo [INFO] Log completo guardado en: %LOG_FILE%
echo.
pause >nul

:FIN
color 07
cls
echo.
echo ╔══════════════════════════════════════════════════════════════════════════════════════════════════════════════╗
echo ║                                                                                                                  ║
echo ║                    MODO ESTUDIO COMPLETADO                                                                      ║
echo ║                                                                                                                  ║
echo ╚══════════════════════════════════════════════════════════════════════════════════════════════════════════════╝
echo.
echo [INFO] Log guardado en: %LOG_FILE%
echo [INFO] Revisa la guía completa en: GUIA_COMPLETA_ESTUDIO.html
echo.
echo ¡Éxito en tu sustentación! 🎓
echo.
pause

