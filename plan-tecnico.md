# Plan técnico RAYAO* · Estado de la entrega

## Tecnología y rutas

- C#, Windows Forms, .NET Framework 4.7.2.
- Solución principal: ProyectoParcialPA.slnx en la raíz.
- Programa: ProyectoParcialPA/ProyectoParcialPA/ProyectoParcialPA.csproj.
- Pruebas: ProyectoParcialPA/ProyectoParcialPA.Tests/ProyectoParcialPA.Tests.csproj, net472.
- Almacenamiento: listas en memoria. Cerrar sesión conserva datos; salir del programa los pierde.
- Proyecto principal clásico: los archivos Compile y EmbeddedResource están registrados explícitamente.

## Entidades

Producto es abstracta y contiene código, nombre, precio, stock y activo. El código se normaliza y queda fijo después del alta; Stock tiene setter privado. Los controladores trabajan con copias que conservan el tipo concreto.

| Familia | Tipos concretos |
| --- | --- |
| PerifericoPC | Teclado, Mouse, MonitorPC |
| ComponentePC | Procesador, MemoriaRAM, TarjetaGrafica |
| EquipoMusical | Microfono, InterfazAudio |
| PerifericoConsola | PerifericoPS5, PerifericoSwitch |
| Derivadas directas de Producto | Vinilo, ProductoGaming |

Vinilo usa artista; los demás tipos usan los atributos de su familia. ProductoGaming permite Consola, Videojuego y Accesorio. InterfazAudio admite cero en una de sus cantidades y exige que al menos una sea positiva. Vinilo acepta años de 1900 al año actual más uno.

Usuario conserva hash, salt, iteraciones, rol y activo. Cliente y Proveedor tienen Id automático, sus datos de contacto y estado activo. Las búsquedas normales muestran activos; la baja es una desactivación.

Compra/Venta contienen Id, IdOperacion único, fecha, usuario vigente, participante y detalles. Cada detalle conserva una copia del producto con código y nombre, cantidad y costo o precio unitario. El historial se devuelve mediante copias.

ResumenInventario contiene cantidad de productos int, unidades totales long y valor decimal. Stock sigue siendo int por producto; usar long en la suma evita desbordar el resumen al combinar varios productos grandes.

## Controladores

- TListaProducto: alta, edición, desactivación, consulta, filtro por familia, stock disponible y resumen global.
- TListaUsuario: autenticación y gestión, permisos efectivos y protección del último administrador activo.
- TListaCliente / TListaProveedor: CRUD lógico, búsqueda, validación e Id automático.
- TListaCompra / TListaVenta: preparación, validación, confirmación, historial y consulta por fechas o participante.
- DatosEjemplo: preparación automática antes del login, con 24 productos, 6 clientes, 4 proveedores, 4 cuentas, 3 compras y 3 ventas. La carga pública continúa restringida al administrador y las existencias provienen de operaciones confirmadas.

EstadoTienda proporciona un bloqueo compartido para confirmar inventario e historial juntos. Los controladores de movimientos preparan todas las copias, totales e identidades antes de publicar cambios. Cantidades repetidas se agrupan por código para comprobar stock. Se consolidan líneas si coinciden código e importe; importes distintos conservan líneas separadas.

Una confirmación repetida se rechaza por IdOperacion, además del bloqueo del botón en la interfaz. Validar o cancelar un borrador no modifica el stock. El responsable se obtiene de la sesión; un usuario enviado en el borrador no reemplaza al usuario autenticado.

## Formularios implementados

| Formulario | Función |
| --- | --- |
| frmLogin | Acceso real, contraseña oculta y validación asíncrona |
| frmAdmin | Inventario, resumen, búsqueda, tipo, plataforma, retro y navegación |
| frmProducto | Alta/edición de 12 tipos con campos dinámicos y stock de consulta |
| frmUsuarios | Gestión exclusiva del administrador |
| frmClientes | Gestión de clientes |
| frmProveedores | Gestión del administrador y consulta del vendedor |
| frmCompra | Borrador de compra, detalles y confirmación |
| frmVenta | Borrador de venta, validación de stock y comprobante |
| frmReportes | Inventario actual, historial, fechas, tipos y exportación CSV |

