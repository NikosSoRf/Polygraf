use Polygraf
go

Insert into Client values('Никита','Щеглов','8461646138');
Insert into Client values('Роман','Егоров','5164853548');
Insert into Client values('Александр','Петров','61568651332');
Insert into Client values('Анна','Комарова','153548513');

Insert into Contract values(1,'2023-01-07','2023-10-07');
Insert into Contract values(2,'2023-07-07','2023-14-07');
Insert into Contract values(3,'2023-13-08','2023-21-08');
Insert into Contract values(4,'2023-09-09','2023-14-09');

insert into Position values('Менеджер');
insert into Position values('Работник склада');
insert into Position values('Технолог');
insert into Position values('Бухгалтер');

insert into Employer values('Менеджер','Валерия','Муравьева','jknyjhiosn','bkfgnbjkxfgik@mail.ru');
insert into Employer values('Менеджер','Павел','Швецов','awefkjotjhop','hfbgkbxfkgnfkk@mail.ru');
insert into Employer values('Технолог','Анастасия','Фокина','aweio;fjofu','cfgncfghfcgh@mail.ru');
insert into Employer values('Технолог','Дарина','Панина','awefkjhibugt','xfghxfghfhgr@mail.ru');
insert into Employer values('Технолог','Никита','Терентьев','eakulbgjhbul','hgxfxghfghgv@mail.ru');
insert into Employer values('Работник склада','Дмитрий','Панкратов','hbfkjhxlirjrg','ghiftjgojhg@mail.ru');

insert into HistoryOfContract values(1,'2023-01-07','На подписании');
insert into HistoryOfContract values(1,'2023-02-07','Тест-печать');
insert into HistoryOfContract values(1,'2023-04-07','Проверка');
insert into HistoryOfContract values(2,'2023-07-07','На подписании');
insert into HistoryOfContract values(2,'2023-10-07','Тест-печать');
insert into HistoryOfContract values(2,'2023-12-07','Проверка');

insert into TechnicalCard values(1,'Какой-то','Кружка');
insert into TechnicalCard values(2,'Какой-то','Кружка');
insert into TechnicalCard values(3,'Какой-то','Книга');
insert into TechnicalCard values(3,'Какой-то','Буклеты');
insert into TechnicalCard values(4,'Какой-то','Бумага');

insert into Materials values('Бумага офсет',100);
insert into Materials values('Бумага картон',150);
insert into Materials values('Бумага мел',100);
insert into Materials values('Бумага постерная',50);

insert into Содержит values(3,1);
insert into Содержит values(4,4);
insert into Содержит values(5,1);

insert into Редактирует values(1,3);
insert into Редактирует values(2,3);
insert into Редактирует values(3,4);
insert into Редактирует values(4,4);
insert into Редактирует values(5,5);

insert into Оформляет values(1,1);
insert into Оформляет values(2,2);
insert into Оформляет values(3,1);
insert into Оформляет values(4,2);
