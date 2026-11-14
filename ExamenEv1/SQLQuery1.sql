IF DB_ID('ClubTenis') IS NULL CREATE DATABASE ClubTenis

USE ClubTenis
GO

IF OBJECT_ID('Pistas') IS NULL CREATE TABLE Pistas (
	IdPista INT NOT NULL PRIMARY KEY,
	Nombre NVARCHAR(50) NOT NULL,
	Superficie NVARCHAR(20) NOT NULL,
	CHECK (Superficie IN ('Tierra Batida', 'Dura', 'Hierba'))
);

IF OBJECT_ID('Reservas') IS NULL CREATE TABLE Reservas (
	IdReserva INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	IdPista INT NOT NULL FOREIGN KEY REFERENCES Pistas (IdPista),
	NombreJugador NVARCHAR(100) NOT NULL,
	EsSocio BIT NOT NULL,
	Fecha Date NOT NULL,
	HoraInicio INT NOT NULL,
	CHECK(HoraInicio BETWEEN 8 AND 21),
	Horas INT NOT NULL,
	CHECK(Horas = 1 OR Horas = 2),
	Importe DECIMAL(6,2) NOT NULL,
	CHECK(Importe >= 0),
	Estado NVARCHAR(10) NOT NULL DEFAULT 'Activa',
	CHECK(Estado IN ('Activa', 'Cancelada'))
);