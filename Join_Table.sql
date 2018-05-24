use avto;
select `Клиент_ID клиента`, ID_авто, timestamp from Заказ join Автомобиль on ID_авто = ID  order by ID_авто;