CREATE TABLE [dbo].[Локация] (
    [id_локация] INT           IDENTITY (1, 1) NOT NULL,
    [Страна]     NVARCHAR (25) NOT NULL,
    [Город]      NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([id_локация] ASC)
)
GO

CREATE TABLE [dbo].[Ученая_степень] (
    [Степень] NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([Степень] ASC)
)
GO

CREATE TABLE [dbo].[Ученое_звание] (
    [Звание] NVARCHAR (25) NOT NULL,
    PRIMARY KEY CLUSTERED ([Звание] ASC)
)
GO

CREATE TABLE [dbo].[Авторы] (
    [id_автор]            INT           IDENTITY (1, 1) NOT NULL,
    [Фамилия]             NVARCHAR (20) NOT NULL,
    [Имя]                 NVARCHAR (20) NOT NULL,
    [Отчество]            NVARCHAR (20) NOT NULL,
    [Адрес]               NVARCHAR (50) NOT NULL,
    [Почтовой_индекс]     NVARCHAR (10) NOT NULL,
    [Рабочий_телефон]     NVARCHAR (20) NOT NULL,
    [Домашний_телефон]    NVARCHAR (20) NOT NULL,
    [e_mail]              VARCHAR (30)  NOT NULL,
    [Ученая_степень]      NVARCHAR (25) NOT NULL,
    [Ученое_звание]       NVARCHAR (25) NOT NULL,
    [Научное_направлвние] NVARCHAR (50) NOT NULL,
    [Кафедра]             NVARCHAR (30) NOT NULL,
    [Место_работы]        NVARCHAR (30) NOT NULL,
    [Должность]           NVARCHAR (50) NOT NULL,
    [id_локация]          INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id_автор] ASC),
    CONSTRAINT [FK_Авторы_Локация] FOREIGN KEY ([id_локация]) REFERENCES [dbo].[Локация] ([id_локация]),
    CONSTRAINT [FK_Авторы_Ученая_степень] FOREIGN KEY ([Ученая_степень]) REFERENCES [dbo].[Ученая_степень] ([Степень]),
    CONSTRAINT [FK_Авторы_Ученое_звание] FOREIGN KEY ([Ученое_звание]) REFERENCES [dbo].[Ученое_звание] ([Звание])
)
GO

CREATE TABLE [dbo].[Конференции] (
    [id_конференция] INT           IDENTITY (1, 1) NOT NULL,
    [Название]       NVARCHAR (50) NOT NULL,
    [Организатор]    NVARCHAR (50) NOT NULL,
    [Статус]         NVARCHAR (50) DEFAULT (N'Международная') NOT NULL,
    [Дата_начало]    DATE          NOT NULL,
    [Оргвзнос]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id_конференция] ASC)
)
GO


CREATE TABLE [dbo].[Гостиницы] (
    [id_гостиница]     INT           IDENTITY (1, 1) NOT NULL,
    [Название]         NVARCHAR (25) NOT NULL,
    [id_локация]       INT           NOT NULL,
    [Адрес]            NVARCHAR (50) NOT NULL,
    [Стоимость_номера] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([id_гостиница] ASC),
    CONSTRAINT [FK_Гостиницы_Локация] FOREIGN KEY ([id_локация]) REFERENCES [dbo].[Локация] ([id_локация])
)
GO

CREATE TABLE [dbo].[Участники] (
    [id_участник]                     INT  IDENTITY (1, 1) NOT NULL,
    [id_автор]                        INT  NULL,
    [id_конференция]                  INT  NOT NULL,
    [id_гостиница]                    INT  NULL,
    [Дата_поступления_оргвзноса]      DATE NOT NULL,
    [Размер_оргвзноса]                INT  NOT NULL,
    [Дата_поступления_заявки]         DATE NOT NULL,
    [Дата_рассылки_1_ого_приглашения] DATE NOT NULL,
    [Дата_рассылки_2_ого_приглашения] DATE NOT NULL,
    [Дата_приезда]                    DATE NOT NULL,
    [Дата_отезда]                     DATE NOT NULL,
    [Докладчик_участник]              BIT  NOT NULL,
    [Потребность_в_гостинице]         BIT  NOT NULL,
    PRIMARY KEY CLUSTERED ([id_участник] ASC),
    UNIQUE NONCLUSTERED ([id_автор] ASC, [id_конференция] ASC),
    CONSTRAINT [FK_Участники_Авторы] FOREIGN KEY ([id_автор]) REFERENCES [dbo].[Авторы] ([id_автор]),
    CONSTRAINT [FK_Участники_Конференции] FOREIGN KEY ([id_конференция]) REFERENCES [dbo].[Конференции] ([id_конференция])
)
GO

CREATE TABLE [dbo].[Доклады] (
    [id_участник]                   INT            NOT NULL,
    [Тема_доклада]                  NVARCHAR (200) NOT NULL,
    [Отметка_о_поступлении_тезисов] BIT            NOT NULL,
    [Количество_страниц]            INT            NOT NULL,
    [Соавторы]                      NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([Тема_доклада] ASC),
    CONSTRAINT [FK_Доклады_Участники] FOREIGN KEY ([id_участник]) REFERENCES [dbo].[Участники] ([id_участник])
)
GO

