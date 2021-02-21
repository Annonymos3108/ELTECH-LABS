CREATE TABLE [dbo].[Кабинеты] (
    [Кабинет] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Кабинет] ASC)
)
GO

CREATE TABLE [dbo].[Класс] (
    [Класс]  NVARCHAR (5)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Класс] ASC)
)
GO

CREATE TABLE [dbo].[Ученики] (
    [id_ученик]     INT           IDENTITY (1, 1) NOT NULL,
    [ФИО]           NVARCHAR (30) NOT NULL,
    [Класс]         NVARCHAR (5)  NOT NULL,
    PRIMARY KEY CLUSTERED ([id_ученик] ASC)
)
GO

CREATE TABLE [dbo].[Оценки] (
    [id_ученик]     INT           NOT NULL,
    [Предмет]       NVARCHAR (20) NOT NULL,
    [I_четверть]    INT           NOT NULL,
    [II_четверть]   INT           NOT NULL,
    [III_четверть]  INT           NOT NULL,
    [IV_четверть]   INT           NOT NULL,
    [Годовая]       INT           NOT NULL
)
GO

CREATE TABLE [dbo].[Преподаватели] (
    [id_препод]     INT           IDENTITY (1, 1) NOT NULL,
    [ФИО]           NVARCHAR (30) NOT NULL,
    [Кабинет]       INT           NULL,
    PRIMARY KEY CLUSTERED ([id_препод] ASC)
)
GO

CREATE TABLE [dbo].[Предметы] (
    [id_препод]     INT           NOT NULL,
    [Предмет]       NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([Предмет] ASC)
)
GO

CREATE TABLE [dbo].[Дни] (
    [День]       NVARCHAR (20) NOT NULL,
    PRIMARY KEY CLUSTERED ([День] ASC)
)
GO

CREATE TABLE [dbo].[Расписание] (
    [День]          NVARCHAR (20) NOT NULL,
    [Класс]         NVARCHAR (5)  NOT NULL,
    [Номер_урока]   INT           NOT NULL,
    [Предмет]       NVARCHAR (20) NOT NULL,
    [id_препод]     INT           NOT NULL,
    [Кабинет]       INT           NOT NULL,
)
GO

ALTER TABLE [dbo].[Преподаватели]  WITH CHECK ADD  CONSTRAINT [FK_Преподаватели_Кабинеты] FOREIGN KEY([Кабинет])
REFERENCES [dbo].[Кабинеты] ([Кабинет])
GO
ALTER TABLE [dbo].[Преподаватели] CHECK CONSTRAINT [FK_Преподаватели_Кабинеты]
GO

ALTER TABLE [dbo].[Расписание]  WITH CHECK ADD  CONSTRAINT [FK_Расписание_Кабинеты] FOREIGN KEY([Кабинет])
REFERENCES [dbo].[Кабинеты] ([Кабинет])
GO
ALTER TABLE [dbo].[Расписание] CHECK CONSTRAINT [FK_Расписание_Кабинеты]
GO

ALTER TABLE [dbo].[Оценки]  WITH CHECK ADD  CONSTRAINT [FK_Оценики_Предметы] FOREIGN KEY([Предмет])
REFERENCES [dbo].[Предметы] ([Предмет])
GO
ALTER TABLE [dbo].[Оценки] CHECK CONSTRAINT [FK_Оценики_Предметы]
GO

ALTER TABLE [dbo].[Оценки]  WITH CHECK ADD  CONSTRAINT [FK_Оценики_Ученики] FOREIGN KEY([id_ученик])
REFERENCES [dbo].[Ученики] ([id_ученик])
GO
ALTER TABLE [dbo].[Оценки] CHECK CONSTRAINT [FK_Оценики_Ученики]
GO

ALTER TABLE [dbo].[Расписание]  WITH CHECK ADD  CONSTRAINT [FK_Расписание_Предметы] FOREIGN KEY([Предмет])
REFERENCES [dbo].[Предметы] ([Предмет])
GO
ALTER TABLE [dbo].[Расписание] CHECK CONSTRAINT [FK_Расписание_Предметы]
GO

ALTER TABLE [dbo].[Предметы]  WITH CHECK ADD  CONSTRAINT [FK_Предметы_Преподаватели] FOREIGN KEY([id_препод])
REFERENCES [dbo].[Преподаватели] ([id_препод])
GO
ALTER TABLE [dbo].[Предметы] CHECK CONSTRAINT [FK_Предметы_Преподаватели]
GO

