CREATE DATABASE [RegionAuthDB]
GO

USE [RegionAuthDB]
GO

CREATE TABLE [dbo].[User] (
    [Id] UNIQUEIDENTIFIER PRIMARY KEY,
    [Name] VARCHAR(255) NOT NULL,
    [Email] VARCHAR(255) NOT NULL,
    [Slug] VARCHAR(255) NOT NULL,
    [PasswordHash] VARCHAR(255) NOT NULL,
    
    CONSTRAINT [UQ_User_Email] UNIQUE([Email]),
    CONSTRAINT [UQ_User_Slug] UNIQUE([Slug])
);

CREATE NONCLUSTERED INDEX [IX_User_Email] ON [dbo].[User]([Email]);
CREATE NONCLUSTERED INDEX [IX_User_Slug] ON [dbo].[User]([Slug]);

CREATE TABLE [dbo].[Role] (
    [Id] UNIQUEIDENTIFIER PRIMARY KEY,
    [Name] VARCHAR(255) NOT NULL,
    [Slug] VARCHAR(255) NOT NULL,
    
    CONSTRAINT [UQ_Role_Slug] UNIQUE([Slug])
);

CREATE NONCLUSTERED INDEX [IX_Role_Slug] ON [dbo].[Role]([Slug]);

CREATE TABLE [dbo].[UserRole] (
    [UserId] UNIQUEIDENTIFIER NOT NULL,
    [RoleId] UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT [PK_UserRole] PRIMARY KEY([UserId], [RoleId]),
    CONSTRAINT [FK_UserRole_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User]([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_UserRole_Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Role]([Id]) ON DELETE CASCADE
);

CREATE TABLE [dbo].[Address] (
    [Id] CHAR(7) PRIMARY KEY,
    [State] CHAR(2) NULL,
    [City] NVARCHAR(80) NULL
);

CREATE INDEX [IX_Addess_City] ON [dbo].[Address]([City]);
CREATE INDEX [IX_Addess_State] ON [dbo].[Address]([State]);
GO