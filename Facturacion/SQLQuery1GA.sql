create database FacturacionGA

use FacturacionGA

create schema fact

create table fact.Cliente
(
	id int identity (1,1),
	CodigodeCliente varchar(5) not null,
	NombredeCliente varchar(60) not null,
	ApellidosdeCliente varchar(80) not null,
	DirecciondeCliente varchar(80) not null,
	Constraint PK_Cliente primary key (id)
)

create table fact.Operadora
(
	id int identity(1,1),
	Descripcion varchar(35) not null,
	constraint PK_Operadora primary key (id)
)

create table fact.DetalleTelefono
(
	id int identity (1,1),
	ClienteId int not null,
	OperadoraId int not null,
	NumerodeTelefono varchar(12) not null,
	constraint PK_DetalleTelefono primary key(id)
)

alter table Fact.DetalleTelefono add constraint FK_Cliente_DetalleTelefono
Foreign Key (ClienteId)
references Fact.Cliente (Id) 

alter table Fact.DetalleTelefono add constraint FK_Operadora_DetalleTelefono
Foreign Key (OperadoraId)
references Fact.Operadora (Id) 

Create table fact.Factura 
(
	id int identity(1,1),
	CodigodeFactura varchar(10) not null, 
	FechaFactura varchar(30)  not null, 
	Descripcion varchar(50) not null, 
	Clienteid int not null, 
	constraint PK_FacturaId primary key (id) 
)

Create table fact.DetalleFactura 
(
	id int identity (1,1), 
	Facturaid int not null, 
	Productoid int not null, 
	Cantidad varchar(10) not null, 
	Precio decimal(8,2) not null,
	constraint PK_DetalleFactura primary key (id)
)

Create table fact.Producto
 (
	id int identity(1,1),
	CodigoProducto int not null, 
	Descripcion varchar(50) not null, 
	Precio decimal(8,2) not null,
	Cantidad int not null, 
	CantidadMinima int not null, 
	CantidadMaxima int not null,
	constraint PK_Producto primary key(id)
 )

 alter table Fact.DetalleFactura add constraint FK_Factura_DetalleFactura
Foreign Key (FacturaId)
references Fact.Factura (Id) 

alter table Fact.DetalleFactura add constraint FK_Producto_DetalleFactura
Foreign Key (ProductoId)
references Fact.Producto (Id) 

alter table Fact.Producto drop column CodigoProducto
alter table Fact.Producto add CodigoProducto varchar not null


select * from fact.Producto


/*Procedimiento para mostrar producto*/
create procedure fact.MostrarProducto
as
select Id,CodigoProducto,Descripcion,Precio,
Cantidad,CantidadMinima,CantidadMaxima
from fact.Producto 
go

/*Procedimiento para insertar producto nuevo*/


create procedure fact.InsertarProducto
@CodigoProducto varchar(10),
@Descripcion varchar(50),
@Precio decimal(8,2),
@Cantidad int,
@CantidadMinima int,
@CantidadMaxima int
as
insert into fact.Producto 
values
(@CodigoProducto,@Descripcion,
@Precio,@Cantidad,@CantidadMinima,@CantidadMaxima)
go

/*Procedimiento para eliminar producto*/
create procedure fact.EliminarProducto
@Id int
as
delete from fact.Producto where Id=@Id
go
/*Actualizar producto*/
create procedure fact.ActualizarProducto
@CodigoProducto int,
@Descripcion varchar(50),
@Precio decimal(8,2),
@Cantidad int,
@CantidadMinima int,
@CantidadMaxima int,
@id int
as
update fact.Producto set 
CodigoProducto=@CodigoProducto, 
Descripcion=@Descripcion,
Precio=@Precio, 
Cantidad=@Cantidad,
CantidadMinima=@CantidadMinima, 
CantidadMaxima=@CantidadMaxima 
where id=@id


select * from fact.Producto