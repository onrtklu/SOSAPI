CREATE TABLE [dbo].[User] (
    [ID]       INT         IDENTITY (1, 1) NOT NULL,
    [Username] NCHAR (100) NULL,
    [Email]    NCHAR (100) NULL,
    [Password] NCHAR (10)  NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

