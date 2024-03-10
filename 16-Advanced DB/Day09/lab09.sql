--1.Create a stored procedure without parameters to show the number of students per department name.[use ITI DB] 
use ITI
create proc getStudsNoPerDept 
as
begin
	select D.Dept_Name , Count(S.St_Id) as StdNo
	from Student S inner join Department D
	on S.Dept_Id = D.Dept_Id
	group by D.Dept_Name
end

exec getStudsNoPerDept

--2. Create a stored procedure that will check for the # of employees in the project p1
--	if they are more than 3 print message to the user “'The number of employees in the project p1 is 3 or more'” 
--	if they are less display a message to the user “'The following employees work for the project p1'”
--	in addition to the first name and last name of each one. [Company DB] 
use Company

create proc project1Emps
as
begin
	declare @no int;
	declare @tab table(Fname varchar(25) ,LName varchar(25));

	insert into @tab
	select E.FName ,E.LName
	from Employee E ,Works_On W, Project P
	where E.SSN = W.ESSN and W.PNo =P.PNumber and P.PNumber ='1'

	select @no = Count(*) from @tab
	
	if(@no >=3)
		select 'The number of employees in the project p1 is 3 or more'
	else
		begin
		select 'The following employees work for the project p1'
		select * from @tab
		end
end

exec project1Emps

--3.	Create a stored procedure that will be used in case there is an old employee has left the project
--		and a new one become instead of him. The procedure should take 3 parameters 
--		(old Emp. number, new Emp. number and the project number) and it will be used to update works_on table. [Company DB]
alter proc replaceEMps @ESSN1 int ,@ESSN2 int ,@PNo int
as
begin
	if exists(select * from Works_On where ESSN = @ESSN1 and PNo = @PNo)
		begin
		update Works_On 
		set ESSN = @ESSN2
		where ESSN = @ESSN1 and PNo = @PNo
		end 
	else 
		select 'data is incorrect' 
end

replaceEMps 1 , 2 , 5
replaceEMps 1 , 1 , 100
replaceEMps 1 ,5 ,2
replaceEMps 1 ,5 ,1
replaceEMps 1 ,2 ,1

--4.add column budget in project table and insert any draft values in it then 
-- Create an Audit table with the following structure 
--ProjectNo 	UserName 	ModifiedDate 	Budget_Old 	Budget_New 
--p2 	Dbo 	2008-01-31	95000 	200000 
--This table will be used to audit the update trials on the Budget column (Project table, Company DB)
--Example:
--If a user updated the budget column then the project number, user name that made that update, the date of the modification 
--and the value of the old and the new budget will be inserted into the Audit table
--Note: This process will take place only if the user updated the budget column

create table auditting(
    ProjectNo VARCHAR(10),
    UserName VARCHAR(50),
    ModifiedDate DATE,
    Budget_Old int,
    Budget_New int
);

create trigger AuditBudgetUpdate on Project
after update as
	if update(budget) 
		begin
			insert into auditting (ProjectNo, UserName, ModifiedDate, Budget_Old, Budget_New)
			select d.PNumber,suser_name(),getdate(),i.Budget,d.Budget from deleted d 
			inner join inserted i on d.PNumber = i.PNumber
		end;

update Project set Budget = 500000;

--5.Create a trigger to prevent anyone from inserting a new record in the Department table [ITI DB]
--“Print a message for user to tell him that he can’t insert a new record in that table”
Use ITI

create trigger t_prevent_insert
on Department
instead of insert
as
	select 'you can not insert a new record in department table'

insert into Department(Dept_Id) values (5)



--6.	 Create a trigger that prevents the insertion Process for Employee table in March [Company DB].
use Company
create trigger prevent_insert_employee on Employee
after insert as
    if MONTH(GETDATE()) = 3
    begin
        select 'Insertion into employee table is not allowed in March.'
        rollback
    end;



--7.	Create a trigger on student table after insert to add Row in Student Audit table (Server User Name , Date, Note)
--		where note will be “[username] Insert New Row with Key=[Key Value] in table [table name]”
--Server User Name		Date 
--	Note 

