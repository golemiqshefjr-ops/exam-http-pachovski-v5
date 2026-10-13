-- ============================================================
-- Вариант 5: Места за настаняване — база данни ExamDb, таблица dbo.Hotels
-- Изпълнете в SQL Server Management Studio или във Visual Studio
-- (View → SQL Server Object Explorer → десен клик върху сървъра → New Query).
-- Скриптът може да се пуска многократно — връща началните данни.
-- ============================================================

IF DB_ID(N'ExamDb') IS NULL
    CREATE DATABASE ExamDb;
GO

USE ExamDb;
GO

IF OBJECT_ID(N'dbo.Hotels', N'U') IS NOT NULL
    DROP TABLE dbo.Hotels;
GO

CREATE TABLE dbo.Hotels
(
    Id    INT            IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Name NVARCHAR(200)  NOT NULL,
    City NVARCHAR(100)  NOT NULL,
    Type NVARCHAR(50)   NOT NULL,
    Rooms INT            NOT NULL,
    PricePerNight DECIMAL(18, 2) NOT NULL
);
GO

-- N пред текста е задължително за кирилица (NVARCHAR)
INSERT INTO dbo.Hotels (Name, City, Type, Rooms, PricePerNight) VALUES
    (N'Хотел Черно море', N'Варна', N'Хотел', 200, 180),
    (N'Вила Роза', N'Варна', N'Къща за гости', 8, 95),
    (N'Хостел Морско', N'Варна', N'Хостел', 20, 35),
    (N'Гранд Хотел София', N'София', N'Хотел', 250, 260),
    (N'Хотел Тримонциум', N'Пловдив', N'Хотел', 150, 170),
    (N'Хотел Шипка', N'Боровец', N'Хотел', 120, 150),
    (N'Къща Бялата', N'Банско', N'Къща за гости', 10, 110),
    (N'Хостел Мостел', N'София', N'Хостел', 40, 30);
GO

SELECT * FROM dbo.Hotels;
