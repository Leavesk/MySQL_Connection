use avto;
SELECT ID_заказа, ID_авто, `Клиент_ID клиента`, марка, модель, цена, timestamp FROM Заказ JOIN Автомобиль ON ID_авто = ID WHERE ID_заказа = 2;