--Note: Use ITI DB
--1.	 Create a view that displays student full name, course name if the student has a grade more than 50. 
alter view studentV 
with encryption
as
	select CONCAT(St_Fname, ' ',St_Lname) as fullName , C.Crs_Name as Course
	from Student S,Stud_Course SC,Course C
	where S.St_Id = SC.St_Id and SC.Crs_Id = C.Crs_Id and Grade >50


select * from studentV

--2.	 Create an Encrypted view that displays manager names and the topics they teach. 
create View ManagersTopicsV
with encryption
as
	select ISNULL(I.Ins_Name,I.Ins_Id) as MgrName ,T.Top_Name as Topic
	from Instructor I,Department D,Ins_Course IC,Course C,Topic T
	where I.Ins_Id =D.Dept_Manager and I.Ins_Id = IC.Ins_Id and IC.Crs_Id =C.Crs_Id and C.Top_Id = T.Top_Id

select * from ManagersTopicsV

--3.	Create a view that will display Instructor Name, Department Name for the ‘SD’ or ‘Java’ Department 
create View InstDeptV
with encryption
as
	select I.Ins_Name as InsName , D.Dept_Name as DeptName
	from Instructor I,Department D
	where I.Dept_Id = D.Dept_Id and D.Dept_Name in ('SD' ,'Java')

select * from InstDeptV
--4.	 Create a view “V1” that displays student data for student who lives in Alex or Cairo. 
--Note: Prevent the users to run the following query 
--Update V1 set st_address=’tanta’
--Where st_address=’alex’;

create view StudentsV
with encryption 
as
	select *
	from Student
	where St_Address in ('Alex' ,'Cairo')
with check option

select * from StudentsV

update StudentsV
set St_Address = 'Tanta'
where St_Address ='Alex'

--Msg 550, Level 16, State 1, Line 47
--The attempted insert or update failed because the target view either specifies WITH CHECK OPTION or spans 
--a view that specifies WITH CHECK OPTION and one or more rows resulting from the operation did not qualify under the CHECK OPTION constraint.

--5.Create a view that will display the project name and the number of employees work on it. “Use SD database”
use SD
create view ProjEmpsV
with encryption
as 
	select P.ProjectName as PName,Count(W.EmpNo) as EmpsCount
	from Company.Project P , Works_on W
	where P.ProjectNo = W.ProjectNo
	group by P.ProjectName

select * from ProjEmpsV

--6.Create index on column (Hiredate) that allow u to cluster the data in table Department. What will happen?
--hint
use ITI
create nonclustered index hdIndex 
on Department(Manager_hiredate)


select * from Department
where Manager_hiredate = '2000-01-01'

--7.Create index that allow u to enter unique ages in student table. What will happen? 
create unique index uniqueAge
on Student(St_Age)

--Msg 1505, Level 16, State 1, Line 78
--The CREATE UNIQUE INDEX statement terminated because a duplicate key was found for 
--the object name 'dbo.Student' and the index name 'uniqueAge'. The duplicate key value is (21).


--8.Using Merge statement between the following two tables [User ID, Transaction Amount]
create table DailyTransactions(
	userID int,
	amount int
)
insert into DailyTransactions values(1,1000),(2,2000),(3,1000)

create table LastTransactions(
	userID int,
	amount int
)
insert into LastTransactions values(1,4000),(4,2000),(2,10000)

merge into LastTransactions As T
using DailyTransactions As S
on T.userID = S.userID
when matched then 
	update 
	set T.amount = S.amount
when not matched then 
	insert (userID,amount) values(S.userID ,S.amount)
output $action;