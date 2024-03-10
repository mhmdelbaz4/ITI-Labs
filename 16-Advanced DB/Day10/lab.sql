--1.	Create a cursor for Employee table that increases Employee salary by 10% if Salary <3000 and increases it by 20% 
--		if Salary >=3000. Use company DB
use Company;
declare c1 cursor 
	for select salary from Employee
	for update 
	declare @sal int
open c1 
	fetch c1 into @sal
	while @@FETCH_STATUS=0
	begin
		if @sal<3000
			update Employee	
				set salary=@sal*1.1
			where current of c1
		else if @sal>=3000
			update Employee	
				set salary=@sal*1.2
			where current of c1
		else
			delete from Employee 
			where current of c1
		fetch c1 into @sal
	end
close c1
deallocate c1 


--2.	Display Department name with its manager name using cursor. Use ITI DB
use ITI;
declare c2 cursor 
	for select d.Dept_Name,i.Ins_Name from Department d inner join Instructor i on d.Dept_Manager = i.Ins_Id 
	for read only 
	declare @dept nvarchar(50), @man nvarchar(50)
open c2
	fetch c2 into @dept, @man
	while @@FETCH_STATUS = 0
	begin
		select @dept, @man
		fetch c2 into @dept, @man
	end
close c2
deallocate c2;
--3.	Try to display all students first name in one cell separated by comma. Using Cursor 
use ITI

declare c3 cursor
for select distinct st_fname
	from Student
	where st_fname is not null
for read only

declare @name varchar(20),@all_names varchar(max)=''
open c3
fetch c3 into @name
while @@FETCH_STATUS=0
	begin
		set @all_names=CONCAT(@all_names,',',@name)
		fetch c3 into @name
	end
select @all_names
close c3
deallocate c3

--4.Create full, differential Backup for SD DB.
	---DONE
--5.Use import export wizard to display students data (ITI DB) in excel sheet
	---DONE
--6.Try to generate script from DB ITI that describes all tables and views in this DB
		-- tasks , generated scripts ,select all objects


--7.Create a sequence object that allow values from 1 to 10 without cycling in a specific column and test it.
use ITI
create sequence s1
as int
	start with 1
	increment by 1
	