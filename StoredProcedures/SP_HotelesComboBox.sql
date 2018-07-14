IF OBJECT_ID('CUATROGDD2018.SP_HotelesComboBox', 'P') IS NOT NULL
    DROP PROCEDURE CUATROGDD2018.SP_HotelesComboBox
GO
CREATE PROCEDURE CUATROGDD2018.SP_HotelesComboBox
AS
	SELECT id_Hotel, LTRIM(RTRIM(pais)) + '-' + LTRIM(RTRIM(ciudad)) + '-' + LTRIM(RTRIM(calle)) + '-' + CAST(nro_calle as varchar(10)) as dir_Hotel from CUATROGDD2018.Hoteles
GO

