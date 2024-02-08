CREATE DATABASE G5Inventory;
GO
USE G5Inventory;
GO

CREATE TABLE Category(
    IdCategory INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    CategoryName NVARCHAR(50) NOT NULL,
	CategoryInfo NVARCHAR(50),
	CategoryCode NVARCHAR(5),
	CategoryStatus NVARCHAR(15)
);
GO

CREATE TABLE Providers(
    IdProvider INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
    ProviderName NVARCHAR(75) NOT NULL,
    Phone NVARCHAR(25) NOT NULL,
    Email NVARCHAR(80) NOT NULL,
	Delivery NVARCHAR(5) NOT NULL
);
GO

CREATE TABLE Products(
	IdProduct INT NOT NULL PRIMARY KEY IDENTITY(1, 1),
	ProductName NVARCHAR(75) NOT NULL,
	Price MONEY NOT NULL,
	IdCategory INT NOT NULL,
	IdProvider INT NOT NULL,
	Expiration DATE NOT NULL,
	Stock INT NOT NULL
);
GO