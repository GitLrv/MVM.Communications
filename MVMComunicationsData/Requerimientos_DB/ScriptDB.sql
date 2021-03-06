USE [MVMComunicationsData]
GO
/****** Object:  Table [dbo].[Contacts]    Script Date: 3/02/2021 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contacts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[FirsName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](200) NOT NULL,
	[Mobil] [nvarchar](20) NULL,
	[Status] [int] NOT NULL,
 CONSTRAINT [PK__Contacts__3214EC0756A90B32] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ContactType]    Script Date: 3/02/2021 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContactType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
 CONSTRAINT [PK__ContactT__3214EC0754B4ECDB] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgContact]    Script Date: 3/02/2021 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgContact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[MsgRecordSec] [int] NOT NULL,
	[ContactId] [int] NOT NULL,
	[ContactTypeId] [int] NOT NULL,
 CONSTRAINT [PK__MsgConta__3214EC07C98E66B8] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgRecord]    Script Date: 3/02/2021 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgRecord](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Prefix] [varchar](5) NOT NULL,
	[Sec] [int] NOT NULL,
	[DocManagerContactId] [int] NOT NULL,
	[Received_Date] [datetime] NOT NULL,
	[Delivered_Date] [datetime] NULL,
	[MsgTypeId] [int] NOT NULL,
	[Digitalization] [bit] NOT NULL,
	[MsgStatusId] [int] NOT NULL,
 CONSTRAINT [PK__MsgRecor__3214EC079E021E5A] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgStatus]    Script Date: 3/02/2021 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgStatus](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__MsgStatu__3214EC07580D6252] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MsgType]    Script Date: 3/02/2021 17:59:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MsgType](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK__MsgType__3214EC0737A6ABA2] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Contacts]  WITH CHECK ADD  CONSTRAINT [FK_Contacts_Employee1] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([Id])
GO
ALTER TABLE [dbo].[Contacts] CHECK CONSTRAINT [FK_Contacts_Employee1]
GO
ALTER TABLE [dbo].[MsgContact]  WITH CHECK ADD  CONSTRAINT [FK_MsgContact_Contacts] FOREIGN KEY([ContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[MsgContact] CHECK CONSTRAINT [FK_MsgContact_Contacts]
GO
ALTER TABLE [dbo].[MsgContact]  WITH CHECK ADD  CONSTRAINT [FK_MsgContact_ContactType] FOREIGN KEY([ContactTypeId])
REFERENCES [dbo].[ContactType] ([Id])
GO
ALTER TABLE [dbo].[MsgContact] CHECK CONSTRAINT [FK_MsgContact_ContactType]
GO
ALTER TABLE [dbo].[MsgRecord]  WITH CHECK ADD  CONSTRAINT [FK_MsgRecord_Contacts] FOREIGN KEY([DocManagerContactId])
REFERENCES [dbo].[Contacts] ([Id])
GO
ALTER TABLE [dbo].[MsgRecord] CHECK CONSTRAINT [FK_MsgRecord_Contacts]
GO
ALTER TABLE [dbo].[MsgRecord]  WITH CHECK ADD  CONSTRAINT [FK_MsgRecord_MsgStatus] FOREIGN KEY([MsgStatusId])
REFERENCES [dbo].[MsgStatus] ([Id])
GO
ALTER TABLE [dbo].[MsgRecord] CHECK CONSTRAINT [FK_MsgRecord_MsgStatus]
GO
ALTER TABLE [dbo].[MsgRecord]  WITH CHECK ADD  CONSTRAINT [FK_MsgRecord_MsgType] FOREIGN KEY([MsgTypeId])
REFERENCES [dbo].[MsgType] ([Id])
GO
ALTER TABLE [dbo].[MsgRecord] CHECK CONSTRAINT [FK_MsgRecord_MsgType]
GO
/****** Object:  StoredProcedure [dbo].[SPMVMInsertMsgRecord]    Script Date: 3/02/2021 17:59:22 ******/
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
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Communication Type' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MsgRecord', @level2type=N'COLUMN',@level2name=N'MsgTypeId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Determina si la comunicación ya fue digitalizada.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'MsgRecord', @level2type=N'COLUMN',@level2name=N'Digitalization'
GO
