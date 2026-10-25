# Plan técnico - RAYAO* 0.2

**Revisión:** 24 de octubre de 2026.

Las clases, pruebas y automatización descritas están planificadas. Este documento no afirma que el código se haya implementado ni que las pruebas ya hayan pasado.

## 1. Confirmación del alcance

Este proyecto corresponde a la versión 0.2 de RAYAO*, con las siguientes áreas funcionales exigidas por las especificaciones:

- Inicio de sesión
- Usuarios con roles
- Compras
- Ventas
- Reportes
- Inventario y gestión de productos
- Clientes, proveedores y usuarios

La idea central es desarrollar una aplicación de escritorio en C# con Windows Forms y .NET Framework 4.7.2, con una organización por capas de Entidades, Controladores y Formularios. Los datos serán en memoria durante la ejecución del programa, sin persistencia en base de datos.

## 2. Estado actual del repositorio

El proyecto actual ya existe en la solución y ahora se ha preparado la base técnica para la etapa 1A y 1B:

- La solución existente está en la raíz del repositorio como `ProyectoParcialPA.slnx`.
- El proyecto principal está ajustado a .NET Framework 4.7.2.
- El proyecto de pruebas `ProyectoParcialPA/ProyectoParcialPA.Tests/ProyectoParcialPA.Tests.csproj` está en net472 con MSTest y referencia al proyecto principal.
- Ya se han implementado las clases base `Producto`, `PerifericoPC` y `Teclado`, junto con sus pruebas de validación iniciales.
- La estructura del proyecto aún no contiene formularios ni controladores del negocio; se dejará para etapas posteriores.

La preparación actual cumple la base técnica necesaria para continuar con la etapa 1B y con la implementación del dominio restante.

## 3. Objetivo de tecnología

- Lenguaje: C#
- UI: Windows Forms
- Framework objetivo: .NET Framework 4.7.2
- Organización: Entidades, Controladores, Formularios
- Persistencia: listas en memoria
- Pruebas: proyecto separado `ProyectoParcialPA.Tests` con MSTest para .NET Framework 4.7.2

Nota de ajuste planificado:

- El proyecto actual está en .NET Framework 4.8.
- En la primera etapa se debe planificar y ajustar el objetivo a 4.7.2 antes de comenzar la implementación de clases y formularios.
- Este cambio no se realizará en esta tarea; solo se deja formalizado en el plan técnico.

## 4. Estructura del repositorio propuesta

### 4.1 Rutas del repositorio y de la solución

Estas rutas son relativas a la raíz del repositorio de Git, donde están README.md, especificaciones.md y este plan. Se conserva la solución existente .slnx en la raíz del repositorio.

| Elemento | Ruta desde la raíz del repositorio |
|---|---|
| Solución existente | `ProyectoParcialPA.slnx` |
| Proyecto principal | `ProyectoParcialPA/ProyectoParcialPA/ProyectoParcialPA.csproj` |
| Arranque principal | `ProyectoParcialPA/ProyectoParcialPA/Program.cs` |
| Nuevo proyecto de pruebas | `ProyectoParcialPA/ProyectoParcialPA.Tests/ProyectoParcialPA.Tests.csproj` |
| Workflow planificado | `.github/workflows/ci.yml` |

Antes de modificar proyectos o crear CI, Copilot comprobará las rutas contra los archivos reales. Si alguna difiere, actualizará la ruta en el plan y conservará la solución existente. No se creará una solución .sln adicional por seguir un ejemplo.

El proyecto principal tendrá Entidades, Controladores, Formularios, Utilidades, Sesiones y Properties.

### 4.2 Proyecto de pruebas

- Proyecto separado ProyectoParcialPA.Tests, dentro de la solución existente.
- Proyecto SDK con Microsoft.NET.Sdk y TargetFramework net472.
- Paquetes Microsoft.NET.Test.Sdk, MSTest.TestFramework y MSTest.TestAdapter, con versiones estables compatibles fijadas al crear el proyecto. Framework y adapter usarán la misma versión.
- Ejecutor elegido: VSTest, tanto en Visual Studio como en CI.
- Referencia al proyecto principal existente.
- Las pruebas no se compilan dentro del ejecutable WinForms.
- Cada prueba de controladores limpia las listas y la sesión antes y después de ejecutarse. Las pruebas que comparten estado estático no se ejecutan en paralelo.

### 4.3 Archivos esperados por capa

Las rutas Entidades, Controladores, Formularios, Sesiones y Utilidades son relativas al proyecto principal. Las rutas que empiezan por ProyectoParcialPA.Tests son relativas a la carpeta de la solución ProyectoParcialPA/. En la sección 14 las rutas se indican desde la raíz del repositorio.

#### Entidades

- `Entidades/Producto.cs`
- `Entidades/PerifericoPC.cs`
- `Entidades/ComponentePC.cs`
- `Entidades/EquipoMusical.cs`
- `Entidades/PerifericoConsola.cs`
- `Entidades/Teclado.cs`
- `Entidades/Mouse.cs`
- `Entidades/MonitorPC.cs`
- `Entidades/Procesador.cs`
- `Entidades/MemoriaRAM.cs`
- `Entidades/TarjetaGrafica.cs`
- `Entidades/Microfono.cs`
- `Entidades/InterfazAudio.cs`
- `Entidades/Vinilo.cs`
- `Entidades/PerifericoPS5.cs`
- `Entidades/PerifericoSwitch.cs`
- `Entidades/ProductoGaming.cs`
- `Entidades/Usuario.cs`
- `Entidades/Cliente.cs`
- `Entidades/Proveedor.cs`
- `Entidades/Compra.cs`
- `Entidades/DetalleCompra.cs`
- `Entidades/Venta.cs`
- `Entidades/DetalleVenta.cs`
- `Entidades/RolUsuario.cs`
- `Entidades/ResumenInventario.cs`

