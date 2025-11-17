# EPS V2 Final - Sistema de Gestión EPS

## 📋 Descripción

Proyecto completo de sistema de gestión EPS desarrollado siguiendo la arquitectura de capas del profesor, con estructura idéntica a la referencia `panaderia_ref`.

## ✅ Estado del Proyecto

- **Compilación:** ✅ Exitosa (0 errores)
- **Estructura:** ✅ Completa e igual a referencia
- **Comentarios:** ✅ Línea por línea en todos los archivos .cs
- **UI:** ✅ Tema morado mejorado

## 🏗️ Estructura del Proyecto

```
EPS_V2_FINAL/
├── 1. presentaciones/
│   ├── asp_presentacion/          (Razor Pages - UI)
│   └── lib_presentaciones/        (Comunicaciones con API)
├── 2. servicios/
│   ├── asp_servicios/             (API REST)
│   └── lib_repositorios/          (Repositorios y Aplicaciones)
├── 3. nucleo/
│   └── lib_dominio/               (Entidades y Helpers)
├── 4. pruebas unitarias/
│   └── Tests/EPS.Tests/           (Pruebas unitarias)
├── secrets.json                   (Configuración - NO en GitHub)
├── SCRIPCORREGIDOULTIMO19092025.sql
└── EPS.sln                        (Solución principal)
```

## 🚀 Cómo Ejecutar

### 1. Configurar Base de Datos

Ejecutar el script SQL:
```sql
SCRIPCORREGIDOULTIMO19092025.sql
```

### 2. Configurar secrets.json

Crear `secrets.json` en la raíz con:
```json
{
  "StringConexion": "Server=localhost\\SQLEXPRESS;Database=EPSDB;Trusted_Connection=True;TrustServerCertificate=True;"
}
```

### 3. Compilar

```bash
dotnet build EPS.sln
```

### 4. Ejecutar API

```bash
dotnet run --project asp_servicios/asp_servicios.csproj
```

### 5. Ejecutar UI

```bash
dotnet run --project asp_presentacion/asp_presentacion.csproj
```

## 🔗 Enlaces

- **Repositorio Principal:** https://github.com/kike5767/eps_v2.git
- **Repositorio Secundario:** https://github.com/kike5767/eps.git
- **Video YouTube:** https://youtu.be/GVyz4-I0t_0

## 📝 Características

- ✅ Arquitectura en capas (Presentación, Servicios, Repositorios, Dominio)
- ✅ API REST con autenticación por tokens
- ✅ UI Razor Pages con tema morado
- ✅ Comentarios línea por línea en todo el código
- ✅ Validaciones completas de CRUD
- ✅ Entity Framework Core
- ✅ Inyección de dependencias

## 🎨 Tema Morado

El proyecto incluye un tema morado completo (#7B2CBF) con:
- Navbar morado
- Botones y cards con colores morados
- Tablas con encabezados morados
- Efectos hover mejorados
- Iconos Bootstrap Icons

## 📄 Documentación

Ver `RESUMEN_CAMBIOS_EPS_V2.html` o `RESUMEN_CAMBIOS_EPS_V2.md` para detalles completos de todos los cambios realizados.

## 👨‍💻 Autor

Proyecto desarrollado para el curso de Desarrollo de Software - Semestre 2 2025

---

**Estado:** ✅ Completado y funcionando

