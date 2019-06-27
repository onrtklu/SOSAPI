CREATE TABLE [dbo].[Event] (
    [ID]        INT      IDENTITY (1, 1) NOT NULL,
    [HallID]    INT      NULL,
    [PlayID]    INT      NULL,
    [EventDate] DATETIME NULL,
    CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([ID] ASC)
);

