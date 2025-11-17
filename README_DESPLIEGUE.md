# 🚀 EPS V2 Final - Despliegue en la Nube

## 📦 Archivos de Configuración para Despliegue

Este proyecto incluye configuración lista para desplegar en Azure App Service (gratis).

### Archivos Creados:

1. **`.github/workflows/azure-deploy.yml`**
   - GitHub Actions para despliegue automático
   - Se ejecuta al hacer push a `main`

2. **`azure-deploy.yml`**
   - Azure DevOps Pipeline (alternativa)
   - Para usar con Azure DevOps

3. **`documentos/GUIA_DESPLIEGUE_NUBE.md`**
   - Guía completa paso a paso para desplegar en Azure
   - Incluye configuración de base de datos
   - Solución de problemas

4. **`documentos/ACTUALIZAR_GITHUB.bat`**
   - Script para actualizar el repositorio en GitHub
   - Agrega todos los archivos nuevos
   - Hace commit y push automático

## 🎯 Opción Recomendada: Azure App Service

### ¿Por qué Azure?

- ✅ Plan gratuito disponible (F1)
- ✅ Soporte nativo para .NET 8.0
- ✅ Azure SQL Database con tier gratuito
- ✅ SSL gratuito incluido
- ✅ Despliegue automático desde GitHub
- ✅ Integración perfecta con .NET

### Pasos Rápidos:

1. **Crear cuenta en Azure:** https://azure.microsoft.com/free/
2. **Seguir la guía:** `documentos/GUIA_DESPLIEGUE_NUBE.md`
3. **Actualizar GitHub:** Ejecutar `documentos/ACTUALIZAR_GITHUB.bat`

## 📝 Notas Importantes

- ⚠️ El archivo `secrets.json` NO se sube a GitHub (está en .gitignore)
- ⚠️ En Azure, la cadena de conexión se configura en Application Settings
- ⚠️ El script SQL debe ejecutarse manualmente en Azure SQL Database
- ✅ La estructura del proyecto NO se modifica para el despliegue

## 🔗 Enlaces Útiles

- **Repositorio GitHub:** https://github.com/kike5767/eps_v2.git
- **Guía de Despliegue:** `documentos/GUIA_DESPLIEGUE_NUBE.md`
- **Azure Portal:** https://portal.azure.com

---

**¡El proyecto está listo para desplegar en la nube!** 🎉

