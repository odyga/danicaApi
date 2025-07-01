/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

if not exists (select * from dbo.Template)
begin
    insert into dbo.Template ([Name], [Subject], [Body])
    values ('Default Template', 'This is a default template subject.', 'This is a default template body.'),
        ('Changing policies', 'Information about our changing policies.', 'Dear PLACEHOLDER, Lorem ipsum dolor sit amet consectetur adipiscing elit.'),
        ('Final warning', 'This is a final warning.', 'Dear PLACEHOLDER, this is a final warning.');
end

if not exists (select * from dbo.Customer)
begin
    insert into dbo.Customer ([Name], [Surname], [Email])
    values ('John', 'Does', 'john@does.lt'), 
        ('Jane', 'Doesnt', 'jane@doesnt.lt');
end
