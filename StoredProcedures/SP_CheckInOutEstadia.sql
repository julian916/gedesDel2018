IF OBJECT_ID('CUATROGDD2018.SP_CheckInOutEstadia') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_CheckInOutEstadia
GO
CREATE PROCEDURE CUATROGDD2018.SP_CheckInOutEstadia(
	 @id int
	,@idUsuario int
	,@fecha datetime
	)
AS 
BEGIN

	IF EXISTS (SELECT 1 FROM [CUATROGDD2018].[Estadias] WHERE [id_estadia]=@id and [id_usuario_checkOut] is null)
		BEGIN
			UPDATE [CUATROGDD2018].[Estadias]
			SET [cant_noches]=@fecha-[fecha_inicio]
				,[id_usuario_checkOut]=@idUsuario
			where [id_estadia]=@id

			UPDATE [CUATROGDD2018].[Reservas]
			SET [id_estado_reserva]=6--Reserva efectivizada
			FROM [CUATROGDD2018].[Reservas] r
			INNER JOIN [CUATROGDD2018].[Estadias] e
			ON r.id_reserva=e.id_reserva
			WHERE r.id_estado_reserva=7 and e.id_usuario_checkOut is not null
	
		END 
	ELSE
		BEGIN

			declare @idHab int,@idEstadiaInsert int

			select @idHab=hxr.id_habitacion
			from [CUATROGDD2018].[Reservas] r
			inner join [CUATROGDD2018].[Habitacion_X_Reserva] hxr
			on r.id_reserva=hxr.id_reserva
			where r.id_reserva=@id

			INSERT INTO [CUATROGDD2018].[Estadias](
						[fecha_inicio]
						,[id_usuario_checkIn]
						,[id_reserva]
						,[id_habitacion])
			VALUES (@fecha,@idUsuario,@id,@idHab)

			SET @idEstadiaInsert = @@IDENTITY

			UPDATE [CUATROGDD2018].[Reservas]
			SET [id_estado_reserva]=7--Reserva con ingreso, en curso
			WHERE id_reserva=@id
	
			SELECT @idEstadiaInsert
		END
END
GO