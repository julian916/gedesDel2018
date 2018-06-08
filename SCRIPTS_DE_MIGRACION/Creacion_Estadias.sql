--CREAR TABLA Estadias

CREATE TABLE dbo.Estadias
(	
	id_estadias int identity(1,1) PRIMARY KEY,
	fecha_inicio datetime,
	cant_noches int null,
	id_usuario_checkIn int,
	id_usuario_checkOut int, /* recepcionistas */
	id_habitacion int foreign key references Habitaciones
	)
GO

-- INSERTAR

DECLARE @idHotel int, @hotelnro numeric(18,0), @habPiso varchar (255),@nroHAB numeric(18,0), @fechinicio datetime, @cantnochess numeric(18,0), @codhabit int 
DECLARE insert_cursor1 CURSOR FOR 
	SELECT Hotel_Nro_Calle, Habitacion_Numero, Habitacion_Piso, Estadia_Fecha_Inicio, Estadia_Cant_Noches
	FROM gd_esquema.Maestra
	WHERE Estadia_Fecha_Inicio is  not null
	GROUP BY Hotel_Nro_Calle, Habitacion_Numero, Habitacion_Piso, Estadia_Fecha_Inicio, Estadia_Cant_Noches
	
	ORDER BY Hotel_Nro_Calle, Habitacion_Numero, Habitacion_Piso
OPEN insert_cursor1
FETCH NEXT FROM insert_cursor1 INTO @hotelnro, @nroHAB, @habPiso, @fechinicio, @cantnochess
WHILE @@FETCH_STATUS=0
	BEGIN
		SELECT @idHotel=id_hotel From Hoteles where @hotelnro=Hoteles.nro_calle
		SELECT @codhabit=id_habitacion 
		FROM dbo.Habitaciones 
		where numero_hab = @nroHAB and piso=@habPiso and id_Hotel=@idHotel
		INSERT INTO dbo.Estadias (fecha_inicio,cant_noches, id_usuario_checkIn,id_usuario_checkOut, id_habitacion)
		VALUES  (@fechinicio,@cantnochess, '1','1',@codhabit)
		FETCH NEXT FROM insert_cursor1 INTO @hotelnro, @nroHAB, @habPiso, @fechinicio, @cantnochess
	END
CLOSE insert_cursor1
DEALLOCATE insert_cursor1
GO

select distinct fecha_inicio, id_habitacion from Estadias 

SELECT * FROM Estadias;