#### Controladores

- `Controladores/TListaProducto.cs`
- `Controladores/TListaUsuario.cs`
- `Controladores/TListaCliente.cs`
- `Controladores/TListaProveedor.cs`
- `Controladores/TListaCompra.cs`
- `Controladores/TListaVenta.cs`

#### Formularios

- `Formularios/frmLogin.cs`
- `Formularios/frmAdmin.cs`
- `Formularios/frmUsuarios.cs`
- `Formularios/frmClientes.cs`
- `Formularios/frmProveedores.cs`
- `Formularios/frmProducto.cs`
- `Formularios/frmCompra.cs`
- `Formularios/frmVenta.cs`
- `Formularios/frmReportes.cs`

#### Sesión y utilidades

- `Sesiones/SesionActual.cs`
- `Utilidades/SeguridadPassword.cs`

#### Pruebas

- `ProyectoParcialPA.Tests/Tests/ProductoTests.cs`
- `ProyectoParcialPA.Tests/Tests/TecladoTests.cs`
- `ProyectoParcialPA.Tests/Tests/SesionActualTests.cs`
- `ProyectoParcialPA.Tests/Tests/UsuarioTests.cs`
- `ProyectoParcialPA.Tests/Tests/TListaProductoTests.cs`
- `ProyectoParcialPA.Tests/Tests/TListaUsuarioTests.cs`
- `ProyectoParcialPA.Tests/Tests/TListaCompraTests.cs`
- `ProyectoParcialPA.Tests/Tests/TListaVentaTests.cs`

## 5. Herencia del dominio

La herencia debe respetar la estructura solicitada en especificaciones.

### 5.1 Base abstracta

- `Producto` (abstracta)
  - `string Codigo`
  - `string Nombre`
  - `decimal Precio`
  - `int Stock`
  - `bool Activo`

### 5.2 Familias abstractas

- `PerifericoPC : Producto`
  - `string Marca`
- `ComponentePC : Producto`
  - `string Marca`
- `EquipoMusical : Producto`
  - `string Marca`
- `PerifericoConsola : Producto`
  - `string Marca`
  - `string TipoAccesorio`
  - `string Compatibilidad`

### 5.3 Clases concretas

- `Teclado : PerifericoPC`
  - `string Tipo`
- `Mouse : PerifericoPC`
  - `int Dpi`
- `MonitorPC : PerifericoPC`
  - `decimal Pulgadas` (permite tamaños como 23.8)
  - `int Hz`
- `Procesador : ComponentePC`
  - `string Socket`
  - `int Nucleos`
- `MemoriaRAM : ComponentePC`
  - `string Capacidad`
  - `string Tipo`
- `TarjetaGrafica : ComponentePC`
  - `string Memoria`
  - `string Chipset`
- `Microfono : EquipoMusical`
  - `string Tipo`
- `InterfazAudio : EquipoMusical`
  - `int Entradas`
  - `int Salidas`
- `Vinilo : Producto`
  - `string Artista`
  - `string Genero`
  - `int Anio`
- `PerifericoPS5 : PerifericoConsola`
- `PerifericoSwitch : PerifericoConsola`
- `ProductoGaming : Producto`
  - `string Marca`
  - `string Plataforma`
  - `string TipoArticulo`
  - `bool EsRetro`

Las entidades mantienen atributos privados, constructores y propiedades con acceso controlado. Codigo queda fijo tras el registro y Stock no se modifica desde formularios. Se podrá usar `List<string> Validar()` para comunicar errores de datos, con validaciones específicas por tipo y comprobación del controlador antes de guardar.

### 5.4 Entidades del negocio

- `Usuario`
  - `int Id`
  - `string NombreUsuario`
  - `string PasswordHash`
  - `string PasswordSalt`
  - `int PasswordIterations`
  - `RolUsuario Rol`
  - `bool Activo`

- `Cliente`
  - `int Id`
  - `string Nombre`
  - `string Apellido`
  - `string Direccion`
  - `string Telefono`
  - `string Email`
  - `bool Activo`

- `Proveedor`
  - `int Id`
  - `string Nombre`
  - `string Contacto`
  - `string Telefono`
  - `string Email`
  - `bool Activo`

- `Compra`
  - `int Id` (asignado al confirmar)
  - `Guid IdOperacion` (asignado una sola vez al iniciar el borrador)
  - `bool Confirmada` (solo lectura desde formularios)
  - `DateTime Fecha`
  - `Proveedor Proveedor`
  - `Usuario Usuario`
  - `List<DetalleCompra> Detalles`

- `DetalleCompra`
  - `string CodigoProducto` (copia del código en el momento del registro)
  - `string NombreProducto`
  - `int Cantidad`
  - `decimal CostoUnitario`
  - `DateTime FechaRegistro`

- `Venta`
  - `int Id` (asignado al confirmar)
  - `Guid IdOperacion` (asignado una sola vez al iniciar el borrador)
  - `bool Confirmada` (solo lectura desde formularios)
  - `DateTime Fecha`
  - `Cliente Cliente`
  - `Usuario Usuario`
  - `List<DetalleVenta> Detalles`

- `DetalleVenta`
  - `string CodigoProducto`
  - `string NombreProducto`
  - `int Cantidad`
  - `decimal PrecioUnitario`
  - `DateTime FechaRegistro`

Importante:

- Cada detalle debe guardar una copia del código, nombre, cantidad y costo/precio del momento en que se registró la operación.
- No basta con guardar una referencia al `Producto`, porque luego puede cambiarse el nombre, el precio o incluso el producto mismo y se perdería la fidelidad del historial.

