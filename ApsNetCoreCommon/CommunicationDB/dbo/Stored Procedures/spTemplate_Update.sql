CREATE PROCEDURE [dbo].[spTemplate_Update]
    @Name NVARCHAR(50),
    @Subject NVARCHAR(50),
    @Body NVARCHAR(666),
    @Id int

AS
begin
    set nocount on;

    update [dbo].[Template]
    set [Name] = @Name,
        [Subject] = @Subject,
        [Body] = @Body
    where [Id] = @Id;
end