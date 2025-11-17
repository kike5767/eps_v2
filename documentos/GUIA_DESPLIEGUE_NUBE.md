# 🚀 Guía de Despliegue en la Nube - EPS V2 Final

## 📋 Opciones de Hosting Gratuito Recomendadas

### 1. Azure App Service (RECOMENDADO) ⭐
**Ventajas:**
- ✅ Soporte nativo para .NET 8.0
- ✅ Plan gratuito disponible (F1)
- ✅ Integración directa con GitHub
- ✅ Azure SQL Database con tier gratuito
- ✅ SSL gratuito incluido
- ✅ Despliegue automático desde GitHub

**Limitaciones del plan gratuito:**
- 1 GB de almacenamiento
- 60 minutos de CPU por día
- Aplicación se suspende después de 20 minutos de inactividad

**Enlaces:**
- Portal Azure: https://portal.azure.com
- Crear cuenta gratuita: https://azure.microsoft.com/free/

### 2. Railway (Alternativa)
**Ventajas:**
- ✅ Plan gratuito con $5 de crédito mensual
- ✅ Despliegue automático desde GitHub
- ✅ Base de datos PostgreSQL incluida
- ✅ SSL automático

**Enlaces:**
- Railway: https://railway.app

### 3. Render (Alternativa)
**Ventajas:**
- ✅ Plan gratuito disponible
- ✅ Despliegue automático desde GitHub
- ✅ Base de datos PostgreSQL gratuita
- ✅ SSL automático

**Enlaces:**
- Render: https://render.com

---

## 🎯 Despliegue en Azure App Service (PASO A PASO)

### PASO 1: Crear Cuenta en Azure

1. Ve a https://azure.microsoft.com/free/
2. Crea una cuenta gratuita (requiere tarjeta de crédito, pero no se cobra nada en el plan gratuito)
3. Verifica tu cuenta

### PASO 2: Crear Azure SQL Database

1. Inicia sesión en https://portal.azure.com
2. Busca "SQL databases" y crea nueva base de datos
3. Configuración:
   - **Nombre:** eps-v2-db
   - **Servidor:** Crear nuevo servidor SQL
   - **Plan de tarifa:** Basic (gratis) o DTU S0 (más económico)
   - **Autenticación:** SQL Server authentication
   - **Usuario:** admin (o el que prefieras)
   - **Contraseña:** (guárdala, la necesitarás)
4. Anota la cadena de conexión que te proporciona Azure

### PASO 3: Crear App Service para el API

1. En Azure Portal, busca "App Services" y crea nuevo
2. Configuración:
   - **Nombre:** eps-v2-api (debe ser único)
   - **Runtime stack:** .NET 8.0
   - **Sistema operativo:** Windows
   - **Plan:** Crear nuevo plan (F1 - Free)
   - **Región:** Elige la más cercana
3. Crea el App Service

### PASO 4: Crear App Service para la UI

1. Repite el paso 3 pero con nombre: **eps-v2-ui**
2. Usa el mismo plan de App Service (F1 - Free) para ahorrar recursos

### PASO 5: Configurar Cadena de Conexión en Azure

1. Ve a tu App Service del API (eps-v2-api)
2. Ve a "Configuration" > "Application settings"
3. Agrega nueva configuración:
   - **Nombre:** StringConexion
   - **Valor:** (Pega la cadena de conexión de Azure SQL Database)
   - **Marca como:** Connection string
4. Guarda los cambios

**Formato de cadena de conexión para Azure SQL:**
```
Server=tcp:tu-servidor.database.windows.net,1433;Initial Catalog=eps-v2-db;Persist Security Info=False;User ID=admin;Password=tu-contraseña;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;
```

### PASO 6: Configurar Despliegue desde GitHub

#### Opción A: Despliegue Manual

1. En tu App Service, ve a "Deployment Center"
2. Selecciona "GitHub" como fuente
3. Autoriza Azure a acceder a tu GitHub
4. Selecciona tu repositorio: `kike5767/eps_v2`
5. Selecciona branch: `main`
6. Para el API, selecciona carpeta: `asp_servicios`
7. Para la UI, selecciona carpeta: `asp_presentacion`
8. Guarda y Azure comenzará a desplegar automáticamente

#### Opción B: GitHub Actions (Automático)

1. Ve a tu repositorio en GitHub
2. Ve a Settings > Secrets and variables > Actions
3. Agrega los siguientes secrets:
   - `AZURE_WEBAPP_PUBLISH_PROFILE_API` (obtén el publish profile desde Azure)
   - `AZURE_WEBAPP_PUBLISH_PROFILE_UI` (obtén el publish profile desde Azure)

**Cómo obtener el Publish Profile:**
1. En Azure Portal, ve a tu App Service
2. Click en "Get publish profile"
3. Descarga el archivo .PublishSettings
4. Copia todo el contenido y pégalo como secret en GitHub

### PASO 7: Ejecutar Script SQL en Azure SQL Database

1. En Azure Portal, ve a tu SQL Database
2. Click en "Query editor"
3. Inicia sesión con tus credenciales
4. Abre el archivo `lib_repositorios/Script.sql` o `SCRIPCORREGIDOULTIMO19092025.sql`
5. Copia y pega el contenido en el Query editor
6. Ejecuta el script (F5)
7. Verifica que las tablas se crearon correctamente

