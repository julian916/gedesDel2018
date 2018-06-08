--CREAR TABLA Estadias

CREATE TABLE dbo.Consumible_X_Estadia
(	
	id_estadia int NOT NULL,
	id_consumible int NOT NULL,
	PRIMARY KEY CLUSTERED ( id_estadia, id_consumible ),
	FOREIGN KEY (id_estadia) REFERENCES [Estadias] ( id_estadias ),
	FOREIGN KEY (id_consumible) REFERENCES [Consumibles] (id_consumible),
	cantidad numeric(18,0),
	monto numeric(18,2),
	)
GO

-- INSERTAR

INSERT INTO Consumible_X_Estadia(id_estadia, id_consumible, monto,cantidad)
SELECT id_estadias,Consumible_Codigo, Item_Factura_Cantidad, Item_Factura_Monto
from gd_esquema.Maestra
JOIN Estadias on Estadia_Cant_Noches=Estadias.cant_noches and Estadia_Fecha_Inicio=Estadias.fecha_inicio
JOIN Habitaciones on Estadias.id_habitacion=Habitaciones.id_habitacion and Habitacion_Numero=Habitaciones.numero_hab and Habitacion_Piso=Habitaciones.numero_hab
JOIN Hoteles on Hoteles.id_hotel=Habitaciones.id_hotel and Hotel_Nro_Calle= Hoteles.nro_calle
where Consumible_Codigo is not null
group by id_estadias,Consumible_Codigo,Consumible_Precio,Item_Factura_Cantidad, Item_Factura_Monto
order by id_estadias,Consumible_Codigo
