CREATE DATABASE [RegionAuthDB]
GO

USE [RegionAuthDB]
GO

CREATE TABLE [dbo].[Address] (
    [Id] CHAR(7) PRIMARY KEY,
    [State] CHAR(2) NULL,
    [City] NVARCHAR(80) NULL
);

CREATE INDEX [IX_Addess_City] ON [dbo].[Address]([City]);
CREATE INDEX [IX_Addess_State] ON [dbo].[Address]([State]);
GO