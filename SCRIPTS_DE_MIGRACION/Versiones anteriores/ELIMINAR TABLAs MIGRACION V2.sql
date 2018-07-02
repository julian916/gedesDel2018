

DROP TABLE [CUATROGDD2018].[Consumible_X_Estadia]
DROP TABLE [CUATROGDD2018].[Estadia_X_Persona]
DROP TABLE [CUATROGDD2018].[Habitacion_X_Reserva]
DROP TABLE [CUATROGDD2018].[Regimen_X_Hotel]
DROP TABLE [CUATROGDD2018].[Usuario_X_Hotel_X_Rol]
DROP TABLE [CUATROGDD2018].[Consumibles]
DROP TABLE [CUATROGDD2018].[Historial_Cierres]
DROP TABLE [CUATROGDD2018].[Facturas]
DROP TABLE [CUATROGDD2018].[Estadias]
DROP TABLE [CUATROGDD2018].[Reservas]
DROP TABLE [CUATROGDD2018].[Estados_Reservas]
DROP TABLE [CUATROGDD2018].[Habitaciones]
DROP TABLE [CUATROGDD2018].[Hoteles]
DROP TABLE [CUATROGDD2018].[Regimenes_Estadia]
DROP TABLE [CUATROGDD2018].[Tipo_Habitacion]
DROP TABLE [CUATROGDD2018].[Roles]
DROP TABLE [CUATROGDD2018].[Personas]
DROP TABLE [CUATROGDD2018].[Usuarios]

DROP SCHEMA CUATROGDD2018


--1 ROLES
SELECT *FROM [CUATROGDD2018].[Roles]

--2 USUARIOS
SELECT *FROM [CUATROGDD2018].[Usuarios] -- SACAR ATRIBUTO HABILITADO


--4 Estado de reservas

SELECT *FROM [CUATROGDD2018].[Estados_Reservas]

--5 Tipo de Habitaciones

SELECT *FROM [CUATROGDD2018].[Tipo_Habitacion]

--6 Hoteles
SELECT *FROM [CUATROGDD2018].[Hoteles]

--7 Insertar Habitaciones

SELECT *FROM [CUATROGDD2018].[Habitaciones]

--8 Regimen de estadia

SELECT *FROM [CUATROGDD2018].[Regimenes_Estadia]

-- 9 Regimen por hotel

SELECT *FROM [CUATROGDD2018].[Regimen_X_Hotel]

-- 10 Consumibles

SELECT *FROM [CUATROGDD2018].[Consumibles]

-- 11 personas

SELECT *FROM [CUATROGDD2018].[Personas] -- campo pais tiene por default "no informado"

--12 reserva
SELECT *FROM [CUATROGDD2018].[Reservas]

--13 Habitaciones por Reserva
SELECT *FROM [CUATROGDD2018].[Habitacion_X_Reserva]

--14 estadias
SELECT *FROM [CUATROGDD2018].[Estadias]

--15 Consumible por estadia
SELECT *FROM [CUATROGDD2018].[Consumible_X_Estadia]

--16 estadia x persona
SELECT *FROM [CUATROGDD2018].[Estadia_X_Persona]  -- 86300 registros :/

-- 17 factura
SELECT *FROM [CUATROGDD2018].[Facturas]

-- USUARIO X HOTEL X ROL
SELECT *FROM [CUATROGDD2018].[Usuario_X_Hotel_X_Rol]