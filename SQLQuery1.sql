Select Product, Supplier, Category, Price
	FROM Product
	JOIN Supplier ON Product.SupplierID = Supplier.SupplierID
	JOIN Category ON Product.CategoryID = Category.CategoryID
WHERE Price >= 100
ORDER BY Price DESC

use Aggregate functions
SELECT	Category,
	COUNT (Product.CategoryID) AS Count,
	SUM(Price) AS Sum,
	AVG(Price) AS Average,
	MAX(Price) AS Maximum,
	MIN(Price) AS Minimum
FROM Product
Join Category ON Product.CategoryID = Category.CategoryID
GROUP BY Category
HAVING AVG(Price) >= 100
ORDER BY SUM(Price) DESC

Insert Data

INSERT INTO Product
		(
		CategoryID,
		SupplierID,
		Product,
		Description,
		Image,
		Price,
		NumberInStock,
		NumberOnOrder,
		ReorderLevel
		)

VALUES
		(
		3,
		6,



Update data
UPDATE Product
		SET Price = 349.00,
			NumberInStock = 3
		WHERE ProductID = 1086

Delete Data
DELETE FROM Product
WHERE ProductID = 1086
