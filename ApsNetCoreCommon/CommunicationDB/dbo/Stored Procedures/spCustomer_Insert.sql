CREATE PROCEDURE [dbo].[spCustomer_Insert]
    @Name NVARCHAR(50), 
    @Surname NVARCHAR(50), 
    @Email NVARCHAR(50),
    @Id int output
AS
begin
    set nocount on;
    insert into [dbo].[Customer] ([Name], [Surname], [Email])
    values (@Name, @Surname, @Email);

    set @Id = SCOPE_IDENTITY();
end