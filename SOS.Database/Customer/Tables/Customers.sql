CREATE TABLE [Customer].[Customers] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [CustomerName]    NVARCHAR (1000) NOT NULL,
    [City_Id]         INT             NULL,
    [Address]         NVARCHAR (MAX)  NULL,
    [Phone]           NVARCHAR (1000) NULL,
    [Email]           NVARCHAR (1000) NULL,
    [ConfirmationKey] NVARCHAR (MAX)  NULL,
    [Password]        NVARCHAR (MAX)  NULL,
    [BirthDate]       DATE            NULL,
    [ActiveDate]      DATETIME        NULL,
    [Datetime]        DATETIME        NULL,
    CONSTRAINT [PK_Customer_Customers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_Customers_City] FOREIGN KEY ([City_Id]) REFERENCES [Constant].[City] ([Id])
);

