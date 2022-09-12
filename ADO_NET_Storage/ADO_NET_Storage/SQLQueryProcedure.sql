USE StorageDb;
GO

CREATE PROCEDURE [dbo].[countProductByManufacturer]
	@manufacturerName NVARCHAR(30),
	@countProduct int OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	SELECT @countProduct=COUNT(P.Id)
	FROM Products as P, Manufacturers as M
	WHERE P.ManufacturerId=M.Id AND M.ManufacturerName=@manufacturerName;
END;