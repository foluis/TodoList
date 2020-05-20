IF((SELECT COUNT(1) FROM [dbo].[Todos]) = 0)
BEGIN
	INSERT INTO [dbo].[Todos] 
	SELECT 'Implement Entity Framework',GETDATE(),DATEADD(DAY,3,GETDATE()),0
END