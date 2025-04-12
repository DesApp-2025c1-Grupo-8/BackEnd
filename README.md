# BackEnd

## 🛠️ Tecnologías utilizadas 

### 📦 Persistencia de datos
La capa de persistencia está implementada en el proyecto Infraestructura, utilizando Entity Framework Core como ORM para el acceso a datos, junto con MySQL como motor de base de datos.

Para facilitar el trabajo con EF Core, se utilizó el proveedor oficial Pomelo.EntityFrameworkCore.MySql, compatible con MySQL Server y MariaDB.

Se aplicó Code First Migrations, permitiendo generar y actualizar la estructura de la base de datos a partir del modelo de entidades del código. Las migraciones se encuentran organizadas dentro de Infraestructura/Persistencia/Migrations.


> Al iniciar la aplicación, se aplica automáticamente la migración pendiente (si existe), creando o actualizando el esquema de la base de datos sin necesidad de intervención manual.



#### 📋 Guía de Integración de Entity Framework Core
La persistencia en este proyecto se implementa utilizando Entity Framework Core (EF Core) 8.0.13 como ORM con soporte para MySQL, a través del proveedor Pomelo.EntityFrameworkCore.MySql.

##### 📁 Organización
EF Core está integrado en la capa de Infraestructura, bajo la carpeta Persistencia. Allí se define el DbContext principal del proyecto, junto con las configuraciones de entidades y las migraciones.

##### 🔌 Configuración
DbContext se configura e inyecta desde el proyecto WebAPI, donde se define la cadena de conexión en appsettings.json y se realiza la configuración del contexto en Program.cs.

Las migraciones se ubican dentro de Infraestructura/Persistencia/Migrations y se generan con el comando:

```
dotnet ef migrations add <Nombre> --project Infraestructura --startup-project WebAPI --output-dir Persistencia/Migrations
```

>⚠️ Asegurarse de tener instalado el paquete Microsoft.EntityFrameworkCore.Design en el proyecto WebAPI (startup project). <br>
>⚠️ Es obligatorio asignar un nombre a la migración, ya que EF Core no permite crear migraciones sin nombre.
##### 📤 Aplicación Automática de Migraciones
Se implementa una estrategia de migración automática en tiempo de ejecución. En Program.cs de WebAPI se invoca:

```
using (var serviceScope = app.Services.CreateScope())
{
    var context = serviceScope.ServiceProvider.GetRequiredService<ProjectContext>();
    context.Database.Migrate();
}
```

>⚠️ Asegurarse de tener instalado el paquete Microsoft.EntityFrameworkCore en el proyecto WebAPI.

Esto permite que la base de datos y su esquema se creen o actualicen automáticamente al iniciar la aplicación, sin necesidad de ejecutar comandos manuales en otros entornos.

##### 📦 Paquetes NuGet Utilizados
>Microsoft.EntityFrameworkCore (8.0.13)<br>
>Microsoft.EntityFrameworkCore.Design (8.0.13)<br>
>Pomelo.EntityFrameworkCore.MySql (8.0.3)


















###### ...