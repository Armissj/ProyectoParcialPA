# RAYAO\* - Especificaciones del sistema

**Versión:** 0.2 - sistema de tienda con compras y ventas  
**Fecha:** 24 de octubre de 2026  
**Materia:** Programación Avanzada en C#  
**Forma de trabajo:** Spec Driven Development (SDD)

La idea es administrar RAYAO*, una tienda de tecnología, gaming y música. Vamos a manejar productos, clientes, proveedores, usuarios, compras y ventas siguiendo la organización que usamos en clase. Las entidades tendrán atributos privados, constructores y propiedades públicas, respetando las reglas que restringen los cambios de código y stock.

## 1. Arquitectura General

- Lenguaje y Framework: C#, Windows Forms, .NET Framework 4.7.2
- Organización: Entidades, Controladores y Formularios
- Persistencia: Listas en memoria (los datos se perderán al cerrar el programa)

La clase base es `Producto`, que es abstracta. Las familias y sus clases concretas quedan así:

| Familia | Clases concretas |
|---|---|
| PerifericoPC | Teclado, Mouse, MonitorPC |
| ComponentePC | Procesador, MemoriaRAM, TarjetaGrafica |
| EquipoMusical | Microfono, InterfazAudio |
| PerifericoConsola | PerifericoPS5, PerifericoSwitch |
| Producto | Vinilo, ProductoGaming |

Las cuatro familias intermedias también son abstractas. Los apartados de PS5 y Switch se muestran por separado. `ProductoGaming` reúne consolas, videojuegos y accesorios; `EsRetro` permite identificar los artículos retro.

## 2. Entidades

### Producto (abstracta)

- Atributos: código (único, en mayúsculas, sin espacios sobrantes), nombre, precio (máx. dos decimales), stock
- Propiedades: públicas para cada atributo
- Constructores: por defecto y parametrizado

### PerifericoPC (abstracta, hereda de Producto)

- marca

### Teclado (hereda de PerifericoPC)

- tipo (mecánico, membrana, etc.)

### Mouse (hereda de PerifericoPC)

- DPI

### MonitorPC (hereda de PerifericoPC)

- pulgadas, Hz

### ComponentePC (abstracta, hereda de Producto)

- marca

### Procesador (hereda de ComponentePC)

- socket, núcleos

### MemoriaRAM (hereda de ComponentePC)

- capacidad, tipo

### TarjetaGrafica (hereda de ComponentePC)

- memoria, chipset

### EquipoMusical (abstracta, hereda de Producto)

- marca

### Microfono (hereda de EquipoMusical)

- tipo (condensador, dinámico, etc.)

### InterfazAudio (hereda de EquipoMusical)

- entradas, salidas

### Vinilo (hereda de Producto)

- artista, género, año

### PerifericoConsola (abstracta, hereda de Producto)

- marca, tipoAccesorio, compatibilidad

### PerifericoPS5 (hereda de PerifericoConsola)

Usa los datos comunes de PerifericoConsola y representa los accesorios compatibles con PS5.

### PerifericoSwitch (hereda de PerifericoConsola)

Usa los datos comunes de PerifericoConsola y representa los accesorios compatibles con Nintendo Switch.

### ProductoGaming (hereda de Producto)

- marca, plataforma, tipoArticulo (consola, videojuego, accesorio), esRetro

### Usuario

- id, nombreUsuario, contraseña (almacenada protegida, no en texto plano), rol (Administrador/Vendedor)
- Propiedades públicas, constructores

### Cuentas de prueba iniciales

| Rol | Usuario | Contraseña de demostración |
|---|---|---|
| Administrador | admin | `Admin123*` |
| Vendedor | vendedor | `Vendedor123*` |

### Cliente

- id, nombre, apellido, dirección, teléfono, email

### Proveedor

- id, nombre, contacto, teléfono, email

### Compra

- id, fecha, proveedor, usuario, lista de DetalleCompra

### DetalleCompra

- producto, cantidad, costoUnitario

### Venta

- id, fecha, cliente, usuario, lista de DetalleVenta

### DetalleVenta

- producto, cantidad, precioUnitario

## 3. Controladores

- TListaProducto: List<Producto>, métodos estáticos para CRUD, búsquedas, filtros, resumen, validaciones.
- TListaUsuario: List<Usuario>, métodos para CRUD, autenticación, comprobación de permisos.
- TListaCliente: List<Cliente>, métodos para CRUD y búsquedas.
- TListaProveedor: List<Proveedor>, métodos para CRUD y búsquedas.
- TListaCompra: List<Compra>, métodos para registrar, consultar y filtrar compras. Controla duplicados y confirma operaciones.
- TListaVenta: List<Venta>, métodos para registrar, consultar y filtrar ventas. Controla duplicados y confirma operaciones.

## 4. Formularios

### frmLogin

- Controles: TextBox usuario, TextBox contraseña (oculta), botón Entrar, botón Salir.
- Función: Validar usuario y contraseña, permitir acceso según rol. Permite cerrar sesión.

