# 🎬 DEMOSTRACIÓN COMPLETA EPS V2 FINAL

## 📋 Guía Visual de Ejecución desde Inicio a Fin

### 🚀 Opción 1: Demostración Automática Completa

**Ejecutar:** `DEMOSTRACION_COMPLETA.bat`

Este script muestra:
1. ✅ Verificación de estructura del proyecto
2. ✅ Compilación completa
3. ✅ Ejecución de pruebas unitarias
4. ✅ Verificación de configuración
5. ✅ Listado de archivos principales
6. ✅ Instrucciones para ejecución manual

---

### 🎯 Opción 2: Ejecutar Proyecto Completo (API + UI)

**Ejecutar:** `EJECUTAR_PROYECTO_COMPLETO.bat`

Este script:
1. ✅ Compila el proyecto
2. ✅ Inicia API en una ventana (puerto 5047)
3. ✅ Inicia UI en otra ventana (puerto 5000)
4. ✅ Abre el navegador automáticamente

---

## 📺 Lo que Verás en Pantalla

### 1️⃣ **Compilación**

```
═══════════════════════════════════════════════════════════════
  PASO 2: COMPILANDO PROYECTO COMPLETO
═══════════════════════════════════════════════════════════════

[INFO] Compilando solucion completa...

Microsoft (R) Build Engine version 17.x.x
Copyright (C) Microsoft Corporation. All rights reserved.

  lib_dominio -> C:\EPS_V2_FINAL\lib_dominio\bin\Debug\net8.0\lib_dominio.dll
  lib_repositorios -> C:\EPS_V2_FINAL\lib_repositorios\bin\Debug\net8.0\lib_repositorios.dll
  lib_presentaciones -> C:\EPS_V2_FINAL\lib_presentaciones\bin\Debug\net8.0\lib_presentaciones.dll
  asp_servicios -> C:\EPS_V2_FINAL\asp_servicios\bin\Debug\net8.0\asp_servicios.dll
  asp_presentacion -> C:\EPS_V2_FINAL\asp_presentacion\bin\Debug\net8.0\asp_presentacion.dll
  EPS.Tests -> C:\EPS_V2_FINAL\Tests\EPS.Tests\bin\Debug\net8.0\EPS.Tests.dll

[OK] Compilacion EXITOSA - 0 Errores
```

### 2️⃣ **Pruebas Unitarias**

```
═══════════════════════════════════════════════════════════════
  PASO 3: EJECUTANDO PRUEBAS UNITARIAS
═══════════════════════════════════════════════════════════════

[INFO] Ejecutando pruebas unitarias...

Test run for C:\EPS_V2_FINAL\Tests\EPS.Tests\bin\Debug\net8.0\EPS.Tests.dll
(.NETCoreApp,Version=v8.0)
Microsoft (R) Test Execution Command Line Tool Version 17.x.x

Starting test execution, please wait...
A total of 1 test files matched the specified pattern.

Passed!  - Failed:     0, Passed:     X, Skipped:     0, Total:     X, Duration: X ms

[OK] Pruebas ejecutadas correctamente
```

### 3️⃣ **API en Ejecución**

```
══════════════════════════════════════════════════════════════
  EPS V2 - API REST (asp_servicios)
══════════════════════════════════════════════════════════════

info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:5047
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5047
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

### 4️⃣ **UI en Ejecución**

```
══════════════════════════════════════════════════════════════
  EPS V2 - UI Razor Pages (asp_presentacion)
══════════════════════════════════════════════════════════════

info: Microsoft.Hosting.Lifetime[14]
      Now listening on: https://localhost:5000
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5000
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
```

### 5️⃣ **Interfaz Web - CRUD de Afiliados**

Al abrir `http://localhost:5000/Afiliados` verás:

