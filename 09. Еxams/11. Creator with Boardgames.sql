-- 10. Creators by Rating
SELECT 
	c.LastName,
	CEILING(AVG(b.Rating)) AS AverageRaiting,
	p.[Name] AS PublisherName
FROM Creators AS c
JOIN CreatorsBoardgames AS cb ON cb.CreatorId = c.Id
JOIN Boardgames AS b ON b.Id = cb.BoardgameId
JOIN Publishers AS p ON p.Id = b.PublisherId
WHERE p.[Name] IN ('Stonemaier Games')
GROUP BY c.LastName, p.[Name]
ORDER BY AVG(b.Rating) DESC
