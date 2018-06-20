CREATE FUNCTION [CUATROGDD2018].[DarRecargaHotel] (@idHotel int)
RETURNS numeric(18,0)
AS BEGIN
    DECLARE @resultado numeric(18,0);
	
    Select @resultado=[cant_estrellas]*[recarga_estrellas]
	from [CUATROGDD2018].[Hoteles]
	where id_hotel=4
	
    RETURN @resultado
END
