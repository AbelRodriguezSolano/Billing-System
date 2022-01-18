
CREATE DATABASE SistemaDeFacturacion

USE SistemaDeFacturacion

CREATE TABLE Productos(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(25) NOT NULL,
	Precio DECIMAL(10,2) NOT NULL CHECK(Precio>=0)
)

INSERT INTO Productos VALUES('Saco de Arroz',2000)
SELECT * FROM Productos

CREATE TABLE Proveedores(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	RncCedula VARCHAR(13) NOT NULL,
	Nombre VARCHAR(25) NOT NULL,
	Telefono VARCHAR(12) NOT NULL,
	Correo VARCHAR(30) NOT NULL
)

INSERT INTO Proveedores VALUES('402-00000-0', 'Abel Perez', '809-000-0000', 'abel@gmail.com')
SELECT * FROM Proveedores


CREATE TABLE Categorias(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(25) NOT NULL,
)

INSERT INTO Categorias VALUES('Premium')
INSERT INTO Categorias VALUES('Regular')
SELECT * FROM Categorias

CREATE TABLE Clientes(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	RncCedula VARCHAR(13) NOT NULL,
	Nombre VARCHAR(25) NOT NULL,
	Telefono VARCHAR(12) NOT NULL,
	Correo VARCHAR(30) NOT NULL,
	Categoria INT NOT NULL CONSTRAINT fk_Cliente_Categoria FOREIGN KEY(Categoria) REFERENCES Categorias(ID),
)



INSERT INTO Clientes VALUES('402-00000-0', 'Luis Perez', '809-000-1111', 'abel@gmail.com', 1)

SELECT * FROM Clientes



SELECT (SELECT Nombre FROM Categorias WHERE ID=Categoria) as Categoria, COUNT(Categoria) as 'Cantidad de Clientes' FROM Clientes GROUP BY Categoria


SELECT RncCedula,Nombre,Telefono,Correo,(CASE WHEN Categoria=1 THEN 'Premium' ELSE 'Regular' END) as Categoria FROM Clientes 

CREATE PROCEDURE VistaClientes
AS
BEGIN
	SELECT Clientes.ID,RncCedula,Clientes.Nombre,Telefono,Correo,Categorias.Nombre as Categoria FROM Clientes 
	JOIN Categorias on Categorias.ID=Clientes.Categoria
END

EXEC VistaClientes;

EXEC VistaEntradas;

EXEC VistaFacturacion;

EXEC VistaStock;

CREATE TABLE Stock(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Producto INT NOT NULL CONSTRAINT fk_Stock_Producto FOREIGN KEY(Producto) REFERENCES Productos(ID),
	Cantidad INT NOT NULL CHECK(Cantidad>=0)
)

CREATE TABLE Entradas(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Producto INT NOT NULL CONSTRAINT fk_Entradas_Producto FOREIGN KEY(Producto) REFERENCES Productos(ID),
	Proveedor INT NOT NULL CONSTRAINT fk_Entradas_Proveedor FOREIGN KEY(Proveedor) REFERENCES Proveedores(ID),
	Cantidad INT NOT NULL CHECK(Cantidad>=0),
	Fecha DATE NOT NULL DEFAULT GETDATE()
)

CREATE PROCEDURE VistaEntradas
AS
BEGIN
	SELECT E.ID,P.Nombre AS 'Producto',PR.Nombre AS 'Proveedor', Cantidad, Fecha FROM Entradas AS E 
	JOIN Productos AS P ON P.ID=E.Producto
	JOIN Proveedores AS PR ON PR.ID=E.Proveedor
END

INSERT INTO Entradas(Producto,Proveedor,Cantidad) VALUES(3,1,15)

SELECT * FROM Entradas
SELECT * FROM Stock

DELETE FROM Entradas WHERE ID<=2

