CREATE PROCEDURE [dbo].[p_add_operation]
    @user_id int,
    @date_taken datetime,
    @count int
AS
    ;with src as
    (
        select 
            @user_id [user_id],
            @date_taken [date_taken]
    ),
    total as
    (
        select 
            1 [count]

        union all

        select 
            [count] + 1
        from 
            total
        where 
            [count] < @count
    )
    
    insert into [dbo].[OperationLog](
        [User_Id],
        [Date_Taken])
    select
        src.[user_id],
        src.[date_taken]
    from
        src
    inner join
        total on 1 = 1
        
RETURN 
