CREATE TABLE [dbo].[User]
(
    [User_Id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    [Login] nvarchar(255) NOT NULL,
    [Last_Name] nvarchar(255) NOT NULL
)
