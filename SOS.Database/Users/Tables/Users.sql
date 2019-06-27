CREATE TABLE [Users].[Users] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [UserName]        NVARCHAR (1000) NULL,
    [UserPassword]    NVARCHAR (MAX)  NULL,
    [UserAuth_Id]     INT             NULL,
    [ConfirmationKey] NVARCHAR (MAX)  NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_Users_Authority] FOREIGN KEY ([UserAuth_Id]) REFERENCES [Users].[Authority] ([Id])
);