CREATE PROCEDURE VistaStock
AS
BEGIN
	SELECT S.ID,P.Nombre AS 'Producto',S.Cantidad FROM Stock AS S 
	JOIN Productos AS P ON P.ID=S.Producto
END

SELECT Producto, SUM(Cantidad) as Cantidad FROM Stock group by Producto

UPDATE Stock SET Cantidad=(SELECT SUM(Cantidad) as Cantidad FROM Stock group by Producto)+5 WHERE Producto=1


--DROP TRIGGER TRG_Stock_InsUpd

CREATE TRIGGER TRG_Stock_InsUpd ON Entradas
AFTER INSERT
AS
BEGIN
	DECLARE @ID INT = NULL;
	DECLARE @Product INT = NULL;
	DECLARE @Proveedor INT = NULL;
	DECLARE @Count INT = NULL;
	DECLARE @Date DATE = NULL;

	SELECT @ID=ID,@Date=Fecha,@Count=Cantidad,@Product=Producto,@Proveedor=Proveedor FROM inserted;

	IF EXISTS(SELECT * FROM Stock WHERE Producto=@Product)
	BEGIN
		UPDATE Stock SET Cantidad=(SELECT Cantidad FROM Stock WHERE Producto=@Product)+@Count WHERE Producto=@Product
	END ELSE
	BEGIN
		INSERT INTO Stock VALUES(@Product,@Count)
	END
END

CREATE TABLE Facturacion(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Cliente INT NOT NULL CONSTRAINT fk_Facturacion_Cliente FOREIGN KEY(Cliente) REFERENCES Clientes(ID),
	Producto INT NOT NULL CONSTRAINT fk_Facturacion_Producto FOREIGN KEY(Producto) REFERENCES Productos(ID),
	Cantidad INT NOT NULL CHECK(Cantidad>=0),
	Fecha DATE NOT NULL DEFAULT GETDATE(),
	SubTotal DECIMAL(10,2) CHECK(SubTotal>=0),
	Total DECIMAL(10,2) CHECK(Total>=0)
)

SELECT * FROM Facturacion


CREATE PROCEDURE VistaFacturacion
AS
BEGIN
	SELECT F.ID,C.Nombre AS 'Cliente',  P.Nombre AS 'Producto', Cantidad, Fecha, SubTotal,Total FROM Facturacion AS F 
	JOIN Clientes AS C ON C.ID=F.Cliente
	JOIN Productos AS P ON P.ID=F.Producto
END

INSERT INTO Facturacion(Cliente,Producto,Cantidad) VALUES(2,1,5)

DELETE FROM Facturacion
DROP TRIGGER TRG_Fact_InsUpd

CREATE TRIGGER TRG_Fact_InsUpd ON Facturacion
AFTER INSERT
AS
BEGIN
	DECLARE @ID INT = NULL;
	DECLARE @Product INT = NULL;
	DECLARE @Cliente INT = NULL;
	DECLARE @Count INT = NULL;
	DECLARE @Precio DECIMAL(10,2) = NULL;
	DECLARE @SubTotal DECIMAL(10,2) = NULL;
	DECLARE @Total DECIMAL(10,2) = NULL;


	SELECT @ID=ID,@Product=Producto,@Cliente=Cliente,@Count=Cantidad FROM inserted;

	SELECT @Precio=Precio FROM Productos WHERE ID=@Product

	SELECT @Cliente=Categoria FROM Clientes WHERE ID=@Cliente;

	SET @SubTotal = @Precio*@Count

	IF @Cliente = 1
	BEGIN
		SET @SubTotal -= @SubTotal*0.05
	END

	SET @Total = @SubTotal+(@SubTotal*0.18)

	UPDATE Stock SET Cantidad=(SELECT Cantidad FROM Stock WHERE Producto=@Product)-@Count WHERE Producto=@Product

	UPDATE Facturacion SET SubTotal=@SubTotal, Total=@Total WHERE ID=@ID
END



