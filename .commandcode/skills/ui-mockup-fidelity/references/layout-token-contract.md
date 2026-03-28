# Layout and Token Contract

Este contrato define las reglas para la implementación de UI en el proyecto, asegurando consistencia con Bulma CSS (v1.0.4) y un enfoque Mobile First.

## Layout Baseline

- **Mobile First:** Todas las implementaciones deben diseñarse primero para dispositivos móviles. Los elementos deben ser apilados por defecto y usar modificadores de Bulma (ej. `bulma-is-tablet`, `bulma-is-desktop`) para definir layouts horizontales en pantallas más grandes.
- **Bulma Grid:** Utilizar el sistema de 12 columnas de Bulma mediante las clases `bulma-columns` y `bulma-column`.
- **Estructura:** Mantener los contenedores de sección (`bulma-section` o `bulma-container`) explícitos para que el espaciado y las capas de fondo sean predecibles.
- **Prefijos:** Todas las clases de Bulma **deben** empezar con el prefijo `bulma-` (ej. `bulma-columns`, `bulma-button`, `bulma-card`, `bulma-is-primary`).

## Background Rules

- Definir estilos de fondo explícitos para la raíz de la página y cada sección principal.
- No depender del fondo por defecto del navegador.
- Utilizar helpers de Bulma como `bulma-has-background-white-ter` o `bulma-has-background-success-light` para alternar fondos según el diseño.

## Color Rules

- **Prioridad de Colores:** Utilizar preferentemente las clases de estado de Bulma: `bulma-is-success` y `bulma-is-warning`, ya que coinciden con las variables de color del proyecto definidas en `GEMINI.md`.
- **Consistencia:** Usar clases como `bulma-has-text-primary` o `bulma-has-background-success-light` para mantener la jerarquía visual.

## Custom CSS & Specificity

Se permite el uso de CSS personalizado (en `wwwroot/app.css`) para estilos que Bulma no cubra, pero **siempre se debe aplicar alta especificidad** para evitar que los estilos base de Bulma o el reseteo de CSS sobrescriban tus reglas.

### Regla de Oro

Incluye siempre el selector de etiqueta junto con la clase.

### Ejemplos basados en 'app.css'

- **Incorrecto:** `.section-redondeado` (Baja especificidad, Bulma podría ignorarlo).
- **Correcto:** `section.section-redondeado { border-radius: 1rem; }`
- **Otros ejemplos:**
  - `header.header` para el hero personalizado.
  - `div.raya-decoration` para elementos ornamentales.
  - `article.icon-category` para layouts de iconos específicos.

## Spacing and Alignment

- Utilizar los helpers de espaciado de Bulma (ej. `bulma-mt-5`, `bulma-px-4`, `bulma-py-6`).
- Mantener una cadencia vertical constante entre encabezados, párrafos y componentes como `bulma-card` o `bulma-box`.
- Respetar la alineación del diseño (centrado mediante `bulma-is-centered` o niveles con `bulma-level`).

## Typography

- **Jerarquía:** Utilizar `bulma-title` y `bulma-subtitle` con modificadores de tamaño (ej. `bulma-is-1` hasta `bulma-is-7`).
- **Peso y Énfasis:** Utilizar helpers como `bulma-has-text-weight-bold` o `bulma-is-italic` según el mockup.
- Mantener la legibilidad ajustando el ritmo de los párrafos y el ancho de línea dentro de contenedores.
