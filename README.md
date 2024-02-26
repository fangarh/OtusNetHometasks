# Домашняя работа 2
    Создание виртуальной базы данных магазина в PostgreSQL
**Цель:**

В этом домашнем задании вы научитесь создавать базу данных с таблицами, а также писать скрипты с использованием основных ключевых слов.<br>
Итогом будет два файла со скриптами: один для создания всех необходимых таблиц с ключами и связями, а другой для запросов.

Спроектируйте и создайте структуру базы данных для виртуального магазина, следуя этому плану:

 **Таблица "Products" (Продукты):**

    ProductID (Основной ключ)
    ProductName (Название продукта)
    Description (Описание)
    Price (Цена)
    QuantityInStock (Количество на складе)


 **Таблица "Users" (Пользователи):**

    UserID (Основной ключ)
    UserName (Имя пользователя)
    Email (Электронная почта)
    RegistrationDate (Дата регистрации)


**Таблица "Orders" (Заказы):**

    OrderID (Основной ключ)
    UserID (Внешний ключ)
    OrderDate (Дата заказа)
    Status (Статус)


**Таблица "OrderDetails" (Детали заказа):**

    OrderDetailID (Основной ключ)
    OrderID (Внешний ключ)
    ProductID (Внешний ключ)
    Quantity (Количество)
    TotalCost (Общая стоимость)


**Установление связей:**

    Связь между "Users" и "Orders"
    Связь между "Orders" и "OrderDetails"
    Связь между "Products" и "OrderDetails"

Скрипт формирования таблиц и связей: *см.  [ветка config](https://github.com/fangarh/OTUS_PG/tree/config)*


# SQL запросы:
    Добавление нового продукта
    Обновление цены продукта
    Выбор всех заказов определенного пользователя
    Расчет общей стоимости заказа
    Подсчет количества товаров на складе
    Получение 5 самых дорогих товаров
    Список товаров с низким запасом (менее 5 штук)

