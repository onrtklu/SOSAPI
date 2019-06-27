CREATE TABLE [Restaurant].[RestaurantComments] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Order_Id]    INT            NULL,
    [Customer_Id] INT            NULL,
    [CommentText] NVARCHAR (MAX) NULL,
    [OrderDate]   DATETIME       NULL,
    [Complaint]   BIT            NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Restaurant_RestaurantComments_Customers] FOREIGN KEY ([Customer_Id]) REFERENCES [Customer].[Customers] ([Id]),
    CONSTRAINT [FK_Restaurant_RestaurantComments_Orders] FOREIGN KEY ([Order_Id]) REFERENCES [Orders].[Orders] ([Id])
);

