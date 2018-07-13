USE [GD1C2018]
GO
--FUNCION QUE DEVUELVE RECARGA DE HOTEL
IF OBJECT_ID('CUATROGDD2018.Fn_DarRecargaHotel') IS NOT NULL
    DROP FUNCTION CUATROGDD2018.Fn_DarRecargaHotel
GO
CREATE FUNCTION [CUATROGDD2018].[Fn_DarRecargaHotel] (@idHotel int)
RETURNS numeric(18,2)
AS BEGIN

    DECLARE @resultado numeric(18,2);
	
    Select @resultado=[cant_estrellas]*[recarga_estrellas]
	from [CUATROGDD2018].[Hoteles]
	where id_hotel=@idHotel
	
    RETURN @resultado
END
GO
--FUNCION QUE DEVUELVE EL PRECIO BASE POR HABITACION
IF OBJECT_ID('CUATROGDD2018.Fn_DarCostoXNoche') IS NOT NULL
    DROP FUNCTION CUATROGDD2018.Fn_DarCostoXNoche
GO
CREATE FUNCTION [CUATROGDD2018].[Fn_DarCostoXNoche] (@idRegimen int,@idTipoHab int)
RETURNS numeric(18,2)
AS BEGIN

    DECLARE @precioBaseReg numeric(18,0);
	DECLARE @porcentual numeric(18,2);
	DECLARE @resultado numeric(18,2);
	
    SELECT @precioBaseReg=[precio_base]
	FROM [CUATROGDD2018].[Regimenes_Estadia]
	where id_regimen=@idRegimen

    SELECT @porcentual=[porcentual]
	FROM [CUATROGDD2018].[Tipo_Habitacion]
	where [id_tipo_habitacion]=@idTipoHab

	set @resultado=@precioBaseReg*@porcentual;
	
    RETURN @resultado
END
GO

--PROCEDIMIENTO QUE CALCULA EL PRECIO X NOCHE
IF OBJECT_ID('CUATROGDD2018.SP_DarCostoHabitacion') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_DarCostoHabitacion
GO

CREATE PROCEDURE [CUATROGDD2018].[SP_DarCostoHabitacion] 
	@idhotel int,
	@idTipoHab int,
	@idRegimen date
AS
BEGIN
	SELECT [CUATROGDD2018].[Fn_DarCostoXNoche](@idRegimen,@idTipoHab)+[CUATROGDD2018].[Fn_DarRecargaHotel](@idhotel)
END
GO
