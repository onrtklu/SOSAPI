CREATE TABLE [Credit].[CustomerCredit] (
    [Id]          INT IDENTITY (1, 1) NOT NULL,
    [Customer_Id] INT NOT NULL,
    [Credit_Id]   INT NOT NULL,
    CONSTRAINT [PK_Credit_CustomerCredit] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Credit_CustomerCredit_Credit] FOREIGN KEY ([Credit_Id]) REFERENCES [Credit].[Credit] ([Id]),
    CONSTRAINT [FK_Credit_CustomerCredit_Customers] FOREIGN KEY ([Customer_Id]) REFERENCES [Customer].[Customers] ([Id])
);

