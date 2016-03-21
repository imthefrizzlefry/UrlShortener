CREATE DATABASE urlmini_db
GO
USE urlmini_db
GO
CREATE TABLE [dbo].[UrlTable] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (500) NOT NULL,
    [Created] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);