CREATE PROCEDURE [dbo].[spCustomer_Delete]
	@Id int
AS
begin
	set nocount on;

	delete from [dbo].[Customer]
	where [Id] = @Id;
end
