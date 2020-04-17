use Repository
go

if exists (select * from sysobjects where name = 'GetEmpAll')
	drop proc GetEmpAll
go

create proc GetEmpAll
as
SELECT
	Employee.EmpId, 
	Employee.EmpName, 
	Employee.EmpGender, 
	Employee.EmpBirthday, 
	Employee.EmpIdNo, 
	Employee.EmpDepId, 
	Employee.EmpAddress, 
	Employee.EmpPhone, 
	Employee.EmpRole1,
	Employee.EmpRole2,
	Employee.EmpRole3,
	(select RoleName from Role where RoleId=  Employee.EmpRole1) as RoleName1, 
	(select RoleName from Role where RoleId=  Employee.EmpRole2) as RoleName2,
	(select RoleName from Role where RoleId=  Employee.EmpRole3) as RoleName3,
	Department.DepName
FROM
	dbo.Employee
	join dbo.Department on Employee.EmpDepId=Department.DepId
WHERE
	Employee.EmpId>10000
go

	exec  GetEmpAll

