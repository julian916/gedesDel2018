CREATE TABLE dbo.Habitaciones
(
	id_habitacion int identity(1,1) PRIMARY KEY,
	id_tipo_habitacion int NOT NULL,
	id_hotel int not NULL,
	piso varchar(255) NOT NULL,
	tiene_Frente varchar (1),
	numero_hab numeric(18,0), 
	esta_Habilitado BIT NOT NULL DEFAULT 0,
	descripcion varchar (255),
	FOREIGN KEY (id_tipo_habitacion) REFERENCES [Tipos_Habitacion] (id_Tipo_Habitacion),
	FOREIGN KEY (id_hotel) REFERENCES [Hoteles] (id_hotel)
)
GO

DECLARE @nroCalle numeric(18,0), @numHab numeric (18,0), @habPiso varchar (255), @habFrente varchar(1), @tipoHab numeric (18,0),@codHotel int 
DECLARE insert_cursor CURSOR FOR 
	SELECT Hotel_Nro_Calle, Habitacion_Numero, Habitacion_Piso, Habitacion_Frente, Habitacion_Tipo_Codigo
	FROM gd_esquema.Maestra
	GROUP BY Hotel_Nro_Calle,Habitacion_Numero,Habitacion_Tipo_Codigo, Habitacion_Piso, Habitacion_Frente
	ORDER BY Hotel_Nro_Calle,Habitacion_Numero,Habitacion_Piso
OPEN insert_cursor
FETCH NEXT FROM insert_cursor INTO @nroCalle, @numHab, @habPiso, @habFrente, @tipoHab 
WHILE @@FETCH_STATUS=0
	BEGIN
		SELECT @codHotel=id_hotel FROM Hoteles where nro_calle = @nroCalle
		INSERT INTO dbo.Habitaciones (id_tipo_habitacion,id_hotel,piso,tiene_Frente,numero_hab)
		VALUES  (@tipoHab, @codHotel,@habPiso,@habFrente,@numHab)
		FETCH NEXT FROM insert_cursor INTO @nroCalle, @numHab, @habPiso, @habFrente, @tipoHab 
	END
CLOSE insert_cursor
DEALLOCATE insert_cursor
GO