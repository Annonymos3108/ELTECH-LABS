/*Запрос на создание имени входа на сервер*/

USE [master]
GO

CREATE DATABASE [Avtopark]
GO

CREATE LOGIN [Dispetcher] 
WITH PASSWORD='dispetcher', 
DEFAULT_DATABASE=[Avtopark], 
CHECK_EXPIRATION=OFF, 
CHECK_POLICY=OFF
GO

USE [Avtopark]
GO
CREATE USER [Dispetcher] FOR LOGIN [Dispetcher]
GO
USE [Avtopark]
GO
EXEC sp_addrolemember N'db_datawriter', N'Dispetcher'
GO

/*запрос на предоставление прав этому пользователю к тем же базам*/
USE [Avtopark]
GO
GRANT DELETE TO [Dispetcher]
GO
USE [Avtopark]
GO
GRANT INSERT TO [Dispetcher]
GO
USE [Avtopark]
GO
GRANT SELECT TO [Dispetcher]
GO
USE [Avtopark]
GO
GRANT UPDATE TO [Dispetcher]
GO
