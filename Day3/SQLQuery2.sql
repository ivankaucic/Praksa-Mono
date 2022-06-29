USE master
GO
IF NOT EXISTS (
	SELECT name
	FROM sys.databases
	WHERE name = N'Book'
)

CREATE DATABASE [Book]

USE[Book]
IF OBJECT_ID('dbo.Author','U') IS NOT NULL
DROP TABLE dbo.Author
GO

CREATE TABLE dbo.Author
(
	AuthorID uniqueidentifier not null primary key,
	AuthorName [varchar](50) not null,
	Age [int] not null,
	Nationality [varchar](50)
);
GO

IF OBJECT_ID('dbo.Book','U') IS NOT NULL
DROP TABLE dbo.Book
GO

CREATE TABLE dbo.Book
(
	BookID uniqueidentifier not null primary key,
	Author uniqueidentifier not null constraint FK_Author foreign key REFERENCES dbo.Author(AuthorID),
	BookName [varchar](50) not null,
	Genre [varchar](50) not null,

);
GO

INSERT INTO dbo.Author (AuthorID,AuthorName,Age,Nationality)
VALUES
(NEWID(),'Harper Lee',45,'USA'),
(NEWID(),'Francis Scott Fitzgerald',65,'USA'),
(NEWID(),'George Orwell',75,'India');
GO

select * from dbo.Author;

INSERT INTO dbo.Book (BookID,Author,BookName,Genre)
VALUES
(NEWID(),(SELECT AuthorID FROM dbo.Author WHERE dbo.Author.AuthorName ='Harper Lee'),'To Kill A Mockingbrid','Drama'),
(NEWID(),(SELECT AuthorID FROM dbo.Author WHERE dbo.Author.AuthorName ='Francis Scott Fitzgerald'),'Great Gatzby','Drama'),
(NEWID(),(SELECT AuthorID FROM dbo.Author WHERE dbo.Author.AuthorName ='George Orwell'),'1984','Psychological'),
(NEWID(),(SELECT AuthorID FROM dbo.Author WHERE dbo.Author.AuthorName ='George Orwell'),'Animal Farm','Satire');
GO

SELECT dbo.Author.AuthorName, dbo.Book.BookName FROM dbo.Author JOIN dbo.Book ON (dbo.Author.AuthorID = dbo.Book.Author)
WHERE dbo.Author.AuthorName = 'Harper Lee';

SELECT dbo.Author.AuthorName, dbo.Book.BookName FROM dbo.Author RIGHT JOIN dbo.Book ON (dbo.Author.AuthorID = dbo.Book.Author);

SELECT dbo.Author.AuthorName, count(*) AS "Book count" FROM dbo.Author JOIN dbo.Book ON (dbo.Author.AuthorID = dbo.Book.Author)
GROUP BY dbo.Author.AuthorName HAVING count(*) > 1; 