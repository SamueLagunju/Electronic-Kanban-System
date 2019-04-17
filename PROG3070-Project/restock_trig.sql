ALTER TRIGGER runner
ON Stock
AFTER UPDATE
AS
BEGIN
	DECLARE @Stock int
	-- Check if the stock of the updated row has reached 5
	SET @Stock = (SELECT Stock FROM inserted)
	If (@Stock <= 5)
	BEGIN
		-- Delay for five minutes
		WAITFOR DELAY '00:01'

		-- Reset stock value
		UPDATE Stock SET Stock = 60
		FROM Stock
	END
END