### frmAdmin (principal)

- Controles:
- Tabla de inventario (DataGridView)
- Búsqueda y filtros
- Resumen general (no cambia por filtros)
- Botones para gestionar productos
- Acceso a los otros módulos según permisos
- Botón para cerrar sesión
- Función: Acceso a módulos, muestra resumen general, permite cerrar sesión.

### frmUsuarios (solo administrador)

- Controles: DataGridView de usuarios, botones Agregar, Editar, Eliminar, Buscar, Salir.
- Función: CRUD de usuarios.

### frmClientes

- Controles: DataGridView de clientes, botones Agregar, Editar, Eliminar, Buscar, Salir.
- Función: CRUD de clientes.

### frmProveedores

- Controles: DataGridView de proveedores, botones Agregar, Editar, Eliminar, Buscar, Salir.
- Función: CRUD de proveedores.

### frmProducto

- Controles: ComboBox tipo de producto, campos dinámicos según tipo, botones Guardar, Cancelar.
- Función: Alta y edición de productos, validaciones, muestra solo campos relevantes. El stock se muestra como dato de consulta. Solo los productos nuevos empiezan en cero; al editar se conserva el stock actual, sin permitir cambiarlo desde este formulario.

### frmCompra

- Controles: ComboBox proveedor, DataGridView para productos de la compra (producto, cantidad, costo), botón Agregar producto, botón Confirmar, botón Cancelar.
- Función: Registrar compras, sumar productos, validar cantidades y costos, confirmar o cancelar operación. El stock solo cambia al confirmar.

### frmVenta

- Controles: ComboBox cliente, DataGridView para productos de la venta (producto, cantidad, precio), botón Agregar producto, botón Confirmar, botón Cancelar, muestra total y comprobante.
- Función: Registrar ventas, sumar productos, validar stock y precios, confirmar o cancelar operación. El stock solo cambia al confirmar.

### frmReportes

- Controles: Filtros por fechas, tipo de reporte (compras, ventas, inventario), DataGridView para mostrar resultados, botón Exportar/Imprimir, botón Salir.
- Función: Consultar y filtrar compras, ventas e inventario.

## 5. Reglas y Validaciones

- El código de producto debe ser único, en mayúsculas y sin espacios sobrantes.
- La búsqueda de productos no distingue mayúsculas/minúsculas.
- Precios y costos con máximo dos decimales, mayores a cero.
- El stock de productos nuevos inicia en cero y solo cambia con compras/ventas confirmadas.
- No se puede vender más unidades de las disponibles.
- Cantidades deben ser enteras y positivas.
- El costo de compra y el precio de venta son datos distintos.
- El stock solo cambia al confirmar una compra o venta completa.
- Antes de confirmar se valida toda la operación. Si se cancela o hay un error en cualquier línea, no se registra la compra o venta ni se modifica ningún stock.
- Si se agrega varias veces el mismo producto en una compra/venta, se suman las cantidades antes de confirmar.
- Evitar doble registro de compras/ventas: deshabilitar botón Confirmar tras primer clic y controlar en el controlador.
- Registrar el usuario que realiza cada operación.
- Las compras y ventas confirmadas conservan los nombres, cantidades y precios originales aunque después se edite el producto.
- Para productos, clientes, proveedores y usuarios con movimientos registrados, solo se pueden desactivar (no eliminar físicamente). Los desactivados no aparecen en altas nuevas ni en búsquedas normales.
- Al editar un producto y cambiar su tipo, se validan y limpian los campos específicos. Si el producto tiene movimientos registrados, no se permite cambiar el tipo.
- El resumen general del inventario muestra totales y no cambia al aplicar filtros.
- Los datos se mantienen solo en memoria; al cerrar el programa se pierden todos los registros. Cerrar sesión conserva las listas mientras el programa siga abierto.
- Código y nombre son obligatorios. Quitamos los espacios del inicio y del final de los textos; escribir solo espacios cuenta como dejar el campo vacío.
- El código se guarda en mayúsculas y no cambia después del registro. PC001 y pc001 se consideran el mismo código, sin importar el tipo de producto.
- Buscamos por código completo o por una parte del nombre o del artista. La búsqueda se combina con los filtros; si está vacía, muestra todos los productos que cumplan los filtros seleccionados.
- El resumen general indica productos activos distintos, unidades disponibles y valor del inventario a precio de venta: suma de precio por stock. Con inventario vacío, los tres valores son cero.
- Si cancelamos una edición o falla una validación, el producto queda como estaba. Después de un cambio se actualizan tabla y resumen, manteniendo la búsqueda y los filtros.

## 6. Permisos por Rol

### Administrador

- Acceso total a todos los módulos: productos, usuarios, clientes, proveedores, compras, ventas, reportes.
- Puede agregar, editar y eliminar/desactivar usuarios, productos, clientes y proveedores.
- Puede consultar todo el inventario y modificar los datos permitidos de los productos. El stock cambia mediante compras y ventas confirmadas.

