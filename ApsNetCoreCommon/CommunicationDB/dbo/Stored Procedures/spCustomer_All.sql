CREATE PROCEDURE [dbo].[spCustomer_All]
AS
Begin
	SELECT [Id], [Name], [Surname], [Email]
	FROM [dbo].[Customer];
END