### 5.5 Tipos auxiliares

- RolUsuario: enum con Administrador y Vendedor, en Entidades/RolUsuario.cs.
- ResumenInventario: CantidadProductos y UnidadesTotales enteros, ValorTotal decimal, en Entidades/ResumenInventario.cs.
- SesionActual: clase estática en Sesiones/SesionActual.cs; mantiene el usuario autenticado y permite iniciar/cerrar sesión sin vaciar las listas del proceso.
- SeguridadPassword: utilidad en Utilidades/SeguridadPassword.cs para generar y verificar PBKDF2.

## 6. Sesión y permisos

Se usará una clase `SesionActual` para mantener la sesión activa durante la ejecución del programa.

### 6.1 Contenido de la sesión

- `Usuario UsuarioActual`
- `bool EstaAutenticado`
- `DateTime FechaInicioSesion`
- `RolUsuario RolActual` (consulta derivada del usuario autenticado, sin un segundo rol editable por la UI)

### 6.2 Permisos exactos

Las especificaciones definen los roles y los permisos esperados:

- Administrador:
  - Puede gestionar usuarios
  - Puede gestionar clientes
  - Puede gestionar proveedores
  - Puede registrar compras
  - Puede registrar ventas
  - Puede consultar reportes
  - Puede gestionar productos
- Vendedor:
  - Puede consultar productos sin agregarlos, modificarlos ni desactivarlos
  - Puede administrar clientes
  - Puede consultar proveedores
  - Puede registrar compras
  - Puede registrar ventas
  - Puede consultar reportes
  - No puede gestionar usuarios
  - No puede agregar, modificar ni desactivar proveedores
  - No puede agregar, modificar ni desactivar productos

Los controladores comprueban el permiso antes de cada operación usando el usuario activo de SesionActual. No aceptan un rol o usuario alternativo suministrado por la UI para autorizarse. La interfaz también oculta o deshabilita acciones sin permiso. No se permite desactivar al último administrador activo.

Ejemplo de validación obligatoria:

- `TListaUsuario.AgregarUsuario(...)`: solo permitido si la sesión actual pertenece a Administrador.
- `TListaCompra.RegistrarCompra(...)`: permitido para Administrador y Vendedor.
- `TListaProveedor.DesactivarProveedor(...)`: debe validar el rol de administrador si la operación modifica la información del proveedor.
- `TListaCliente.AgregarCliente(...)` y `TListaCliente.ActualizarCliente(...)`: permitido para Administrador y Vendedor.

## 7. Contraseñas y seguridad

Se usará PBKDF2-HMAC-SHA256 con salt aleatorio por usuario y una configuración inicial de 600.000 iteraciones. Se utilizará una API compatible con .NET Framework 4.7.2.

### 7.1 Estructura de almacenamiento

En Usuario se guardan:

- PasswordHash: hash de 32 bytes codificado en Base64.
- PasswordSalt: salt aleatorio de al menos 16 bytes, codificado en Base64.
- PasswordIterations: entero con las iteraciones usadas; valor inicial 600000.

El algoritmo de esta versión será PBKDF2-HMAC-SHA256. SeguridadPassword generará el salt con un generador criptográfico y comprobará los hashes con una comparación en tiempo constante compatible con .NET Framework 4.7.2.

### 7.2 Reglas de manejo

- No se guarda ni se registra la contraseña en texto plano.
- Cada usuario recibe un salt aleatorio, aunque dos contraseñas sean iguales.
- Cambiar una contraseña genera un nuevo salt y un nuevo hash.
- Se comprueba la contraseña con los parámetros almacenados, sin recortarla ni cambiar sus mayúsculas/minúsculas.
- Las cuentas demo admin / Admin123* y vendedor / Vendedor123* se preparan una sola vez al arrancar el proceso, almacenando hashes. Iniciar o cerrar sesión no reinicializa usuarios ni inventario.
- Un usuario inactivo no puede iniciar sesión ni autorizar operaciones.

La configuración inicial sigue la recomendación de OWASP para PBKDF2-HMAC-SHA256 consultada al revisar el plan. El tiempo de arranque y autenticación se comprobará durante la implementación.

## 8. Reglas del producto y del inventario

- Código único, en mayúsculas, sin espacios sobrantes.
- Nombre obligatorio; espacios vacíos o solo espacios cuentan como vacío.
- Stock inicial de productos nuevos en cero.
- Marca es obligatoria para los tipos que la usan y Artista para Vinilo. En Teclado también se exige el tipo; se definirán y comprobarán los campos específicos de cada clase antes de integrarla en formularios.
- Stock solo cambia al confirmar compra o venta.
- No se puede vender más de lo disponible.
- Cantidades enteras y positivas.
- Precio/costo mayores a cero y con máximo dos decimales.
- Si el producto ya tiene movimientos registrados, no se permite cambiar el tipo de producto ni su familia.
- Los productos desactivados no aparecen en altas nuevas ni búsquedas normales.
- El código no cambia después de ser guardado.
- La búsqueda no distingue mayúsculas/minúsculas.
- El resumen general del inventario debe mostrar distintos productos activos, unidades disponibles y valor del inventario a precio de venta.

## 9. Métodos concretos de los controladores

Los controladores usarán listas privadas y métodos estáticos con validaciones concretas. Las consultas no permitirán modificar directamente las colecciones internas.

Producto se identifica por su string Codigo en todas las operaciones. No tiene Id numérico. Los IDs enteros corresponden a usuarios, clientes, proveedores, compras y ventas.

