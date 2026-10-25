# RAYAO* · Tienda de PC, gaming y música

Proyecto académico de Mateo Armijos. C#, Windows Forms y .NET Framework 4.7.2, con Entidades, Controladores y Formularios.

## Abrir y ejecutar

1. Abre la solución de la raíz: ProyectoParcialPA.slnx.
2. Establece ProyectoParcialPA como proyecto de inicio y ejecuta con F5.
3. Entra como administrador o vendedor.

| Rol | Usuario | Contraseña de demostración |
| --- | --- | --- |
| Administrador | admin | Admin123* |
| Vendedor | vendedor | Vendedor123* |

Las contraseñas se guardan como PBKDF2-HMAC-SHA256 con salt individual y 600000 iteraciones. Las cuentas de demostración se crean una sola vez por ejecución.

## Qué puedes hacer

- Gestionar los 12 tipos concretos de productos de PC, audio, vinilos y consolas.
- Buscar por código, nombre o artista y combinar tipo, plataforma y retro.
- Gestionar clientes, proveedores y usuarios con permisos por rol.
- Registrar compras y ventas con varios productos, validación de stock y confirmación única.
- Consultar el historial con sus datos originales, ver comprobantes e imprimirlos.
- Consultar reportes de inventario, compras y ventas y exportar CSV.

## Preparar la demostración

Como administrador, pulsa **Cargar ejemplo**. Se agregan 16 productos de muestra, un cliente y un proveedor; todos los productos comienzan con stock cero. Los nombres y precios son datos de demostración. El botón conserva los registros existentes y evita cargar el ejemplo dos veces.

Compra 5 unidades de PC001 a costo 18.00; después vende 2 a precio 25.50. La compra suma 90.00, la venta suma 51.00 y el stock queda en 3. El valor de inventario de ese producto será 76.50.

## Memoria y permisos

Los datos viven en listas estáticas en memoria. Cerrar sesión conserva la tienda; cerrar el programa pierde los datos. El vendedor consulta productos y proveedores, gestiona clientes, compra, vende y consulta reportes. El administrador gestiona todos los módulos.

## Compilación y pruebas

En Windows, scripts/Verificar.ps1 restaura, compila y ejecuta MSTest, y genera un TRX nuevo. La solución contiene el proyecto de pruebas separado net472.

La entrega incorpora 90 pruebas MSTest. En la preparación se ejecutaron sus aserciones mediante un runner por reflexión en Mono: 90 superadas, 0 fallidas. También se ejecutó un recorrido gráfico con 61 comprobaciones de interfaz. Documentacion/VALIDACION.md detalla el entorno y las comprobaciones pendientes de Windows.

GitHub Actions compila y ejecuta las pruebas en Windows. El resultado remoto solo queda confirmado después del push; consulta el job Build and test y el artefacto rayao-test-results.

## Organización

| Ruta | Contenido |
| --- | --- |
| ProyectoParcialPA/ProyectoParcialPA | Programa WinForms |
| ProyectoParcialPA/ProyectoParcialPA.Tests | Pruebas MSTest |
| Entidades, dentro del programa | Productos, usuarios, clientes, proveedores y movimientos |
| Controladores, dentro del programa | Listas, permisos y reglas de negocio |
| Formularios, dentro del programa | Nueve pantallas editables |
| Assets/png, dentro del programa | Fondos, productos, iconos y logo |
| Documentacion | Guía de demostración, validación y explicación para exponer |

La integración se entrega también por bloques para registrar cada avance en GitHub. El código y sus resultados se revisaron con apoyo de IA.
