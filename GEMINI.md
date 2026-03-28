# GEMINI.md

## Propósito

Este archivo define las reglas y convenciones para los agentes (automatizados) que trabajan en este proyecto ASP.NET Core con Blazor Server y Entity Framework.

---

## Stack Tecnológico

* ASP.NET Core
* Blazor Server
* Entity Framework Core
* SQL Server (proveedor configurado)
* Bulma CSS Framework
* CSS puro (Si se usa CSS, aplicar alta especificidad para evitar conflictos con Bulma CSS. Ver ejemplo en `ProyectoSocioEconomico.WebUI/wwwroot/app.css`)

---

## Estructura del Proyecto

* `ProyectoSocioEconomico.WebUI/Components/Pages` → Componentes Razor (páginas)
* `ProyectoSocioEconomico.Domain/Entities` → Entidades del dominio
* `ProyectoSocioEconomico.Infrastructure/Data` → DbContext y configuraciones EF
* `ProyectoSocioEconomico.Infrastructure/Services` → Servicios de infraestructura (implementaciones)
* `ProyectoSocioEconomico.Application/Interfaces` → Interfaces de servicios de aplicación
* `ProyectoSocioEconomico.WebUI/wwwroot` → Archivos estáticos (CSS, JS, imágenes)
* `ProyectoSocioEconomico.Infrastructure/Migrations` → Migraciones EF Core

---

## Convenciones de Código

* Usar **PascalCase** para clases y propiedades
* Usar **camelCase** para variables locales
* Mantener componentes Blazor ligeros, delegando lógica a servicios
* Validaciones usando Data Annotations o Fluent Validation

---

## Entity Framework

* Las entidades del dominio se encuentran en `ProyectoSocioEconomico.Domain/Entities`
* Configuración adicional en `OnModelCreating` del `AppDbContext` (`ProyectoSocioEconomico.Infrastructure/Data/AppDbContext.cs`)
* Crear migraciones con:

  ```bash
  dotnet ef migrations add NombreMigracion --project ProyectoSocioEconomico.Infrastructure --startup-project ProyectoSocioEconomico.WebUI
  ```

* Aplicar migraciones:

  ```bash
  dotnet ef database update --project ProyectoSocioEconomico.Infrastructure --startup-project ProyectoSocioEconomico.WebUI
  ```

* Migración inicial: `20260326064441_InitialCreate`

---

## Buenas Prácticas

* No hardcodear strings de conexión
* Usar `appsettings.json` y `appsettings.Development.json` en `ProyectoSocioEconomico.WebUI/`
* Manejar errores con middleware (ya configurado en Program.cs)
* Usar `async/await` en acceso a datos
* Separar responsabilidades según capas (Domain, Application, Infrastructure, WebUI)

---

## Notas

* Mantener el código limpio
* Mantener el código simple (Keep it simple, stupid)
* Evitar duplicación (Don't repeat yourself)
* Documentar métodos importantes
* Los componentes Blazor deben ser reactivos y usar parámetros adecuadamente

## UI

When editing .razor files:

* Prioritize BulmaCSS (no Tailwind, no Bootstrap)
* When you use Bulma classes, they should be start with "bulma-" and after the class name, you can add your personalized classes.
* If you wanana use personalized classes, you can use css but with a lot of priotity.
  For example:
  `section.section-redondeado`
* Improve layout using web-design-guidelines
* Maintain layout fidelity using ui-mockup-fidelity
* Prefer Bulma helpers (columns, box, card, level)
* Prefer Bulma components (columns, card, box, level)
* Use reusable Razor components
* Use components instead of duplicated markup
* Avoid inline styles
* Keep accessibility attributes
* Keep semantic HTML
* Keep markup minimal and clean

Always prioritize BulmaCSS classes over custom CSS.
