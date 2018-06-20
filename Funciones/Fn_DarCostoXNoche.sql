CREATE FUNCTION [CUATROGDD2018].[DarCostoXNoche] (@idRegimen int,@idTipoHab int)
RETURNS numeric(18,0)
AS BEGIN
    DECLARE @precioBaseReg numeric(18,0);
	DECLARE @porcentual numeric(18,2);
	DECLARE @resultado numeric(18,0);
	
    SELECT @precioBaseReg=[precio_base]
	FROM [CUATROGDD2018].[Regimenes_Estadia]
	where id_regimen=@idRegimen

    SELECT @porcentual=[porcentual]
	FROM [CUATROGDD2018].[Tipo_Habitacion]
	where [id_tipo_habitacion]=@idTipoHab

	set @resultado=@precioBaseReg*@porcentual;
	
    RETURN @resultado
END
