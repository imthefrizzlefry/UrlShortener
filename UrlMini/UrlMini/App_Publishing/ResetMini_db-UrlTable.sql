
GO

IF (SELECT OBJECT_ID('tempdb..#tmpErrors')) IS NOT NULL DROP TABLE #tmpErrors
GO
CREATE TABLE #tmpErrors (Error int)
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL READ COMMITTED
GO
BEGIN TRANSACTION

Go
PRINT N'Dropping [dbo].[UrlTable] if it exists...';
IF (SELECT OBJECT_ID('urlmini_db..UrlTable')) IS NOT NULL DROP TABLE [dbo].[UrlTable]

GO
PRINT N'Creating [dbo].[UrlTable]...';


GO
CREATE TABLE [dbo].[UrlTable] (
    [Id]      INT          IDENTITY (1, 1) NOT NULL,
    [Url]     NVARCHAR (500) NOT NULL,
    [Created] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO
PRINT N'Creating unnamed constraint on [dbo].[UrlTable]...';


GO
ALTER TABLE [dbo].[UrlTable]
    ADD DEFAULT GetDate() FOR [Created];

GO
PRINT N'Inserting Default Value into [dbo].[UrlTable]...';

GO
INSERT [dbo].[UrlTable] (Url)
	SELECT 'https://home.stevenfarnell.net';
INSERT [dbo].[UrlTable] (Url)
	SELECT 'JUNK';
DELETE FROM [dbo].[UrlTable] WHERE Url = 'JUNK'

GO
IF @@ERROR <> 0
   AND @@TRANCOUNT > 0
    BEGIN
        ROLLBACK;
    END

IF @@TRANCOUNT = 0
    BEGIN
        INSERT  INTO #tmpErrors (Error)
        VALUES                 (1);
        BEGIN TRANSACTION;
    END


GO

IF EXISTS (SELECT * FROM #tmpErrors) ROLLBACK TRANSACTION
GO
IF @@TRANCOUNT>0 BEGIN
PRINT N'The transacted portion of the database update succeeded.'
COMMIT TRANSACTION
END
ELSE PRINT N'The transacted portion of the database update failed.'
GO
DROP TABLE #tmpErrors
GO
PRINT N'Update complete.';


GO
SELECT * FROM [dbo].[UrlTable]
