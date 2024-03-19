Create DATABASE SistemaVentas;

use SistemaVentas
create table categorias(
	categoria_id int primary key,
	nombre varchar(50) not null,
	descripcion varchar(1000)
);

CREATE TABLE usuarios (
	usuario_id int primary key,
    nombre_usuario varchar(50) NOT NULL,
    contrasena varchar(100) NOT NULL,
    tipo_usuario varchar(20) NOT NULL
);

create table proveedores(
	proveedor_id int primary key,
	nombre_proveedor varchar(50) not null,
	apellido1_proveedor varchar(50) not null,
	apellido2_proveedor varchar(50) not null,
	correo_proveedor varchar(100)
	foreign key (proveedor_id) references usuarios(usuario_id)
);

create table productos(
	producto_id int primary key,
	categoria_id int,
	proveedor_id int,
	nombre_producto varchar(50) not null,
	stock int,
	ruta_imagen nvarchar(255),
	descripcion varchar(500),
    precio DECIMAL(10,2),
	foreign key (categoria_id) references categorias(categoria_id),
	foreign key (proveedor_id) references proveedores(proveedor_id)
);

create table historialVentas(
	historial_id int primary key,
	proveedor_id int,
	fecha_venta date,
	foreign key (proveedor_id) references proveedores(proveedor_id)
);

create table historialVentasDetalles(
	historial_id int,
	producto_id int,
	cantidad_vendida int,
	foreign key (historial_id) references historialVentas(historial_id),
	foreign key (producto_id) references productos(producto_id),
	primary key (historial_id, producto_id)
);

create table clientes(
	cliente_id int primary key,
	nombre_cliente varchar(50) not null,
	apellido1_cliente varchar(50) not null,
	apellido2_cliente varchar(50) not null,
	direccion varchar(100),
	telefono int,
	correo_cliente varchar(50)
	foreign key (cliente_id) references usuarios(usuario_id)
);

create table ordenesComprasClientes(
	orden_id int primary key,
	cliente_id int,
	proveedor_id int,
	fecha_compra date,
	foreign key (cliente_id) references clientes (cliente_id),
	foreign key (proveedor_id) references proveedores (proveedor_id)
);

create table ordenesComprasDetalles(
	orden_id int,
	producto_id int,
	cantidad int,
	precio_unitario int,
	primary key (orden_id, producto_id),
	foreign key (orden_id) references ordenesComprasClientes(orden_id),
	foreign key (producto_id) references productos(producto_id),
);

create table pagos(
	pagos_id int primary key,
	cliente_id int,
	tipo_pago varchar(100),
	numero_tarjeta bigint,
	vencimiento_tarjeta varchar(20),
	codigo_tarjeta int
	foreign key (cliente_id) references clientes(cliente_id)
);

create table entregas(
	entregas_id int primary key,
	cliente_id int,
	fecha date,
	direccion varchar (100),
	estado varchar (100),
	foreign key (cliente_id) references clientes(cliente_id)
);

create table reportesTransacciones(
	reporte_id int primary key,
	cliente_id int,
	orden_id int,
	producto_id int,
	proveedor_id int,
	fecha_reporte date,
	precio_unitario int,
	foreign key (cliente_id) references clientes (cliente_id),
	foreign key (orden_id) references ordenesComprasClientes (orden_id),
	foreign key (producto_id) references productos (producto_id),
	foreign key (proveedor_id) references proveedores (proveedor_id)
);

insert into categorias (categoria_id, nombre, descripcion)
values
	(1, 'Frutas', 'Esta categoría incluye variedad de frutas frescas'),
	(2, 'Verduras', 'Esta categoría incluye variedad de verduras frescas'),
	(3, 'granos', 'Esta categoría incluye variedad de legumbres y granos'),
	(4, 'lacteos', 'Esta categoría incluye variedad de lacteos'),
	(5, 'carnes', 'Esta categoría incluye variedad de carnes y aves de calidad'),
	(6, 'huevos', 'Esta categoría incluye variedad de huevos'),
	(7, 'hierbas', 'Esta categoría incluye variedad de hierbas y especias');

