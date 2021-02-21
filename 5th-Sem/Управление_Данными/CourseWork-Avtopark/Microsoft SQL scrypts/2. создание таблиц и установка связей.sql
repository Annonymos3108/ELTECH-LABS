USE [master]
GO

CREATE DATABASE [Avtopark]
GO


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

CREATE TABLE [dbo].[Водители] (
    [Паспорт] VARCHAR (11)  NOT NULL,
    [ФИО]     NVARCHAR (50) NOT NULL,
    [Оклад]   INT     NOT NULL,
    [Стаж]    INT           NOT NULL,
    [Класс]   NCHAR (5)     NOT NULL,
    PRIMARY KEY CLUSTERED ([Паспорт] ASC)
)
GO

CREATE TABLE [dbo].[Оклад] (
    [Класс] NCHAR (5) NOT NULL,
    [Оклад] NCHAR (6) NOT NULL,
    PRIMARY KEY CLUSTERED ([Класс] ASC)
)
GO

CREATE TABLE [dbo].[Водят] (
    [id_Водителя] INT           IDENTITY (1, 1) NOT NULL,
    [Паспорт]     VARCHAR (11)  NOT NULL,
    [Автобус]     NVARCHAR (6)  NOT NULL,
    [ФИО]         NVARCHAR (50) NOT NULL,
    [Маршрут]     INT           NOT NULL,
    [Дата]        DATE          NOT NULL,
    PRIMARY KEY CLUSTERED ([id_Водителя] ASC)
)
GO

CREATE TABLE [dbo].[Маршруты] (
    [Маршрут]                  INT           NOT NULL,
    [Начальный_пункт]          NVARCHAR (25) NOT NULL,
    [Конечный_пункт]           NVARCHAR (25) NOT NULL,
    [Время_начала_движения]    TIME (7)      NOT NULL,
    [Время_окончания_движения] TIME (7)      NOT NULL,
    [Интервал(мин)]            INT           NOT NULL,
    [Протяженность(мин)]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Маршрут] ASC)
)
GO

CREATE TABLE [dbo].[Списанные_автобусы] (
    [Автобус] NVARCHAR (6)  NOT NULL,
    [Тип]     NVARCHAR (20) NOT NULL,
    [Дата]    DATE          NOT NULL,   
    PRIMARY KEY CLUSTERED ([Автобус] ASC) 
)
GO

ALTER TABLE [dbo].[Водят]  WITH CHECK ADD  CONSTRAINT [FK_Водят_Автобусы] FOREIGN KEY([Автобус])
REFERENCES [dbo].[Автобусы] ([Автобус])
GO
ALTER TABLE [dbo].[Водят] CHECK CONSTRAINT [FK_Водят_Автобусы]
GO
ALTER TABLE [dbo].[Водят]  WITH CHECK ADD  CONSTRAINT [FK_Водят_Водители] FOREIGN KEY([Паспорт])
REFERENCES [dbo].[Водители] ([Паспорт])
GO
ALTER TABLE [dbo].[Водят] CHECK CONSTRAINT [FK_Водят_Водители]
GO
ALTER TABLE [dbo].[Водят]  WITH CHECK ADD  CONSTRAINT [FK_Водят_Маршруты] FOREIGN KEY([Маршрут])
REFERENCES [dbo].[Маршруты] ([Маршрут])
GO
ALTER TABLE [dbo].[Водят] CHECK CONSTRAINT [FK_Водят_Маршруты]
GO
ALTER TABLE [dbo].[Водители]  WITH CHECK ADD  CONSTRAINT [FK_Водители_Оклад] FOREIGN KEY([Класс])
REFERENCES [dbo].[Оклад] ([Класс])
GO
ALTER TABLE [dbo].[Водители] CHECK CONSTRAINT [FK_Водители_Оклад]
GO
ALTER TABLE [dbo].[Автобусы]  WITH CHECK ADD  CONSTRAINT [FK_Автобусы_Тип_вместимость] FOREIGN KEY([Тип])
REFERENCES [dbo].[Тип_вместимость] ([Тип])
GO
ALTER TABLE [dbo].[Автобусы] CHECK CONSTRAINT [FK_Автобусы_Тип_вместимость]
GO