 SELECT e.EmployeeID,e.FirstName,e.ManagerID,m.FirstName as [ManagerName]
 FROM Employees AS e
 INNER JOIN Employees AS m
 ON e.ManagerID = m.EmployeeID
 Where e.ManagerID IN (3,7)
 Order by e.EmployeeID