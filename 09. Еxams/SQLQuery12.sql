-- 11. Creator with Boardgames
CREATE FUNCTION udf_CreatorWithBoardgames(@name NVARCHAR(30))
RETURNS INT
BEGIN
    DECLARE @creatorId INT =
	(
        SELECT Id
        FROM Creators
        WHERE FirstName = @name
    )

    RETURN
	(
        SELECT COUNT(*)
        FROM CreatorsBoardgames
        WHERE CreatorId = @creatorId
    )

END