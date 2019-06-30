CREATE TABLE [Restaurant].[Rate] (
    [Id]                    INT IDENTITY (1, 1) NOT NULL,
    [Restaurant_Comment_Id] INT NOT NULL,
    [OrderRate]             INT NULL,
    [RestaurantRate]        INT NULL,
    [FoodRate]              INT NULL,
    [ServiceRate]           INT NULL,
    [WaiterRate]            INT NULL,
    [Restaurant_Id]         INT NOT NULL,
    CONSTRAINT [PK_Restaurant_Rate] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Restaurant_Rate_Restaurant] FOREIGN KEY ([Restaurant_Id]) REFERENCES [Restaurant].[Restaurant] ([Id]),
    CONSTRAINT [FK_Restaurant_Rate_RestaurantComments] FOREIGN KEY ([Restaurant_Comment_Id]) REFERENCES [Restaurant].[RestaurantComments] ([Id])
);



