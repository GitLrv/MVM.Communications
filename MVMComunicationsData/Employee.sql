CREATE TABLE [dbo].[Employee]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [ProfileId] INT NOT NULL,
    [DepartmentId] INT NULL, 
    [ContactId] INT NULL, 
    [Active] BIT NULL, 
    
)
