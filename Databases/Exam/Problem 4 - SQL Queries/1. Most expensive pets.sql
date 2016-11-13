USE PetStore

SELECT TOP 5 p.Price, p.Breed, YEAR(p.BirthDateTime) AS 'Birth Year'
FROM Pets p
WHERE YEAR(p.BirthDateTime) >= 2012
ORDER BY p.Price DESC