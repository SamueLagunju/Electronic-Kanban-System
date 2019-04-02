USE [Kanban System Data]
GO

/****** Object:  StoredProcedure [dbo].[instantiate_station]    Script Date: 2019-04-02 10:05:56 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- Procedure to check existence of station, creating it if needed
CREATE PROCEDURE [dbo].[instantiate_station]
	@StationNumber int,	-- Desired Station Number
	@Experience nvarchar(17),	-- Worker Experience
	@DefectRate float,	-- Frequency of Defects
	@Speed float,		-- Speed of station
	@Result int OUTPUT	-- Return value
AS
BEGIN
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
	-- If station was not found, create it
	ELSE
		BEGIN
			INSERT INTO Station VALUES (@StationNumber, 0)
			INSERT INTO StationProperties VALUES (@StationNumber, @Experience, @DefectRate, @Speed)
			INSERT INTO Stock VALUES (@StationNumber, 1, 55)
			INSERT INTO Stock VALUES (@StationNumber, 2, 35)
			INSERT INTO Stock VALUES (@StationNumber, 3, 24)
			INSERT INTO Stock VALUES (@StationNumber, 4, 40)
			INSERT INTO Stock VALUES (@StationNumber, 5, 60)
			INSERT INTO Stock VALUES (@StationNumber, 6, 75)
			INSERT INTO StationBin VALUES (@StationNumber, 1)
			INSERT INTO StationBin VALUES (@StationNumber, 2)
			INSERT INTO StationBin VALUES (@StationNumber, 3)
			INSERT INTO StationBin VALUES (@StationNumber, 4)
			INSERT INTO StationBin VALUES (@StationNumber, 5)
			INSERT INTO StationBin VALUES (@StationNumber, 6)
		END
	END
GO


