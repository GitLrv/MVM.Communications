CREATE TABLE [dbo].[MsgRecord]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [Prefix] VARCHAR(5) NOT NULL,
    [Sec] INT NOT NULL, 
    [DocManagerContactId] INT NOT NULL, 
    [Registration_Date] DATETIME NOT NULL,
    [Received_Date] DATETIME NULL, 
    [Delivered_Date] DATETIME NULL, 
    [MsgTypeId] INT NULL, 
    [Digitalization] BIT NULL, 
    [MsgStatusId] INT NULL, 
    CONSTRAINT [FK_MsgRecord_ContactType] FOREIGN KEY ([DocManagerContactId]) REFERENCES [Contacts]([Id]), 
    CONSTRAINT [FK_MsgRecord_MsgType] FOREIGN KEY ([MsgTypeId]) REFERENCES [MsgType]([Id]), 
    CONSTRAINT [FK_MsgRecord_MsgStatus] FOREIGN KEY ([MsgStatusId]) REFERENCES [MsgStatus]([Id]) 
    
)

GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Digital Format Id',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'MsgRecord',
    @level2type = N'COLUMN',
    @level2name = 'Digitalization'
GO
EXEC sp_addextendedproperty @name = N'MS_Description',
    @value = N'Communication Type',
    @level0type = N'SCHEMA',
    @level0name = N'dbo',
    @level1type = N'TABLE',
    @level1name = N'MsgRecord',
    @level2type = N'COLUMN',
    @level2name = N'MsgTypeId'
GO
