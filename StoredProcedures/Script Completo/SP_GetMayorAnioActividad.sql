IF OBJECT_ID('CUATROGDD2018.SP_GetMayorAnioActividad') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_GetMayorAnioActividad
GO
CREATE PROCEDURE CUATROGDD2018.SP_GetMayorAnioActividad
AS
	SELECT TOP 1 (YEAR(R.fecha_desde)) AÑO
	FROM CUATROGDD2018.Reservas R
	ORDER BY R.fecha_desde DESC
GO