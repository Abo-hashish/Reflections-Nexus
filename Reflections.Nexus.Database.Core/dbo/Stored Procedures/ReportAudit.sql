CREATE PROCEDURE [dbo].[ReportAudit]
	
AS
	
	SELECT     AuditId, ObjectName, RecordId, PropertyName, OldValue, 
                      NewValue, AuditType, Audit.Created, FirstName, LastName
FROM         Audit INNER JOIN
                      UserAccount ON Audit.CreatedBy = UserAccount.UserAccountId
	RETURN
