--1.Create a scalar function that takes date and returns Month name of that date.

create function getMonthName(@date date)
returns varchar(15)
begin
	return datename(MM, @date)
end

select dbo.getMonthName(getdate());

--2.Create a multi-statements table-valued function that takes 2 integers and returns the values between them.
create function getNumbers(@n1 int ,@n2 int)
returns @tab table(numbers int)
as
begin
	while @n1 < @n2
	begin
		set @n1 +=1;
		insert into @tab values (@n1);
	end
return
end

select * from getNumbers(10,20)
select * from getNumbers(10,10)
select * from getNumbers(20,10)


--3.Create inline function that takes Student No and returns Department Name with Student full name.
alter function getNameAndDept(@stdNo int)
returns table
as
return(
	select CONCAT(s.St_Fname,' ', S.St_Lname) as StdName, D.Dept_Name as DeptName 
							from newSchema.Student S inner join Department D
							on S.Dept_Id = D.Dept_Id
							where S.St_Id = @stdNo
)

select * from getNameAndDept(1);
select * from getNameAndDept(2);

-- 4.	Create a scalar function that takes Student ID and returns a message to user 
--	If first name and Last name are null then display 'First name & last name are null'
--b.	If First name is null then display 'first name is null'
--c.	If Last name is null then display 'last name is null'
--d.	Else display 'First name & last name are not null'
alter function getFullName(@StdID int)
returns varchar(50)
begin
	declare @fname varchar(50)
	declare @lname varchar(50)
	declare @result varchar(50)
	
	select @fname = St_Fname ,@lname =St_Lname
	from newSchema.Student
	where St_Id = @StdID
	
	if @fname is null and @lname is null
		set @result = 'First name & last name are null'
	else if @fname is null
		set @result = 'First name is null'
	else if @lname is null
		set @result = 'Last name is null'
	else 
		set @result = 'First name & last name are  not null'
	return @result
end

select dbo.getFullName(1)
select dbo.getFullName(2)
select dbo.getFullName(3)



--5.	Create inline function that takes integer which represents manager ID and displays department name,
--		Manager Name and hiring date 
create function getMangerInfo(@MgrID int)
returns table
as
return(
	select D.Dept_Name ,I.Ins_Name as MgrName ,D.Manager_hiredate
	from Instructor I inner join Department D
				on I.Ins_Id = D.Dept_Manager
	where D.Dept_Manager = @MgrID
)

select * from getMangerInfo(1)
select * from getMangerInfo(5)

--6.Create multi-statements table-valued function that takes a string
-- If string='first name' returns student first name
-- If string='last name' returns student last name 
-- If string='full name' returns Full Name from student table 
-- Note: Use “ISNULL” function
alter function getStdName(@partName varchar(20))
returns @tab table (StdName varchar(50))
as
begin
	if(@partName = 'first name')
		insert into @tab
		select isnull(St_Fname,St_Lname) from newSchema.Student
	if(@partName = 'last name')
		insert into @tab
		select ISNULL(St_Lname,St_Fname) from newSchema.Student
	else if (@partName = 'full name')
		insert into @tab
		select concat(St_Fname,' ',St_Lname) from newSchema.Student
	return
end

select * from getStdName('first name')
select * from getStdName('last name')
select * from getStdName('full name')
select * from getStdName('')


--7.Write a query that returns the Student No and Student first name without the last char
select St_Id ,SUBSTRING(St_Fname,1,len(St_Fname)-1)
from  newSchema.Student

--8.Write query to delete all grades for the students Located in SD Department 


-- delete s,sc 
-- from  newSchema.Student s,Stud_Course sc ,Department D
--where s.St_Id = sc.St_Id and s.Dept_Id = D.Dept_Id and D.Dept_Location ='SD'

delete from Stud_Course where Stud_Course.St_Id in(
	select s.St_Id from newSchema.Student s inner join Department D
	on s.Dept_Id = D.Dept_Id
	where D.Dept_Name ='SD'
)