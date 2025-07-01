CREATE PROCEDURE [dbo].[spTemplate_GetById]
	@Id int
AS
Begin
	set nocount on;

	select [Id], [Name], [Subject], [Body]
	from [dbo].[Template]
	where [Id] = @Id;
End
