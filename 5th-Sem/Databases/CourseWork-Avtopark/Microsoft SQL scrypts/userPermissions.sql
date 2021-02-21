
USE [C:\USERS\ARTHU\SOURCE\REPOS\LOGINTEST\TESTBD.MDF]

CREATE LOGIN [Admin] 
WITH PASSWORD='admin', 
DEFAULT_DATABASE=[C:\USERS\ARTHU\SOURCE\REPOS\LOGINTEST\TESTBD.MDF], 
CHECK_EXPIRATION=OFF, 
CHECK_POLICY=OFF
GO

USE [C:\USERS\ARTHU\SOURCE\REPOS\LOGINTEST\TESTBD.MDF]
GO
CREATE USER [Admin] FOR LOGIN [Admin]
GO
USE [C:\USERS\ARTHU\SOURCE\REPOS\LOGINTEST\TESTBD.MDF]
GO
EXEC sp_addrolemember N'db_datawriter', N'Admin'
GO

USE [C:\USERS\ARTHU\SOURCE\REPOS\LOGINTEST\TESTBD.MDF]
GO
GRANT DELETE TO [Admin]
GO
USE [C:\USERS\ARTHU\SOURCE\REPOS\LOGINTEST\TESTBD.MDF]
GO
GRANT INSERT TO [Admin]
GO
USE [C:\USERS\ARTHU\SOURCE\REPOS\LOGINTEST\TESTBD.MDF]
GO
GRANT SELECT TO [Admin]
GO
USE [C:\USERS\ARTHU\SOURCE\REPOS\LOGINTEST\TESTBD.MDF]
GO
GRANT UPDATE TO [Admin]
GO




USE [C:\USERS\ARTHU\SOURCE\REPOS\LOGINTEST\TESTBD.MDF]

CREATE TABLE [dbo].[Автобусы] (
    [Автобус] NVARCHAR (6)  NOT NULL,
    [Тип]     NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Автобус] ASC) 
)
GO

CREATE TABLE [dbo].[Тип_вместимость] (
    [Тип]               NVARCHAR (20) NOT NULL,
    [Вместимость(мест)] INT           NOT NULL, 
    CONSTRAINT [PK_Тип_вместимость] PRIMARY KEY ([Тип])
)
GO


USE [C:\USERS\ARTHU\SOURCE\REPOS\LOGINTEST\TESTBD.MDF]

INSERT INTO Тип_вместимость VALUES(N'малый',40)
INSERT INTO Тип_вместимость VALUES(N'средний',65)
INSERT INTO Тип_вместимость VALUES(N'большой',110)
INSERT INTO Тип_вместимость VALUES(N'сочлененный большой',120)
INSERT INTO Тип_вместимость VALUES(N'большой двухъярусный',150)


INSERT INTO Автобусы(Автобус, Тип) VALUES(N'р258ол', N'малый')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'п528чт', N'большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'к002лл', N'большой двухъярусный')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'ф789би', N'сочлененный большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'р963де', N'большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'в111ты', N'малый')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'с125но', N'сочлененный большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'а138че', N'малый')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'ф236за', N'большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'ф253др', N'малый')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'р263гр', N'большой двухъярусный')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'р267нм', N'сочлененный большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'р268гх', N'большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'у289ьф', N'большой двухъярусный')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'р292ць', N'большой двухъярусный')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'т425ер', N'малый')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'т336юю', N'большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'т226уы', N'сочлененный большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'н658оэ', N'большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'м758уы', N'большой двухъярусный')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'н896гт', N'малый')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'н967тр', N'большой двухъярусный')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'х487гф', N'малый')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'р265оф', N'сочлененный большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'я743ор', N'большой')
INSERT INTO Автобусы(Автобус, Тип) VALUES(N'в222ро', N'сочлененный большой')