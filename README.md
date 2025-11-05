# ColegioApp - Solución por capas (.NET 8 + SQL Server)

Estructura por proyectos: Entity, Data, Business, Utilities, Diagram, Web.

## Cómo correr
1) Abre `ColegioApp.sln` en Visual Studio.
2) Ajusta connection string si no usas LocalDB en `Web/appsettings.json`.
3) Crea migraciones y base:
   - Instala dotnet-ef (una vez): `dotnet tool install --global dotnet-ef`
   - Desde carpeta **Web** (o solución con `-s Web/Web.csproj`):
     ```bash
     dotnet ef migrations add InitialCreate -s Web/Web.csproj -p Entity/Entity.csproj
     dotnet ef database update -s Web/Web.csproj -p Entity/Entity.csproj
     ```
4) Ejecuta el proyecto **Web**. Swagger siempre disponible en `/swagger`.

## Entidades
Estudiante, Profesor, Curso, Materia, Periodo, CursoMateria (pivote), Nota (pivote extendido).
