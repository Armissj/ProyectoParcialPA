# RAYAO\* - Cómo va a funcionar el sistema

**Versión:** 0.1 - catálogo e inventario  
**Fecha:** 24 de octubre de 2026  
**Materia:** Programación Avanzada en C#  
**Forma de trabajo:** Spec Driven Development (SDD)

## 1. Qué queremos hacer

La idea es crear un programa para RAYAO*, una tienda que junta dos cosas que nos gustan: las PC y la música. Vamos a manejar periféricos, componentes de PC, equipos para hacer música y discos de vinilo.

En esta primera versión queremos llevar el inventario: saber qué productos hay, cuánto cuestan y cuántas unidades quedan. También vamos a poder agregar productos, buscarlos, cambiar sus datos y eliminarlos.

Para empezar, vamos a trabajar con listas en memoria, como en la práctica de clase. Eso significa que los datos estarán disponibles mientras el programa esté abierto y se perderán al cerrarlo. Cada vez que lo abramos, la lista empezará vacía.

## 2. Quién lo va a usar

Lo va a usar la persona encargada de la tienda. Desde las ventanas del programa podrá revisar y administrar los productos. Por ahora vamos a trabajar con un solo tipo de usuario.

## 3. Qué productos vamos a manejar

| Categoría | Qué podemos poner aquí |
|---|---|
| Periféricos PC | Teclados, mouse y audífonos para PC. |
| Componentes PC | Memorias RAM, SSD y tarjetas gráficas. |
| Equipo musical | Micrófonos, interfaces de audio, controladores MIDI y monitores de estudio. |
| Vinilos | Discos con el nombre del álbum y del artista. |

En los vinilos podemos incluir distintos artistas y géneros. Los productos que ingresemos para mostrar cómo funciona el programa serán ejemplos de prueba.

## 4. Qué datos tendrá cada producto

| Dato | Qué vamos a guardar | Qué debemos revisar |
|---|---|---|
| Código | Un texto para identificar el producto. | Es obligatorio y no se puede repetir. Quitaremos los espacios del inicio y del final y lo guardaremos en mayúsculas. Una vez registrado, el código se queda igual. |
| Nombre | El nombre del producto o del álbum, si es un vinilo. | No puede quedar vacío. |
| Categoría | Una de las cuatro categorías de la tienda. | Hay que seleccionar una. |
| Marca | La marca del periférico, componente o equipo musical. | Es obligatoria en esas tres categorías. |
| Artista | El nombre del artista del vinilo. | Es obligatorio cuando el producto es un vinilo. |
| Precio | Lo que cuesta una unidad, en dólares. | Tiene que ser mayor que cero y tener máximo dos decimales. Usaremos decimal. |
| Stock | Cuántas unidades tenemos. | Tiene que ser un número entero, desde cero en adelante. |

Antes de guardar, quitaremos los espacios que sobren al inicio y al final de los textos. Escribir solo espacios cuenta como dejar el dato vacío. Si registramos un vinilo, la Marca quedará vacía. En las otras categorías, el Artista quedará vacío.

## 5. Qué tiene que hacer el programa

### RF01. Agregar un producto

Abrimos el formulario, llenamos los datos y damos clic en Aceptar. Si todo está bien, el producto se agrega a la lista y aparece en la tabla. Si falta algo o hay un dato incorrecto, el programa nos dice qué debemos corregir y no lo guarda.

### RF02. Ver los productos

En la ventana principal vamos a tener una tabla, usando DataGridView, con estas columnas: Código, Nombre, Categoría, Marca, Artista, Precio y Stock. Los precios se mostrarán con dos decimales.

Si todavía no hemos registrado nada, la tabla estará vacía y aparecerá un mensaje indicando que no hay productos.

### RF03. Buscar un producto

Vamos a poder buscar por el código completo, por una parte del nombre o por una parte del nombre del artista. Tiene que funcionar igual si escribimos con mayúsculas o minúsculas. También se quitarán los espacios que sobren al inicio y al final de la búsqueda.

Si dejamos la búsqueda vacía, se mostrarán todos los productos de la categoría que tengamos seleccionada. Si no se encuentra nada, la tabla quedará vacía y el programa nos avisará.

### RF04. Cambiar los datos de un producto

Primero seleccionamos el producto. Al abrir el formulario, sus datos ya tienen que estar cargados. Podemos cambiar el nombre, la categoría, la marca, el artista, el precio y el stock. El código se verá en pantalla, pero no se podrá editar.

Al aceptar, se actualiza ese mismo producto y se revisan las mismas reglas que al registrarlo. Si cambiamos la categoría, se pedirá Marca o Artista según corresponda y se dejará vacío el campo que ya no aplique. Si damos en Cancelar, se cerrará la ventana y el producto quedará como estaba.

### RF05. Eliminar un producto

Seleccionamos el producto y damos clic en Eliminar. Antes de borrarlo, el programa nos preguntará si estamos seguros. Si aceptamos, se elimina solo ese producto y se actualiza la tabla. Si cancelamos, todo queda igual.

### RF06. Mostrar productos por categoría

Vamos a poder escoger una categoría o la opción Todas. Por ejemplo, al escoger Vinilos se mostrarán solo los discos.

La categoría también se aplicará cuando hagamos una búsqueda. Si tenemos seleccionado Vinilos y buscamos un artista, se mostrarán los vinilos que coincidan. Con Todas, la búsqueda se hará entre los productos de cualquier categoría.

### RF07. Ver un resumen del inventario

En la ventana principal vamos a mostrar cuántos productos distintos tenemos registrados, cuántas unidades hay en total y cuánto vale todo el inventario.

