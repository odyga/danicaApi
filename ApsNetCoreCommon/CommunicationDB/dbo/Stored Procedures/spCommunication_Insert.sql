CREATE PROCEDURE [dbo].[spCommunication_Insert]
	@CustomerId INT,
	@TemplateId INT,
	@sentDate DATETIME2,
	@MsgBody NVARCHAR(998),
	@Id INT OUTPUT
AS
begin
	set nocount on;
	insert into [dbo].[CommunicationLog] ([CustomerId], [TemplateId], [SentDate], [Status], [MsgBody])
	values (@CustomerId, @TemplateId, @sentDate, 'Sent', @MsgBody);

	set @Id = SCOPE_IDENTITY();
end
