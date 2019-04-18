--Project Name  : PROG3070-Project
--Programmer    : Gabriel Stewart
--Version Date  : 2019-04-01
--Description   : This view simplifies the access to data required in the Overseer tool
CREATE VIEW [dbo].[stationData] 
AS
SELECT
    FirstSet.Station,
    FirstSet.Active,
    FirstSet.Produced,
    SecondSet.Passed
FROM
(
    SELECT Station, Active, COUNT(Product.TestResult) AS Produced
    FROM Station
	JOIN Product ON Product.StationNumber = Station.Station
    GROUP BY Station, Active
) AS FirstSet
INNER JOIN
(
    SELECT  StationNumber, COUNT(*) AS Passed
    FROM Product
    WHERE TestResult = 'Pass'
    GROUP BY StationNumber
) AS SecondSet
ON FirstSet.Station = SecondSet.StationNumber
GO


