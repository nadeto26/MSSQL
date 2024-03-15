-- 12. Search for Boardgame with Specific Category
CREATE OR ALTER PROCEDURE usp_SearchByCategory(@category VARCHAR(50))
AS
	SELECT
		b.[Name],
		b.YearPublished,
		b.Rating,
		c.[Name] AS CategoryName,
		p.[Name] AS PublisherName,
		CONCAT(pr.PlayersMin, ' ', 'people') AS MinPlayers,
		CONCAT(pr.PlayersMax, ' ', 'people') AS MaxPlayers
	FROM Boardgames AS b
	JOIN Categories AS c ON b.CategoryId = c.Id
	JOIN Publishers AS p ON b.PublisherId = P.Id
	JOIN PlayersRanges AS pr ON b.PlayersRangeId = pr.Id
	WHERE c.[Name] IN (@category)
	ORDER BY p.[Name], b.YearPublished DESC