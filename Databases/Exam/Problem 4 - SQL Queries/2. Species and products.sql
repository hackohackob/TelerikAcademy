USE PetStore

SELECT s.Name,COUNT(p.Id) AS 'Total Number Of Products'
FROM Species s
	INNER JOIN ProductSpecies ps ON s.Id = ps.SpeciesId
	INNER JOIN Products p ON p.Id = ps.ProductId
GROUP BY s.Name
ORDER BY COUNT(p.ID) 