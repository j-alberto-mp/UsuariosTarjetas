CREATE DATABASE ClientesBD;

USE ClientesBD;

CREATE TABLE Clientes (
	ClienteID INT PRIMARY KEY IDENTITY
	,Nombre NVARCHAR(30) NOT NULL
	,ApellidoPaterno NVARCHAR(70) NOT NULL
	,ApellidoMaterno NVARCHAR(70) NOT NULL
	,Rfc NVARCHAR(13) NOT NULL
	,FechaRegistro DATETIME
	,FechaActualizacion DATETIME
);