Un error de validación debe comunicarse con un resultado y un mensaje comprensible, sin cambios parciales. La autenticación y los permisos se comprueban también al llamar directamente al controlador.

### 9.1 `TListaProducto`

- `List<Producto> ObtenerTodos()`
  - Resultado: lista completa de productos activos por defecto
  - Validación: sin parámetros inválidos

- `Producto BuscarPorCodigo(string codigo)`
  - Parámetro: código en mayúsculas o no
  - Resultado: producto coincidente o `null`
  - Validación: `codigo` no nulo ni vacío

- `List<Producto> BuscarPorNombreOParte(string texto)`
  - Parámetro: texto libre
  - Resultado: productos que coinciden parcial o totalmente
  - Validación: texto normalizado sin espacios sobrantes

- `List<Producto> FiltrarPorTipo(string tipoProducto)`
  - Parámetro: nombre de la familia o tipo
  - Resultado: productos que cumplen el filtro
  - Validación: tipo reconocido

- `bool AgregarProducto(Producto producto, out string mensaje)`
  - Parámetro: producto nuevo
  - Resultado: verdadero si se agregó correctamente
  - Validación: código único, nombre válido, precio > 0, no duplicado

- `bool ActualizarProducto(string codigoOriginal, Producto cambios, out string mensaje)`
  - Parámetros: código original y objeto temporal con cambios; el original no se modifica mientras el usuario rellena el formulario
  - Resultado: verdadero si se actualizó
  - Validación: no cambiar código, preservar stock y estado del producto guardado, no cambiar tipo si tiene movimientos, y validar los campos del nuevo tipo antes de aplicar cambios

- `bool DesactivarProducto(string codigo, out string mensaje)`
  - Resultado: verdadero si se desactivó
  - Validación: producto existente y activo

- `bool ValidarStockDisponible(string codigo, int cantidadSolicitada)`
  - Resultado: verdadero si hay stock suficiente
  - Validación: cantidad > 0, producto activo

- `decimal ObtenerValorInventarioVenta()`
  - Resultado: suma de `precio * stock`
  - Validación: inventario activo

- `ResumenInventario ObtenerResumenGeneral()`
  - Resultado: objeto resumen con productos activos, unidades y valor total
  - Validación: sin errores

### 9.2 `TListaUsuario`

- `List<Usuario> ObtenerTodos()`
- `Usuario BuscarPorId(int id)`
- `Usuario BuscarPorNombreUsuario(string nombreUsuario)`
- `bool AgregarUsuario(Usuario usuario)`
- `bool ActualizarUsuario(Usuario usuario)`
- `bool DesactivarUsuario(int idUsuario)`
- `bool ValidarCredenciales(string usuario, string password)`
  - Resultado: verdadero si coinciden con hash/salt
  - Validación: ambos campos no vacíos
- `bool TienePermiso(string accion)`
  - Parámetro: acción a verificar
  - Resultado: si el rol tiene permiso
  - Validación: acción reconocida y usuario activo de SesionActual; una acción desconocida se rechaza
- `Usuario Login(string usuario, string password)`
  - Resultado: usuario autenticado o `null`
  - Validación: no nulos ni vacíos

### 9.3 `TListaCliente`

- `List<Cliente> ObtenerTodos()`
- `Cliente BuscarPorId(int id)`
- `List<Cliente> BuscarPorNombre(string texto)`
- `bool AgregarCliente(Cliente cliente)`
- `bool ActualizarCliente(Cliente cliente)`
- `bool DesactivarCliente(int idCliente)`

### 9.4 `TListaProveedor`

- `List<Proveedor> ObtenerTodos()`
- `Proveedor BuscarPorId(int id)`
- `List<Proveedor> BuscarPorNombre(string texto)`
- `bool AgregarProveedor(Proveedor proveedor)`
- `bool ActualizarProveedor(Proveedor proveedor)`
- `bool DesactivarProveedor(int idProveedor)`

### 9.5 `TListaCompra`

- `bool RegistrarCompra(Compra compra, out string mensaje)`
  - Resultado: verdadero si confirma la compra y aplica stock; el usuario responsable se obtiene de SesionActual
  - Validación: proveedor válido, usuario actual válido, cantidades positivas, costo > 0, no doble confirmación, permisos de rol

- `bool AgregarDetalleCompra(Compra compra, Producto producto, int cantidad, decimal costoUnitario)`
  - Resultado: verdadero si se incorpora la línea
  - Validación: producto activo, cantidad > 0, costo > 0, no repetir producto sin consolidar

- `bool ValidarCompraAntesDeConfirmar(Compra compra)`
  - Resultado: la compra completa es válida
  - Validación: todas las líneas válidas, total no nulo, proveedor y usuario asignados

- `List<Compra> BuscarPorFechas(DateTime desde, DateTime hasta)`
- `List<Compra> BuscarPorProveedor(int idProveedor)`

### 9.6 `TListaVenta`

- `bool RegistrarVenta(Venta venta, out string mensaje)`
  - Resultado: verdadero si confirma la venta y descuenta stock; el usuario responsable se obtiene de SesionActual
  - Validación: cliente válido, usuario actual válido, permisos, stock suficiente, cantidades enteras y positivas, no doble confirmación

- `bool AgregarDetalleVenta(Venta venta, Producto producto, int cantidad, decimal precioUnitario)`
  - Resultado: verdadero si se incorpora la línea
  - Validación: stock disponible, cantidad > 0, precio > 0, producto activo

- `bool ValidarVentaAntesDeConfirmar(Venta venta)`
  - Resultado: la venta completa es válida
  - Validación: stock total y precios coherentes, cliente y usuario asignados

- `List<Venta> BuscarPorFechas(DateTime desde, DateTime hasta)`
- `List<Venta> BuscarPorCliente(int idCliente)`