ALTER TABLE [dbo].[Расписание]  WITH CHECK ADD  CONSTRAINT [FK_Расписание_Преподаватели] FOREIGN KEY([id_препод])
REFERENCES [dbo].[Преподаватели] ([id_препод])
GO
ALTER TABLE [dbo].[Расписание] CHECK CONSTRAINT [FK_Расписание_Преподаватели]
GO

ALTER TABLE [dbo].[Ученики]  WITH CHECK ADD  CONSTRAINT [FK_Ученики_Класс] FOREIGN KEY([Класс])
REFERENCES [dbo].[Класс] ([Класс])
GO
ALTER TABLE [dbo].[Ученики] CHECK CONSTRAINT [FK_Ученики_Класс]
GO

ALTER TABLE [dbo].[Расписание]  WITH CHECK ADD  CONSTRAINT [FK_Расписание_Класс] FOREIGN KEY([Класс])
REFERENCES [dbo].[Класс] ([Класс])
GO
ALTER TABLE [dbo].[Расписание] CHECK CONSTRAINT [FK_Расписание_Класс]
GO

ALTER TABLE [dbo].[Расписание]  WITH CHECK ADD  CONSTRAINT [FK_Расписание_Дни] FOREIGN KEY([День])
REFERENCES [dbo].[Дни] ([День])
GO
ALTER TABLE [dbo].[Расписание] CHECK CONSTRAINT [FK_Расписание_Дни]
GO




INSERT INTO Дни (День) VALUES(N'Понедельник')
GO
INSERT INTO Дни (День) VALUES(N'Вторник')
GO
INSERT INTO Дни (День) VALUES(N'Среда')
GO
INSERT INTO Дни (День) VALUES(N'Четверг')
GO
INSERT INTO Дни (День) VALUES(N'Пятница')
GO
INSERT INTO Дни (День) VALUES(N'Суббота')
GO


INSERT INTO Кабинеты (Кабинет) VALUES(1)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(2)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(3)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(4)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(5)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(6)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(7)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(8)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(9)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(10)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(11)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(12)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(13)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(14)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(15)
GO
INSERT INTO Кабинеты (Кабинет) VALUES(16)
GO

INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Александрова Евa Васильевна', 16)
GO
INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Шилова Береслава Георгьевна', 2)
GO
INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Красильникова Лигия Мэлсовна', 3)
GO
INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Кононов Сергей Дмитриевич', 4)
GO
INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Цветков Гордей Романович', 5)
GO
INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Семёнова Марта Арсеньевна', 6)
GO
INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Колобова Наталья Тихоновна', 7)
GO
INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Шестаков Ермак Вадимович', 8)
GO
INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Суханов Борис Вениаминович', 9)
GO
INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Щукина Карина Павловна', 10)
GO
INSERT INTO Преподаватели (ФИО, Кабинет) VALUES(N'Никитина Алика Борисовна', 11)
GO
INSERT INTO Преподаватели (ФИО) VALUES(N'Куликов Ефрем Лукьевич')
GO
INSERT INTO Преподаватели (ФИО) VALUES(N'Русакова Октябрина Иринеевна')
GO
INSERT INTO Преподаватели (ФИО) VALUES(N'Харитонов Кондратий Константинович')
GO
INSERT INTO Преподаватели (ФИО) VALUES(N'Борисов Аввакум Андреевич')
GO


INSERT INTO Класс (Класс) VALUES(N'1А')
GO
INSERT INTO Класс (Класс) VALUES(N'1Б')
GO
INSERT INTO Класс (Класс) VALUES(N'2А')
GO
INSERT INTO Класс (Класс) VALUES(N'2Б')
GO
INSERT INTO Класс (Класс) VALUES(N'3')
GO
INSERT INTO Класс (Класс) VALUES(N'4')
GO
INSERT INTO Класс (Класс) VALUES(N'5')
GO
INSERT INTO Класс (Класс) VALUES(N'6')
GO
INSERT INTO Класс (Класс) VALUES(N'7')
GO
INSERT INTO Класс (Класс) VALUES(N'8А')
GO
INSERT INTO Класс (Класс) VALUES(N'8Б')
GO
INSERT INTO Класс (Класс) VALUES(N'9А')
GO
INSERT INTO Класс (Класс) VALUES(N'9Б')
GO
INSERT INTO Класс (Класс) VALUES(N'10А')
GO
INSERT INTO Класс (Класс) VALUES(N'10Б')
GO


