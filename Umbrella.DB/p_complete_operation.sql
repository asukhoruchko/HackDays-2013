CREATE PROCEDURE [dbo].[p_complete_operation]
    @user_id int,
    @date_returned datetime,
    @count int
AS
    ;with to_update as
    (
	    select top (@count)
		    ol.Operation_Log_Id
	    from
		    OperationLog ol
	    where
		    [user_id] = @user_id
		    and Date_Returned is null
	    order by
		    date_taken 
    )

    update ol
    set
	    ol.date_returned = @date_returned
    from
	    OperationLog ol
    inner join
	    to_update tu on
		    tu.Operation_Log_Id = ol.Operation_Log_Id

RETURN
