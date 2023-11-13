use master
go

IF NOT EXISTS(SELECT name FROM master.dbo.sysdatabases where name='PruebaDoubleVPartners' )
CREATE DATABASE PruebaDoubleVPartners
GO

use PruebaDoubleVPartners
go

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'TipoIdentificacion')
CREATE TABLE [dbo].[TipoIdentificacion] (
    [Identificador] INT           IDENTITY (1, 1) NOT NULL,
    [Nombre]        NVARCHAR (50) NOT NULL,
    CONSTRAINT [PK_TipoIdenficacion] PRIMARY KEY CLUSTERED ([Identificador] ASC)
);
GO

if not exists(SELECT * from TipoIdentificacion)
INSERT into TipoIdentificacion (Nombre) VALUES('CC'),('CE'),('TI')
go

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Persona')
CREATE TABLE [dbo].[Persona] (
    [Identificador]        INT            IDENTITY (1, 1) NOT NULL,
    [Nombres]              NVARCHAR (50)  NOT NULL,
    [Apellidos]            NVARCHAR (50)  NOT NULL,
    [NumeroIdentificacion] INT            NOT NULL,
    [Email]                NVARCHAR (MAX) NOT NULL,
    [TipoIdentificacion]   INT            NOT NULL,
    [FechaCreacion]        DATETIME       NOT NULL,
    [Identificacion]       NVARCHAR (MAX) NOT NULL,
    [NombreCompleto]       NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_Persona] PRIMARY KEY CLUSTERED ([Identificador] ASC),
    CONSTRAINT [FK_Persona_TipoIdentificacion] FOREIGN KEY ([TipoIdentificacion]) REFERENCES [dbo].[TipoIdentificacion] ([Identificador])
);
go

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'dbo' AND TABLE_NAME = 'Usuario')
CREATE TABLE [dbo].[Usuario] (
    [Identificador] INT            NOT NULL,
    [NombreUsuario] NVARCHAR (50)  NOT NULL,
    [Pass]          NVARCHAR (MAX) NOT NULL,
    [FechaCreacion] DATETIME       NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED ([Identificador] ASC),
    CONSTRAINT [FK_Usuario_Persona] FOREIGN KEY ([Identificador]) REFERENCES [dbo].[Persona] ([Identificador])
);
GO

IF EXISTS (
SELECT *
    FROM INFORMATION_SCHEMA.ROUTINES
WHERE SPECIFIC_SCHEMA = N'dbo'
    AND SPECIFIC_NAME = N'SpPersonasCreadas'
    AND ROUTINE_TYPE = N'PROCEDURE'
)
DROP PROCEDURE dbo.SpPersonasCreadas
GO
-- Create the stored procedure in the specified schema
CREATE PROCEDURE dbo.SpPersonasCreadas
   
AS
BEGIN
    -- body of the stored procedure
    SELECT * from Persona
END
GO


