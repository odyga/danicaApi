CREATE PROCEDURE [dbo].[spCustomer_Update]
    @Name NVARCHAR(50), 
    @Surname NVARCHAR(50), 
    @Email NVARCHAR(50),
    @Id int 
AS
begin
    set nocount on;

    update [dbo].[Customer] 
    set [Name] = @Name, 
        [Surname] = @Surname, 
        [Email] = @Email
    where [Id] = @Id;
end