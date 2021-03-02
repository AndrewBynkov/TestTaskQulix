USE [EmployeeManager];
GO

-- Employee

Create procedure spGetAllEmployee
as
Begin
    select *
    from [organization].[Employees]
    order by Id
End
GO

Create procedure spAddEmployee
(
    @Name VARCHAR(50),
    @Surname VARCHAR(50),
    @SecondName VARCHAR(30),
    @HiringDate date,
    @Position INT
)
as
Begin
    Insert into [organization].[Employees] (Name, Surname, SecondName, HiringDate,Position)
    Values (@Name,@Surname,@SecondName, @HiringDate,@Position)
End
GO

Create procedure spUpdateEmployee
(
    @Id INT ,
    @Name VARCHAR(50),
    @Surname VARCHAR(50),
    @SecondName VARCHAR(30),
    @HiringDate date,
    @Position INT
)
as
begin
   Update [organization].[Employees]
   set Name=@Name,
   Surname=@Surname,
   SecondName=@SecondName,
   HiringDate=@HiringDate,
   Position=@Position
   where Id=@Id
End
GO


Create procedure spDeleteEmployee
(
    @Id int
)
as
begin
    Delete from [organization].[Employees] where Id=@Id
End
GO

-- Company

