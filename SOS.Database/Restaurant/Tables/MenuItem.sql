CREATE TABLE [Restaurant].[MenuItem] (
    [Id]                    INT             IDENTITY (1, 1) NOT NULL,
    [Restaurant_Id]         INT             NULL,
    [ItemName]              NVARCHAR (1000) NULL,
    [Category_Id]           INT             NULL,
    [Description]           NVARCHAR (MAX)  NULL,
    [Ingredients]           NVARCHAR (MAX)  NULL,
    [EstimatedDeliveryTime] INT             NULL,
    [Price]                 DECIMAL (18, 2) NULL,
    [IsActive]              BIT             CONSTRAINT [DF_MenuItem_IsActive] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK__MenuItem__3214EC071FB01BEC] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Restaurant_MenuItem_MenuCategory] FOREIGN KEY ([Category_Id]) REFERENCES [Restaurant].[MenuCategory] ([Id]),
    CONSTRAINT [FK_Restaurant_MenuItem_Restaurant] FOREIGN KEY ([Restaurant_Id]) REFERENCES [Restaurant].[Restaurant] ([Id])
);





