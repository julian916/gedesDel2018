IF OBJECT_ID('CUATROGDD2018.SP_GetAll_TiposHabitaciones') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetAll_TiposHabitaciones
GO
CREATE PROCEDURE [CUATROGDD2018].[SP_GetAll_TiposHabitaciones]
AS
BEGIN
	SELECT * FROM CUATROGDD2018.Tipo_Habitacion

END
GO