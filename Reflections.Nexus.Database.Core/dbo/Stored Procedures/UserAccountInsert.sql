CREATE PROCEDURE [dbo].[UserAccountInsert]
(
	@UserAccountId int OUTPUT,
	@AccountName varchar(50),
	@FirstName varchar(50),
	@LastName varchar(50),
	@Email varchar(100),
	@IsActive bit,	
	@CreatedBy int	
)	
AS
	SET NOCOUNT ON
	INSERT INTO UserAccount (AccountName, FirstName, LastName, Email, IsActive, Created, CreatedBy, Updated, UpdatedBy) 
         VALUES (@AccountName, 
				@FirstName,
				@LastName,
				@Email,
				@IsActive,
				GetDate(),
                @CreatedBy, 
                GetDate(),
                @CreatedBy)

	SET @UserAccountId = Scope_Identity()                
	RETURN