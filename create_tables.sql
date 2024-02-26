---------- Drop constraint if exists


alter table public.orders
drop constraint if exists orders_users_fk;
alter table public.orders
drop constraint if exists orders_status_fk;
alter table public.order_details
drop constraint if exists order_orderdetails_fk;
alter table public.order_details
drop constraint if exists order_product_fk;


--------- Delete / Create tables

drop table if exists public.products;
create table public.products(
	product_id uuid default gen_random_uuid() primary key,
	product_name varchar(512) not null,
	description text,
	price numeric (12,2),
	qtt integer
);

drop table if exists public.users;
create table public.users(
	user_id uuid default gen_random_uuid() primary key,
	user_name text,
	email varchar(512) not null,
	registration_date date
);

drop table if exists public.order_status;
create table public.order_status(
	status_id int primary key,
	name varchar(512) not null
);

drop table if exists public.orders;
create table public.orders(
	order_id uuid default gen_random_uuid() primary key,
	user_id uuid,
	order_date date,
	status_id int
);

drop table if exists public.order_details;
create table public.order_details(
	order_detail_id uuid default gen_random_uuid() primary key,
	order_id uuid,
	product_id uuid,
	qtt integer,
	total_cost numeric (12,2)
);

-------- Adding constraint

alter table public.orders
add constraint orders_status_fk
foreign key (status_id)
references public.order_status(status_id);

alter table public.orders
add constraint orders_users_fk
foreign key (user_id)
references public.users(user_id);

alter table public.order_details
add constraint order_orderdetails_fk
foreign key (order_id)
references public.orders(order_id);

alter table public.order_details
add constraint order_product_fk
foreign key (product_id)
references public.products(product_id);