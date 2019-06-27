/****** Object:  Trigger [dbo].[xct_t_Vendor_DELETE]    Script Date: 2/1/2017 6:58:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER  [dbo].[xct_t_Vendor_DELETE]
   ON  [dbo].[Vendor]
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @VendId varChar(255)

	DELETE FROM xct_tblDSLXML
	FROM deleted
	WHERE deleted.VendId = xct_tblDSLXML.itemID
	AND xct_tblDSLXML.itemType = 'VENDOR'
	AND (xct_tblDSLXML.status != 'RECEIVED' AND xct_tblDSLXML.status != 'ERROR')

	print @@rowcount
	
	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT VendId
	FROM deleted


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @VendId

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@VendId
			 ,@itemType='VENDOR'
			 ,@status='DELETE'
			 ,@returnResults=0
			
		FETCH NEXT
		FROM insertedCursor
		INTO @VendId
	END

	DEALLOCATE insertedCursor


END



GO

/****** Object:  Trigger [dbo].[xct_t_Vendor_INSERT]    Script Date: 2/1/2017 6:58:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER  [dbo].[xct_t_Vendor_INSERT]
   ON  [dbo].[Vendor]
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @VendId varChar(255)
	
	
	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT VendId
	FROM inserted
	WHERE (1=1)
	AND NOT EXISTS
	(
		SELECT *
		FROM xct_tblDSLXML qt WITH(NOLOCK)
		WHERE qt.itemID = inserted.VendId
		AND qt.itemType = 'VENDOR'
		AND (qt.status != 'RECEIVED' AND qt.status != 'ERROR')
	)


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @VendId

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@VendId
			 ,@itemType='VENDOR'
			 ,@status='ADD'
			 ,@returnResults=0
			
		FETCH NEXT
		FROM insertedCursor
		INTO @VendId
	END

	DEALLOCATE insertedCursor

END



GO

/****** Object:  Trigger [dbo].[xct_t_Vendor_UPDATE]    Script Date: 2/1/2017 6:58:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER  [dbo].[xct_t_Vendor_UPDATE]
   ON  [dbo].[Vendor]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @VendId varChar(255)
	
	
	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT VendId
	FROM inserted
	WHERE (1=1)
	AND NOT EXISTS
	(
		SELECT *
		FROM xct_tblDSLXML qt WITH(NOLOCK)
		WHERE qt.itemID = inserted.VendId
		AND qt.itemType = 'VENDOR'
		AND (qt.status != 'RECEIVED' AND qt.status != 'ERROR')
	)


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @VendId

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@VendId
			 ,@itemType='VENDOR'
			 ,@status='UPDATE'
			 ,@returnResults=0
			
		FETCH NEXT
		FROM insertedCursor
		INTO @VendId
	END

	DEALLOCATE insertedCursor

END



GO

