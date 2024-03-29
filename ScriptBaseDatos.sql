-- CREATE DATABASE tiendabd;
-- USE tiendabd;

CREATE TABLE Cliente (
    Id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY NOT NULL,
    Nombre VARCHAR(60) NOT NULL,
    Apellidos VARCHAR(60) NOT NULL,
    Direccion VARCHAR(150) NOT NULL
);

CREATE TABLE Tienda (
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    Sucursal VARCHAR(60) NOT NULL,
    Direccion VARCHAR(150) NOT NULL,
);

CREATE TABLE Articulo (
    Codigo UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY NOT NULL,
    Descripcion VARCHAR(1200) NOT NULL,
    Precio DECIMAL(5,2) NOT NULL,
    Imagen VARCHAR(50),
    Stock INT,  
);

CREATE TABLE ArticuloTienda (
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
    IdArticulo UNIQUEIDENTIFIER NOT NULL,
    IdTienda INT NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IdArticulo) REFERENCES Articulo (Codigo),
    FOREIGN KEY (IdTienda) REFERENCES Tienda (Id),
);

CREATE TABLE ClienteArticulo (
    Id UNIQUEIDENTIFIER PRIMARY KEY NOT NULL DEFAULT NEWID(),
    IdCliente UNIQUEIDENTIFIER NOT NULL,
    IdArticulo UNIQUEIDENTIFIER NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (IdCliente) REFERENCES Cliente (Id),
    FOREIGN KEY (IdArticulo) REFERENCES Articulo (Codigo),
);
