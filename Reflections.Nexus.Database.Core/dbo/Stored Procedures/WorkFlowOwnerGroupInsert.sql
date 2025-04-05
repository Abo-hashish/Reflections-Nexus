

CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupInsert]
(
    @WorkFlowOwnerGroupId  int OUTPUT, 
    @WorkFlowId  int, 
    @OwnerGroupName  varchar(50), 
    @DefaultUserAccountId  int, 
    @IsDefaultSameAsLast  bit, 
    @Description  varchar(255), 
    @CreatedBy  int
)
AS
    SET NOCOUNT ON

    INSERT INTO WorkFlowOwnerGroup (WorkFlowId, OwnerGroupName, DefaultUserAccountId, IsDefaultSameAsLast, Description, Created, CreatedBy, Updated, UpdatedBy)
         VALUES (
                @WorkFlowId, 
                @OwnerGroupName, 
                @DefaultUserAccountId, 
                @IsDefaultSameAsLast, 
                @Description, 
                GetDate(), 
                @CreatedBy, 
                GetDate(), 
                @CreatedBy
                )
    SET @WorkFlowOwnerGroupId = Scope_Identity()

    RETURN