insert into usuarios (usuario_id, nombre_usuario, contrasena, tipo_usuario)
values
    (01, 'Juanito', 'juan1234', 'proveedor'),
    (02, 'LuisPP', '9876ppl', 'proveedor'),
    (31, 'pedrojl', 'pE123', 'cliente'),
    (32, 'Kevinmp', 'mpkev12', 'cliente');

insert into proveedores (proveedor_id, nombre_proveedor, apellido1_proveedor, apellido2_proveedor, correo_proveedor)
values
	(01, 'Juan', 'Pérez', 'Pérez', 'juan@egmail.com'),
	(02, 'Luis', 'Portuguez', 'Portuguez', 'luisportu@gmail.com');

insert into productos (producto_id,categoria_id, proveedor_id, nombre_producto, stock, ruta_imagen, descripcion, precio)
values
	(10, 1, 01, 'Manzanas rojas', 100, '/imagenes/manzanas.jpg', 'Manzanas rojas frescas de temporada', 1.02),
	(20, 2, 01, 'Plátanos', 50, '/imagenes/platanos.jpg', 'Plátanos orgánicos recién cosechados', 3.05),
	(30, 4, 02, 'Leche', 75, '/imagenes/leche.jpg', 'leche entera fresca', 5.00),
	(40, 3, 02, 'Arroz', 200, '/imagenes/arroz.jpg', 'Arroz blanco de alta calidad', 10.02),
	(50, 5, 02, 'Pechuga de pollo', 30, '/imagenes/pechugadpollo.jpg', 'Pechuga de pollo fresca', 22.05),
	(60, 6, 02, 'Huevos de codorniz', 200, '/imagenes/huevoscodorniz.jpg', 'Huevos de codorniz de alta calidad', 15.02),
	(70, 7, 01, 'albahaca', 20, '/imagenes/albahaca.jpg', 'Albahaca fresca y de la mejor calidad', 2.01);

insert into historialVentas(historial_id, proveedor_id, fecha_venta)
values
	(22, 01, '2024-02-10'),
	(23, 02, '2024-02-11');

insert into historialVentasDetalles(historial_id, producto_id, cantidad_vendida)
values
	(22, 10, 20),
	(23, 50, 30),
	(22, 30, 25),
	(23, 40, 50);

insert into clientes (cliente_id,nombre_cliente,apellido1_cliente,apellido2_cliente, direccion, telefono, correo_cliente )
values
	(31, 'Pedro', 'Jimenez', 'López', 'San Jose, Tibas', 123456789, 'pedrott@gmail.com'),
	(32, 'Kevin', 'Martínez', 'Arias', 'Guanacaste, Santa Cruz', 987654321, 'kevinma@gmail.com');

insert into ordenesComprasClientes(orden_id,cliente_id,proveedor_id,fecha_compra)
values
	(41, 31, 01, '2024-02-10'),
	(42, 32, 02, '2024-02-11');

insert into ordenesComprasDetalles(orden_id, producto_id, cantidad, precio_unitario)
values
	(41, 10, 10, 1.02),
	(42, 20, 15, 3.05),
	(42, 30, 20, 5.00),
	(41, 40, 10, 10.02);

insert into pagos (pagos_id, cliente_id, tipo_pago, numero_tarjeta, vencimiento_tarjeta, codigo_tarjeta)
values
	(100,31,'Tarjeta de credito', 1013052146809576, '2026-02',123),
	(101,32,'Paypal', 5303968251439834, '2027-06',987);

insert into entregas(entregas_id, cliente_id, fecha, direccion, estado)
values
	(200, 31, '2024-02-10', 'San Jose, Tibas', 'Entregado'),
	(201, 32, '2024-02-11', 'Guanacaste, Santa Cruz', 'En camino');

insert into reportesTransacciones (reporte_id, cliente_id, orden_id, proveedor_id, fecha_reporte,precio_unitario)
values
	(63, 31, 41, 01, '2024-02-10', 1.02),
	(61, 31, 41, 01, '2024-02-10', 10.02),
	(62, 32, 42, 02, '2024-02-12', 3.05);
