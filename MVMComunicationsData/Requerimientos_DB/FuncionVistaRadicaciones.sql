USE [MVMComunicationsData]
GO
/****** Object:  UserDefinedFunction [dbo].[FNGetMsgRecords]    Script Date: 3/02/2021 21:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER FUNCTION [dbo].[FNGetMsgRecords]
(
@FECHA_INICIAL DateTime,
@FECHA_FINAL DateTime
)
RETURNS TABLE
AS
RETURN
(
	SELECT Radicacion.[Prefix] + RIGHT('00000000'+CAST(Radicacion.[Sec] AS VARCHAR(10)),8) AS Consecutivo,
	Contacts.FirsName + ' ' + Contacts.LastName AS [Gestor Documental],
	ISNULL(CONVERT(VARCHAR, [Received_Date], 20),'') AS [Fecha Recibido],
	ISNULL(CONVERT(VARCHAR, [Delivered_Date], 20), '') AS [Fecha Entregado],
	TipoComunicacion.Name AS [Tipo Comunicación],
	CASE WHEN [Digitalization] = 1 THEN 'SI' ELSE 'NO' END AS Digitalization,
	Estado.Name AS [Estado],
	(SELECT TOP 1 ContactoRemitente.FirsName + ' ' + ContactoRemitente.LastName
		FROM [dbo].[MsgContact] MensajeContacto
		INNER JOIN [dbo].[Contacts] ContactoRemitente
		ON MensajeContacto.ContactId = ContactoRemitente.Id
		WHERE MsgRecordSec = Radicacion.Sec AND MensajeContacto.ContactTypeId = 1
	) AS Remitente,
	(SELECT TOP 1 ContactoDestinatrio.FirsName + ' ' + ContactoDestinatrio.LastName
		FROM [dbo].[MsgContact] MensajeContacto
		INNER JOIN [dbo].[Contacts] ContactoDestinatrio
		ON MensajeContacto.ContactId = ContactoDestinatrio.Id
		WHERE MsgRecordSec = Radicacion.Sec AND MensajeContacto.ContactTypeId = 2
	) AS Destinatario
	FROM [dbo].[MsgRecord] Radicacion
	INNER JOIN [dbo].[Contacts] Contacts 
	ON Radicacion.DocManagerContactId = Contacts.Id
	INNER JOIN [dbo].[MsgType] TipoComunicacion
	ON Radicacion.MsgTypeId = TipoComunicacion.Id
	INNER JOIN [dbo].[MsgStatus] Estado
	ON Radicacion.MsgStatusId = Estado.Id
	WHERE [Received_Date] >= CONVERT(VARCHAR, @FECHA_INICIAL, 20) 
	AND [Received_Date] < CONVERT(VARCHAR, @FECHA_FINAL, 20)
)
