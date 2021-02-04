CREATE TABLE [dbo].[ConsecutiveControl]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MsgTypeId] INT NOT NULL, 
    [Prefix] VARCHAR(5) NULL, 
    [Sec] INT NOT NULL IDENTITY, 
    [Consecutive_Length] INT NULL, 
    [Date_Control] DATETIME NULL
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'The last number asignated',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'ConsecutiveControl',
    @level2type = N'COLUMN',
    @level2name = N'Date_Control'