-- Create Student Audit table
use ITI;

CREATE TABLE StudentAudit (
    ServerUserName VARCHAR(50),
    Date DATETIME,
    Note VARCHAR(MAX)
);
create trigger AfterInsertStudent on Student
after insert as
    declare @ServerUserName varchar(50);
    declare @Date datetime;
    declare @Note varchar(1000);
    set @ServerUserName = SUSER_SNAME();
    set @Date = GETDATE();
	declare @KeyValue int;
    select @KeyValue = St_Id from inserted;
    set @Note = @ServerUserName + 'Insert New Row with Key=' + CAST(@KeyValue as varchar(10)) + ' in table Student';
    insert into StudentAudit (ServerUserName, Date, Note)
    values (@ServerUserName, @Date, @Note);
	
insert into Student (St_Id, St_Fname, St_Lname,St_Address,St_Age,Dept_Id,St_super)
VALUES (70, 'John', 'Doe', '123 Main St', 25, 10, 5);

SELECT * FROM StudentAudit;


--8.Create a trigger on student table instead of delete to add Row in Student Audit table
--(Server User Name, Date, Note) where note will be“ try to delete Row with Key=[Key Value]”
create trigger deleteStudent on Student
instead of delete as 
	declare @ServerUserName varchar(50);
    declare @Date datetime;
    declare @Note varchar(1000);
	set @ServerUserName = SUSER_SNAME();
    set @Date = GETDATE();
	declare @KeyValue int;
    select @KeyValue = St_Id from deleted;
	set @Note = @ServerUserName + 'try to delete row with key=' + CAST(@KeyValue as varchar(10)) + ' in table Student';

delete from student where St_Id = 5;

select * from StudentAudit;

	


--9.	Display all the data from the Employee table (HumanResources Schema) 
--As an XML document “Use XML Raw”. “Use Adventure works DB” 
--A)	Elements
--B)	Attributes

use AdventureWorks2012;
select * from HumanResources.Employee 
	for xml raw('Employee'), elements,root('Employees');
select * from HumanResources.Employee 
	for xml raw('Employee'), root('Employee');

--10.	Display Each Department Name with its instructors. “Use ITI DB”
--A)	Use XML Auto
--B)	Use XML Path

use ITI;
select d.Dept_Name,i.Ins_Name from Department d inner join  Instructor i 
	on d.Dept_Id = i.Dept_Id for xml auto, elements, root('Departments')

select d.dept_name, 
	(select i.Ins_Name from Instructor i where i.Dept_Id = d.Dept_Id 
		for xml path('Instructor'),type) from Department d;



--11.	Use the following variable to create a new table “customers” inside the company DB.
-- Use OpenXML
use company;
declare @docs xml ='<customers>
              <customer FirstName="Bob" Zipcode="91126">
                     <order ID="12221">Laptop</order>
              </customer>
              <customer FirstName="Judy" Zipcode="23235">
                     <order ID="12221">Workstation</order>
              </customer>
              <customer FirstName="Howard" Zipcode="20009">
                     <order ID="3331122">Laptop</order>
              </customer>
              <customer FirstName="Mary" Zipcode="12345">
                     <order ID="555555">Server</order>
              </customer>
       </customers>'

DECLARE @doc int;
EXEC sp_xml_preparedocument @doc OUTPUT, @docs;

INSERT INTO customers (FirstName, Zipcode, OrderID, Product)
SELECT *
FROM OPENXML (@doc, '/customers/customer')
WITH (
    FirstName NVARCHAR(50) '@FirstName',
    Zipcode NVARCHAR(10) '@Zipcode',
    OrderID INT 'order/@ID',
    Product NVARCHAR(100) 'order'
);

EXEC sp_xml_removedocument @doc;
select * from customers

--Bonus :
--1.	Transform all functions in lab2 to be stored procedures
--2.	Create a trigger that prevents users from altering any table in Company DB.