Los nueve formularios incluyen .cs, .Designer.cs y .resx. La vista previa visual anterior se reemplazó por operaciones reales. Program usa ContextoTienda para pasar entre login y menú, conservando listas al cerrar sesión.

RayaoTema carga Assets/png desde el directorio del ejecutable. El proyecto copia los recursos al compilar. Los formularios conservan controles estándar para el diseñador de Visual Studio.

## Validaciones

- Campos de cliente/proveedor obligatorios, teléfono con al menos siete dígitos y email con formato válido.
- Precios y costos mayores a cero y con máximo dos decimales.
- Cantidades enteras positivas y control de desbordamientos de stock e importes.
- Datos inválidos no generan cambios parciales.
- Un producto con movimientos conserva el tipo aunque su stock llegue a cero.
- Los reportes por fechas incluyen ambos días completos; el inventario es el estado actual.
- CSV con UTF-8, comillas escapadas y tratamiento de textos que puedan interpretarse como fórmulas.

## Pruebas y CI

Microsoft.NET.Test.Sdk 18.11.0; MSTest.TestAdapter y MSTest.TestFramework 4.5.1. Las pruebas compartidas se ejecutan sin paralelismo para aislar las listas estáticas.

Se conservaron las pruebas del dominio y se ampliaron las de ejemplos. Total de la etapa 7: 96. La ejecución local por reflexión sobre MSTest en Mono pasó las 96; el recorrido gráfico de la etapa 7 pasó 68 comprobaciones. Las evidencias identifican ese entorno y no se presentan como una ejecución de VSTest en Windows.

GitHub Actions restaura y compila la solución, ejecuta VSTest, comprueba código de salida y que el TRX tenga pruebas ejecutadas, y publica el resultado. Actualizaciones de acciones verificadas en los repositorios oficiales de actions/checkout, actions/setup-dotnet, actions/upload-artifact y microsoft/setup-msbuild.

## Entrega por etapas

1. Inventario y CI: referencias de compilación, permisos de consulta, stock inicial y cambio real de tipo.
2. Clientes y proveedores: entidades, controladores y pruebas.
3. Compras y ventas: movimientos atómicos, historial, stock y pruebas.
4. Formularios: acceso, navegación y conexión con controladores.
5. Identidad visual: PNG, iconos y copia de recursos.
6. Validación y exposición: instrucciones, evidencias y verificación de Windows.

Cada bloque se entrega con sus archivos y un commit sugerido. La publicación y los Pull Requests los realiza Mateo desde su repositorio.

## Comprobaciones pendientes del entorno Windows

- Abrir los formularios en el diseñador de Visual Studio.
- Ejecutar scripts/Verificar.ps1 o el workflow para confirmar el TRX de Windows.
- Probar impresión con una impresora o controlador PDF instalado.

La compilación con Mono, las aserciones y la ejecución gráfica local ya se comprobaron. La guía de demo cubre compra 5, venta 2 y stock final 3.


## Etapa 7 · Correcciones y ejemplos completos

- Productos abre frmProducto desde el menú; Agregar prepara un alta y el vendedor usa una ficha de consulta.
- La navegación crea los formularios dentro del manejo de errores y presenta el mensaje si una pantalla no puede abrirse.
- Login prepara los ejemplos en segundo plano, cierra la sesión de preparación y mantiene la autenticación normal.
- Las doce plantillas tienen datos válidos y códigos nuevos; la edición conserva los datos del producto existente.
- Usuarios, clientes y proveedores muestran listas cargadas y nuevas fichas de ejemplo editables.
- Compra y venta abren borradores de dos líneas. Abrir o cancelar conserva existencias e historial.
- Los reportes tienen compras, ventas e inventario de muestra desde el primer inicio.
- Rama sugerida: fix/etapa7-productos-ejemplos. La aplicación se comprueba en Windows después de copiar los archivos de esta etapa.
