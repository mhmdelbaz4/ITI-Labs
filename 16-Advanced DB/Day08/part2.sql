--1)Create view named   “v_clerk” that will display employee#,project#, the date of hiring of all the jobs of the type 'Clerk'.
use SD

create View V_Clerk
with encryption
as
	select E.EmpNo as employee# ,P.ProjectNo as project#, W.Enter_Date as startDate
	from HR.Employee E, Works_on W, company.Project P
	where E.EmpNo = W.EmpNo and W.ProjectNo = P.ProjectNo and W.Job='Clerk'


select * from V_Clerk
--2)	 Create view named  “v_without_budget” that will display all the projects data without budget
create view v_without_budget
with encryption 
as
	select *
	from company.Project
	where Budget = 0 or Budget is null

select * from v_without_budget

--3)	Create view named  “v_count “ that will display the project name and the # of jobs in it
create view v_count
with encryption
as
	select p.ProjectName ,count(distinct w.Job) as Jobs#
	from company.Project p,Works_on w
	where p.ProjectNo = w.ProjectNo
	group by p.ProjectName

select * from v_count
--4)	 Create view named ” v_project_p2” that will display the emp#  for the project# ‘p2’
--use the previously created view  “v_clerk”
create view v_project_p2
with encryption 
as
	select employee#
	from V_Clerk
	where project# ='p2'

select * from v_project_p2

--5)	modifey the view named  “v_without_budget”  to display all DATA in project p1 and p2 
alter view v_without_budget
with encryption 
as
	select *
	from company.Project
	where ProjectNo in ('p1','p2')

select * from v_without_budget
--6)	Delete the views  “v_ clerk” and “v_count”
drop view V_clerk, v_count

--7)	Create view that will display the emp# and emp lastname who works on dept# is ‘d2’
create view EmpV
with encryption
as
	select EmpNo ,LName
	from HR.Employee 
	where DeptNo ='d2'

select * from EmpV
--8)	Display the employee  lastname that contains letter “J”
--Use the previous view created in Q#7
select LName
from EmpV
where CHARINDEX('J' ,LName) != 0


--9)	Create view named “v_dept” that will display the department# and department name.
create view v_dept
with encryption 
as
	select DeptNo ,DeptName
	from company.Department

select * from v_dept


--10)using the previous view try enter new department data where dept# is ’d4’ and dept name is ‘Development’
insert into v_dept values('d4','Development')
-- address allow null

--11)Create view name “v_2006_check” that will display employee#, the project #where he works and the date of joining 
--the project which must be from the first of January and the last of December 2006.
create view v_2006_check
with encryption 
as
	select E.EmpNo as Employee#,P.ProjectNo as project#
	from company.Project P ,HR.Employee E ,Works_on W
	where P.ProjectNo = W.ProjectNo and E.EmpNo = W.EmpNo and year(W.Enter_Date) ='2006'

select * from v_2006_check
