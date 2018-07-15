IF OBJECT_ID('CUATROGDD2018.SP_GetEstadoReserva') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetEstadoReserva
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_GetEstadoReserva] @idEstado int
AS
Begin
	SELECT Estados_Reservas.descripcion FROM [CUATROGDD2018].[Estados_Reservas] where id_estado_reserva = @idEstado
End
GO