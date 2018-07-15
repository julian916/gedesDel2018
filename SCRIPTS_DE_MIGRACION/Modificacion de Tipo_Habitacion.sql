ALTER TABLE [GD1C2018].[CUATROGDD2018].[Tipo_Habitacion]
ADD Capacidad INT NULL 

update [CUATROGDD2018].Tipo_Habitacion
set Capacidad = 1
where id_tipo_habitacion=1001
update [CUATROGDD2018].Tipo_Habitacion
set Capacidad = 2
where id_tipo_habitacion=1002
update [CUATROGDD2018].Tipo_Habitacion
set Capacidad = 3
where id_tipo_habitacion=1003
update [CUATROGDD2018].Tipo_Habitacion
set Capacidad = 4
where id_tipo_habitacion=1004
update [CUATROGDD2018].Tipo_Habitacion
set Capacidad = 5
where id_tipo_habitacion=1005