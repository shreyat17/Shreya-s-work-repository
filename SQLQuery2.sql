create table Employee
(
Empid int identity primary key,
First_Name varchar(50),
Last_Name varchar(50),
Age int,
Salary int,
)
insert into Employee values('Shreya','Tr','20',15000)
insert into Employee values('Navya','A','21',16000)
insert into Employee values('Manasa','G','20',17000)
insert into Employee values('Sreshta','K','20',18000)
insert into Employee values('Sudha','P','20',19000)
select * from Employee

