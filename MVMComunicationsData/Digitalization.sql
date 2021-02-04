CREATE TABLE [dbo].[Digitalization]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [MsgRecordSec] INT NOT NULL, 
    [MediaTypeId] INT NOT NULL, 
    [ResourcePath] NVARCHAR(500) NULL, 
    [Date_Create] DATETIME NULL 
)
