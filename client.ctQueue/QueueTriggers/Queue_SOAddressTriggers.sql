
/****** Object:  Trigger [dbo].[xct_t_ePay_SOAddress_DELETE]    Script Date: 2/1/2017 6:59:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[xct_t_SOAddress_DELETE]
   ON  [dbo].[SOAddress]
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @CustID varChar(255)
	DECLARE @ShipToID varChar(255)
	DECLARE @ItemID varChar(255)

	DELETE FROM xct_tblDSLXML
	FROM deleted
	WHERE RTRIM(deleted.CustID) + '|' + RTRIM(deleted.ShipToID) = xct_tblDSLXML.itemID
	AND xct_tblDSLXML.itemType = 'SOADDRESS'
	AND (xct_tblDSLXML.status != 'RECEIVED' AND xct_tblDSLXML.status != 'ERROR')

	print @@rowcount
	
	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT CustId, ShipToId
	FROM deleted


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @CustID, @ShipToID

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @ItemID = RTRIM(@CustID) + '|' + RTRIM(@ShipToID)
		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@ItemID
			 ,@itemType='SOADDRESS'
			 ,@status='DELETE'
			 ,@returnResults=0
			
		FETCH NEXT
		FROM insertedCursor
		INTO @CustID, @ShipToID
	END

	DEALLOCATE insertedCursor


END



GO

/****** Object:  Trigger [dbo].[xct_t_ePay_SOAddress_INSERT]    Script Date: 2/1/2017 6:59:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[xct_t_SOAddress_INSERT]
   ON  [dbo].[SOAddress]
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @CustID varChar(255)
	DECLARE @ShipToID varChar(255)	
	DECLARE @ItemID varChar(255)
	
	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT CustId, ShipToId
	FROM inserted
	WHERE (1=1)
	AND NOT EXISTS
	(
		SELECT *
		FROM xct_tblDSLXML qt WITH(NOLOCK)
		WHERE qt.itemID = RTRIM(inserted.CustID) + '|' + RTRIM(inserted.ShipToID)
		AND qt.itemType = 'SOADDRESS'
		AND (qt.status != 'RECEIVED' AND qt.status != 'ERROR')
	)


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @CustID, @ShipToID

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @ItemID = RTRIM(@CustID) + '|' + RTRIM(@ShipToID)
		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@ItemID
			 ,@itemType='SOADDRESS'
			 ,@status='ADD'
			 ,@returnResults=0
			
		FETCH NEXT
		FROM insertedCursor
		INTO @CustID, @ShipToID
	END

	DEALLOCATE insertedCursor

END



GO

/****** Object:  Trigger [dbo].[xct_t_ePay_SOAddress_UPDATE]    Script Date: 2/1/2017 6:59:49 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[xct_t_SOAddress_UPDATE]
   ON  [dbo].[SOAddress]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @CustID varChar(255)
	DECLARE @ShipToID varChar(255)	
	DECLARE @ItemID varChar(255)
	
	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT CustId, ShipToId
	FROM inserted
	WHERE (1=1)
	AND NOT EXISTS
	(
		SELECT *
		FROM xct_tblDSLXML qt WITH(NOLOCK)
		WHERE qt.itemID = RTRIM(inserted.CustID) + '|' + RTRIM(inserted.ShipToID)
		AND qt.itemType = 'SOADDRESS'
		AND (qt.status != 'RECEIVED' AND qt.status != 'ERROR')
	)


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @CustID, @ShipToID

	WHILE @@FETCH_STATUS = 0
	BEGIN
		SET @ItemID = RTRIM(@CustID) + '|' + RTRIM(@ShipToID)
		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@ItemID
			 ,@itemType='SOADDRESS'
			 ,@status='UPDATE'
			 ,@returnResults=0
			
		FETCH NEXT
		FROM insertedCursor
		INTO @CustID, @ShipToID
	END

	DEALLOCATE insertedCursor

END



GO


