CREATE PROCEDURE [dbo].[p_insert_user]
    @login nvarchar(255),
    @last_name nvarchar(255)
AS
    insert into [dbo].[User] (Login, Last_Name)
    values (@login, @last_name)

RETURN 
