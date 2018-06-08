CREATE TABLE dbo.Regimen_X_Hotel
(
	id_regimen int NOT NULL,
	id_hotel int NOT NULL,
	estado varchar(255) NOT NULL
	PRIMARY KEY CLUSTERED ( id_regimen, id_hotel ),
	FOREIGN KEY (id_regimen) REFERENCES [Regimenes_Estadia] ( id_regimen ),
	FOREIGN KEY (id_hotel) REFERENCES [Hoteles] (id_hotel)
)
GO

DECLARE @nroCalle numeric(18,0), @descReg varchar(255), @codReg int, @codHotel int
DECLARE insert_cursor CURSOR FOR 
	SELECT Hotel_Nro_Calle, Regimen_Descripcion 
	FROM gd_esquema.Maestra 
	GROUP BY Hotel_Nro_Calle, Regimen_Descripcion
	ORDER BY Hotel_Nro_Calle
OPEN insert_cursor
FETCH NEXT FROM insert_cursor INTO @nroCalle,@descReg
WHILE @@FETCH_STATUS=0
	BEGIN
		SELECT @codHotel=id_hotel FROM Hoteles where nro_calle = @nroCalle
		SELECT @codReg=id_regimen FROM Regimenes_Estadia where descripcion = @descReg
		INSERT INTO dbo.Regimen_X_Hotel (id_regimen, id_hotel, estado)
		VALUES  (@codReg, @codHotel, 'Activo')
		FETCH NEXT FROM insert_cursor INTO @nroCalle,@descReg
	END
CLOSE insert_cursor
DEALLOCATE insert_cursor
GO