create database Povarenok;

create table Roles
(
  RoleID int primary key,
  RoleName varchar(100) not null
);
create table Buyers
(
  UserID int primary key,
  UserSurname varchar(100) not null,
  UserName varchar(100) not null,
  UserPatronymic varchar(100) not null,
  UserLogin text not null,
  UserPassword text not null,
  UserRole int not null,
  foreign key (UserRole) references Roles(RoleID) 
);
create table Products
(
  ProductArticleNumber nvarchar(100) primary key,
  ProductName text not null,
  ProductDescription text not null,
  ProductCategory text not null,
  ProductPhoto int not null,
  ProductManufacturer text not null,
  ProductCost decimal(19,4) not null,
  ProductDiscountAmount tinyint null,
  ProductQuantityInStock int not null,
  ProductStatus text not null
);
create table Orders
(
  OrderID int primary key,
  OrderStatus text not null,
  OrderDeliveryDate datetime not null,
  OrderPickupPoint text not null
);
create table OrdersProducts
(
  OrderID int not null,
  ProductArticleNumber nvarchar(100)  not null,
  Primary key (OrderID,ProductArticleNumber),
  foreign key (OrderID) references Orders(OrderID),
  foreign key (ProductArticleNumber) references Product(ProductArticleNumber)
);