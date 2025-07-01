# danicaApi
#Short summary

### Database "setup". 


lets test on local db, using visual studio's sql server. Select localDB (find pannel here: view > sql server object explorer).

Open: /ApsNetCoreCommon/CommunicationDB/ApsNetCoreCommon.sln
right-click project > publish.
choose button 'Load profile' > ApsNetCoreCommon\CommunicationDB\CommunicationDB.publish.xml
OR chose your db connection/name

now database should be visible on sql server explorer (might need to refresh the list)
we've uploaded stored procedures and some test data.

### API notes:

code at \Api\Api.sln
could be tested via swagger (examples are declared pretty clear on running project) or postman, or whatever tool you like.

### What to find

crud actions for customers and message/communication templates, code, stored procedures and filling some init rows.
chosen messages supposeto lay down under CommunicationLog, should be saved to its table with data (communication template, user id, full message, time sent, status-done by deafault could be other)

### what not to find AKA 
TO-Might-DO: 
saving communication log;
unit tests;
maybe auth on "sending" msgs

~rejected fun ideas:
Random mode for sending communication OR dropping tables from the db~
