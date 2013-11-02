CREATE PROCEDURE [dbo].[p_add_operation]
    @user_id int,
    @date_taken datetime,
    @date_returned datetime
AS
    insert into [dbo].[OperationLog](
        [User_Id],
        [Date_Taken],
        [Date_Returned])
    values (@user_id, @date_taken, @date_returned)
        
RETURN 
