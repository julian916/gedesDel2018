/*Generar una tabla temporal con los campos necesarios para armar la tabla Facturas*/
SELECT 
      [Reserva_Codigo]
	  ,Estadia_Fecha_Inicio
	  ,[Cliente_Pasaporte_Nro]
	  ,Cliente_Mail
	  ,[Factura_Nro]
	  ,Factura_Fecha
	  ,Factura_Total
	  ,Regimen_Precio
	  ,Estadia_Cant_Noches
	  ,sum(Consumible_Precio) as total_consumible
INTO #TEMP_FACTURA     
FROM [dbo].[Tabla_Maestra]
WHERE Factura_Nro IS NOT NULL
GROUP BY [Reserva_Codigo]
	  ,Estadia_Fecha_Inicio
	  ,[Cliente_Pasaporte_Nro]
	  ,Cliente_Mail
	  ,[Factura_Nro]
	  ,Factura_Fecha
	  ,Factura_Total
	  ,Regimen_Precio
	  ,Estadia_Cant_Noches
ORDER BY [Factura_Nro];
 
/*Insertar tabla Facturas*/
insert into [CUATROGDD2018].[Facturas](
			nro_factura
			,fecha
			,precio_total
			,puntos_obtenidos
			,id_estadias
			,id_persona)
select temp.[Factura_Nro]
		,temp.Factura_Fecha
		,temp.Factura_Total
		,case when temp.total_consumible>=10 and (temp.Regimen_Precio*temp.Estadia_Cant_Noches)>=20 then 2
			  when temp.total_consumible>=10 and (temp.Regimen_Precio*temp.Estadia_Cant_Noches)<20 then 1
			  when temp.total_consumible<10 and (temp.Regimen_Precio*temp.Estadia_Cant_Noches)>=20 then 1
			  else 0
		end as puntos
		,est.id_estadias
		,per.id_persona
from #TEMP_FACTURA temp
inner join [CUATROGDD2018].[Personas] per
on temp.[Cliente_Pasaporte_Nro]=per.nro_documento
and temp.Cliente_Mail=per.email
inner join [CUATROGDD2018].[Estadias] est
on temp.[Reserva_Codigo]=est.[id_reserva];

drop table #TEMP_FACTURA;