INSERT INTO Ученики (ФИО, Класс) VALUES(N'Лаврентьев Корней Федосеевич',N'1А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Нестеров Ярослав Наумович',N'1А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Сазонов Феликс Эдуардович',N'1А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Фомин Максим Русланович',N'1А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Кошелев Ефим Мэлсович',N'1А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Савельева Сандра Авдеевна',N'1А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Данилова Серафима Артемовна',N'1А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Хохлова Таира Сергеевна',N'1А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Бобылёва Марианна Ярославовна',N'1А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Денисова Христина Евгеньевна',N'1А')
GO


INSERT INTO Ученики (ФИО, Класс) VALUES(N'Капустин Владислав Витальевич',N'1Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Громова Ирма Лукьяновна',N'1Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Сысоев Парамон Платонович',N'1Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Белоусова Вера Протасьевна',N'1Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Молчанов Мечеслав Демьянович',N'1Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Панова Эдуарда Семёновна',N'1Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Цветков Роберт Лукьевич',N'1Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Ильина Раиса Улебовна',N'1Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Брагин Флор Куприянович',N'1Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Кулакова Лариса Иринеевна',N'1Б')
GO

INSERT INTO Ученики (ФИО, Класс) VALUES(N'Ковалёв Дональд Тихонович',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Шарова Иоланта Натановна',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Елисеев Аполлон Федотович',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Александрова Руслана Альбертовна',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Шестаков Натан Лукьевич',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Никитин Савелий Борисович',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Соколова Данна Юрьевна',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Власов Терентий Дмитрьевич',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Шарапов Юлий Васильевич',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Блинова Прасковья Евгеньевна',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Данилова Альберта Рудольфовна',N'2А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Комаров Лазарь Егорович',N'2А')
GO

INSERT INTO Ученики (ФИО, Класс) VALUES(N'Суворов Николай Валерьевич',N'2Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Гусева Наоми Германновна',N'2Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Исаев Всеволод Георгиевич',N'2Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Карпова Станислава Федосеевна',N'2Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Титова Мэри Максимовна',N'2Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Сысоева Майя Лукьяновна',N'2Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Шилов Аввакуум Никитевич',N'2Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Соловьёв Дмитрий Матвеевич',N'2Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Журавлёв Евгений Семенович',N'2Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Родионова Снежана Гордеевна',N'2Б')
GO


INSERT INTO Ученики (ФИО, Класс) VALUES(N'Тетерин Станислав Константинович',N'3')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Волкова Береслава Еремеевна',N'3')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Анисимов Артем Платонович',N'3')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Третьяков Давид Артёмович',N'3')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Макаров Игорь Геннадьевич',N'3')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Харитонов Эрнест Максимович',N'3')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Маркова Амина Тимуровна',N'3')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Никифорова Аэлита Александровна',N'3')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Иванкова Селена Давидовна',N'3')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Игнатьева Габи Петровна',N'3')
GO


INSERT INTO Ученики (ФИО, Класс) VALUES(N'Шубин Авраам Матвеевич',N'4')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Игнатов Прохор Христофорович',N'4')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Чернова Изольда Степановна',N'4')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Исаева Роксана Филипповна',N'4')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Калашников Бенедикт Борисович',N'4')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Цветкова Эмилия Наумовна',N'4')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Блохин Борис Протасьевич',N'4')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Волков Мартын Яковович',N'4')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Семёнова Дебора Павловна',N'4')
GO


INSERT INTO Ученики (ФИО, Класс) VALUES(N'Носков Илья Константинович',N'5')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Беспалова Иветта Артёмовна',N'5')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Беляков Мстислав Антонинович',N'5')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Авдеев Владимир Созонович',N'5')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Маслова Любовь Федоровна',N'5')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Зайцева Диодора Анатольевна',N'5')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Зайцев Арнольд Максович',N'5')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Гурьев Ибрагил Оскарович',N'5')
GO


INSERT INTO Ученики (ФИО, Класс) VALUES(N'Кириллов Севастьян Дамирович',N'6')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Ширяев Яков Лаврентьевич',N'6')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Комиссаров Бенедикт Вениаминович',N'6')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Тимофеев Михаил Игоревич',N'6')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Жукова Илона Тарасовна',N'6')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Боброва Лали Даниловна',N'6')
GO

