

CREATE PROCEDURE [dbo].[WorkFlowOwnerGroupUpdate]
(
    @WorkFlowOwnerGroupId  int, 
    @WorkFlowId  int, 
    @OwnerGroupName  varchar(50), 
    @DefaultUserAccountId  int, 
    @IsDefaultSameAsLast  bit, 
    @Description  varchar(255), 
    @UpdatedBy  int, 
    @RowVersion  timestamp
)
AS
    SET NOCOUNT ON

    UPDATE WorkFlowOwnerGroup
       SET 
           WorkFlowId = @WorkFlowId, 
           OwnerGroupName = @OwnerGroupName, 
           DefaultUserAccountId = @DefaultUserAccountId, 
           IsDefaultSameAsLast = @IsDefaultSameAsLast, 
           Description = @Description, 
           Updated = GetDate(), 
           UpdatedBy = @UpdatedBy
     WHERE WorkFlowOwnerGroupId = @WorkFlowOwnerGroupId
       AND RowVersion = @RowVersion

    RETURN @@ROWCOUNT

