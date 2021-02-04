USE [MVMComunicationsData]
GO

/****** Object:  Trigger [dbo].[TUpdateConsecutiveControl]    Script Date: 3/02/2021 18:02:05 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TRIGGER [dbo].[TUpdateConsecutiveControl]  
ON [dbo].[MsgRecord]  
AFTER INSERT 
AS  
	
   DECLARE @LastSec INT
   SELECT @LastSec = Sec FROM [dbo].[MsgRecord] WHERE Id = IDENT_CURRENT('[dbo].[MsgRecord]')
   --SELECT @LastSec AS Secuencia

   DECLARE @LastMsgTypeId INT
   SELECT @LastMsgTypeId = MsgTypeId FROM [dbo].[MsgRecord] WHERE Sec = @LastSec
   --SELECT @LastMsgTypeId As Tipo_Comunicacion
   
   DECLARE @CurrentSec INT
   DECLARE @SequenceName VARCHAR(50)
   IF @LastMsgTypeId = 1
   BEGIN
	SET @SequenceName ='IMsgBy1'
   END
   ELSE IF @LastMsgTypeId = 2
   BEGIN
	SET @SequenceName ='EMsgBy1'
   END

   SELECT @CurrentSec = Cast(ISNULL(seq.current_value,N'''') as INT) 
	FROM sys.sequences AS seq where seq.name = @SequenceName
   	
   IF @CurrentSec >= (SELECT Sec FROM [dbo].[ConsecutiveControl] WHERE MsgTypeId = @LastMsgTypeId)
	  BEGIN
		UPDATE [dbo].[ConsecutiveControl]
		SET [Sec] = @LastSec
		,[Date_Control] = GetDate()
		WHERE [MsgTypeId] = @LastMsgTypeId
	  END
GO

ALTER TABLE [dbo].[MsgRecord] ENABLE TRIGGER [TUpdateConsecutiveControl]
GO