INSERT INTO Ученики (ФИО, Класс) VALUES(N'Борисова Аделия Степановна',N'7')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Крюкова Юзефа Аркадьевна',N'7')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Соколова Каролина Даниловнаа',N'7')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Чернова Эрика Якуновна',N'7')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Рыбакова Амина Семёновна',N'7')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Русаков Любомир Станиславович',N'7')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Веселова Инга Алексеевна',N'7')
GO

INSERT INTO Ученики (ФИО, Класс) VALUES(N'Костина Милда Антоновна',N'8А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Фадеев Родион Глебович',N'8А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Зуева Августина Тимофеевна',N'8А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Николаева Дэнна Вениаминовна',N'8А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Лихачёва Азалия Юрьевна',N'8А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Никонов Севастьян Максимович',N'8А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Харитонов Лазарь Проклович',N'8А')
GO

INSERT INTO Ученики (ФИО, Класс) VALUES(N'Лыткина Сабрина Куприяновна',N'8Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Князев Алан Михайлович',N'8Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Морозова Дарья Тарасовна',N'8Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Симонов Александр Миронович',N'8Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Лебедева Альжбета Богуславовна',N'8Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Ситников Гордий Тихонович',N'8Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Пономарёва Берта Мироновна',N'8Б')
GO


INSERT INTO Ученики (ФИО, Класс) VALUES(N'Мельников Фрол Созонович',N'9А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Куликов Вениамин Мэлсович',N'9А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Полякова Эдита Альвиановна',N'9А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Алексеева Цветана Вячеславовна',N'9А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Беляева Зарина Денисовна',N'9А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Ширяева Амелия Георгьевна',N'9А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Князев Тимофей Даниилович',N'9А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Панфилов Аверьян Павлович',N'9А')
GO

INSERT INTO Ученики (ФИО, Класс) VALUES(N'Куликова Пелагея Сергеевна',N'9Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Шилова Юнона Рубеновна',N'9Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Власова Милиса Антониновна',N'9Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Рыбакова Никки Аристарховна',N'9Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Прохоров Осип Русланович',N'9Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Панфилов Устин Николаевич',N'9Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Авдеев Вольдемар Олегович',N'9Б')
GO

INSERT INTO Ученики (ФИО, Класс) VALUES(N'Николаева Зарина Давидовна',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Беляков Ефрем Матвеевич',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Ефимова Октябрина Аркадьевна',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Некрасова Эдуарда Максовна',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Петухов Дональд Артёмович',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Фокин Май Ростиславович',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Киселёв Наум Иванович',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Кириллов Май Анатольевич',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Копылов Мирослав Егорович',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Кузьмина Аза Федоровна',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Фомина Калерия Дмитриевна',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Пахомов Корней Михайлович',N'10А')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Павлова Марианна Артёмовна',N'10А')
GO

INSERT INTO Ученики (ФИО, Класс) VALUES(N'Орехова Агнесса Геласьевна',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Гусева Илона Альвиановна',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Лобанова Любава Михайловна',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Белозёрова Властилина Данииловна',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Мамонтова Ангелина Алексеевна',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Соболева Фая Адольфовна',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Ларионова Борислава Вениаминовна',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Белоусова Доминика Эдуардовна',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Костин Степан Ярославович',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Мишин Альфред Аркадьевич',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Беляков Алан Олегович',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Богданов Ибрагил Альбертович',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Петухов Варлаам Антонович',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Авдеев Юрий Агафонович',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Тетерин Олег Владиславовича',N'10Б')
GO
INSERT INTO Ученики (ФИО, Класс) VALUES(N'Федосеев Глеб Тарасович',N'10Б')
GO



INSERT INTO Предметы (id_препод, Предмет) VALUES(1, N'Физика')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(2, N'Химия')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(3, N'Алгебра')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(4, N'География')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(5, N'История')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(6, N'Билология')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(7, N'Литература')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(8, N'Русский язык')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(9, N'Английский язык')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(10, N'Французский язык')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(11, N'Немецкий язык')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(12, N'Информатика')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(13, N'Математика')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(14, N'Обществознание')
GO
INSERT INTO Предметы (id_препод, Предмет) VALUES(15, N'Физкультура')
GO

