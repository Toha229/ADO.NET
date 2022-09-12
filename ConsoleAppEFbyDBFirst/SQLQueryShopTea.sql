--CREATE DATABASE ShopTea;
--GO;
use ShopTea;
GO;

CREATE TABLE TypesTea(
    Id INT PRIMARY KEY NOT NULL IDENTITY,
    TypeTea NVARCHAR(20) NOT NULL CHECK(TypeTea<>N''),
    DescriptionInfo NVARCHAR(MAX) NOT NULL DEFAULT 'Info...'
)
GO;

INSERT INTO TypesTea VALUES (N'black',default),(N'yellow',default);
GO;

CREATE TABLE Country(
    Id INT PRIMARY KEY NOT NULL IDENTITY,
    NameCountry NVARCHAR(20) NOT NULL CHECK(NameCountry<>N'')
)
GO;

INSERT INTO Country VALUES (N'Brazil'),(N'Argentina'),('Ukraine');
GO;

CREATE TABLE Tea
(
    Id INT PRIMARY KEY NOT NULL IDENTITY,
    NameSort NVARCHAR(20) NOT NULL CHECK(NameSort<>N''),
    CountryId INT NOT NULL FOREIGN KEY REFERENCES Country(Id) ,
    TypeTeaId INT NOT NULL FOREIGN KEY REFERENCES TypesTea(Id),
    DescriptionInfo NVARCHAR(MAX) NOT NULL,
    NumberGrams DECIMAL(6,2) NOT NULL,
    Price MONEY NOT NULL
  );
GO;

INSERT INTO Tea VALUES
(N'Три слони',1,1,N'Представляє 75 % всесвітньої продукції та надає маленькі, плоскі та подовжені плоди мідно-зеленого кольору.',200,149.99),
(N'Тисяча і одна ніч',2,2,N'Велике крупне листя, зібране в заповілній зоні.',150,139.99);