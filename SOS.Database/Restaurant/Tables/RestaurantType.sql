CREATE TABLE [Restaurant].[RestaurantType] (
    [Id]                 INT             IDENTITY (1, 1) NOT NULL,
    [RestaurantTypeName] NVARCHAR (1000) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

