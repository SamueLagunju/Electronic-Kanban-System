CREATE TRIGGER runner
ON Stock
AFTER UPDATE
AS
BEGIN
	-- Check if the stock of the updated row has reached 5
	IF ((SELECT S.Stock FROM Stock S
		INNER JOIN inserted i
		ON i.Station = S.Station
		WHERE i.Station = S.Station) <= 5)
	BEGIN
		-- Delay for five minutes
		WAITFOR DELAY '00:05'

		-- Reset stock value
		UPDATE Stock SET Stock = (SELECT Capacity FROM Bin WHERE Bin = 1)
		FROM Stock S
		INNER JOIN inserted i
		ON i.Station = S.Station
		INNER JOIN Bin B
		ON B.Part = S.Part
	END
END