```
┌─────────────────────────────────────────────────────────────┐
│  🏥 EPS - Sistema de Gestión                                │
│     [Inicio] [Afiliados]                                    │
├─────────────────────────────────────────────────────────────┤
│                                                             │
│  📋 Gestión de Afiliados - EPS                             │
│                                                             │
│  [+ Nuevo Afiliado]                                         │
│                                                             │
│  ┌───────────────────────────────────────────────────────┐ │
│  │ ID │ Nombre    │ Documento │ Email        │ Acciones │ │
│  ├────┼───────────┼───────────┼─────────────┼──────────┤ │
│  │ 1  │ Juan P.   │ 12345678  │ juan@...     │ [Editar] │ │
│  │ 2  │ María G.  │ 87654321  │ maria@...    │ [Editar] │ │
│  └───────────────────────────────────────────────────────┘ │
│                                                             │
└─────────────────────────────────────────────────────────────┘
```

**Características visuales:**
- 🟣 **Tema morado** en navbar, botones y cards
- 📝 **Formulario CRUD** completo
- ✅ **Mensajes de éxito/error** con alertas
- 🎨 **Iconos Bootstrap** en botones
- 📊 **Tabla responsive** con hover effects

---

## 🧪 Pruebas de Negocio

### Ejecutar Pruebas de Lógica de Negocio:

```bash
dotnet test Tests/EPS.Tests/EPS.Tests.csproj --verbosity normal
```

**Verás:**
- ✅ Validación de entidades
- ✅ Pruebas de servicios
- ✅ Pruebas de repositorios
- ✅ Resultados detallados

---

## 📊 Flujo Completo CRUD

### 1. **LISTAR** (GET)
```
Endpoint: POST /Afiliados/Listar
Body: { "Llave": "..." }

Respuesta:
{
  "Entidades": [
    { "Id": 1, "Nombre": "Juan", ... },
    { "Id": 2, "Nombre": "María", ... }
  ],
  "Respuesta": "OK",
  "Fecha": "2025-11-15 03:45:00"
}
```

### 2. **GUARDAR** (POST)
```
Endpoint: POST /Afiliados/Guardar
Body: {
  "Llave": "...",
  "Entidad": {
    "Id": 0,
    "Nombre": "Nuevo Afiliado",
    "Documento": "12345678",
    "Email": "nuevo@email.com",
    ...
  }
}

Respuesta:
{
  "Entidad": { "Id": 3, "Nombre": "Nuevo Afiliado", ... },
  "Respuesta": "OK",
  "Fecha": "2025-11-15 03:46:00"
}
```

### 3. **MODIFICAR** (PUT)
```
Endpoint: POST /Afiliados/Modificar
Body: {
  "Llave": "...",
  "Entidad": {
    "Id": 3,
    "Nombre": "Afiliado Modificado",
    ...
  }
}
```

### 4. **BORRAR** (DELETE)
```
Endpoint: POST /Afiliados/Borrar
Body: {
  "Llave": "...",
  "Entidad": { "Id": 3 }
}
```

---

## 🎥 Para Grabar la Demostración

1. **Ejecutar:** `DEMOSTRACION_COMPLETA.bat`
   - Muestra compilación y pruebas

2. **Ejecutar:** `EJECUTAR_PROYECTO_COMPLETO.bat`
   - Inicia API y UI

3. **Abrir navegador** y mostrar:
   - Listado de afiliados
   - Crear nuevo afiliado
   - Editar afiliado
   - Borrar afiliado
   - Tema morado en acción

4. **Mostrar código:**
   - Comentarios línea por línea
   - Estructura de proyectos
   - Archivos principales

---

## ✅ Checklist de Demostración

- [x] Compilación exitosa
- [x] Pruebas unitarias ejecutadas
- [x] API funcionando (puerto 5047)
- [x] UI funcionando (puerto 5000)
- [x] CRUD completo funcionando
- [x] Tema morado visible
- [x] Comentarios en código visibles
- [x] Estructura de proyectos mostrada

---

## 🔗 Enlaces

- **GitHub:** https://github.com/kike5767/eps_v2.git
- **YouTube:** https://youtu.be/GVyz4-I0t_0

---

**¡Todo listo para la demostración completa!** 🎉

