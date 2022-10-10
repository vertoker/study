create database Povarenok;

create table Counters
(
  CounterID int primary key,
  TableCounter int not null
);

create table Addresses
(
  AddressID int primary key,
  AddressName varchar(128)
);

create table Users
(
  UserID int primary key,
  UserName varchar(100) not null,
  UserSurname varchar(100) not null,
  UserPatronymic varchar(100) not null,
  UserLogin text not null,
  UserPassword text not null,
  UserRole int not null
);

create table Products
(
  ProductID int primary key,
  ProductName text not null,
  ProductCategory int not null,
  ProductCost decimal(19,4) not null,
  ProductDiscountAmount tinyint null,
  ProductQuantityInStock int not null,
  ProductImage image
);

create table Orders
(
  OrderID int primary key,
  OrderProducts text not null,
  OrderQuantities text not null,
  OrderOrderDate datetime not null,
  OrderDeliveryDate datetime not null,
  OrderStatus int not null
);