CREATE PROCEDURE [CUATROGDD2018].[SP_altaHabitacon] @idTipoHabitacion int, @idHotel int, @piso numeric(18, 0), 
 @frente nvarchar(50), @nroHab numeric(18, 0), @comodidades varchar(255)

AS  
	INSERT INTO [CUATROGDD2018].[Habitaciones] ( id_tipo_habitacion, id_hotel, piso, frente, nro_habitacion, comodidades)
	VALUES ( @idTipoHabitacion, @idHotel, @piso, @frente, @nroHab, @comodidades)
GO