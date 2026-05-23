# CatalogoApp

Aplicación web para gestionar un catálogo personal de videojuegos. Permite agregar títulos, filtrarlos por género y dejar reviews con calificación de estrellas.

Construida con **ASP.NET Core MVC (.NET 10)** siguiendo una arquitectura en capas (Clean Architecture).

---

##  Funcionalidades

- Listado de videojuegos con filtro por género
- Vista de detalle de cada juego
- Agregar nuevos títulos al catálogo
- Sistema de reviews con calificación de 1 a 5 estrellas
- Registro e inicio de sesión de usuarios (sesión con cookies)
- Persistencia de datos en archivos JSON (sin base de datos)

---

##  Estructura del proyecto

```
CatalogoApp/
├── CatalogoApp.Domain/          # Modelos e interfaces (Item, Review, User)
├── CatalogoApp.Application/     # Servicios de negocio (ItemService, ReviewService, UserService)
├── CatalogoApp.Infrastructure/  # Repositorios JSON (lectura/escritura de archivos)
└── CatalogoApp.Presentation/    # Proyecto web MVC (Controllers, Views, wwwroot)
    └── Data/                    # Archivos items.json, users.json, reviews.json
```

---

##  Cómo ejecutar

### Requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)

### Pasos

```bash
# 1. Clonar el repositorio
git clone https://github.com/tu-usuario/CatalogoApp.git
cd CatalogoApp

# 2. Ejecutar el proyecto
dotnet run --project CatalogoApp/CatalogoApp.Presentation
```

La app estará disponible en `https://localhost:5001` o `http://localhost:5000`.

---

##  Tecnologías

| Capa | Tecnología |
|---|---|
| Framework | ASP.NET Core MVC (.NET 10) |
| Persistencia | JSON (System.Text.Json) |
| Sesiones | ASP.NET Core Session |
| Frontend | HTML/CSS vanilla + Tag Helpers |

---

##  Notas
Este readme junto al estilo de paginas fue hecho con Claude Sonnet.

- Los datos se guardan en archivos `.json` dentro de `CatalogoApp.Presentation/Data/`. No se requiere ninguna base de datos.
- Para agregar videojuegos o dejar reviews es necesario registrarse e iniciar sesión.
- El proyecto no incluye autenticación con roles; cualquier usuario registrado puede agregar ítems.
