USE [MVMComunicationsData]
GO

/****** Object:  StoredProcedure [dbo].[SPMVMInsertMsgRecord]    Script Date: 3/02/2021 22:02:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Leonardo Rojas Vasilescu
-- Create date: 03-Feb-2021
-- Description:	Procedimiento almacenado para insertar una comunicación 
-- =============================================
CREATE PROCEDURE [dbo].[SPMVMInsertMsgRecord] 
@DocManagerContactId INT,
@MsgTypeId INT,
@FromContactId INT,
@ToContactId INT
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;
	DECLARE @Prefix VARCHAR(5)
	SET @Prefix = ''
	DECLARE @Sec INT
	SET @Sec = 0

	BEGIN TRANSACTION [TInsertMsgRecord]

	BEGIN TRY
	  
	 SELECT @Prefix = Prefix FROM [dbo].[ConsecutiveControl] WHERE MsgTypeId = @MsgTypeId 
	 IF @MsgTypeId = 1
		BEGIN
			SET @Sec = NEXT VALUE FOR IMsgBy1
		END
	 ELSE IF @MsgTypeId = 2
			BEGIN
				SET @Sec = NEXT VALUE FOR EMsgBy1
			END

	 IF @Sec > (SELECT Sec FROM [dbo].[ConsecutiveControl] WHERE MsgTypeId = @MsgTypeId AND getDate() >= Date_Control)   
		BEGIN
			INSERT INTO [dbo].[MsgRecord]
			   ([Prefix]
			   ,[Sec]
			   ,[DocManagerContactId]
			   ,[Received_Date]
			   ,[Delivered_Date]
			   ,[MsgTypeId]
			   ,[Digitalization]
			   ,[MsgStatusId])
			VALUES
			   (@Prefix
			   ,@Sec
			   ,@DocManagerContactId
			   ,GetDate()
			   ,NULL
			   ,@MsgTypeId
			   ,0
			   ,1)

			    BEGIN TRANSACTION [TInsertMsgContacts]
					BEGIN TRY
						INSERT INTO [dbo].[MsgContact]
								   ([MsgRecordSec]
								   ,[ContactId]
								   ,[ContactTypeId])
							 VALUES
								   (@Sec
								   ,@FromContactId
								   ,1)

							INSERT INTO [dbo].[MsgContact]
								   ([MsgRecordSec]
								   ,[ContactId]
								   ,[ContactTypeId])
							 VALUES
								   (@Sec
								   ,@ToContactId
								   ,2)
						COMMIT TRANSACTION [TInsertMsgContacts]
					END TRY

					BEGIN CATCH

					  ROLLBACK TRANSACTION [TInsertMsgContacts]

					END CATCH
		END
	 ELSE  
		ROLLBACK TRANSACTION [TInsertMsgRecord]
     

      COMMIT TRANSACTION [TInsertMsgRecord]

	END TRY

	BEGIN CATCH

      ROLLBACK TRANSACTION [TInsertMsgRecord]

	END CATCH
   
END
GO

