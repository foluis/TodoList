IF((SELECT COUNT(1) FROM [dbo].[ToDos]) = 0)
BEGIN
	INSERT INTO [dbo].[ToDos] 
	SELECT 'Implement Entity Framework',GETDATE(),DATEADD(DAY,3,GETDATE()),0
END