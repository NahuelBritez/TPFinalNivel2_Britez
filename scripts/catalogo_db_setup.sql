USE master;
GO
IF DB_ID('CATALOGO_DB') IS NULL
    CREATE DATABASE CATALOGO_DB;
GO

USE CATALOGO_DB;
GO

IF OBJECT_ID('dbo.MARCAS', 'U') IS NULL
CREATE TABLE [dbo].[MARCAS](
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Descripcion] VARCHAR(50) NOT NULL,
 CONSTRAINT [PK_MARCAS] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO


IF OBJECT_ID('dbo.CATEGORIAS', 'U') IS NULL
CREATE TABLE [dbo].[CATEGORIAS](
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Descripcion] VARCHAR(50) NOT NULL,
 CONSTRAINT [PK_CATEGORIAS] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO


IF OBJECT_ID('dbo.ARTICULOS', 'U') IS NULL
CREATE TABLE [dbo].[ARTICULOS](
    [Id] INT IDENTITY(1,1) NOT NULL,
    [Codigo] VARCHAR(50) NOT NULL,
    [Nombre] VARCHAR(50) NOT NULL,
    [Descripcion] VARCHAR(150) NOT NULL,
    [IdMarca] INT NULL, 
    [IdCategoria] INT NULL,
    [ImagenUrl] VARCHAR(1000) NOT NULL,
    [Precio] MONEY NOT NULL,
 CONSTRAINT [PK_ARTICULOS] PRIMARY KEY CLUSTERED ([Id] ASC),
 FOREIGN KEY (IdMarca) REFERENCES MARCAS(Id),
 FOREIGN KEY (IdCategoria) REFERENCES CATEGORIAS(Id) 
);
GO


IF NOT EXISTS (SELECT 1 FROM MARCAS WHERE Descripcion = 'Samsung')
INSERT INTO MARCAS (Descripcion) VALUES 
('Samsung'), 
('Apple'), 
('Sony'), 
('Xiaomi');
GO


IF NOT EXISTS (SELECT 1 FROM CATEGORIAS WHERE Descripcion = 'Celulares')
INSERT INTO CATEGORIAS (Descripcion) VALUES 
('Celulares'),
('Televisores'), 
('Accesorios'), 
('Electrodomésticos');
GO


INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)
VALUES 
('SM01', 'Samsung Galaxy A52', 'Smartphone con pantalla de 6.5 pulgadas', 1, 1, 'https://www.samsung.com/ar/mobile-accessories/galaxy-a52--a52-5g-silicone-cover-blue-ef-pa525tlegww/', 89999),
('XM02', 'Xiaomi Mi TV 4A', 'Televisor inteligente de 32 pulgadas', 4, 2, 'https://tuxiaomi.es/wp-content/uploads/2019/08/mi-tv-32-tuxiaomi.jpg', 25000),
('AP03', 'Apple AirPods Pro', 'Auriculares inalámbricos con cancelación de ruido', 2, 3, 'https://www.apple.com/newsroom/images/product/airpods/standard/Apple-AirPods-Pro-2nd-gen-hero-220907_big.jpg.large.jpg', 19999),
('SY04', 'Sony PS5', 'Consola de videojuegos de última generación', 3, 3, 'https://arsonyb2c.vtexassets.com/arquivos/ids/362074/PlayStation-5-DualShock.jpg?v=638162215101070000', 49999);
GO

SELECT * FROM ARTICULOS;
GO
