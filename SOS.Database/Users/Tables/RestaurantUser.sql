CREATE TABLE [Users].[RestaurantUser] (
    [Id]            INT IDENTITY (1, 1) NOT NULL,
    [Restaurant_Id] INT NULL,
    [User_Id]       INT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Users_RestaurantUser_Restaurant] FOREIGN KEY ([Restaurant_Id]) REFERENCES [Restaurant].[Restaurant] ([Id]),
    CONSTRAINT [FK_Users_RestaurantUser_Users] FOREIGN KEY ([User_Id]) REFERENCES [Users].[Users] ([Id])
);

