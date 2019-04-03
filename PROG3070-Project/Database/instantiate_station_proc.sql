--Project Name  : PROG3070-Project
--Programmer    : Gabriel Stewart
--Version Date  : 2019-04-01
--Description   : Procedure to check existence of station, creating it if needed

CREATE PROCEDURE [dbo].[instantiate_station]
	@StationNumber int,	-- Desired Station Number
	@Experience nvarchar(20),	-- Worker Experience
	@DefectRate float,	-- Frequency of Defects
	@Speed float,		-- Speed of station
	@Result int OUTPUT	-- Return value
AS
BEGIN
BEGIN TRANSACTION t1
	BEGIN TRY
		-- Get matching active status for passed station number
		DECLARE @Status int
		SET @Status = (SELECT Active FROM Station WHERE Station=@StationNumber)
		-- If the station was found, but was inactie, update the number with new stations details
		IF @Status = 0
			BEGIN 
				UPDATE StationProperties
				SET Experience=@Experience,
					DefectRate=@DefectRate,
					Speed=@Speed
				WHERE StationNumber=@StationNumber
				SET @Result=1
			END;
		-- If the station was found and is active, return an error. Number cannot be used
		ELSE IF @Status = 1
			BEGIN 
				SET @Result=0
			END;
		-- If station was not found, create it by creating required values in tables
		ELSE
			BEGIN
				INSERT INTO Station VALUES (@StationNumber, 0)
				INSERT INTO StationProperties VALUES (@StationNumber, @Experience, @DefectRate, @Speed)
				INSERT INTO Stock VALUES (@StationNumber, 1, (SELECT Capacity FROM Bin WHERE Bin = 1))
				INSERT INTO Stock VALUES (@StationNumber, 2, (SELECT Capacity FROM Bin WHERE Bin = 2))
				INSERT INTO Stock VALUES (@StationNumber, 3, (SELECT Capacity FROM Bin WHERE Bin = 3))
				INSERT INTO Stock VALUES (@StationNumber, 4, (SELECT Capacity FROM Bin WHERE Bin = 4))
				INSERT INTO Stock VALUES (@StationNumber, 5, (SELECT Capacity FROM Bin WHERE Bin = 5))
				INSERT INTO Stock VALUES (@StationNumber, 6, (SELECT Capacity FROM Bin WHERE Bin = 6))
				INSERT INTO StationBin VALUES (@StationNumber, 1)
				INSERT INTO StationBin VALUES (@StationNumber, 2)
				INSERT INTO StationBin VALUES (@StationNumber, 3)
				INSERT INTO StationBin VALUES (@StationNumber, 4)
				INSERT INTO StationBin VALUES (@StationNumber, 5)
				INSERT INTO StationBin VALUES (@StationNumber, 6)
				SET @Result=1
			END
		END TRY
		-- If any errors occured during the procedure, all changes must be rolled back
		BEGIN CATCH
			ROLLBACK TRANSACTION t1
			RETURN 0
		END CATCH
COMMIT TRANSACTION t1
RETURN @Result
END
GO