### Vendedor

- Puede consultar productos, administrar clientes, consultar proveedores, registrar compras y ventas, consultar reportes.
- No puede modificar productos, proveedores ni usuarios.
- Los permisos se comprueban tanto en la interfaz como en los controladores.

## 7. Pruebas y Resultados Esperados

### Pruebas de acceso y roles

- Entrar como admin (admin/Admin123*) permite acceso total.
- Entrar como vendedor (vendedor/Vendedor123*) impide gestionar usuarios y modificar productos o proveedores. Sí permite consultar proveedores y usar las demás funciones autorizadas.
- Intentar acceder a un módulo sin permiso muestra mensaje y no permite la acción.

### Pruebas de productos y stock

- Crear producto "MON001", stock inicial 0.
- Comprar 5 unidades: stock queda en 5.
- Vender 2 unidades: stock queda en 3.
- Intentar vender 4 unidades: operación rechazada, stock sigue en 3.
- Cancelar una compra o venta: stock no cambia.
- Editar producto con movimientos: no se puede cambiar su tipo. Los cambios permitidos conservan el código, el stock actual y el historial.
- Eliminar producto con movimientos: solo se desactiva, no se elimina.

### Pruebas de compras y ventas

- Registrar compra con varios productos y cantidades, confirmar: stock aumenta correctamente.
- Registrar venta con varios productos y cantidades, confirmar: stock disminuye correctamente.
- Agregar dos veces el mismo producto en una compra suma cantidades antes de confirmar.
- Intentar confirmar dos veces la misma operación: solo se registra una vez.
- Cancelar operación: no cambia nada.

### Pruebas de clientes y proveedores

- Alta, baja, modificación y búsqueda de clientes y proveedores.
- Eliminar cliente/proveedor con movimientos: solo se desactiva.

### Pruebas de reportes

- Consultar compras, ventas e inventario.
- Filtrar por fechas y tipos de producto.
- Ver totales y comprobantes.

### Pruebas de sesión y persistencia

- Permite cerrar sesión y volver a frmLogin.
- Al cerrar el programa, todos los datos se pierden.

## 8. Orden de desarrollo por etapas (con pruebas en cada una)

### 1. Diseño de entidades y controladores

- Crear jerarquía de productos, Usuario, Cliente, Proveedor, Compra, DetalleCompra, Venta, DetalleVenta
- Controladores para cada entidad
- Pruebas: crear, buscar, modificar y desactivar entidades en memoria

### 2. frmLogin y control de acceso

- Validación de usuario y contraseña, roles, cierre de sesión
- Pruebas: acceso con cuentas de prueba, restricciones por rol

### 3. frmAdmin

- Tabla de inventario, búsqueda, filtros, resumen, botones de gestión
- Pruebas: visualizar inventario, aplicar filtros, ver resumen

### 4. frmUsuarios (solo admin)

- CRUD de usuarios, desactivación
- Pruebas: agregar, editar, desactivar usuarios, comprobar permisos

### 5. frmProducto y TListaProducto

- Alta, baja, modificación, validaciones, stock solo por compras/ventas
- Pruebas: crear producto, editar, desactivar, cambiar tipo, validar reglas

### 6. frmClientes y frmProveedores

- CRUD completo, desactivación
- Pruebas: agregar, editar, desactivar, comprobar restricciones

### 7. frmCompra

- Registrar compras, sumar productos, validar cantidades y costos, confirmar/cancelar
- Pruebas: stock, duplicados, cancelaciones, validaciones

### 8. frmVenta

- Registrar ventas, validar stock, confirmar/cancelar
- Pruebas: stock, duplicados, cancelaciones, validaciones

### 9. frmReportes

- Consultas y filtros
- Pruebas: reportes por fechas, totales, comprobantes

### 10. Pruebas integrales y validaciones finales

### 11. Personalización visual (logo, fondos, iconos)

**Nota:**

Durante el desarrollo, realizar las pruebas indicadas en cada etapa para asegurar el cumplimiento de las reglas y el correcto funcionamiento del sistema.

## 9. Cómo vamos a trabajar con SDD

Primero dejamos estas especificaciones en el repositorio. Después preparamos el plan técnico con archivos, responsabilidades, métodos, controles y tareas por etapa. Con ese plan pediremos a Copilot que genere el código por partes.

En cada etapa revisaremos el código y ejecutaremos sus pruebas. Los casos de este documento indican lo que esperamos; todavía no son resultados ejecutados. Guardaremos las evidencias cuando exista el programa.

Los cambios se trabajarán en ramas y se revisarán con Pull Requests antes de integrarlos a main. También prepararemos un flujo de GitHub Actions para compilar y ejecutar las pruebas automáticas.

Si cambia una función, primero actualizamos las especificaciones y el plan. Los fondos, iconos y demás recursos visuales se prepararán con el estilo de RAYAO* cuando tengamos definidas las pantallas.
