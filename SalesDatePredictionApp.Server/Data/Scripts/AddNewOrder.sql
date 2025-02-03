CREATE PROCEDURE AddNewOrder
	@CustomerId INT,
    @Empid INT,
    @Shipperid INT,
    @Shipname NVARCHAR(100),
    @Shipaddress NVARCHAR(255),
    @Shipcity NVARCHAR(100),
    @Orderdate DATETIME,
    @Requireddate DATETIME,
    @Shippeddate DATETIME,
    @Freight DECIMAL(18,2),
    @Shipcountry NVARCHAR(100),
    @Productid INT,
    @Unitprice DECIMAL(18,2),
    @Qty INT,
    @Discount DECIMAL(5,2)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @Orderid INT;

    INSERT INTO Sales.Orders(Custid, Empid, Shipperid, Shipname, Shipaddress, Shipcity, Orderdate, Requireddate, Shippeddate, Freight, Shipcountry)
	VALUES (@CustomerId, @Empid, @Shipperid, @Shipname, @Shipaddress, @Shipcity, @Orderdate, @Requireddate, @Shippeddate, @Freight, @Shipcountry);

    SET @Orderid = SCOPE_IDENTITY();

    INSERT INTO Sales.OrderDetails(Orderid, Productid, Unitprice, Qty, Discount)
    VALUES (@Orderid, @Productid, @Unitprice, @Qty, @Discount);
END;
