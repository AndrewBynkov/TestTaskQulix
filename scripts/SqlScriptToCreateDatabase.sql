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
 [EmployeesId] int NOT NULL ,
 [CompanyesId] int NOT NULL ,

 CONSTRAINT [PK_selling] PRIMARY KEY CLUSTERED ([Id] ASC),
 CONSTRAINT [FK_47] FOREIGN KEY ([EmployeesId])  REFERENCES [organization].[Employees]([Id]),
 CONSTRAINT [FK_60] FOREIGN KEY ([CompanyesId])  REFERENCES [organization].[Companies]([Id])
);
GO

CREATE NONCLUSTERED INDEX [fkIdx_48] ON [organization].[CompanyEmployees]
 (
  [EmployeesId] ASC
 )

GO

CREATE NONCLUSTERED INDEX [fkIdx_61] ON [organization].[CompanyEmployees]
 (
  [CompanyesId] ASC
 )

GO
