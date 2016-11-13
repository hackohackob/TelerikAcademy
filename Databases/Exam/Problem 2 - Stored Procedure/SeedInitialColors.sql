USE PetStore;
GO
CREATE PROCEDURE uspAddColorsIfNone 
AS 
	if (SELECT COUNT(*) from Colors) = 0
	BEGIN
		 INSERT INTO Colors(Color)
		 VALUES ('black'),
			('white'),
			('red'),
			('mixed')
	END
GO
EXECUTE uspAddColorsIfNone;
GO