### PASO 8: Configurar URLs en la UI

1. Una vez desplegado, obtén la URL del API (ej: https://eps-v2-api.azurewebsites.net)
2. En el código de la UI, actualiza la URL del API en:
   - `lib_presentaciones/Comunicaciones.cs` (si es necesario)
3. O configura una variable de entorno en Azure App Service (UI):
   - **Nombre:** API_URL
   - **Valor:** https://eps-v2-api.azurewebsites.net

### PASO 9: Verificar Despliegue

1. **API:** Visita https://eps-v2-api.azurewebsites.net/swagger
2. **UI:** Visita https://eps-v2-ui.azurewebsites.net
3. Prueba las operaciones CRUD desde la UI

---

## 🔧 Configuración Adicional para Azure

### Variables de Entorno Recomendadas

En cada App Service, configura estas variables de entorno:

**Para el API (eps-v2-api):**
- `ASPNETCORE_ENVIRONMENT` = `Production`
- `StringConexion` = (cadena de conexión a Azure SQL)

**Para la UI (eps-v2-ui):**
- `ASPNETCORE_ENVIRONMENT` = `Production`
- `API_URL` = https://eps-v2-api.azurewebsites.net

### Configurar CORS (si es necesario)

Si la UI y API están en dominios diferentes, configura CORS en el API:

1. En `asp_servicios/Startup.cs`, agrega:
```csharp
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowUI",
        builder => builder
            .WithOrigins("https://eps-v2-ui.azurewebsites.net")
            .AllowAnyMethod()
            .AllowAnyHeader());
});
```

2. En el método `Configure`, agrega:
```csharp
app.UseCors("AllowUI");
```

---

## 📝 Notas Importantes

### ⚠️ Limitaciones del Plan Gratuito

1. **App Service F1:**
   - Se suspende después de 20 minutos de inactividad
   - Primera petición después de suspensión puede tardar 30-60 segundos
   - 60 minutos de CPU por día

2. **Azure SQL Database (Basic):**
   - 5 DTU (Database Transaction Units)
   - 2 GB de almacenamiento máximo
   - Puede ser lento con muchas conexiones simultáneas

### 💡 Recomendaciones

1. **Para desarrollo/pruebas:** Plan gratuito es suficiente
2. **Para producción:** Considera actualizar a plan de pago (B1 mínimo)
3. **Monitoreo:** Usa Application Insights (gratis hasta cierto límite)
4. **Backups:** Configura backups automáticos en Azure SQL

---

## 🔄 Actualizar Código en Producción

### Método 1: Push a GitHub (Automático)
1. Haz cambios en tu código local
2. Commit y push a GitHub:
   ```bash
   git add .
   git commit -m "Descripción de cambios"
   git push origin main
   ```
3. Azure detectará los cambios y desplegará automáticamente

### Método 2: Despliegue Manual desde Visual Studio
1. Click derecho en el proyecto (asp_servicios o asp_presentacion)
2. Selecciona "Publish"
3. Selecciona "Azure App Service"
4. Elige tu App Service
5. Click en "Publish"

---

## 🐛 Solución de Problemas

### Problema: "Application Error"
- Verifica los logs en Azure Portal > App Service > Log stream
- Revisa que la cadena de conexión esté correcta
- Verifica que el script SQL se ejecutó correctamente

### Problema: "Timeout"
- El plan gratuito puede ser lento
- Considera actualizar a un plan de pago

### Problema: "Database connection failed"
- Verifica la cadena de conexión en Application Settings
- Asegúrate de que el firewall de Azure SQL permita conexiones desde Azure Services
- Verifica que el servidor SQL esté activo

### Problema: "CORS error"
- Configura CORS en el API como se explicó arriba
- Verifica que las URLs sean correctas

---

## 📊 Monitoreo y Logs

### Ver Logs en Tiempo Real
1. En Azure Portal, ve a tu App Service
2. Click en "Log stream"
3. Verás los logs en tiempo real

### Application Insights (Opcional)
1. Crea un recurso Application Insights
2. Conéctalo a tu App Service
3. Obtendrás métricas detalladas de rendimiento

---

## ✅ Checklist de Despliegue

- [ ] Cuenta de Azure creada
- [ ] Azure SQL Database creada
- [ ] Script SQL ejecutado en Azure SQL
- [ ] App Service para API creado
- [ ] App Service para UI creado
- [ ] Cadena de conexión configurada en App Service (API)
- [ ] Despliegue desde GitHub configurado
- [ ] URLs de producción funcionando
- [ ] CORS configurado (si es necesario)
- [ ] Pruebas CRUD funcionando

---

## 🎉 ¡Despliegue Completado!

Una vez completados todos los pasos, tu aplicación estará disponible en:
- **API:** https://eps-v2-api.azurewebsites.net
- **UI:** https://eps-v2-ui.azurewebsites.net
- **Swagger:** https://eps-v2-api.azurewebsites.net/swagger

¡Éxito con tu despliegue! 🚀

