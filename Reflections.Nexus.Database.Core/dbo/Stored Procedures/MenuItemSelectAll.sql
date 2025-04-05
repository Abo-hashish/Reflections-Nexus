CREATE PROCEDURE [dbo].[MenuItemSelectAll]	
AS
	SET NOCOUNT ON
	
	SELECT MenuItemId, MenuItemName, Description, Url, ParentMenuItemId, DisplaySequence, IsAlwaysEnabled, 
	       Created, CreatedBy, Updated, UpdatedBy, RowVersion
	FROM MenuItem
	ORDER BY ParentMenuItemId, DisplaySequence, MenuItemName
	
	RETURN
