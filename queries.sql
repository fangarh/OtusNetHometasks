--------------   Добавление нового продукта (так-же заполняем таблицы для следующих задач)

insert into public.products(product_name, description, price, qtt)
values ('Чайник', 'Tefal T1', 4200.3, 5), ('Чайник', 'Tefal T2', 3200.5, 2), ('Утюг', 'Tefal Г2', 5200.3, 1), ('Чайник', 'BOSH Г1', 2200.3, 9),
('Утюг', 'REDMOND T1', 4200.13, 7), ('Утюг', 'BORQ T1', 12000.3, 15);

insert into public.users(user_name, email, registration_date) 
values ('user1', 'user1@ya.ru', '1986-10-22'), ('user2', 'user2@mail.ru', '1986-02-12'), ('user2', 'user2@yahoo.ru', '1993-05-02');

insert into public.order_status(status_id, "name") 
values (1, 'оформляется'), (2, 'подтверждение'), (3, 'оплата'), (4, 'доставка'), (5, 'выполнен');

insert into public.orders(user_id, order_date, status_id) 
values ('8e03a31d-2b82-4e87-9bb8-172992dd73cc', '2024-02-20', 4), ('6f8e1870-d183-45ca-970c-be0be8495391', '2024-02-26', 1), 
('8e03a31d-2b82-4e87-9bb8-172992dd73cc', '2024-02-26', 3), ('a5eb5fbc-535e-457c-b54a-32cea360ab0a', '2023-11-10', 5), 
('a5eb5fbc-535e-457c-b54a-32cea360ab0a', '2023-10-16', 5), ('6f8e1870-d183-45ca-970c-be0be8495391', '2023-10-19', 5);

insert into public.order_details (order_id, product_id,qtt, total_cost) 
values ('2a1eca88-4530-408d-8714-b3177441ce5b', 'b2c7256b-7b7c-4cd6-8473-fb2fb3aae333', 2, 6401), 
 ('62fcfc09-9e24-4232-810a-f4e4bc6d54a5', 'a20a29d6-c15a-4b15-a14a-a1c0d2bacd80', 1, 12000.3), 
 ('70bf3351-9292-4ad1-bb20-8783644e7589', '44cea68c-a7aa-4f2e-8c1d-6fd399e7fb9c', 2, 8400.6),
 ('74e72555-f670-439f-a804-4a7bc6a963a7', '95a87c02-bfcf-4321-ba89-497494052331', 3, 6600.9), 
 ('dc4bb5db-664b-4f89-bcb8-c576784210dc', 'a20a29d6-c15a-4b15-a14a-a1c0d2bacd80', 1, 12000.3);
 
insert into public.order_details (order_id, product_id,qtt, total_cost) 
values ('2a1eca88-4530-408d-8714-b3177441ce5b', '44cea68c-a7aa-4f2e-8c1d-6fd399e7fb9c', 2, 8400.6), 
 ('62fcfc09-9e24-4232-810a-f4e4bc6d54a5', '6b2373e4-e2b1-4dbf-b04b-68668e7162ae', 1, 5200.3);

--------------   Обновление цены продукта

update public.products set price = 7500, description = 'REDMOND ET5' WHERE product_id = 'fb672a53-7911-4fec-9506-f281325a7889';

--------------   Выбор всех заказов определенного пользователя

select * from public.orders o
left join public.order_details od on o.order_id = od.order_id
inner join public.order_status os on o.status_id = os.status_id
where user_id = '8e03a31d-2b82-4e87-9bb8-172992dd73cc';

-------------- Расчет общей стоимости заказа

with order_full_price as (
	select order_id, sum(total_cost) as "total_summ", sum(qtt) as "order_total_qtt" from public.order_details 
	group by order_id
)
select * from public.orders o
left join order_full_price of on o.order_id = of.order_id
where o.order_id = '2a1eca88-4530-408d-8714-b3177441ce5b'

-------------- Подсчет количества товаров на складе

select sum(qtt) from public.products;

-------------- Получение 5 самых дорогих товаров

select * from public.products 
order by price desc
limit 5;

-------------- Список товаров с низким запасом (менее 5 штук)
select * from public.products 
where qtt < 5
order by qtt desc;



