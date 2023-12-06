/****** Object:  Trigger [dbo].[xct_t_ePay_Customer_DELETE]    Script Date: 2/1/2017 6:58:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[xct_t_Customer_DELETE]
   ON  [dbo].[Customer]
   AFTER DELETE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @CustID varChar(255)

	DELETE FROM xct_tblDSLXML
	FROM deleted
	WHERE deleted.CustId = xct_tblDSLXML.itemID
	AND xct_tblDSLXML.itemType = 'CUSTOMER'
	AND (xct_tblDSLXML.status != 'RECEIVED' AND xct_tblDSLXML.status != 'ERROR')

	print @@rowcount
	
	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT CustId
	FROM deleted


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @CustID

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@CustID
			 ,@itemType='CUSTOMER'
			 ,@status='DELETE'
			 ,@returnResults=0
			
		FETCH NEXT
		FROM insertedCursor
		INTO @CustID
	END

	DEALLOCATE insertedCursor


END



GO

/****** Object:  Trigger [dbo].[xct_t_ePay_Customer_INSERT]    Script Date: 2/1/2017 6:58:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[xct_t_Customer_INSERT]
   ON  [dbo].[Customer]
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @CustID varChar(255)
	
	
	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT CustID
	FROM inserted
	WHERE (1=1)
	AND NOT EXISTS
	(
		SELECT *
		FROM xct_tblDSLXML qt WITH(NOLOCK)
		WHERE qt.itemID = inserted.CustID
		AND qt.itemType = 'CUSTOMER'
		AND (qt.status != 'RECEIVED' AND qt.status != 'ERROR')
	)


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @CustID

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@CustID
			 ,@itemType='CUSTOMER'
			 ,@status='ADD'
			 ,@returnResults=0
			
		FETCH NEXT
		FROM insertedCursor
		INTO @CustID
	END

	DEALLOCATE insertedCursor

END



GO

/****** Object:  Trigger [dbo].[xct_t_ePay_Customer_UPDATE]    Script Date: 2/1/2017 6:58:07 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[xct_t_Customer_UPDATE]
   ON  [dbo].[Customer]
   AFTER UPDATE
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	DECLARE @CustID varChar(255)
	
	
	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT CustId
	FROM inserted
	WHERE (1=1)
	AND NOT EXISTS
	(
		SELECT *
		FROM xct_tblDSLXML qt WITH(NOLOCK)
		WHERE qt.itemID = inserted.CustId
		AND qt.itemType = 'CUSTOMER'
		AND (qt.status != 'RECEIVED' AND qt.status != 'ERROR')
	)


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @CustID

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@CustID
			 ,@itemType='CUSTOMER'
			 ,@status='UPDATE'
			 ,@returnResults=0
			
		FETCH NEXT
		FROM insertedCursor
		INTO @CustID
	END

	DEALLOCATE insertedCursor

END



GO


