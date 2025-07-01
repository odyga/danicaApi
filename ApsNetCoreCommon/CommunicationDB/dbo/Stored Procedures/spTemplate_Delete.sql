CREATE PROCEDURE [dbo].[spTemplate_Delete]
	@Id int
AS
begin
	set nocount on;

	delete from [dbo].[Template]
	where [Id] = @Id;
end