Las búsquedas por texto incluyen el artista del vinilo y se combinan con los filtros. El resumen general se calcula sobre todo el inventario activo.

BuscarPorFechas incluye todos los registros de ambos días, incluso los del último día por la tarde, y rechaza un rango invertido.

## 10. Formularios y eventos

### 10.1 `frmLogin`

Controles:

- `TextBox txtUsuario`
- `TextBox txtPassword`
- `Button btnEntrar`
- `Button btnSalir`

Eventos:

- `btnEntrar_Click(object sender, EventArgs e)`
- `btnSalir_Click(object sender, EventArgs e)`
- `Form_Load(object sender, EventArgs e)`

Función:

- Validar usuario y contraseña.
- Si la autenticación es correcta, guardar la sesión en `SesionActual`.
- Cerrar sesión debe limpiar la sesión activa y volver al login.

### 10.2 `frmAdmin`

Controles:

- `DataGridView dgvInventario`
- `TextBox txtBuscar`
- `ComboBox cboFiltro`
- `Label lblResumenGeneral`
- `Button btnProductos`
- `Button btnUsuarios`
- `Button btnClientes`
- `Button btnProveedores`
- `Button btnCompras`
- `Button btnVentas`
- `Button btnReportes`
- `Button btnCerrarSesion`

Eventos:

- `Load`
- `txtBuscar_TextChanged`
- `cboFiltro_SelectedIndexChanged`
- `btnProductos_Click`
- `btnUsuarios_Click`
- `btnClientes_Click`
- `btnProveedores_Click`
- `btnCompras_Click`
- `btnVentas_Click`
- `btnReportes_Click`
- `btnCerrarSesion_Click`

Función:

- Cargar inventario.
- Mostrar resumen general.
- Permitir navegación a módulos según permisos.

### 10.3 `frmUsuarios`

Controles:

- `DataGridView dgvUsuarios`
- `Button btnAgregar`
- `Button btnEditar`
- `Button btnEliminar`
- `Button btnBuscar`
- `Button btnSalir`

Eventos:

- `Load`
- `btnAgregar_Click`
- `btnEditar_Click`
- `btnEliminar_Click`
- `btnBuscar_Click`
- `btnSalir_Click`

Función:

- CRUD de usuarios.
- Solo accesible por Administrador.

### 10.4 `frmClientes`

Controles:

- `DataGridView dgvClientes`
- `Button btnAgregar`
- `Button btnEditar`
- `Button btnEliminar`
- `Button btnBuscar`
- `Button btnSalir`

Eventos:

- `Load`
- `btnAgregar_Click`
- `btnEditar_Click`
- `btnEliminar_Click`
- `btnBuscar_Click`
- `btnSalir_Click`

Función:

- CRUD de clientes.
- Disponible para Administrador y Vendedor.

### 10.5 `frmProveedores`

Controles:

- `DataGridView dgvProveedores`
- `Button btnAgregar`
- `Button btnEditar`
- `Button btnEliminar`
- `Button btnBuscar`
- `Button btnSalir`

Eventos:

- `Load`
- `btnAgregar_Click`
- `btnEditar_Click`
- `btnEliminar_Click`
- `btnBuscar_Click`
- `btnSalir_Click`

Función:

- CRUD de proveedores.
- Consulta disponible para vendedor; edición/alta/baja de administrador.

### 10.6 `frmProducto`

Controles:

- `ComboBox cboTipoProducto`
- `TextBox txtCodigo`
- `TextBox txtNombre`
- `TextBox txtPrecio`
- `Label lblStock` o campo de stock solo lectura, tanto al registrar como al editar
- `Panel pnlCamposDinamicos`
- `Button btnGuardar`
- `Button btnCancelar`

Eventos:

- `Load`
- `cboTipoProducto_SelectedIndexChanged`
- `btnGuardar_Click`
- `btnCancelar_Click`

Función:

- Alta y edición de productos.
- Muestra solo campos relevantes según el tipo.
- Los productos nuevos empiezan en cero. Al editar se muestra y conserva el stock actual. El stock no se edita desde este formulario.
- Si el producto tiene movimientos, no se permite cambiar el tipo.

### 10.7 `frmCompra`

Controles:

- `ComboBox cboProveedor`
- `DataGridView dgvCompra`
- `Button btnAgregarProducto`
- `Button btnConfirmar`
- `Button btnCancelar`
- `Label lblTotalCompra`

Eventos:

- `Load`
- `btnAgregarProducto_Click`
- `btnConfirmar_Click`
- `btnCancelar_Click`

Función:

- Registrar una compra con líneas de detalle.
- Validar proveedor, cantidades, costo y permisos.
- Si algo falla, no se guarda ni cambia stock.
- Confirmar solo una vez.

### 10.8 `frmVenta`

Controles:

- `ComboBox cboCliente`
- `DataGridView dgvVenta`
- `Button btnAgregarProducto`
- `Button btnConfirmar`
- `Button btnCancelar`
- `Label lblTotalVenta`
- `TextBox txtComprobante` o panel de comprobante si se requiere visualización

Eventos:

- `Load`
- `btnAgregarProducto_Click`
- `btnConfirmar_Click`
- `btnCancelar_Click`

Función:

- Registrar una venta con líneas de detalle.
- Validar stock, precios, cantidades, cliente y permisos.
- El stock se actualiza solo al confirmar la venta completa.

### 10.9 `frmReportes`

Controles:

- `DateTimePicker dtpDesde`
- `DateTimePicker dtpHasta`
- `ComboBox cboTipoReporte`
- `DataGridView dgvReporte`
- `Button btnGenerar`
- `Button btnExportar`
- `Button btnImprimir`
- `Button btnSalir`

