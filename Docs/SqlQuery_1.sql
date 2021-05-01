USE AerishDb
GO

DECLARE @calcID SMALLINT
DECLARE @clientID SMALLINT = 3

SELECT @calcID = CalcID FROM cd.tbl_MasterEmployee WHERE RecordStatus = 'Active' AND ClientID = @clientID
SELECT * FROM cd.tbl_MasterEmployee WHERE CalcID = @calcID AND ClientID = @clientID
SELECT ShortDesc, Amount, IsTaxable, RecordStatus FROM cd.tbl_MasterEmployeeEarning WHERE CalcID = @calcID AND ClientID = @clientID
SELECT ShortDesc, EmployeeAmount, EmployerAmount, RecordStatus FROM cd.tbl_MasterEmployeeDeduction WHERE CalcID = @calcID AND ClientID = @clientID
SELECT ShortDesc, Amount, RecordStatus FROM cd.tbl_MasterEmployeeLoan WHERE CalcID = @calcID AND ClientID = @clientID

--SELECT * FROM dbo.JobInstances
SELECT [Message], StackTrace FROM dbo.tbl_JobInstanceError WHERE ProcessInstanceID = (SELECT MAX(ProcessInstanceID) FROM dbo.tbl_JobInstance)

--SELECT * FROM cd.MasterEmployees

-- SELECT * FROM dbo.Deductions