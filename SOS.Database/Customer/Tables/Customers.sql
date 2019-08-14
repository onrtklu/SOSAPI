CREATE TABLE [Customer].[Customers] (
    [Id]              INT             IDENTITY (1, 1) NOT NULL,
    [NameSurname]     NVARCHAR (1000) NULL,
    [City_Id]         INT             NULL,
    [Address]         NVARCHAR (MAX)  NULL,
    [PhoneNumber]     NVARCHAR (1000) NULL,
    [Email]           NVARCHAR (1000) NOT NULL,
    [ConfirmationKey] NVARCHAR (MAX)  NULL,
    [Password]        NVARCHAR (MAX)  NOT NULL,
    [BirthDate]       DATE            NULL,
    [PictureUrl]      NVARCHAR (MAX)  NULL,
    [ActiveDate]      DATETIME        NULL,
    [Datetime]        DATETIME        NULL,
    CONSTRAINT [PK_Customer_Customers] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Customer_Customers_City] FOREIGN KEY ([City_Id]) REFERENCES [Constant].[City] ([Id])
);