Para sacar ese valor, multiplicamos el precio por el stock de cada producto y sumamos los resultados. El resumen siempre será de todo el inventario, aunque estemos viendo una búsqueda o una sola categoría. Se actualizará al agregar, modificar o eliminar. Si la lista está vacía, los tres valores serán cero.

## 6. Reglas que vamos a tener en cuenta

- No se puede repetir un código. Por ejemplo, PC001 y pc001 se tomarán como el mismo código.
- Si hay un error en los datos, no se cambia lo que ya estaba guardado.
- Para modificar o eliminar, primero hay que seleccionar un producto. Si no lo hacemos, el programa nos avisa y no cambia nada.
- Si damos en Cancelar al registrar o editar, no se guardan los cambios.
- Los mensajes tienen que explicar qué dato falta o qué está mal.
- Después de guardar un cambio, la tabla y el resumen se actualizan. La búsqueda y la categoría que teníamos seleccionadas se mantienen.

## 7. Cómo vamos a organizar el código

Vamos a usar C#, Windows Forms y .NET Framework 4.7.2. Lo organizaremos como el trabajo de clase, con Entidades, Controladores y Formularios.

| Carpeta | Clase o formulario | Para qué lo vamos a usar |
|---|---|---|
| Entidades | Producto | Para guardar los datos del producto, con sus atributos, constructores y propiedades. |
| Controladores | TListaProducto | Para manejar List<Producto>, revisar que los códigos no se repitan y hacer las operaciones de agregar, modificar, eliminar, buscar y consultar. |
| Formularios | frmAdmin | Será la ventana principal, donde veremos la tabla, la búsqueda, las categorías, el resumen y los botones. |
| Formularios | frmProducto | Será la ventana para registrar o editar. Aquí llenaremos los datos y tendremos Aceptar y Cancelar. |

Seguiremos usando nombres como TListaProducto, CrearObjeto() y Listar(), igual que en clase. Para consultar las listas podemos usar LINQ.

El nombre de la tienda es RAYAO*. En los archivos y las clases usaremos Rayao, sin el asterisco.

## 8. Cómo vamos a comprobar que funciona

Estas son las pruebas que vamos a hacer cuando el programa esté creado. Aquí dejamos escrito qué esperamos que pase; después registraremos los resultados y las evidencias.

| Prueba | Función | Qué vamos a revisar |
|---|---|---|
| CA01 | RF01, RF02 | Agregar PC001, Teclado mecánico, Periféricos PC, una marca, precio 25.50 y stock 5. Tiene que guardarse un producto y aparecer en la tabla. |
| CA02 | RF01 | Intentar agregar pc001 cuando ya existe PC001. Tiene que avisar que el código está repetido y dejar la lista igual. |
| CA03 | RF01, RF04 | Dejar un dato obligatorio vacío o escribir solo espacios. Tiene que pedir que lo completemos y no guardar el cambio. |
| CA04 | RF01, RF04 | Poner stock negativo o con decimales. No tiene que permitir guardarlo. |
| CA05 | RF01, RF04 | Poner precio cero, negativo o con más de dos decimales. Tiene que pedir un precio válido. |
| CA06 | RF01, RF04 | Intentar guardar un vinilo sin Artista, o un periférico, componente o equipo musical sin Marca. Tiene que pedir el dato que falta. |
| CA07 | RF03, RF06 | Buscar tecla y escoger Periféricos PC. Tienen que salir solo los periféricos cuyo nombre contenga ese texto, sin importar las mayúsculas. También probaremos que buscar un artista encuentre sus vinilos. |
| CA08 | RF04 | Cambiar el precio y el stock de PC001. Tiene que actualizarse el mismo producto, conservar su código y mantenerse la cantidad de productos registrados. |
| CA09 | RF01, RF04 | Llenar datos y dar en Cancelar. El inventario tiene que quedar como estaba antes de abrir el formulario. |
| CA10 | RF05 | Intentar eliminar un producto y cancelar. Tiene que seguir en la lista. Si repetimos la operación y confirmamos, tiene que borrarse solo ese producto. |
| CA11 | RF04, RF05 | Dar en Modificar o Eliminar sin seleccionar nada. Tiene que aparecer un aviso y no cambiar la lista. |
| CA12 | RF03, RF06 | Dejar vacía la búsqueda y escoger Vinilos. Tienen que aparecer todos los vinilos. Al escoger Todas, tiene que aparecer el inventario completo. |
| CA13 | RF07 | Tener un producto de 25.50 con stock 5 y otro de 10.00 con stock 2. El resumen tiene que indicar 2 productos, 7 unidades y 147.50 dólares. Cambiar el filtro no debe cambiar ese resumen general. |
| CA14 | RF02, RF03, RF07 | Abrir el programa con la lista vacía o buscar algo que no existe. La tabla tiene que quedar vacía. El resumen será cero solo si no hay ningún producto en todo el inventario. |
| CA15 | RF04 | Cambiar un producto de Equipo musical a Vinilos. Tiene que pedir Artista y dejar Marca vacía. Si cancelamos, tienen que mantenerse la categoría y los datos que tenía antes. |

## 9. Cómo vamos a trabajar con SDD

Primero dejamos escrito lo que queremos que haga el sistema en este archivo. Con eso vamos a preparar el plan técnico, repartir las tareas y pedirle a la IA que genere el código siguiendo estas indicaciones.

Después vamos a ejecutar el programa y hacer las pruebas de arriba para ver si cumple lo que pedimos. Si queremos cambiar alguna función, primero actualizamos lo que está escrito y luego cambiamos el programa.

Este documento irá en la rama documentacion-sdd. Vamos a guardar el cambio con un commit y abrir un Pull Request para revisarlo antes de pasarlo a main y seguir con la implementación.
