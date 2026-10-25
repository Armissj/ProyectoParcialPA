# Validación · Etapa 7

## Evidencia ejecutada

- Compilación del programa con Mono C# 6.8: correcta, sin advertencias.
- 96 métodos de prueba con las aserciones de MSTest 4.5.1 mediante runner por reflexión: 96 superados, 0 fallidos. Inicialización y limpieza ejecutadas por caso, de forma secuencial.
- Siete pruebas de carga y plantillas: permisos, datos de todos los módulos, balance de stock contra historial, repetición sin duplicados, conservación de datos existentes, preparación sin dejar una sesión abierta y códigos de ejemplo únicos.
- Recorrido WinForms en Mono con pantalla virtual: 68 comprobaciones correctas.
- Comparación con la compilación anterior de la etapa 6: el botón Productos devolvía BOTON_PRODUCTOS_ABRE_FRMPRODUCTO=False. La etapa 7 abrió el diálogo desde ese botón y desde Agregar producto.

El recorrido gráfico probó login real como administrador y vendedor, carga automática, las doce plantillas de producto, guardado, edición de un vinilo existente, clientes, proveedores y usuarios, borradores de compra y venta, cancelación sin efectos, confirmación, comprobante, los tres reportes y CSV. La ficha del vendedor se comprobó en consulta y rechazó guardar.

## Entorno y límites

No se ejecutó Visual Studio ni VSTest de Windows dentro de este entorno. Los XML incluidos son resultados locales del runner de Mono, no un TRX de Windows. Las capturas muestran el programa ejecutado en Mono; los controles y la tipografía pueden verse distintos en Windows.

Queda ejecutar scripts/Verificar.ps1 y el workflow en Windows, y comprobar el diseñador y la impresión en el equipo de exposición. La etapa 7 conserva los archivos .Designer.cs y .resx, y no cambia la configuración de permisos ni la protección de contraseñas de la tienda.

## Cambio de la regla de ejemplos

La etapa 6 cargaba un catálogo opcional sin stock. Por petición del usuario, la etapa 7 prepara automáticamente una tienda completa de demostración. Los productos se crean con stock cero; las compras y ventas confirmadas generan sus existencias e historial. Preparar las fichas de alta o los borradores no guarda nada hasta la acción del usuario.

La carga inicial ocurre antes de habilitar el login y cierra la sesión temporal de preparación. Entrar a la tienda sigue exigiendo una autenticación válida. Las cargas posteriores no reinician las listas ni reemplazan registros ya existentes.
