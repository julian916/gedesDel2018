INSERT INTO [CUATROGDD2018].[Tipo_Habitacion] ([id_tipo_habitacion],[descripcion],[porcentual])
SELECT DISTINCT  Habitacion_Tipo_Codigo,Habitacion_Tipo_Descripcion,Habitacion_Tipo_Porcentual
FROM gd_esquema.Maestra