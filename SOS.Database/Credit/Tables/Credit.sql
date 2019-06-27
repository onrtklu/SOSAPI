CREATE TABLE [Credit].[Credit] (
    [Id]         INT             IDENTITY (1, 1) NOT NULL,
    [CreditName] NVARCHAR (1000) NOT NULL,
    [CreditRate] INT             NULL,
    CONSTRAINT [PK_Credit_Credit] PRIMARY KEY CLUSTERED ([Id] ASC)
);

