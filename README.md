# BackEnd

## 🛠️ Tecnologías utilizadas 

### 📦 Persistencia de datos
La capa de persistencia está implementada en el proyecto Infraestructura, utilizando Entity Framework Core como ORM para el acceso a datos, junto con MySQL como motor de base de datos.

Para facilitar el trabajo con EF Core, se utilizó el proveedor oficial Pomelo.EntityFrameworkCore.MySql, compatible con MySQL Server y MariaDB.

Se aplicó Code First Migrations, permitiendo generar y actualizar la estructura de la base de datos a partir del modelo de entidades del código. Las migraciones se encuentran organizadas dentro de Infraestructura/Persistencia/Migrations.


> Al iniciar la aplicación, se aplica automáticamente la migración pendiente (si existe), creando o actualizando el esquema de la base de datos sin necesidad de intervención manual.



