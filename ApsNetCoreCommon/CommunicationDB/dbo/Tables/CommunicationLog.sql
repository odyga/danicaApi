CREATE TABLE [dbo].[CommunicationLog]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[CustomerId] INT NOT NULL, 
	[TemplateId] INT NOT NULL, 
	[SentDate] DATETIME2 NOT NULL , 
	[Status] NVARCHAR(20) NOT NULL, 
	[MsgBody] NVARCHAR(998) NOT NULL, 
    FOREIGN KEY (CustomerId) REFERENCES Customer(Id),
	FOREIGN KEY (TemplateId) REFERENCES Template(Id)
)
