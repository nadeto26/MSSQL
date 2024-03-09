-- 04. Delete
CREATE TABLE TempTableWithAddresses
(
    Id INT IDENTITY PRIMARY KEY,
    AddressId INT
)

INSERT INTO TempTableWithAddresses(AddressId)
SELECT Id
FROM Addresses
WHERE Town LIKE 'L%'

DECLARE @addressToRemove INT = 
(
	SELECT
    AddressId
    FROM TempTableWithAddresses
    WHERE Id = 1
)

DELETE FROM CreatorsBoardgames
WHERE BoardgameId IN
(
	SELECT b.Id
    FROM Boardgames AS b
    LEFT JOIN Publishers AS p ON p.Id = b.PublisherId
    WHERE p.AddressId IN (@addressToRemove)
)

DELETE FROM Boardgames
WHERE PublisherId IN
(
	SELECT Id
	FROM Publishers
	WHERE AddressId IN (@addressToRemove)
)

DELETE FROM Publishers
WHERE AddressId IN (@addressToRemove)

DELETE FROM Addresses
WHERE Id IN (@addressToRemove)
