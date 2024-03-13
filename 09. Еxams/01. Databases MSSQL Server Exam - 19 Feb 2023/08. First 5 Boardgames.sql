-- 07. Creators without Boardgames
SELECT 
	c.Id,
	CONCAT(c.FirstName, ' ', c.LastName) AS CreatorName,
	c.Email
FROM Creators AS c
LEFT JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
WHERE cb.BoardgameId IS NULL