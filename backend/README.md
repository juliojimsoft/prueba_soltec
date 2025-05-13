# Backend API - Autenticación JWT en .NET

Este proyecto es un backend construido en **C# con .NET**, utilizando una arquitectura por capas que incluye **Controladores**, **Servicios**, **Repositorios**, **Modelos** e **Interfaces**, y que implementa autenticación basada en **JWT (JSON Web Token)**.

## 🛠️ Tecnologías

- .NET 8 +
- C#
- Entity Framework Core
- Postgresql
- JWT (JSON Web Tokens)
- AutoMapper (opcional)
- Swagger (para documentación de API)
- ASP.NET Core Web API

## 📁 Estructura del proyecto

/Controllers -> Endpoints HTTP
/Services -> Lógica de negocio
/Repositories -> Acceso a datos (EF Core u otro ORM)
/Interfaces -> Interfaces para los servicios/repositorios
/Models -> Modelos de dominio y DTOs
/Helpers -> Configuraciones y utilidades (por ejemplo, JWT)

## 🔐 Autenticación

El proyecto usa autenticación JWT. Al iniciar sesión, el backend genera un token firmado que el cliente debe enviar en el encabezado `Authorization` de cada solicitud protegida.

**Formato del encabezado:**
Authorization: Bearer {token}

## 🔄 Endpoints principales

| Método | Ruta                 | Descripción                | Autenticación |
| ------ | -------------------- | -------------------------- | ------------- |
| POST   | `/api/auth/login`    | Iniciar sesión             | ❌            |
| POST   | `/api/auth/register` | Crear nuevo usuario        | ❌            |
| GET    | `/api/users`         | Obtener todos los usuarios | ✅            |
| GET    | `/api/users/{id}`    | Obtener un usuario por ID  | ✅            |
| PUT    | `/api/users/{id}`    | Actualizar usuario         | ✅            |
| DELETE | `/api/users/{id}`    | Eliminar usuario           | ✅            |

## 🚀 Cómo ejecutar

1. Clona el repositorio:

```bash
git clone https://github.com/tuusuario/tu-repo.git
cd tu-repo

2. Configura la cadena de conexión en appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=MiDb;User Id=usuario;Password=clave;"
}

3. Ejecuta las migraciones (si usas EF Core):
dotnet ef database update

4. Corre el proyecto:
dotnet run

5. Accede a Swagger:
http://localhost:{puerto}/swagger
```

🧪 Pruebas
Puedes usar Postman o cualquier cliente HTTP para probar los endpoints. Recuerda agregar el token JWT en el encabezado para las rutas protegidas.

📌 Notas
Asegurate de mantener la clave JWT secreta en un entorno seguro (usa variables de entorno en produccion).

Puedes personalizar los claims del token segun los roles/permisos de tu aplicacion.
