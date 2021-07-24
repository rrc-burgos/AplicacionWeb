
insert into Empleados (DepartamentoId,Cedula,Nombre,Apellido,Salario,Nacimiento,Titulo) 
values (1,'1751411032', 'ALBERTO','Perez',850.5,'1994-07-15','Tecnologo');

SET IDENTITY_INSERT Empleados ON
insert into Empleados (EmpleadoId,DepartamentoId,Cedula,Nombre,Apellido,Salario,Nacimiento,Titulo) 
values (10,1,'1751411032', 'ALBERTO','Perez',850.5,'1994-07-15','Tecnologo');
insert into Empleados (EmpleadoId,DepartamentoId,Cedula,Nombre,Apellido,Salario,Nacimiento,Titulo) 
values (12,1,'1751411032', 'ALBERTO','Perez',850.5,'1994-07-15','Tecnologo');
SET IDENTITY_INSERT Empleados OFF   