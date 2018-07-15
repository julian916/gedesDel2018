IF OBJECT_ID('CUATROGDD2018.SP_GetTipoHabitacion_PorID') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetTipoHabitacion_PorID
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetTipoHabitacion_PorID]
	@idTipo int
AS
BEGIN
	SELECT * FROM [CUATROGDD2018].[Tipo_Habitacion] T_H
	WHERE T_H.id_tipo_habitacion = @idTipo
END
GO