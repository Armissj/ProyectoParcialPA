# RAYAO* · Tienda de PC, gaming y música

Proyecto académico de Mateo Armijos. C#, Windows Forms y .NET Framework 4.7.2, organizado en Entidades, Controladores y Formularios.

## Abrir y ejecutar

Abre ProyectoParcialPA.slnx desde la raíz. En Visual Studio establece **ProyectoParcialPA** como proyecto de inicio y ejecuta F5. El proyecto ProyectoParcialPA.Tests contiene las pruebas.

El login prepara una demostración en segundo plano y muestra el estado mientras carga. Al terminar puedes usar los botones Ejemplo admin y Ejemplo vendedor; completan las credenciales y debes pulsar Entrar. La preparación no deja una sesión iniciada.

| Rol | Usuario | Contraseña inicial de demostración |
| --- | --- | --- |
| Administrador | admin | Admin123* |
| Vendedor | vendedor | Vendedor123* |
| Vendedor de caja | caja_demo | Caja123* |
| Administrador de ejemplo | encargado_demo | Encargado123* |

Las contraseñas se guardan como PBKDF2-HMAC-SHA256, con salt individual y 600000 iteraciones. Las credenciales de la tabla son las de la demostración, no datos de usuarios reales.

## Ejemplos de la etapa 7

La carga inicial crea 24 productos de los 12 tipos concretos, 6 clientes, 4 proveedores, 4 usuarios, 3 compras y 3 ventas. Las compras ingresan 288 unidades y las ventas descuentan 12: el stock total queda en **276 unidades**. PC001 empieza con 10 unidades y PC002 con 11.

Los movimientos de ejemplo se registran usando los mismos controladores y validaciones de la tienda. Los productos nuevos siguen empezando con stock cero. Los contactos y precios son ficticios. Las selecciones de vinilos underground están identificadas como Demo; no representan ediciones comerciales verificadas.

La carga ocurre una sola vez por ejecución y conserva los registros existentes. Cerrar sesión mantiene los datos y las modificaciones; cerrar el programa pierde todas las listas y prepara una demostración nueva al volver a abrirlo.

## Pantallas conectadas

- Login: preparación de la demo y ejemplos de credenciales.
- Principal: inventario, resúmenes, búsquedas y filtros.
- Productos: el botón Productos abre la ficha seleccionada; si no hay selección, el administrador abre un alta. Agregar producto prepara un ejemplo editable de cada tipo. El vendedor abre la ficha en consulta.
- Usuarios, clientes y proveedores: listas con ejemplos y una ficha de alta preparada. Guardar confirma la creación; seleccionar una fila permite consultar o editar según el rol. La contraseña de una cuenta existente permanece vacía en el editor.
- Compra y venta: borradores de dos productos para revisar, modificar, quitar, confirmar o cancelar. Abrir o cancelar no registra movimientos.
- Reportes: inventario actual e historial de compras y ventas por fechas y tipo, con exportación CSV.

El administrador gestiona todos los módulos. El vendedor consulta productos y proveedores, gestiona clientes, compra, vende y consulta reportes; no administra usuarios ni modifica el inventario desde la ficha.

## Recursos y pruebas

Los nueve formularios conservan .cs, .Designer.cs y .resx. Assets debe estar junto a ProyectoParcialPA.csproj; el proyecto copia sus recursos al directorio de salida al compilar.

Se ejecutaron **96 métodos de prueba con las aserciones reales de MSTest** mediante un runner por reflexión en Mono: 96 superados, 0 fallidos. El recorrido gráfico de la etapa 7 pasó **68 comprobaciones**. Se reprodujo además el fallo anterior: el botón Productos de la etapa 6 no abría frmProducto.

La ejecución de Visual Studio, VSTest/GitHub Actions, diseñador e impresión en Windows queda por confirmar en ese entorno. scripts/Verificar.ps1 realiza la restauración, compilación y pruebas y genera un TRX de Windows. Documentacion/VALIDACION.md detalla el alcance.

Para exponer, sigue Documentacion/GUIA_DEMO.md y GUION_EXPOSICION.md.