Eventos:

- `Load`
- `btnGenerar_Click`
- `btnExportar_Click`
- `btnImprimir_Click`
- `btnSalir_Click`

Función:

- Consultar compras y ventas por fechas. Inventario muestra el estado actual y usa filtros de productos; no representa inventario histórico por fecha.
- Mostrar resultados y permitir exportación o impresión.

## 11. Historial de operaciones

Cada operación registrada debe conservar un historial detallado e inmutable desde el punto de vista del dato de la operación.

### 11.1 Reglas del historial

- Las compras y ventas deben guardar una lista de detalles con copia de los datos relevantes del momento.
- Se conserva:
  - código del producto
  - nombre del producto
  - cantidad
  - costo unitario (compras) o precio unitario (ventas)
  - fecha de registro
- Las operaciones no deben depender del producto actual para su información histórica.
- Si luego el producto cambia de nombre o precio, el historial conserva los valores originales. El tipo no se cambia cuando ya existen movimientos.

### 11.2 Confirmación y repetición de operaciones

- Cada borrador tiene un IdOperacion creado una sola vez. Los reintentos conservan ese identificador; no se crea uno nuevo por cada clic en Confirmar.
- El controlador rechaza un IdOperacion ya confirmado, además de deshabilitar el botón en la UI.
- Se valida toda la operación: sesión, permiso, cliente/proveedor activo, productos activos, cantidades, importes y límites del stock entero.
- Para comprobar una venta se suman todas las cantidades de un mismo código. Las líneas no se validan aisladamente permitiendo superar el stock total.
- Las líneas repetidas pueden consolidarse si coinciden código e importe unitario. Si tienen costos/precios distintos, se conservan separados y se agrupan solo para validar/aplicar el stock.
- Tras validar se preparan las copias del historial y los stocks finales. La actualización de todos los productos y el registro forman una única operación en memoria, sin resultados parciales ante un fallo.
- Una operación confirmada queda cerrada y sus detalles no pueden modificarse mediante una referencia al borrador original.
- Cancelar un borrador no registra nada ni cambia stock.

### 11.3 Validación del historial

- Antes de registrar una compra o venta, debe validarse que cada detalle tenga los datos necesarios.
- La operación completa se debe confirmar en una sola transacción lógica local: si una parte falla, todo queda revertido en memoria.
- No se modifica el stock si una compra o venta no confirmó correctamente.

## 12. Pruebas automáticas (primero) 

La estrategia será Test-First: se crearán pruebas para cada regla antes de la implementación funcional.

### 12.1 Proyecto de pruebas

- Proyecto separado: `ProyectoParcialPA.Tests`
- Framework: MSTest
- Compatibilidad: .NET Framework 4.7.2
- Referencia: proyecto principal de `ProyectoParcialPA`

### 12.2 Orden sugerido de pruebas

#### Fase 1: reglas básicas de Producto y Usuario

Las pruebas de Producto usarán Teclado como clase concreta. La unicidad global se comprueba en TListaProducto, no en una entidad aislada.

- `ProductoTests.ValidarCodigoSeNormalizaEnMayusculas()`
  - Resultado esperado: el código ` pc001 ` se normaliza a `PC001`. La duplicidad se comprueba aparte en el controlador.

- `ProductoTests.ValidarNombreObligatorio()`
  - Resultado esperado: nombre en blanco o solo espacios devuelve error.

- `ProductoTests.ValidarPrecioMayorACero()`
  - Resultado esperado: precio `0` o negativo devuelve error.

- `TecladoTests.ValidarMarcaYTipoObligatorios()`
  - Resultado esperado: falta de marca o tipo se comunica como error antes de guardar.

- `UsuarioTests.PasswordHashDebeSerValido()`
  - Resultado esperado: el hash generado con PBKDF2 verifica correctamente.

- `UsuarioTests.DosUsuariosDebenTenerSaltDiferente()`
  - Resultado esperado: dos usuarios distintos tienen salt distintos.

#### Fase 2: validación de inventario

- `TListaProductoTests.AgregarProductoDuplicadoDebeFallar()`
  - Resultado esperado: no se permite duplicar el código.

- `TListaProductoTests.StockInsuficienteDebeRechazarVenta()`
  - Resultado esperado: venta con cantidad mayor a stock devuelve false.

- `TListaProductoTests.ProductoDesactivadoNoApareceEnBusquedaNormal()`
  - Resultado esperado: no se incluye en búsquedas activas.

#### Fase 3: compras y ventas

- `TListaCompraTests.CompraConCantidadNegativaDebeFallar()`
  - Resultado esperado: error de validación.

- `TListaCompraTests.CompraValidaDebeActualizarStock()`
  - Resultado esperado: stock aumenta con compra confirmada.

- `TListaVentaTests.VentaConStockInsuficienteDebeFallar()`
  - Resultado esperado: venta rechazada.

- `TListaVentaTests.VentaValidaDebeRestarStock()`
  - Resultado esperado: stock disminuye solo si se confirma.

- `TListaVentaTests.DobleConfirmacionDebeSerBloqueada()`
  - Resultado esperado: segundo clic no confirma y no duplica registro.

#### Fase 4: historial y permisos

- `TListaVentaTests.HistorialGuardaPrecioYNombreOriginales()`
  - Resultado esperado: la venta conserva código, nombre y cantidad del momento.

- `TListaCompraTests.HistorialGuardaCostoOriginal()`
  - Resultado esperado: compra conserva costo original aunque el producto cambie luego.

- `TListaUsuarioTests.AdminPuedeCrearUsuario()`
  - Resultado esperado: admin tiene permisos.

