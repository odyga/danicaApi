CREATE PROCEDURE [dbo].[spTemplate_All]
AS
Begin
	SELECT [Id], [Name], [Subject], [Body]
	FROM [dbo].[Template]
END
