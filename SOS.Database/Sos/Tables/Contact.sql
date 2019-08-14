CREATE TABLE [Sos].[Contact] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [NameSurname] NVARCHAR (500) NULL,
    [Email]       NVARCHAR (50)  NULL,
    [PhoneNumber] NVARCHAR (50)  NULL,
    [Message]     NVARCHAR (MAX) NULL,
    [CreateDate]  DATETIME       NULL,
    CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED ([Id] ASC)
);

