# **AgenciaViajes – Backend**
Desarrollado en ASP.NET Core Web API para la gestión de reservas y facturación de una agencia de viajes.
El sistema implementa Entity Framework Core bajo el enfoque Code First, permitiendo el manejo de datos y la evolución de la base de datos mediante migraciones.
# Instalación y configuración
## 1. Clonación del repositorio
Ejecutar el siguiente comando desde una terminal:

```git clone <URL_DEL_REPOSITORIO>```
## 2. Configuración de la cadena de conexión
Modificar el archivo appsettings.json y establecer la cadena de conexión a la base de datos:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=TU_SERVIDOR;Database=AgenciaViajes;Trusted_Connection=True;TrustServerCertificate=True"
}
```

## 3. Restauración de la base de datos
El sistema utiliza una base de datos SQL Server restaurada desde un archivo .bak.
## 4. Instalación de dependencias
En caso de ser necesario, instalar los paquetes de Entity Framework Core :

- Microsoft.EntityFrameworkCore
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools
