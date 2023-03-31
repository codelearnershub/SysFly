CREATE DATABASE SchoolAPP;
USE SchoolApp;
create table USER(
Id int primary key,
firstname varchar(225),
lastname varchar(225),
age int
);
insert into USER(ID, firstname, lastname, age) values(1, 'ade', 'bolu', 20);
create table TEACHER(
Id int not null,
USERId int unique,
TeacherRegNo varchar(225),
Email varchar(225) unique,
primary key(id),
foreign key(USERId) references USER(Id)
);
insert into Teacher(ID, USERId,TeacherRegNo,Email) values(1,1,'abc', 'bolu@gmail.com');