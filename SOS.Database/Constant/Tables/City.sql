CREATE TABLE [Constant].[City] (
    [Id]       INT             IDENTITY (1, 1) NOT NULL,
    [CityName] NVARCHAR (1000) NOT NULL,
    [ZipCode]  INT             NULL,
    CONSTRAINT [PK__City__3214EC0704ADF401] PRIMARY KEY CLUSTERED ([Id] ASC)
);

