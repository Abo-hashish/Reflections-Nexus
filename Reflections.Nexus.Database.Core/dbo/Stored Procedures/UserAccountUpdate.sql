CREATE PROCEDURE [dbo].[UserAccountUpdate]
(
	@UserAccountId int,
	@AccountName varchar(50),
	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(100),
	@IsActive bit,	
	@UpdatedBy int,
	@RowVersion timestamp
)	
AS
	SET NOCOUNT ON
	
	UPDATE UserAccount 
       SET AccountName = @AccountName
         , FirstName = @FirstName
         , LastName = @LastName
         , Email = @Email
         , IsActive = @IsActive
         , Updated = GetDate()
         , UpdatedBy = @UpdatedBy
     WHERE UserAccountId = @UserAccountId
       AND RowVersion = @RowVersion
                   
	RETURN @@ROWCOUNT
