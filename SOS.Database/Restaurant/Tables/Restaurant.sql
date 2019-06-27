CREATE TABLE [Restaurant].[Restaurant] (
    [Id]                INT             IDENTITY (1, 1) NOT NULL,
    [RestaurantName]    NVARCHAR (1000) NULL,
    [City_Id]           INT             NULL,
    [Address]           NVARCHAR (MAX)  NULL,
    [Phone]             NVARCHAR (1000) NULL,
    [Email]             NVARCHAR (1000) NULL,
    [ConfirmationKey]   NVARCHAR (MAX)  NULL,
    [RestaurantType_Id] INT             NULL,
    [Datetime]          DATETIME        NULL,
    CONSTRAINT [PK__Restaura__3214EC07F7BEC576] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Restaurant_Restaurant_City] FOREIGN KEY ([City_Id]) REFERENCES [Constant].[City] ([Id]),
    CONSTRAINT [FK_Restaurant_Restaurant_RestaurantType] FOREIGN KEY ([RestaurantType_Id]) REFERENCES [Restaurant].[RestaurantType] ([Id])
);