- `TListaUsuarioTests.VendedorNoPuedeCrearUsuario()`
  - Resultado esperado: vendedor falla al intentar crear usuario.

- `TListaCompraTests.VendedorPuedeRegistrarCompra()`
  - Resultado esperado: vendedor sí puede comprar según especificaciones.

### 12.3 Casos adicionales por comprobar

- Precio con más de dos decimales: rechazar sin cambiar el producto guardado.
- Editar y cancelar: conservar código, stock, nombre y precio originales.
- Contraseña incorrecta o usuario inactivo: rechazar acceso. Cerrar sesión conserva las listas.
- Operación vacía o con una línea inválida entre otras válidas: no guardar ni modificar ningún stock.
- Stock 5 y dos líneas de venta del mismo código, de 3 unidades cada una: rechazar y mantener stock 5.
- Confirmar dos veces el mismo IdOperacion: un solo registro y una sola modificación de stock.
- Compra de 5 desde stock 0: queda 5; venta de 2: queda 3; intento de vender 4: se rechaza y queda 3.
- Comprobar todos los permisos del vendedor llamando al controlador, además de probarlos en la UI.
- Resumen: productos a 25.50 con stock 5 y a 10.00 con stock 2 dan 2 productos, 7 unidades y 147.50 dólares. Los filtros no cambian ese resumen.

## 13. GitHub Actions para compilación y pruebas

El workflow .github/workflows/ci.yml se incorporará cuando el primer conjunto de pruebas reales esté implementado, antes de los formularios.

### 13.1 Eventos y entorno

- Eventos push y pull_request.
- Runner windows-latest.
- Preparar MSBuild de Visual Studio 17.12 o posterior, compatible con .slnx.
- Preparar un SDK .NET estable para el proyecto de pruebas SDK y VSTest. El SDK es una herramienta; la aplicación y las pruebas siguen apuntando a .NET Framework 4.7.2.
- Comprobar que están disponibles las reference assemblies de .NET Framework 4.7.2; preparar el targeting pack o las reference assemblies oficiales si faltan.
- Usar Microsoft.NET.Test.Sdk, MSTest.TestFramework y MSTest.TestAdapter con versiones compatibles fijadas.

### 13.2 Comandos planificados

Ejecutar desde la raíz del repositorio, usando Debug al compilar y al ejecutar las pruebas:

```powershell
msbuild "ProyectoParcialPA.slnx" /t:Restore /p:RestorePackagesConfig=true
msbuild "ProyectoParcialPA.slnx" /t:Build /p:Configuration=Debug
dotnet test "ProyectoParcialPA/ProyectoParcialPA.Tests/ProyectoParcialPA.Tests.csproj" --configuration Debug --no-build --no-restore --logger "trx;LogFileName=test-results.trx" --results-directory "TestResults"
```

MSBuild restaura y compila la solución existente. dotnet test ejecuta las pruebas ya compiladas con VSTest. Si las rutas reales cambian, se actualizan tanto en el plan como en el workflow.

### 13.3 Validación del workflow

- Los fallos de restauración, compilación o pruebas hacen fallar el job.
- Comprobar que se descubre y ejecuta más de cero pruebas.
- Conservar los resultados TRX como evidencia, también cuando falle una prueba.
- Revisar el resultado de CI antes de integrar una PR de implementación a main.

Estos comandos son el plan de ejecución y todavía no se han probado contra el sistema. Se comprobarán cuando existan el proyecto de pruebas y sus primeros casos.

## 14. Etapas de implementación

Todas las rutas de esta sección son relativas a la raíz del repositorio.

### Etapa 1: preparación del proyecto y pruebas iniciales

Archivos a preparar:

- `ProyectoParcialPA/ProyectoParcialPA/ProyectoParcialPA.csproj` (ajustar objetivo planificado a .NET Framework 4.7.2)
- `ProyectoParcialPA/ProyectoParcialPA.Tests/ProyectoParcialPA.Tests.csproj`
- `ProyectoParcialPA/ProyectoParcialPA.Tests/Tests/ProductoTests.cs`
- `ProyectoParcialPA/ProyectoParcialPA.Tests/Tests/UsuarioTests.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/Producto.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/PerifericoPC.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/Teclado.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/Usuario.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/RolUsuario.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/ResumenInventario.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Sesiones/SesionActual.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Utilidades/SeguridadPassword.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Controladores/TListaProducto.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Controladores/TListaUsuario.cs`

Objetivo:

- Ajustar la plataforma.
- Definir la base de Producto/Usuario.
- Probar validaciones básicas antes de seguir con más entidades.

Subpasos de la etapa 1:

- **1A. Preparación:** comprobar rutas, ajustar el framework y App.config si corresponde, comprobar el targeting pack y crear el proyecto separado de pruebas con referencia al principal. Compilar la solución existente.
- **1B. Productos base:** definir primero los casos de normalización, campos obligatorios y precio usando Teclado; implementar Producto, PerifericoPC y Teclado hasta que pasen.
- **1C. Usuarios y sesión:** preparar RolUsuario, Usuario, SeguridadPassword, SesionActual y TListaUsuario con las cuentas de demostración y pruebas de acceso. Definir ResumenInventario y completar TListaProducto en la siguiente etapa.
- Incorporar CI con el primer conjunto de pruebas reales funcionando. Guardar evidencia del fallo inicial de la regla y del resultado tras implementarla.

### Etapa 2: inventario y reglas de negocio

Completar primero las clases restantes: ComponentePC, EquipoMusical, PerifericoConsola, Mouse, MonitorPC, Procesador, MemoriaRAM, TarjetaGrafica, Microfono, InterfazAudio, Vinilo, PerifericoPS5, PerifericoSwitch y ProductoGaming. Añadir validaciones de sus campos específicos antes de usarlas en formularios.

