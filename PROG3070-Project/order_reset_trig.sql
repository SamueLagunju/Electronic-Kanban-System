--Project Name  : PROG3070-Project
--Programmer    : Gabriel Stewart
--Version Date  : 2019-03-30
--Description   : This trigger executes when the Order value reaches 0, and deactivates all machines
CREATE TRIGGER order_reset
ON Configuration AFTER UPDATE
AS
BEGIN
	-- Update all active values in Configuration table
	IF (SELECT Value FROM Configutation WHERE Item = 'Order') = 0
	BEGIN
		UPDATE Station
		SET Active = 0
	END
END