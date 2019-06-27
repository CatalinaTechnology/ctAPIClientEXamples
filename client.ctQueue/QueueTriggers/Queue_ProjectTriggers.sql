/****** Object:  Trigger [dbo].[xct_t_PJPENT_INSERT]    Script Date: 2/13/2017 6:51:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[xct_t_PJPENT_INSERT]
   ON  [dbo].[PJPENT]
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @ProjectID varChar(255)
	DECLARE @XMLContent Varchar(4000)


	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT p.project, '{"myPJPROJ": {"ProjectID":"' + RTRIM(p.project) + '", "user1":"' + RTRIM(p.User1) + '", "user2":"' + RTRIM(p.User2) + '", "Location": "PJPENT_Insert"}}' AS XMLContent
	FROM inserted ph
	JOIN PJPROJ p
		ON ph.project = p.project
	WHERE (1=1)
	AND NOT EXISTS
	(
		SELECT *
		FROM xct_tblDSLXML qt WITH(NOLOCK)
		WHERE qt.itemID = ph.project
		AND qt.itemType = 'PROJECT'
		AND (qt.status != 'RECEIVED' AND qt.status != 'ERROR')
	)


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @ProjectID, @XMLContent

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@ProjectID
			 ,@itemType='PROJECT'
			 ,@status='ADD'
			 ,@returnResults=0
			 ,@xmlContent=@XMLContent
			
		FETCH NEXT
		FROM insertedCursor
		INTO @ProjectID, @XMLContent
	END

	DEALLOCATE insertedCursor
END


GO

/****** Object:  Trigger [dbo].[xct_t_PJPENT_UPDATE]    Script Date: 2/13/2017 6:51:03 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[xct_t_PJPENT_UPDATE]
   ON  [dbo].[PJPENT]
   AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @ProjectID varChar(255)
	DECLARE @XMLContent Varchar(4000)


	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT p.project, '{"myPJPROJ": {"ProjectID":"' + RTRIM(p.project) + '", "user1":"' + RTRIM(p.User1) + '", "user2":"' + RTRIM(p.User2) + '", "Location": "PJPENT_UPdate"}}' AS XMLContent
	FROM inserted ph
	JOIN PJPROJ p
		ON ph.project = p.project
	WHERE (1=1)
	AND NOT EXISTS
	(
		SELECT *
		FROM xct_tblDSLXML qt WITH(NOLOCK)
		WHERE qt.itemID = ph.project
		AND qt.itemType = 'PROJECT'
		AND (qt.status != 'RECEIVED' AND qt.status != 'ERROR')
	)


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @ProjectID, @XMLContent

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@ProjectID
			 ,@itemType='PROJECT'
			 ,@status='ADD'
			 ,@returnResults=0
			 ,@xmlContent=@XMLContent
			
		FETCH NEXT
		FROM insertedCursor
		INTO @ProjectID, @XMLContent
	END

	DEALLOCATE insertedCursor
END


GO

/****** Object:  Trigger [dbo].[xct_t_PJPROJ_INSERT]    Script Date: 2/13/2017 6:51:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[xct_t_PJPROJ_INSERT]
   ON  [dbo].[PJPROJ]
   AFTER INSERT
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @ProjectID varChar(255)
	DECLARE @XMLContent Varchar(4000)


	DECLARE  insertedCursor SCROLL CURSOR FOR
	SELECT project, '{"myPJPROJ": {"ProjectID":"' + RTRIM(ph.project) + '", "user1":"' + RTRIM(ph.User1) + '", "user2":"' + RTRIM(ph.User2) + '", "Location": "PJPROG_Insert"}}' AS XMLContent
	FROM inserted ph
	WHERE (1=1)
	AND NOT EXISTS
	(
		SELECT *
		FROM xct_tblDSLXML qt WITH(NOLOCK)
		WHERE qt.itemID = ph.project
		AND qt.itemType = 'PROJECT'
		AND (qt.status != 'RECEIVED' AND qt.status != 'ERROR')
	)


	OPEN insertedCursor
	
	FETCH
	FROM insertedCursor
	INTO @ProjectID, @XMLContent

	WHILE @@FETCH_STATUS = 0
	BEGIN

		exec xct_spDSLEditDSLXML   
			 @actionType='ADD'
			 ,@siteID='DEFAULT'
			 ,@itemID=@ProjectID
			 ,@itemType='PROJECT'
			 ,@status='ADD'
			 ,@returnResults=0
			 ,@xmlContent=@XMLContent
			
		FETCH NEXT
		FROM insertedCursor
		INTO @ProjectID, @XMLContent
	END

	DEALLOCATE insertedCursor
END


GO

/****** Object:  Trigger [dbo].[xct_t_PJPROJ_UPDATE]    Script Date: 2/13/2017 6:51:22 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE TRIGGER [dbo].[xct_t_PJPROJ_UPDATE]
   ON  [dbo].[PJPROJ]
   AFTER UPDATE
AS 
BEGIN
	SET NOCOUNT ON;

	DECLARE @lupd_prog varchar(255)

	SELECT @lupd_prog = RTRIM(LTRIM(lupd_prog))
	FROM inserted

	if @lupd_prog = 'PAPRJ'
	BEGIN
		DECLARE @ProjectID varChar(255)
		DECLARE @XMLContent Varchar(4000)

		DECLARE  insertedCursor SCROLL CURSOR FOR
		SELECT project, '{"myPJPROJ": {"ProjectID":"' + RTRIM(ph.project) + '", "user1":"' + RTRIM(ph.User1) + '", "user2":"' + RTRIM(ph.User2) + '", "Location": "PJPROG_Update"}}' AS XMLContent
		FROM  inserted ph
		WHERE (1=1)
		AND NOT EXISTS
		(
			SELECT *
			FROM xct_tblDSLXML qt WITH(NOLOCK)
			WHERE qt.itemID = ph.project
			AND qt.itemType = 'PROJECT'
			AND (qt.status != 'RECEIVED' AND qt.status != 'ERROR')
		)


		OPEN insertedCursor
	
		FETCH
		FROM insertedCursor
		INTO @ProjectID, @XMLContent

		WHILE @@FETCH_STATUS = 0
		BEGIN

			exec xct_spDSLEditDSLXML   
				 @actionType='ADD'
				 ,@siteID='DEFAULT'
				 ,@itemID=@ProjectID
				 ,@itemType='PROJECT'
				 ,@status='ADD'
				 ,@returnResults=0
				 ,@xmlContent=@XMLContent
			
			FETCH NEXT
			FROM insertedCursor
			INTO @ProjectID, @XMLContent
		END

		DEALLOCATE insertedCursor
	END
END


GO



