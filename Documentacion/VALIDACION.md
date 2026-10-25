# Verificación de la entrega

## Resultados ejecutados

- Compilación del programa completo mediante Mono C# 6.8: correcta.
- 90 métodos de prueba con las aserciones de MSTest 4.5.1: 90 superados, 0 fallidos.
- Runner local: invocación por reflexión de cada prueba, con inicialización y limpieza. Las pruebas se ejecutaron de manera secuencial.
- Tras añadir comprobaciones explícitas al test de permisos, se volvió a ejecutar ese caso: correcto.
- Flujo gráfico WinForms ejecutado en Mono y pantalla virtual: 61 comprobaciones correctas.

El recorrido gráfico usó los controles y eventos reales: login, catálogo de ejemplo, alta de cliente y proveedor, alta de los 12 tipos, filtros, compra de cinco, venta de dos, stock tres, comprobante, rechazo de stock insuficiente, cancelación, reporte, CSV, alta de usuario, edición, roles y cambio de sesión.

Las capturas corresponden al programa ejecutado en ese entorno con datos de prueba; la tipografía y los controles pueden verse ligeramente distintos en Windows.

## Límites de esta verificación

No se ejecutó Visual Studio ni VSTest de Windows dentro de este entorno. Los XML locales son evidencias del runner de Mono y están identificados como tales. No son un TRX producido por GitHub Actions. El TRX de Windows se obtendrá al ejecutar scripts/Verificar.ps1 o publicar el cambio y esperar el workflow.

El diseñador de Visual Studio y la impresión con una impresora real o PDF deben comprobarse en el equipo de exposición. La función de impresión está conectada al comprobante, pero no se envió ningún trabajo de impresión durante estas pruebas.

## CI

Se corrigió el registro de TListaProducto y ResumenInventario en el proyecto. El fallo recibido en GitHub se debía a que el .csproj actualizado no había entrado en el commit 0ed385e.

El workflow conserva el runner Windows, .NET Framework 4.7.2, restauración, compilación, pruebas, comprobación de contador ejecutado y publicación del TRX. Los resultados remotos siguen pendientes hasta el push del usuario.

## Evidencias

La carpeta de evidencias de la entrega incluye el XML de las 90 pruebas, el log del recorrido gráfico y las capturas. Los tests de compras y ventas verifican también casos que no se muestran en la demo: desbordamientos, líneas repetidas, participantes inactivos, copias protegidas y conservación del historial.
