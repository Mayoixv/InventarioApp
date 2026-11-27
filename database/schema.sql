IF DB_ID('InventarioDB') IS NULL CREATE DATABASE InventarioDB;
GO
USE InventarioDB;
GO
IF OBJECT_ID('dbo.Productos') IS NULL
CREATE TABLE dbo.Productos (
    Id       INT IDENTITY(1,1) PRIMARY KEY,
    Nombre   NVARCHAR(100)  NOT NULL,
    Precio   DECIMAL(10,2)  NOT NULL,
    Cantidad INT            NOT NULL
);
GO
