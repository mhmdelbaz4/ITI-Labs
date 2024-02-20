-- create deaprtment table
use SD;
create table Department (
	DeptNo varchar(2) primary key,
	DeptName varchar(50) ,
	Location varchar(2)
);

-- loc type
create rule locRule as @x in ('NY','DS','KW');
create default locDefault as 'NY';
sp_addtype  loc ,'nchar(2)';
sp_bindrule locRule,loc;
sp_bindefault LocDefault ,loc;

alter table Department
alter column Location loc;


--employee table
create table Employee(
	EmpNo int primary key,
	FName varchar(25) not null,
	LName varchar(25) not null,
	DeptNo int,
	Salary int,
	constraint fk foreign key (DeptNo) references Department(DeptNo),
	constraint uniqueSalary unique(Salary),
);


create rule min6k as @x >= 6000;
sp_bindrule min6k ,'Employee.Salary';


-- add employee EmpNo=111 in works_on
insert into Works_on(EmpNo) values(11111)

--Msg 515, Level 16, State 2, Line 37
--Cannot insert the value NULL into column 'ProjectNo', table 'SD.dbo.Works_on'; column does not allow nulls. INSERT fails.

--change employee number 10102 to 11111
update Works_on
set EmpNo = 11111

--The UPDATE statement conflicted with the FOREIGN KEY constraint "FK_Works_on_Employee".
--The conflict occurred in database "SD",table "dbo.Employee", column 'EmpNo'


-- change employee number 10102 to 22222
update Employee
set EmpNo = 22222
where EmpNo = 10102;

--Msg 547, Level 16, State 0, Line 51
--The UPDATE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee".
--The conflict occurred in database "SD", table "dbo.Works_on", column 'EmpNo'


-- delete employee 10102
delete from Employee 
where EmpNo = 10102

--Msg 547, Level 16, State 0, Line 61
--The DELETE statement conflicted with the REFERENCE constraint "FK_Works_on_Employee".
--The conflict occurred in database "SD", table "dbo.Works_on", column 'EmpNo'.


-- add telephoneNumber to employee table
ALTER TABLE Employee
ADD TelephoneNumber varchar(11);


-- drop column
alter table Employee
drop column TelephoneNumber

-- company schema
create schema company; 
alter schema company transfer Department;

-- HR Schema
create schema HR; 
alter schema HR transfer Employee;

--3.	 Write query to display the constraints for the Employee table.
sp_helpconstraint HR.Employee


-- create synonm 
create synonym Emp
for HR.Employee


select * from Employee
-- error
select * from Emp
--correct
select * from HR.Employee
--correct
select * from HR.Emp
--error

--5.	Increase the budget of the project where the manager number is 10102 by 10%.
update company.project
set budget += budget *0.1
where ProjectNo = (select ProjectNo from Works_on where EmpNo =10102 and Job= 'Manager');


--join 
update company.project 
set Budget += Budget *0.1 
from HR.Employee as E , dbo.Works_on w ,company.Project P
where E.EmpNo = w.EmpNo and w.ProjectNo = P.ProjectNo and E.EmpNo = 10102 and Job='Manager'

--6.	Change the name of the department for which the employee named James works.The new department name is Sales.
update company.Department 
set DeptName = 'Sales'
where DeptNo = (Select DeptNo from HR.Employee where FName = 'James')

--join 
update company.Department
set DeptName = 'Sales'
from company.Department D ,HR.Employee E
where D.DeptNo = E.DeptNo and E.FName='James'

--7.Change the enter date for the projects for those employees who work in project p1 and belong to department ‘Sales’. 
--The new date is 12.12.2007.
update Works_on
set Enter_Date ='12.12.2007'
where ProjectNo = 'p1' and EmpNo in (select EmpNo from HR.Employee where DeptNo = 
									(select DeptNo from company.Department where DeptName ='Sales'))

--join 
update Works_on 
set Enter_Date = '12.12.2007'
from HR.Employee E , Works_on W ,company.Department D
where E.EmpNo = W.EmpNo and E.DeptNo = D.DeptNo and w.ProjectNo = 'p1'


--8.	Delete the information in the works_on table for all employees who work for the department located in KW.
delete from Works_on
where EmpNo in (select EmpNo from HR.Employee where DeptNo = 
								(select DeptNo from company.Department where Location ='KW'))

--join
delete from Works_on
where EmpNo in (Select EmpNo from HR.Employee E join company.Department D 
				on E.DeptNo = D.DeptNo
				where D.Location ='KW')


--9.	Try to Create Login Named(ITIStud) who can access Only student and Course tablesfrom ITI DB then allow him to select and insert data into
--tables and deny Delete and update .(Use ITI DB)
use ITI
create schema newschema
alter schema newschema transfer Course
alter schema newschema transfer Student 