Después completar TListaProducto y sus pruebas, clientes/proveedores y finalmente compras/ventas. Los tipos que use una prueba o controlador deben estar implementados en ese incremento.

Archivos:

- `ProyectoParcialPA/ProyectoParcialPA/Entidades/Cliente.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/Proveedor.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/Compra.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/DetalleCompra.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/Venta.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Entidades/DetalleVenta.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Controladores/TListaCliente.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Controladores/TListaProveedor.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Controladores/TListaCompra.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Controladores/TListaVenta.cs`
- `ProyectoParcialPA/ProyectoParcialPA.Tests/Tests/TListaProductoTests.cs`
- `ProyectoParcialPA/ProyectoParcialPA.Tests/Tests/TListaCompraTests.cs`
- `ProyectoParcialPA/ProyectoParcialPA.Tests/Tests/TListaVentaTests.cs`

Objetivo:

- Reglas de stock, compra y venta.
- Historial detallado con copia de datos.
- Validación de confirmación y doble registro.

### Etapa 3: formularios base

Archivos:

- `ProyectoParcialPA/ProyectoParcialPA/Formularios/frmLogin.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Formularios/frmAdmin.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Formularios/frmProducto.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Formularios/frmUsuarios.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Formularios/frmClientes.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Formularios/frmProveedores.cs`

Objetivo:

- Login y navegación.
- Alta/edición de productos y CRUD de datos de catálogo.
- Permisos en UI y en backend.

### Etapa 4: formularios de compras, ventas y reportes

Archivos:

- `ProyectoParcialPA/ProyectoParcialPA/Formularios/frmCompra.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Formularios/frmVenta.cs`
- `ProyectoParcialPA/ProyectoParcialPA/Formularios/frmReportes.cs`

Objetivo:

- Registro completo de transacciones.
- Totales, comprobantes y filtros por fechas.
- Visualización del historial para reportes.

### Etapa 5: validación final, revisión de CI y pulido

Archivos:

- `.github/workflows/ci.yml` (ya creado con las primeras pruebas; aquí se revisa y amplía)
- ajustes finales en los controladores y en los formularios
- últimos tests de integración y regresión

Objetivo:

- Compilar limpio.
- Ejecutar pruebas en CI.
- Verificar permisos, stock y reportes end-to-end.

## 15. Enfoque de trabajo recomendado

Se sigue una mezcla de desarrollo guiado por especificaciones y pruebas incrementales.

- Primero se escriben tests para la regla que se está implementando.
- Luego se implementa la entidad o el controlador que la cumple.
- Después se revisa la lógica de permisos y validaciones.
- Finalmente se integra con la UI.

Este proceso permite comprobar las reglas críticas. La evidencia será el resultado real de las pruebas; el plan por sí solo no garantiza el funcionamiento.

## 16. Resultado esperado final

El sistema debe permitir:

- autenticación con roles
- gestión de productos con validaciones de tipo, precio y stock
- compras y ventas confirmadas de forma segura
- historial íntegro de movimientos
- reportes por fechas
- reglas de permisos por rol
- pruebas automáticas en un proyecto separado
- compilación y validación automática en GitHub Actions

## 17. Primera decisión de implementación real

La primera etapa no debe partir desde un formulario, sino desde la base de negocio y la prueba:

- Crear la estructura de proyecto y del proyecto de pruebas.
- Definir `Producto`, `PerifericoPC`, `Teclado` y `Usuario`.
- Crear una primera batería de pruebas para:
  - validación de código
  - validación de nombre
  - validación de precio
  - hash PBKDF2
  - herencia y ejemplo concreto con `Teclado`
- Confirmar estas pruebas antes de avanzar a compras, ventas y formularios.

## 18. Resumen ejecutivo

- Objetivo: implementar RAYAO* 0.2 con C#, Windows Forms y .NET Framework 4.7.2.
- Proyecto actual: arranque incompleto en .NET 4.8, lo que hay que ajustar en la primera etapa.
- Arquitectura: Entidades, Controladores, Formularios.
- Seguridad: PBKDF2, salt aleatorio por usuario, `PasswordHash`, `PasswordSalt` e `PasswordIterations`.
- Inventario: activo/inactivo y stock solo cambia al confirmar.
- Historial: detalles con copia del código, nombre, cantidad y costo/precio originales.
- Permisos: el vendedor puede administrar clientes, consultar proveedores y registrar compras; las comprobaciones se hacen en los controladores.
- Pruebas: proyecto separado `ProyectoParcialPA.Tests` con MSTest y referencia al proyecto principal.
- CI/CD: workflow de GitHub Actions para Windows, build y tests.

La secuencia de trabajo será preparar el entorno, definir pruebas e implementar las reglas, incorporar CI con las primeras pruebas reales y después integrar formularios. El diseño visual se preparará con el estilo de RAYAO* cuando estén definidas las pantallas.

## 19. Referencias técnicas de apoyo

- [OWASP: Password Storage Cheat Sheet](https://cheatsheetseries.owasp.org/cheatsheets/Password_Storage_Cheat_Sheet.html).
- [Microsoft: NuGet Package Restore](https://learn.microsoft.com/en-us/nuget/consume-packages/package-restore).
- [Microsoft: MSBuild y soporte de .slnx](https://learn.microsoft.com/en-us/visualstudio/msbuild/whats-new-msbuild-17-0).
- [Microsoft: dotnet test con VSTest](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-test-vstest).
- [Microsoft: MSTest.TestFramework y frameworks compatibles](https://www.nuget.org/packages/MSTest.TestFramework).
