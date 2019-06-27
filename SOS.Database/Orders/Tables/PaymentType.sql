CREATE TABLE [Orders].[PaymentType] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [PaymentTypeName] NVARCHAR (1000) NULL,
    CONSTRAINT [PK_Orders_PaymentType] PRIMARY KEY CLUSTERED ([Id] ASC)
);

