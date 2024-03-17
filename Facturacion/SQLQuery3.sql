use FacturacionGA

/*Procedimiento para mostrar cliente*/

create procedure fact.MostrarCliente
as
select Id,CodigodeCliente,NombredeCliente,ApellidosdeCliente ,
DirecciondeCliente
from fact.Cliente
go


/*Procedimiento para insertar producto nuevo*/


create procedure fact.InsertarCliente
@CodigodeCliente varchar(5),
@NombredeCliente varchar(60),
@ApellidosdeCliente varchar(80),
@DirecciondeCliente varchar(80)
as
insert into fact.Cliente
values
(@CodigodeCliente,@NombredeCliente,
@ApellidosdeCliente,@DirecciondeCliente)
go

/*Procedimiento para eliminar producto*/

create procedure fact.EliminarCliente
@Id int
as
delete from fact.Cliente where Id=@Id
go

/*Actualizar producto*/

create procedure fact.ActualizarCliente
@CodigodeCliente varchar(5),
@NombredeCliente varchar(50),
@ApellidosdeCliente varchar(80),
@DirecciondeCliente varchar(80),
@id int
as
update fact.Cliente set 
CodigodeCliente=@CodigodeCliente,
NombredeCliente=@NombredeCliente,
ApellidosdeCliente=@ApellidosdeCliente,
DirecciondeCliente=@DirecciondeCliente
where id=@id

