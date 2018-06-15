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
		INSERT INTO [CUATROGDD2018].[Habitaciones] (id_tipo_habitacion,id_hotel,piso,frente,nro_habitacion)
		VALUES  (@tipoHab, @codHotel,@habPiso,@habFrente,@numHab)
		FETCH NEXT FROM insert_cursor INTO @nroCalle, @numHab, @habPiso, @habFrente, @tipoHab 
	END
CLOSE insert_cursor
DEALLOCATE insert_cursor
GO