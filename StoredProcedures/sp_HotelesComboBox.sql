USE GD1C2018
GO
IF OBJECT_ID('dbo.sp_HotelesComboBox', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_HotelesComboBox
GO
CREATE PROCEDURE dbo.sp_HotelesComboBox
AS
	SELECT id_Hotel, calle+'-'+CAST(nro_calle as varchar(10)) as dir_Hotel from CUATROGDD2018.Hoteles
GO
