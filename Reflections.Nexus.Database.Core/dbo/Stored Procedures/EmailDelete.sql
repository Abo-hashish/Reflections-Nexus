

CREATE PROCEDURE [dbo].[EmailDelete]
(
    @EmailId int
)
AS
    SET NOCOUNT ON

    DELETE
      FROM Email
     WHERE EmailId = @EmailId

    RETURN

