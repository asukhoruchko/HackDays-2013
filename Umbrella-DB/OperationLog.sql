CREATE TABLE [dbo].[OperationLog]
(
    [Operation_Log_Id] INT NOT NULL PRIMARY KEY,
    [User_Id] INT NOT NULL REFERENCES [dbo].[User](User_ID),
    [Date_Taken] Date NOT NULL,
    [Date_Returned] Date NOT NULL
)