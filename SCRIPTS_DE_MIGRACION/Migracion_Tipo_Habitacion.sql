INSERT INTO [CUATROGDD2018].[Tipo_Habitacion] ([id_tipo_habitacion],[descripcion],[porcentual])
SELECT DISTINCT  Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion,Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra
update CUATROGDD2018.Tipo_Habitacion 
set
    cant_Huespedes = (case	when descripcion='Base Simple' then 1
							when descripcion='Base Doble' then 2
							when descripcion='Base Triple' then 3
							when descripcion='Base Cuadruple' then 4
							else 5 end)