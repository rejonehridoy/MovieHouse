CREATE TABLE [User]
(
[Uid] int identity(101,1) primary key not null,
Name varchar(50) not null,
Email varchar(50) not null unique,
[Password] varchar(200) not null,
NoOfWatch int default 0,
RunTimeWatch int default 0,
)

CREATE TABLE Movies
(
Mid int identity(1001,1) primary key not null,
Name varchar(100),
Category varchar(20),
[Description] varchar(200),
PosterURL varchar(300),
PhotoURL varchar(300),
ReleaseYear varchar(5),
Runtime int,
StudioName varchar(50),
Ratings varchar(5),
NoOfReview int default 0,
NoOfView int default 0,
)

CREATE TABLE Genre
(
Gid int identity(1,1) primary key not null,
Title varchar(50) not null,
)

CREATE TABLE MovieGenre
(
Gid int not null FOREIGN KEY REFERENCES Genre(Gid),
Mid int not null FOREIGN KEY REFERENCES Movies(Mid),
)

CREATE TABLE Directors
(
Did int identity(1,1) primary key not null,
Name varchar(50),
)

CREATE TABLE MovieDirectors
(
Did int not null FOREIGN KEY REFERENCES Directors(Did),
Mid int not null FOREIGN KEY REFERENCES Movies(Mid),
)

CREATE TABLE [Cast]
(
Cid int identity(501,1) primary key not null,
Name varchar(50) not null,
Nationality varchar(20),
Gender varchar(7),
Age varchar(4),
)

CREATE TABLE MovieCast
(
Cid int not null FOREIGN KEY REFERENCES [Cast](Cid),
Mid int not null FOREIGN KEY REFERENCES Movies(Mid),
)

CREATE TABLE ViewHistory
(
Mid int not null FOREIGN KEY REFERENCES Movies(Mid),
Uid int not null FOREIGN KEY REFERENCES [User](Uid),
[Date] varchar(10),
)

CREATE TABLE Queue
(
Mid int not null FOREIGN KEY REFERENCES Movies(Mid),
Uid int not null FOREIGN KEY REFERENCES [User](Uid),
)

CREATE TABLE Review
(
Rid int identity(1,1) primary key not null,
Mid int not null FOREIGN KEY REFERENCES Movies(Mid),
Uid int not null FOREIGN KEY REFERENCES [User](Uid),
Rating varchar(10),
Message varchar(300),
ReviewDate varchar(10),
)

CREATE TABLE FriendSuggestion
(
Fid int identity(201,1) primary key not null,
Mid int not null FOREIGN KEY REFERENCES Movies(Mid),
Sender int not null FOREIGN KEY REFERENCES [User](Uid),
Receiver int not null FOREIGN KEY REFERENCES [User](Uid),
Date varchar(10),
)

CREATE TABLE UserChoice
(
Uid int not null FOREIGN KEY REFERENCES [User](Uid),
Gid int not null FOREIGN KEY REFERENCES Genre(Gid),
PriorityCount int default 0,
)