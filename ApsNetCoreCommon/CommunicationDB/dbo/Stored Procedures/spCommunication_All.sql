CREATE PROCEDURE [dbo].[spCommunication_All]
	@Id INT = NULL,
	@CustomerId INT = NULL, 
	@TemplateId INT = NULL

AS
Begin
	SELECT *
	FROM [dbo].[CommunicationLog]
	WHERE (@Id IS NULL OR [Id] = @Id)
		AND (@CustomerId IS NULL OR [CustomerId] = @CustomerId)
		AND (@TemplateId IS NULL OR [TemplateId] = @TemplateId);
END
