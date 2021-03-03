CREATE DATABASE EmployeeManager;
GO

USE [EmployeeManager];
GO

CREATE SCHEMA [organization];
GO

CREATE TABLE [organization].[Employees]
(
 [Id]         int IDENTITY (1, 1) NOT NULL ,
 [Name]       nvarchar(50) NOT NULL ,
 [Surname]    nvarchar(50) NOT NULL ,
 [SecondName] nvarchar(50) NULL ,
 [HiringDate] date NOT NULL ,
 [Position]   int NOT NULL ,

 CONSTRAINT [PK_byers] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [organization].[Companies]
(
 [Id]               int IDENTITY (1, 1) NOT NULL ,
 [Name]             nvarchar(50) NOT NULL ,
 [OrganizationForm] nvarchar(50) NOT NULL ,

 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED ([Id] ASC)
);
GO

CREATE TABLE [organization].[CompanyEmployees]
(
 [Id]          int IDENTITY (1, 1) NOT NULL ,
 [EmployeeId] int NOT NULL ,
 [CompanyId] int NOT NULL ,

 CONSTRAINT [PK_selling] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_47] FOREIGN KEY ([EmployeeId])  REFERENCES [organization].[Employees]([Id]),
 CONSTRAINT [FK_60] FOREIGN KEY ([CompanyId])  REFERENCES [organization].[Companies]([Id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_48] ON [organization].[CompanyEmployees]
 (
  [EmployeeId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_61] ON [organization].[CompanyEmployees]
 (
  [CompanyId] ASC
 )

GO

INSERT INTO [organization].[Companies] (Name, OrganizationForm)
VALUES ('Basic', 'None');

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





