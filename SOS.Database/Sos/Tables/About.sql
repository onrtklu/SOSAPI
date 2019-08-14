CREATE TABLE [Sos].[About] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Address]     NVARCHAR (MAX) NULL,
    [PhoneNumber] NVARCHAR (50)  NULL,
    [Email]       NVARCHAR (50)  NULL,
    CONSTRAINT [PK_About] PRIMARY KEY CLUSTERED ([Id] ASC)
);

