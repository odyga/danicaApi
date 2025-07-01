CREATE PROCEDURE [dbo].[spTemplate_Insert]
    @Name NVARCHAR(50),
    @Subject NVARCHAR(50),
    @Body NVARCHAR(666),
    @Id int output
AS
begin
    set nocount on;
    insert into [dbo].[Template] ([Name], [Subject], [Body])
    values (@Name, @Subject, @Body);

    set @Id = SCOPE_IDENTITY();
end