CREATE TABLE [dbo].[Contacts]
(
	[Id] INT NOT NULL PRIMARY KEY,
    [EmployeeId] INT NOT NULL,
    [FirsName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [Email] NVARCHAR(200) NULL, 
    [Mobil] NVARCHAR(20) NULL, 
    [Status] INT NULL, 
     
    
)
