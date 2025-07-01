CREATE PROCEDURE [dbo].[spCustomer_GetById]
	@Id int
AS
Begin
	set nocount on;

	select [Id], [Name], [Surname], [Email] 
	from [dbo].[Customer]
	where [Id] = @Id;
End
