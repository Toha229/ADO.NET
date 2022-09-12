DROP DATABASE IF EXISTS StorageDb;
GO

CREATE DATABASE StorageDb COLLATE Cyrillic_General_100_CI_AS;
GO

USE StorageDb;

CREATE TABLE Categorys
(
    Id int PRIMARY KEY IDENTITY(1,1),
    CategoryName nvarchar(30) NOT NULL
);

GO

CREATE TABLE Manufacturers
(
    Id INT IDENTITY PRIMARY KEY,
    ManufacturerName NVARCHAR(30) NOT NULL,
	[Address] NVARCHAR(50) NOT NULL,
	Details NVARCHAR(50) NOT NULL,	--реквізити виробника
	Email  nvarchar(30) NOT NULL,
	Phone  nvarchar(30) NOT NULL CHECK(Phone LIKE '+3(0[0-9][0-9])-[0-9][0-9][0-9]-[0-9][0-9]-[0-9][0-9]')
);

GO

CREATE TABLE Products
(
    Id int PRIMARY KEY IDENTITY(1,1),
    ProductName nvarchar(30) NOT NULL,
    Price money DEFAULT 0 CHECK(Price >= 0),
    Amount int DEFAULT 0 CHECK(Amount >= 0),
  	DeliveryDt date NOT NULL DEFAULT GETDATE(), -- дата постачання
	CreatedDt date NOT NULL DEFAULT GETDATE(), -- дата виготовлення
    CategoryId int FOREIGN KEY REFERENCES Categorys(Id),
	ManufacturerId int FOREIGN KEY REFERENCES Manufacturers(Id)
);


--ALTER TABLE Products
--ADD FOREIGN KEY(CategoryId) REFERENCES Categorys(Id);
--ALTER TABLE Products
--ADD FOREIGN KEY(ManufacturerId) REFERENCES Manufacturers(Id);

INSERT INTO Categorys
VALUES  ('Baking'), ('Cereals'), ('Preserves'), ('Milk'), ('Meat'), ('Drinks'),('Computer'),('Parfum');
GO

select * from Categorys;
go

INSERT INTO Manufacturers
VALUES  ('Skyba', 'Rivne', 'r/r 0932327367234','skyba@gmail.com','+3(067)-356-45-78'), 
		('Chempion','Lviv', 'r/r 0932327367344','chempion@gmail.com','+3(067)-357-45-78'), 
		('Ferma','Kiyv', 'r/r 0978327367234','ferma@gmail.com','+3(098)-356-45-71'), 
		('Nasha Riaba','Sumy', 'r/r 0932657367234','nasha_riaba@gmail.com','+3(097)-356-48-98'), 
		('FarmCompany','Lviv', 'r/r 0932398767234','farmCompany@gmail.com','+3(067)-356-45-65'), 
		('Sandora','Dnipro', 'r/r 0932987367234','sandora@gmail.com','+3(067)-987-78-78'),
		('Chernigivske','Rivne', 'r/r 0932324467234','chernigivske@gmail.com','+3(067)-456-45-45'),
		('Company Cereals','Harkiv', 'r/r 0932326547234','company_cereals@gmail.com','+3(067)-698-45-23'),
		('Prostokvashino','Radiviliv', 'r/r 0932656547234','prostokvashino@gmail.com','+3(067)-998-45-23');
GO

select * from Manufacturers;
go



INSERT INTO Products
VALUES  ('Bread', 15.0, 23, '2022-05-07','2022-05-01', 
			(SELECT Id FROM Categorys WHERE CategoryName = 'Baking'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Skyba')),
		('Rice', 13.0, 15, '2022-07-07','2022-07-07', 
			(SELECT Id FROM Categorys WHERE CategoryName = 'Cereals'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Company Cereals')),
		('Buckwheat', 12.5, 19, '2022-06-07','2022-06-02',
			(SELECT Id FROM Categorys WHERE CategoryName = 'Cereals'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Company Cereals')),
		('Corn', 18.0, 8, '2022-07-07','2022-06-27',
			(SELECT Id FROM Categorys WHERE CategoryName = 'Preserves'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Chempion')),
		('Tuna', 27.0, 6, '2022-07-07','2022-05-26',
			(SELECT Id FROM Categorys WHERE CategoryName = 'Preserves'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Chempion')),
		('Milk', 24.5, 12, '2022-07-15','2022-07-14', 
			(SELECT Id FROM Categorys WHERE CategoryName = 'Milk'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Ferma')),
		('Kefir', 21.0, 10, '2022-07-17','2022-07-17', 
			(SELECT Id FROM Categorys WHERE CategoryName = 'Milk'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Prostokvashino')),
		('Yoghurt', 18.5, 7, '2022-07-16','2022-07-16',
			(SELECT Id FROM Categorys WHERE CategoryName = 'Milk'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Ferma')),
		('Chicken', 28.0, 12, '2022-07-16','2022-07-14',
			(SELECT Id FROM Categorys WHERE CategoryName = 'Meat'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Nasha Riaba')),
		('Beaf', 32.0, 3, '2022-07-17','2022-07-16',
			(SELECT Id FROM Categorys WHERE CategoryName = 'Meat'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Nasha Riaba')),
		('Water', 10.5, 8, '2022-07-18','2022-07-10',
			(SELECT Id FROM Categorys WHERE CategoryName = 'Drinks'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'FarmCompany')),
		('Juce', 15.0, 15, '2022-07-18','2022-06-12',
			(SELECT Id FROM Categorys WHERE CategoryName = 'Drinks'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Sandora')),
		('Beer', 19.0, 25, '2022-07-22','2022-07-20',
			(SELECT Id FROM Categorys WHERE CategoryName = 'Drinks'),
			(SELECT Id FROM Manufacturers WHERE ManufacturerName = 'Chernigivske'));
GO

select * from products;
	






SELECT CategoryName, COUNT(Products.Id) as "Product count"
FROM Products
JOIN Categorys ON CategoryId=Categorys.Id
GROUP BY CategoryName;
