﻿SELECT Локация.Город, Доклады.Тема_доклада 
FROM Доклады INNER JOIN 
					(Участники INNER JOIN 
						(Авторы INNER JOIN Локация ON Авторы.id_локация = Локация.id_локация)
					ON Участники.id_автор = Авторы.id_автор)
			 ON Участники.id_участник = Доклады.id_участник
WHERE (Локация.Город = N'Санкт-Петербург' AND Участники.id_конференция = 4)  
