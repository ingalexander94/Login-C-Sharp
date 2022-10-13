create database Login
go
use Login
go
create table Users
(
	Id UNIQUEIDENTIFIER primary Key default NEWID(),
	Username nvarchar (50) unique not null,
	FullName nvarchar (50) not null,
	Email  nvarchar (100) unique not null,
	Password nvarchar (100) not null
)
go
insert into Users values (NEWID(), 'Alexander94', 'Alexander Peñaloza','alexanderpenaloza3@gmail.com','123456')
go

select *from Users