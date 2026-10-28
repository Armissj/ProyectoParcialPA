# Guion para exponer RAYAO*

## Presentación

RAYAO es una tienda que junta cosas que me gustan: periféricos y componentes de PC, consolas y música. El sistema permite revisar productos, registrar clientes y proveedores, comprar mercadería y venderla.

Para poder demostrar todas las pantallas, al iniciar se prepara una tienda de ejemplo. Tiene productos, clientes, proveedores y operaciones. Los datos están en memoria: si cierro sesión siguen ahí, pero si cierro el programa se pierden.

## Cómo organicé el programa

Usé la estructura de entidades, controladores y formularios. Las entidades representan los datos, por ejemplo Producto, Cliente, Compra y Venta. Los controladores trabajan con las listas y comprueban las reglas. Los formularios permiten introducir y mostrar esa información.

La clase Producto es abstracta. De ella salen las familias y los tipos concretos: un procesador tiene socket y núcleos, mientras que un vinilo tiene artista, género y año. Así cada producto tiene sus propios datos y se puede manejar en la misma lista de productos.

## Lo que voy a mostrar

Primero entro como administrador. Aquí está el inventario de ejemplo con 24 productos y 276 unidades. El botón Productos abre la ficha seleccionada. En Agregar producto puedo cambiar el tipo y ver los campos que necesita cada uno.

Después puedo enseñar clientes, proveedores y usuarios. Las fichas nuevas traen ejemplos que puedo editar. Solo se guardan cuando pulso Guardar.

En Compras y Ventas se prepara una lista de productos. Puedo revisar cantidades y precios antes de confirmar. El stock cambia cuando confirmo toda la operación. Si cancelo, no cambia nada. Los ejemplos del historial también entraron por estos controladores: no puse el stock manualmente.

En Reportes puedo ver inventario, compras y ventas, filtrar por fechas y exportar CSV. El historial conserva los datos originales del movimiento aunque después cambie el producto.

Por último cierro sesión y entro como vendedor. Conserva los datos, pero sus permisos cambian: consulta la ficha de productos, registra operaciones y no administra usuarios.

## Corrección de la etapa 7

Se corrigió el botón Productos: antes solo llevaba al buscador y no abría la ficha. También se completaron los ejemplos para practicar todos los módulos. Se verificó que abrir y cancelar borradores no cambia el stock, y que cambiar de cuenta conserva la tienda.

## Pruebas y alcance

El proyecto tiene 96 pruebas con MSTest. Las aserciones se ejecutaron con un runner en Mono, con 96 resultados correctos. Además se hizo un recorrido real de formularios con 68 comprobaciones. GitHub Actions y el script de verificación permiten comprobar la compilación y las pruebas en Windows; su resultado se confirma cuando se ejecutan allí.

Una limitación del proyecto es que todavía no guarda en una base de datos. Para esta versión se utilizaron listas en memoria, de acuerdo con las especificaciones del trabajo.
