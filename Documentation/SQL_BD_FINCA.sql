/*
DROP TABLE dbo.[User];
DROP TABLE dbo.[UserWork];
DROP TABLE dbo.[Kind];
DROP TABLE dbo.[Medicine];
DROP TABLE dbo.[Farm];
*/

USE [master]
GO
CREATE DATABASE exdibo; 
GO
USE [exdibo]
GO

DROP TABLE [User];

	-- 1)
CREATE TABLE [User](  
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	Code INT UNIQUE NOT NULL,
	DNI VARCHAR(30) UNIQUE NOT NULL,
	[Name] VARCHAR (50) NOT NULL, 
	FirstName VARCHAR (50) NOT NULL,
	LastName VARCHAR (50) NOT NULL, 
	Email VARCHAR (100) UNIQUE NOT NULL,
	[Password] VARCHAR (50) NOT NULL, 
	Birth DATE NOT NULL,
	Gender VARCHAR (9) NOT NULL, 
	Job VARCHAR (50) NOT NULL,
	Mobile VARCHAR (20) NOT NULL, 
	Phone VARCHAR (20) NOT NULL, 
	[Role] VARCHAR (20) NOT NULL, 
	Token VARCHAR (50) NOT NULL, 
	RegisterDate DATETIME NOT NULL, 
	[Status] BIT NOT NULL
	);


	-- 2)
CREATE TABLE [Farm] (
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	Code VARCHAR (20) NOT NULL,
    [Name] VARCHAR (50) NOT NULL,
    Email VARCHAR (60) NOT NULL,
    [Address]VARCHAR (200) NOT NULL,
	Register DATETIME NOT NULL, 
	[Status] BIT NOT NULL   
	);


	-- 3) -- Emplaye of Farm X
CREATE TABLE UserWork (
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	IdUser INT NOT NULL,
	IdFarm INT NOT NULL,
	CONSTRAINT FK_UserWork_UserId FOREIGN KEY (IdUser) REFERENCES [User](Id),
	CONSTRAINT FK_UserWork_FarmId FOREIGN KEY (IdFarm) REFERENCES [Farm](Id)
	); 


	-- 4)
CREATE TABLE [Kind] (
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	[Name] VARCHAR (50) NOT NULL,
	[Status] BIT NOT NULL
	);

CREATE TABLE Enfermedad (
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Enfermedad] VARCHAR (99) NOT NULL,
	[Status] BIT DEFAULT 1);

	-- 5)
CREATE TABLE Breed (
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	[Name] VARCHAR (50) NOT NULL,
	Purpose VARCHAR (50) NOT NULL,
	Genetics VARCHAR (10) NOT NULL,
	[Status] BIT NOT NULL
	);  -- Race


	-- 6)
CREATE TABLE [Group] (
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	IdFarm INT NOT NULL,
	Number INT NOT NULL,
	[Name] VARCHAR (50) NOT NULL,
	[Status] BIT NOT NULL
	);


	-- 7)
CREATE TABLE Medicine (
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	[Name] VARCHAR (50) NOT NULL,
	IdKind INT NOT NULL,
    [Apply] VARCHAR (50) NOT NULL, ---Administracion: Subcutanea, Intravenosa, Intramuscular ....
	Via VARCHAR (50) NOT NULL,  ---Uso/Via: Oral, Injectable, Tópico ,Externo, ....      
	Dose VARCHAR (60) NOT NULL, --- ML / CC 
    Often INT NOT NULL, --- Cada / Horas
    Times INT NOT NULL, --- Veces
    Withdrawal INT NOT NULL, ---Days 
    Contraindication VARCHAR(200) NOT NULL,
    Note VARCHAR(200) NOT NULL,  
	Register DATETIME NOT NULL, 
	[Status] BIT NOT NULL,
	CONSTRAINT FK_Kind_ FOREIGN KEY (IdKind) REFERENCES [Kind](Id)
	);


	-- 8)
CREATE TABLE Bovine(
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	Number INT NOT NULL, 
	Earring	VARCHAR(10) NOT NULL,
	IdMother INT NOT NULL,
	IdFather INT NOT NULL,
	IdBreed INT NOT NULL,
	IdFarm INT NOT NULL,
	IdGroup INT NOT NULL,
	Brand VARCHAR(12) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	Gender VARCHAR(12) NOT NULL,
	Born DATETIME NOT NULL,
	ProductionMilk INT NOT NULL,
	Birth INT NOT NULL,
	Pregnant BIT NOT NULL,
	Ovulation DATETIME NOT NULL,
	OvulationTimes INT NOT NULL,
	StartWeight FLOAT NOT NULL, 
	[Weight] FLOAT NOT NULL, 
	FinalWeight FLOAT NOT NULL,
	AdmissionDate DATETIME NOT NULL,
	DischargeDate DATETIME NOT NULL,
	Price FLOAT NOT NULL,
	Notes VARCHAR(150) NOT NULL,
    Discards BIT NOT NULL,
	[Status] BIT NOT NULL,
	CONSTRAINT FK_Breed_Bovine FOREIGN KEY (IdBreed) REFERENCES [Breed](Id),
	CONSTRAINT FK_Farm_Bovine FOREIGN KEY (IdFarm) REFERENCES [Farm](Id),
	CONSTRAINT FK_Group_Bovine FOREIGN KEY (IdGroup) REFERENCES [Group](Id)
	);

	-- 9)
CREATE TABLE MedicineRecord (
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	IdUser INT NOT NULL,
	IdMedicine INT NOT NULL,
	IdBovine INT NOT NULL,
	IdFarm INT NOT NULL,
	IdGroup INT NOT NULL,
	IdKind INT NOT NULL,
	Ilness VARCHAR(99) NOT NULL, 
	Symptom VARCHAR(300) NULL,
	Register DATETIME NOT NULL, 
	Notes VARCHAR(400),
	[Status] BIT NOT NULL,
	CONSTRAINT FK_Medicine_MedicineRecord FOREIGN KEY (IdMedicine) REFERENCES [Medicine](Id),
	CONSTRAINT FK_Bovine_MedicineRecord FOREIGN KEY (IdBovine) REFERENCES [Bovine](Id),
	CONSTRAINT FK_Farm_MedicineRecord FOREIGN KEY (IdFarm) REFERENCES [Farm](Id),
	CONSTRAINT FK_Group_MedicineRecord FOREIGN KEY (IdGroup) REFERENCES [Group](Id),
	CONSTRAINT FK_Kind_MedicineRecord FOREIGN KEY (IdKind) REFERENCES [Kind](Id),
	CONSTRAINT FK_User_MedicineRecord FOREIGN KEY (IdUser) REFERENCES [User](Id)
	);  


	-- 10)
CREATE TABLE Ovulation (
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	IdMother INT NOT NULL,
	IdFather INT NOT NULL,
	IdBreed INT NOT NULL,
	IdFarm INT NOT NULL,
	IdGroup INT NOT NULL, 
	Register DATETIME NOT NULL, 
	[Status] BIT NOT NULL,
	CONSTRAINT FK_Mother_Ovulation FOREIGN KEY (IdMother) REFERENCES Bovine(Id),
	CONSTRAINT FK_Father_Ovulation FOREIGN KEY (IdFather) REFERENCES Bovine(Id),
	CONSTRAINT FK_Breed_Ovulation FOREIGN KEY (IdBreed) REFERENCES [Breed](Id),
	CONSTRAINT FK_Farm_Ovulation FOREIGN KEY (IdFarm) REFERENCES [Farm](Id),
	CONSTRAINT FK_Group_Ovulation FOREIGN KEY (IdGroup) REFERENCES [Group](Id),
	);


	-- 11)
CREATE TABLE [Production] (
	Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
	[Name] VARCHAR (50) NOT NULL,
	IdBovine INT NOT NULL, 
	IdFarm INT NOT NULL,
	IdGroup INT NOT NULL, 
	[Output] FLOAT NOT NULL, 
	Register DATETIME NOT NULL, 
	[Status] BIT NOT NULL,
	CONSTRAINT FK_Bovine_Production FOREIGN KEY (IdBovine) REFERENCES [Bovine](Id),
	CONSTRAINT FK_Farm_Production FOREIGN KEY (IdFarm) REFERENCES [Farm](Id),
	CONSTRAINT FK_Group_Production FOREIGN KEY (IdGroup) REFERENCES [Group](Id)
	);




CREATE PROCEDURE sp_userlist
AS
BEGIN
	SELECT * FROM [exdibo].[dbo].[User]
END


CREATE PROCEDURE sp_validateuser(
	@Email VARCHAR(100), @Password VARCHAR(50))
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[User] WHERE (([Email] = @Email) AND ([Password] = @Password))
END


CREATE PROCEDURE sp_insert_user(
	@Code int, @DNI varchar(30), @Name varchar(50), @FirstName varchar(50), @LastName varchar(40), @Email varchar(60), 
	@Password varchar(30), @Birth DATE, @Gender varchar(9), @Job varchar(50), @Mobile varchar(20), @Phone varchar(20),
    @Role varchar(20), @Token varchar(50), @RegisterDate datetime, @Status bit)
AS BEGIN
	INSERT INTO [User]
		([Code], [DNI], [Name], [FirstName], [LastName], [Email], [Password], [Birth],[Gender], [Job], [Mobile], [Phone], [Role], [Token], [RegisterDate], [Status])
     VALUES
        (@Code, @DNI, @Name, @FirstName, @LastName, @Email, @Password, @Birth, @Gender, @Job, @Mobile, @Phone, @Role, @Token, @RegisterDate, @Status)
END



CREATE PROCEDURE sp_update_user
	(
	@Id int, @Code int, @DNI varchar(30), @Name varchar(50), @FirstName varchar(50), @LastName varchar(40), @Email varchar(60), 
	@Password varchar(30), @Birth DATE, @Gender varchar(9), @Job varchar(50), @Mobile varchar(20), @Phone varchar(20), @Role varchar(20), 
	@Token varchar(50), @RegisterDate datetime, @Status bit
	)
AS BEGIN
UPDATE [dbo].[User]
   SET [Code] = @Code ,[DNI] = @DNI ,[Name] = @Name, [FirstName] = @FirstName, [LastName] = @LastName, [Email] = @Email ,[Password] = @Password 
   , [Birth] = @Birth, [Gender] = @Gender ,[Job] = @Job ,[Mobile] = @Mobile,[Phone] = @Phone ,[Role] = @Role ,[Token] = @Token,[RegisterDate] = @RegisterDate,[Status] = @Status
 WHERE Id = @Id
END


CREATE PROCEDURE sp_user_by_id
	(@Id INT)
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[User] WHERE [Id] = @Id; 
END



CREATE PROCEDURE sp_change_status_user
	(@Id int, @Status bit)
AS BEGIN
UPDATE [dbo].[User]
   SET [Status] = @Status
 WHERE Id = @Id
END

--------------------------------------------------

CREATE PROCEDURE sp_breed_list
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[Breed] WHERE [Status] = 1; 
END

CREATE PROCEDURE sp_farm_list
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[Farm] WHERE [Status] = 1; 
END


CREATE PROCEDURE sp_group_list
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[Group] WHERE [Status] = 1; 
END

------- Numero Sugerido

CREATE PROCEDURE sp_suggested_number
AS BEGIN
SELECT MAX(Number) AS Number FROM [exdibo].[dbo].[Bovine];
END

-------  INSERT COWS  ------

CREATE PROCEDURE sp_insert_bovine (
	@Number INT, @Earring VARCHAR(50), @IdMother INT, @IdFather INT, @IdBreed INT, @IdFarm INT, @IdGroup INT, @Brand VARCHAR(12), @Name VARCHAR(50), @Gender VARCHAR(12), @Pregnant BIT, @Born DATETIME, @ProductionMilk INT, 
	@Birth INT, @Ovulation DATETIME, @OvulationTimes INT, @StartWeight FLOAT, @Weight FLOAT, @FinalWeight FLOAT, @AdmissionDate DATETIME, @DischargeDate DATETIME, @Price FLOAT, @Notes VARCHAR(150), @Discards BIT, @Status BIT)
AS BEGIN
	INSERT INTO [Bovine]
           ([Number], [Earring],[IdMother], [IdFather], [IdBreed], [IdFarm], [IdGroup], [Brand], [Name], [Gender], [Pregnant],[Born], [ProductionMilk], [Birth],
		   [Ovulation], [OvulationTimes], [StartWeight], [Weight], [FinalWeight], [AdmissionDate], [DischargeDate], [Price], [Notes], [Discards], [Status])
     VALUES
           (@Number, @Earring, @IdMother, @IdFather, @IdBreed, @IdFarm, @IdGroup, @Brand, @Name, @Gender,
			@Pregnant, @Born, @ProductionMilk, @Birth, @Ovulation, @OvulationTimes, @StartWeight, @Weight, 
			@FinalWeight, @AdmissionDate, @DischargeDate, @Price, @Notes, @Discards, @Status)
END

------	UPDATE COWS

CREATE PROCEDURE sp_update_bovine (
	@Id INT, @Number INT, @Earring VARCHAR(50), @IdMother INT, @IdFather INT, @IdBreed INT, @IdFarm INT, @IdGroup INT, @Brand VARCHAR(12), @Name VARCHAR(50), @Gender VARCHAR(12), @Pregnant BIT, @Born DATETIME, @ProductionMilk INT, 
	@Birth INT, @Ovulation DATETIME, @OvulationTimes INT, @StartWeight FLOAT, @Weight FLOAT, @FinalWeight FLOAT, @AdmissionDate DATETIME, @DischargeDate DATETIME, @Price FLOAT, @Notes VARCHAR(150), @Discards BIT, @Status BIT)
AS BEGIN
	UPDATE [exdibo].[dbo].[Bovine] SET
           [Number] = @Number, [Earring] = @Earring,[IdMother] = @IdMother, [IdFather] = @IdFather, [IdBreed] = @IdBreed, [IdFarm] = @IdFarm, [IdGroup] = @IdGroup,
		   [Brand] = @Brand, [Name] = @Name, [Gender] = @Gender, [Pregnant] = @Pregnant,[Born] = @Born, [ProductionMilk] = @ProductionMilk, [Birth] = @Birth,
		   [Ovulation] = @Ovulation, [OvulationTimes] = @OvulationTimes, [StartWeight] = @StartWeight, [Weight] = @Weight, [FinalWeight]  = @FinalWeight,
		   [AdmissionDate] = @AdmissionDate, [DischargeDate] = @DischargeDate, [Price] = @Price, [Notes] = @Notes, [Discards] = @Discards, [Status] = @Status
     WHERE Id = @Id 
END

------ SEARCH BOVINE BY NAME OR EARRING

CREATE PROCEDURE sp_search_bovine_by_earring_or_name
(@Clave TEXT)
AS BEGIN
SELECT * FROM [Bovine] AS b WHERE ((b.Name LIKE CONCAT('%', @Clave, '%') OR b.Earring LIKE CONCAT('%', @Clave, '%'))); 
END


EXEC sp_search_bovine_by_earring_or_name @Clave='Mi'; 

------ Reporte Producciones al Azar

----SELECT * FROM [exdibo].[dbo].[Production] WHERE @Desde <= Register AND Register <= @Hasta;

CREATE PROCEDURE sp_report_production
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
SELECT pr.Id, pr.Name AS Codigo, pr.Output AS Production, pr.Register, pr.Status, pr.IdBovine, bo.Number, bo.Earring, bo.Name, bo.pregnant 
FROM (
SELECT p.Id, p.Name, p.Output, p.Register, p.Status, p.IdBovine
FROM [exdibo].[dbo].[Production] AS p
WHERE @Desde <= p.Register AND p.Register <= @Hasta) AS pr
INNER JOIN [exdibo].[dbo].[Bovine] AS bo
ON pr.IdBovine = bo.Id
END

------ Reporte Produccion Promedio

CREATE PROCEDURE sp_report_production_average
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
SELECT COUNT(Id) AS Cows, SUM(Output) AS Production, AVG(DISTINCT [Output]) AS Average, MIN(Register) AS [From] , MAX(Register) AS [To]
FROM [Production]
WHERE @Desde <= Register AND Register <= @Hasta;
END


---- PRODUCTION BY ID PRODUCTION

CREATE PROCEDURE sp_production_by_id
(@IdProduction INT)
AS BEGIN
SELECT pr.Id, pr.Name AS Codigo, pr.Output AS Production, pr.Register, pr.Status, pr.IdBovine, bo.Number, bo.Earring, bo.Name, bo.pregnant 
FROM (
SELECT p.Id, p.Name, p.Output, p.Register, p.Status, p.IdBovine
FROM [exdibo].[dbo].[Production] AS p
WHERE @IdProduction = p.Id) AS pr
INNER JOIN [exdibo].[dbo].[Bovine] AS bo
ON pr.IdBovine = bo.Id
END



------- STATUS COWS

CREATE PROCEDURE sp_status_bovine (
	@Id INT, @Status BIT)
AS BEGIN
	UPDATE [exdibo].[dbo].[Bovine] SET [Status] = @Status WHERE Id = @Id 
END

------- STATUS PRODUCTION

CREATE PROCEDURE sp_status_production (@Id INT, @Status BIT)
AS BEGIN
	UPDATE [exdibo].[dbo].[Production] SET [Status] = @Status WHERE Id = @Id 
END

------- UPDATE PRODUCTION

CREATE PROCEDURE sp_update_production
(@Id INT, @Name TEXT, @IdBovine INT, @Output INT, @Register DATETIME, @Status BIT)
AS BEGIN
	UPDATE [exdibo].[dbo].[Production] 
	SET [Name] = @Name, [IdBovine] = @IdBovine, [Output] = @Output, 
	[Register] = @Register,[Status] = @Status 
	WHERE Id = @Id 
END

-----	INSERT OVULATION  -------

CREATE PROCEDURE sp_insert_ovulation (@IdMother INT, @IdFather INT, @IdBreed INT, @IdFarm INT, @IdGroup INT, @Register DATETIME, @Status BIT)
AS BEGIN
	INSERT INTO [Ovulation] ([IdMother], [IdFather], [IdBreed], [IdFarm], [IdGroup], [Register], [Status])
	VALUES (@IdMother, @IdFather, @IdBreed, @IdFarm, @IdGroup, @Register, @Status)
END

-----	INSERT PRODUCTION  -------

CREATE PROCEDURE sp_insert_production (@Name VARCHAR(50), @IdBovine INT, @IdFarm INT, @IdGroup INT, @Output FLOAT,	@Register DATETIME, @Status BIT)
AS BEGIN
	INSERT INTO [Production]([Name], [IdBovine], [IdFarm], [IdGroup], [Output],	[Register], [Status]) 
	VALUES (@Name, @IdBovine, @IdFarm, @IdGroup, @Output,	@Register, @Status)
END

-------   UPDATE PRODUCTION   ---------

CREATE PROCEDURE sp_update_bovine_production (@Production INT, @IdBovine INT)
AS BEGIN
	UPDATE [dbo].[Bovine] SET [Bovine].[ProductionMilk] = @Production WHERE [Bovine].[Id] = @IdBovine;
END
---------  REGISTER MEDICINE   --------

CREATE PROCEDURE sp_insert_medicine (@Name VARCHAR(50), @IdKind INT, @Apply VARCHAR(50), @Via VARCHAR(50), @Dose VARCHAR(50), @Often INT, @Times INT, @Withdrawal INT, @Contraindication VARCHAR(200), @Note VARCHAR(200), @Register DATETIME, @Status BIT)
AS BEGIN
	INSERT INTO [dbo].[Medicine] ([Name], [IdKind], [Apply], [Via], [Dose], [Often], [Times], [Withdrawal], [Contraindication], [Note], [Register], [Status])
     VALUES (@Name, @IdKind, @Apply, @Via, @Dose, @Often, @Times, @Withdrawal, @Contraindication, @Note, @Register, @Status)
END

--------   UPDATE MEDICINE   --------

CREATE PROCEDURE sp_update_medicine (@Id INT, @Name VARCHAR(50), @IdKind INT, @Apply VARCHAR(50), @Via VARCHAR(50), @Dose VARCHAR(50), @Often INT, @Times INT, @Withdrawal INT, @Contraindication VARCHAR(200), @Note VARCHAR(200), @Register DATETIME, @Status BIT)
AS BEGIN UPDATE [dbo].[Medicine]
   SET [Name] = @Name, [IdKind] = @IdKind, [Apply] = @Apply , [Via] = @Via , [Dose] = @Dose, [Often] = @Often,
   [Times] = @Times,[Withdrawal] = @Withdrawal ,[Contraindication] = @Contraindication,[Note] = @Note, 
   [Register] = @Register, [Status] = @Status 
 WHERE [dbo].[Medicine].[Id] = @Id
END

---------   DELETE MEDICINE   ---------

CREATE PROCEDURE sp_status_medicine (@Id INT, @Status BIT)
AS BEGIN UPDATE [dbo].[Medicine]
   SET [Status] = @Status 
 WHERE [dbo].[Medicine].[Id] = @Id
END

------   KIND LIST ------------

CREATE PROCEDURE sp_kind_list
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[Kind] WHERE [Status] = 1 ORDER BY [Name];
END

  -------	MEDICINE LIST   -----------

CREATE PROCEDURE sp_medicine_list
AS BEGIN
SELECT me.*, kd.Name AS Kind FROM(
	SELECT * FROM [exdibo].[dbo].[Medicine]) AS me
	INNER JOIN [exdibo].[dbo].[Kind] AS kd
	ON me.IdKind = kd.Id
END

  -------	ACTIVE MEDICINE LIST   -----------

CREATE PROCEDURE sp_medicine_active_list
AS BEGIN
SELECT me.*, kd.Name AS Kind FROM(
	SELECT * FROM [exdibo].[dbo].[Medicine] WHERE [Status] = 1) AS me
	INNER JOIN [exdibo].[dbo].[Kind] AS kd
	ON me.IdKind = kd.Id
END

----   LIST OF RECORDS   ----

CREATE PROCEDURE sp_records_list
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[MedicineRecord] WHERE [Status] = 1;
END

----   MEDICINE BY ID   ----

CREATE PROCEDURE sp_medicine_by_id
(@Id INT)
AS BEGIN
SELECT me.*, kd.Name AS Kind FROM
	(SELECT * FROM [exdibo].[dbo].[Medicine] WHERE [Id] = @Id) AS me
	INNER JOIN [exdibo].[dbo].[Kind] AS kd
	ON me.IdKind = kd.Id
END

----   LIST OF THE BOVINES  ----

CREATE PROCEDURE sp_bovine_list
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[Bovine] AS b WHERE b.[Status] = 1 ORDER BY b.[Number];
END

------ UPDATE NUMBER OF BIRTHS  -------------

CREATE PROCEDURE sp_update_bovine_births
(@IdAnimal INT)
AS BEGIN 
UPDATE [exdibo].[dbo].[Bovine] 
SET Birth = ((SELECT Birth FROM [Bovine] WHERE Id = @IdAnimal) +1) 
WHERE Id = @IdAnimal;
END

----   BOVINE BY NUMBER  ----

CREATE PROCEDURE sp_bovine_by_number
(@num INT)
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[Bovine] WHERE [Number] = @num; 
END

----   BOVINE BY ID   ----

CREATE PROCEDURE sp_bovine_by_id
(@Id INT)
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[Bovine] WHERE [Id] = @Id;
END

----    DETAILS OF THE BOVINE   ----

CREATE PROCEDURE sp_details_of_bovine_by_id
 (@bovine INT)
AS BEGIN
	SELECT bo.*, mo.Number AS MotherNumber, mo.Name AS Mother, mo.Gender AS MotherGender, 
	mb.Name AS MotherBreed,	fa.Number AS FatherNumber, fa.Name AS Father, fa.Gender AS FatherGender, 
	fb.Name AS FatherBreed, be.Name AS Breed, fr.Name AS Farm, gr.Name AS [Group] 
		FROM (SELECT * 
				FROM [Bovine] 
				WHERE [Bovine].[Id] = @bovine) AS bo
	INNER JOIN [Bovine] AS fa
		ON bo.IdFather = fa.Id
	INNER JOIN [Bovine] AS mo
		ON bo.IdMother = mo.Id
	INNER JOIN [Breed] AS fb
		ON fb.Id = fa.IdBreed
	INNER JOIN [Breed] AS mb
		ON mb.Id = mo.IdBreed
	INNER JOIN [Breed] AS be
		ON bo.IdBreed = be.Id
	INNER JOIN [Farm] AS fr
		ON bo.IdFarm = fr.Id
	INNER JOIN [Group] AS gr
		ON bo.IdGroup = gr.Id
END

 -------    LIST OF ILNESS

CREATE PROCEDURE sp_Ilness_list
AS BEGIN
	SELECT * FROM [exdibo].[dbo].[Enfermedad] WHERE [Status] = 1;
END


------ UPDATE 

CREATE PROCEDURE sp_status_ilness (@Id INT, @Status BIT)
AS BEGIN
UPDATE [exdibo].[dbo].[Enfermedad] 
 SET  [Status] = @Status
 WHERE [Id] = @Id;
END


-----  SELECT GESTACION OVULATION 
CREATE PROCEDURE sp_monthly_gestation
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
SELECT 
ge.Id, 
ge.IdMother AS MotherId, mo.Number AS MotherNumber, mo.Earring AS MotherEarring, mo.Name AS MotherName, 
ge.IdFather AS FatherId, fa.Number AS FatherNumber, fa.Earring AS FatherEarring, fa.Name AS FatherName, 
ge.IdBreed, br.Name AS BreedName, 
ge.IdFarm, fr.Name AS FarmName, 
ge.IdGroup, gr.Name AS GroupName,
ge.Register, ge.Reovulation AS Ovulation, ge.Status 
FROM (SELECT ov.*, DATEADD(DAY, 22, ov.Register) AS Reovulation 
		FROM [Ovulation] AS ov
		WHERE [Status] = 0 OR (@Desde <= Register AND Register <= @Hasta)) AS ge
INNER JOIN [Bovine] AS mo
ON ge.IdMother = mo.Id
INNER JOIN [Bovine] AS fa
ON ge.IdFather = fa.Id
INNER JOIN [Breed] br
ON ge.IdBreed = br.Id
INNER JOIN [Farm] AS fr
ON ge.IdFarm = fr.Id
INNER JOIN [Group] AS gr
ON ge.IdGroup = gr.Id
END


----------    REPORT OF OVULATION

CREATE PROCEDURE sp_ovulation_report_from_to
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
	SELECT ov.Id, bo.Number, bo.Earring, ov.IdMother, bo.Name AS MotherName, ov.IdFather, fa.Name AS FatherName, ov.IdBreed, 
	br.Name AS BreedName, ov.IdFarm, fr.Name AS FarmName, ov.IdGroup, gr.Name AS GroupName , ov.Register, ov.Status 
	FROM [Ovulation] AS ov
	INNER JOIN [Bovine] AS bo 
	ON ov.IdMother = bo.Id
	INNER JOIN [Bovine] AS fa 
	ON ov.IdFather = fa.Id
	INNER JOIN [Breed] br
	ON ov.IdBreed = br.Id
	INNER JOIN [Farm] AS fr
	ON ov.IdFarm = fr.Id
	INNER JOIN [Group] AS gr
	ON ov.IdGroup = gr.Id
	WHERE ov.Register >= @Desde AND ov.Register <= @Hasta;
END

-----------   REPORT BORN    -----------------

CREATE PROCEDURE sp_born_report_from_to
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
	SELECT bo.Id, bo.Number, bo.Earring, bo.IdMother, mo.Name AS Mother, bo.IdFather, fa.Name AS Father, 
				bo.IdBreed, bo.IdFarm, bo.IdGroup, bo.Brand, bo.Name, bo.Gender,
				bo.Pregnant, bo.Born, bo.ProductionMilk, bo.Birth, 
				bo.Ovulation, bo.OvulationTimes, bo.StartWeight, bo.Weight, 
				bo.FinalWeight, bo.AdmissionDate, bo.DischargeDate,
				bo.Price, bo.Notes, bo.Discards, bo.Status 
	FROM [Bovine] bo
	INNER JOIN [Bovine] AS fa 
		ON bo.IdFather = fa.Id
	INNER JOIN [Bovine] AS mo 
		ON bo.IdMother = mo.Id
	WHERE bo.Born >= @Desde AND bo.Born <= @Hasta;
END

--------   REPORT DISCARDS   ---------

CREATE PROCEDURE sp_discard_report_from_to
(@Desde DATETIME, @Hasta DATETIME)
AS
BEGIN
SELECT *
FROM [Bovine] AS bo
WHERE bo.Discards = 1 AND bo.DischargeDate >= @Desde AND bo.DischargeDate <= @Hasta;
END


--------   IMPLANT REPORTS   -------- 
 
CREATE PROCEDURE sp_implant_report_from_to 
 (@Desde DATETIME, @Hasta DATETIME)    --- AGREGAR LOS ATRIBIUTOS
AS
BEGIN
SELECT con.Register, con.Name, con.Apply, con.Times, con.Withdrawal, bo.Number, bo.Name AS Bovine, fr.Name AS Farm, gr.Name AS [Group], ki.Name AS [Kind]  
	FROM(
		SELECT mc.*
		FROM (	SELECT mra.*, me.Name, me.Apply, me.Times, me.Withdrawal 
				FROM	(SELECT mr.IdMedicine, mr.IdBovine, mr.IdFarm, mr.IdGroup, mr.IdKind, mr.Register 
						FROM [MedicineRecord] AS mr 
						WHERE mr.IdKind = 1) AS mra
						INNER JOIN Medicine me
						ON mra.IdMedicine = me.Id) AS mc
WHERE	((@Desde <= mc.Register AND  mc.Register <= @Hasta)  OR
		(@Desde <=  DATEADD(DAY, mc.Withdrawal, mc.Register) AND DATEADD(DAY, mc.Withdrawal, mc.Register) <= @Hasta) OR
		(mc.Register <= @Desde AND @Hasta <= DATEADD(DAY, mc.Withdrawal, mc.Register)) OR
		(mc.Register > @Desde AND @Hasta > DATEADD(DAY, mc.Withdrawal, mc.Register)))) AS con
	INNER JOIN [Bovine] AS bo 
	ON con.IdBovine = bo.Id 
	INNER JOIN [Farm] AS fr
	ON con.IdFarm = fr.Id
	INNER JOIN [Group] AS gr
	ON con.IdGroup = gr.Id
		INNER JOIN [Kind] ki
	ON con.IdKind = ki.Id;
END


---- EXPEDIENTE BY NUMBER BOVINE ----

CREATE PROCEDURE sp_medicine_record_by_bovine
 (@NumberBovine INT)
AS BEGIN
SELECT mr.Id AS IdMRecord, mr.Register AS RegMRecord, mr.Notes AS Comment, 
	mr.IdBovine, bo.Number, bo.Earring, bo.IdFather, bo.Father, bo.IdMother, bo.Mother, bo.IdBreed, bo.Breed, bo.IdFarm, 
	fr.Name AS Farm, bo.IdGroup, gr.Name AS [Group], bo.Name, bo.Gender, bo.Born, bo.ProductionMilk, bo.Birth, bo.Pregnant,
	bo.Ovulation,bo.OvulationTimes,bo.StartWeight,bo.Weight,bo.FinalWeight, AdmissionDate, bo.DischargeDate, bo.Price, bo.Discards,
	bo.Status, bo.Notes, me.Id AS IdMedicine, me.Name AS Medicine, me.IdKind, ki.Name AS Kind, me.Apply, me.Via, me.Dose, me.Often, me.Times,
	me.Withdrawal, me.Contraindication, me.Note AS Indication, 
	mr.IdUser, us.Name AS Username, us.FirstName, us.LastName 
FROM (SELECT * FROM [MedicineRecord] WHERE IdBovine = (SELECT Id FROM [Bovine] WHERE Number = @NumberBovine)) AS mr  
INNER JOIN [Medicine] AS me  
ON mr.IdMedicine = me.Id	
INNER JOIN [Farm] AS fr
ON mr.IdFarm = fr.Id
INNER JOIN [Group] AS gr
ON mr.IdGroup = gr.Id
INNER JOIN [Kind] ki
ON mr.IdKind = ki.Id
INNER JOIN (SELECT bv.*, mo.Name AS Mother, fa.Name AS Father, be.Name AS Breed 
	FROM [Bovine] AS bv 
	INNER JOIN [Bovine] AS mo 
	ON bv.IdMother = mo.Id
	INNER JOIN [Bovine] AS fa 
	ON bv.IdFather = fa.Id
	INNER JOIN [Breed] be
	ON bv.IdBreed = be.Id) AS bo
ON mr.IdBovine = bo.Id
INNER JOIN [User] AS us
ON mr.IdUser = us.Id
END


---- EXPEDIENTE BY DATE ----

CREATE PROCEDURE sp_medicine_record_by_date  ----> by_id_Bovine OR by_id_user
 (@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
SELECT mr.Id AS IdMRecord, mr.Register AS RegMRecord, mr.Notes AS Comment, 
	mr.IdBovine, bo.Number, bo.Earring, bo.IdFather, bo.Father, bo.IdMother, bo.Mother, bo.IdBreed, bo.Breed, bo.IdFarm, 
	fr.Name AS Farm, bo.IdGroup, gr.Name AS [Group], bo.Name, bo.Gender, bo.Born, bo.ProductionMilk, bo.Birth, bo.Pregnant,
	bo.Ovulation,bo.OvulationTimes,bo.StartWeight,bo.Weight,bo.FinalWeight, AdmissionDate, bo.DischargeDate, bo.Price, bo.Discards,
	bo.Status, bo.Notes, me.Id AS IdMedicine, me.Name AS Medicine, me.IdKind, ki.Name AS Kind, me.Apply, me.Via, me.Dose, me.Often, me.Times,
	me.Withdrawal, me.Contraindication, me.Note AS Indication, 
	mr.IdUser, us.Name AS Username, us.FirstName, us.LastName
FROM (SELECT * FROM [MedicineRecord] mer WHERE @Desde <= mer.Register AND mer.Register <= @Hasta ) AS mr 
INNER JOIN [Medicine] AS me   
ON mr.IdMedicine = me.Id
INNER JOIN [Farm] AS fr
ON mr.IdFarm = fr.Id
INNER JOIN [Group] AS gr
ON mr.IdGroup = gr.Id
INNER JOIN [Kind] ki
ON mr.IdKind = ki.Id
INNER JOIN (SELECT bv.*, mo.Name AS Mother, fa.Name AS Father, be.Name AS Breed 
	FROM [Bovine] AS bv 
	INNER JOIN [Bovine] AS mo 
	ON bv.IdMother = mo.Id
	INNER JOIN [Bovine] AS fa 
	ON bv.IdFather = fa.Id
	INNER JOIN [Breed] be
	ON bv.IdBreed = be.Id) AS bo
ON mr.IdBovine = bo.Id
INNER JOIN [User] AS us
ON mr.IdUser = us.Id
END

---- EXPEDIENTE BY CODE USER ----

CREATE PROCEDURE sp_medicine_record_by_user 
 (@IDUser INT)
AS BEGIN
SELECT mr.Id AS IdMRecord, mr.Register AS RegMRecord, mr.Notes AS Comment, 
	mr.IdBovine, bo.Number, bo.Earring, bo.IdFather, bo.Father, bo.IdMother, bo.Mother, bo.IdBreed, bo.Breed, bo.IdFarm, 
	fr.Name AS Farm, bo.IdGroup, gr.Name AS [Group], bo.Name, bo.Gender, bo.Born, bo.ProductionMilk, bo.Birth, bo.Pregnant,
	bo.Ovulation,bo.OvulationTimes,bo.StartWeight,bo.Weight,bo.FinalWeight, AdmissionDate, bo.DischargeDate, bo.Price, bo.Discards,
	bo.Status, bo.Notes, me.Id AS IdMedicine, me.Name AS Medicine, me.IdKind, ki.Name AS Kind, me.Apply, me.Via, me.Dose, me.Often, me.Times,
	me.Withdrawal, me.Contraindication, me.Note AS Indication, 
	mr.IdUser, us.Name AS Username, us.FirstName, us.LastName 
FROM (SELECT * FROM [MedicineRecord] mer WHERE mer.IdUser = (SELECT Id FROM [User] WHERE Code = @IDUser)) AS mr 
INNER JOIN [Medicine] AS me
ON mr.IdMedicine = me.Id
INNER JOIN [Farm] AS fr
ON mr.IdFarm = fr.Id
INNER JOIN [Group] AS gr
ON mr.IdGroup = gr.Id
INNER JOIN [Kind] ki
ON mr.IdKind = ki.Id
INNER JOIN (SELECT bv.*, mo.Name AS Mother, fa.Name AS Father, be.Name AS Breed 
	FROM [Bovine] AS bv 
	INNER JOIN [Bovine] AS mo 
	ON bv.IdMother = mo.Id
	INNER JOIN [Bovine] AS fa 
	ON bv.IdFather = fa.Id
	INNER JOIN [Breed] be
	ON bv.IdBreed = be.Id) AS bo
ON mr.IdBovine = bo.Id
INNER JOIN [User] AS us
ON mr.IdUser = us.Id
END

---- EXPEDIENTE BY ID RECORD ----

CREATE PROCEDURE sp_medicine_record_by_id
 (@IdRecord INT)
AS BEGIN
SELECT mr.Id AS IdMRecord, mr.Register AS RegMRecord, mr.Notes AS Comment, 
	mr.IdBovine, bo.Number, bo.Earring, bo.IdFather, bo.Father, bo.IdMother, bo.Mother, bo.IdBreed, bo.Breed, bo.IdFarm, 
	fr.Name AS Farm, bo.IdGroup, gr.Name AS [Group], bo.Name, bo.Gender, bo.Born, bo.ProductionMilk, bo.Birth, bo.Pregnant,
	bo.Ovulation,bo.OvulationTimes,bo.StartWeight,bo.Weight,bo.FinalWeight, AdmissionDate, bo.DischargeDate, bo.Price, bo.Discards,
	bo.Status, bo.Notes, me.Id AS IdMedicine, me.Name AS Medicine, me.IdKind, ki.Name AS Kind, me.Apply, me.Via, me.Dose, me.Often, me.Times,
	me.Withdrawal, me.Contraindication, me.Note AS Indication, 
	mr.IdUser, us.Name AS Username, us.FirstName, us.LastName
FROM (SELECT * FROM [MedicineRecord] mer WHERE mer.Id = @IdRecord) AS mr 
INNER JOIN [Medicine] AS me
ON mr.IdMedicine = me.Id
INNER JOIN [Farm] AS fr
ON mr.IdFarm = fr.Id
INNER JOIN [Group] AS gr
ON mr.IdGroup = gr.Id
INNER JOIN [Kind] ki
ON mr.IdKind = ki.Id
INNER JOIN (SELECT bv.*, mo.Name AS Mother, fa.Name AS Father, be.Name AS Breed 
	FROM [Bovine] AS bv 
	INNER JOIN [Bovine] AS mo 
	ON bv.IdMother = mo.Id
	INNER JOIN [Bovine] AS fa 
	ON bv.IdFather = fa.Id
	INNER JOIN [Breed] be
	ON bv.IdBreed = be.Id) AS bo
ON mr.IdBovine = bo.Id
INNER JOIN [User] AS us
ON mr.IdUser = us.Id
END


---------  REGISTER MEDICINE RECORD   --------

CREATE PROCEDURE sp_insert_medicine_record
(@IdUser INT, @IdMedicine INT, @IdBovine INT, @IdFarm INT, @IdGroup INT, @IdKind INT, @Ilness VARCHAR(99), @Symptom VARCHAR(300), @Register DATETIME, @Notes VARCHAR(400), @Status BIT)
	AS BEGIN 
		INSERT INTO [dbo].[MedicineRecord] ([IdUser], [IdMedicine], [IdBovine], [IdFarm], [IdGroup], [IdKind], [Ilness], [Symptom], [Register], [Notes], [Status]) 
		VALUES	(@IdUser, @IdMedicine, @IdBovine, @IdFarm, @IdGroup, @IdKind, @Ilness, @Symptom, @Register, @Notes, @Status)
	END
   
   ----   GRAFICOS  ------

CREATE PROCEDURE sp_pregnant_report_from_to
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
SELECT 
COUNT(ov.Id) AS Total,
DateName( month , DateAdd( month , MONTH(ov.Register) , -1 ) ) AS [Months],
SUM(CASE WHEN ov.Status = 1 THEN 1 ELSE 0 END) AS [Pregnants], 
SUM(CASE WHEN ov.Status = 0 THEN 1 ELSE 0 END) AS [Emptys]
FROM (SELECT * FROM [Ovulation] WHERE @Desde <= Register AND Register <= @Hasta) AS ov
GROUP BY MONTH(ov.Register)
END

-----   UPDATE BOVINE OVULATION

CREATE PROCEDURE sp_update_bovine_ovulation
(@Gestation BIT, @Ovulation DATETIME, @IdBovine INT)
AS BEGIN
	UPDATE [dbo].[Bovine] 
	SET [Pregnant] = @Gestation, [Ovulation] = @Ovulation, [OvulationTimes] = OvulationTimes + 1 
	WHERE [Id] = @IdBovine;
END

-----   UPDATE OVULATION STATUS

CREATE PROCEDURE sp_update_ovulation_status
(@Gestation BIT, @IdOvulation INT)
AS BEGIN
	UPDATE [dbo].[Ovulation] 
	SET [Status] = @Gestation
	WHERE [Id] = @IdOvulation;
END

-----   UPDATE BOVINE OVULATION

CREATE PROCEDURE sp_update_bovine_pregnant
(@Gestation BIT, @IdBovine INT)
AS BEGIN
	UPDATE [dbo].[Bovine] 
	SET [Pregnant] = @Gestation
	WHERE [Id] = @IdBovine;
END

------------  
SELECT * FROM [Bovine];



--- INSERT MANUAL

INSERT INTO [User]
(Code, DNI, [Name], FirstName, LastName, Email, [Password], Birth, Gender, Job, Mobile, Phone, [Role] , Token, RegisterDate, [Status])  
VALUES 
(1075,'207820248','Andrew','Anchía','Gonzalez','aoanchiag@est.utn.ac.cr','qMuJLbVUk3ZZHRVNcz1T3w==','1998-07-30','Masculino','ING. Software','+50685758771','+50664479545', '0','000000','2022-04-28 00:00:00.000',1),
(1076,'602140810','Jorge','Anchía','Muñoz','jorgeoam72@gmail.com','qMuJLbVUk3ZZHRVNcz1T3w==','1972-04-28','Masculino','Veterinario','+50660923401','+50661482669', '5','000000','2022-04-28 00:00:00.000',1),
(1077,'3-765-890','EXPEDIENTE','DIGITAL','BOVINO','exdivo@outlook.com','qMuJLbVUk3ZZHRVNcz1T3w==','2022-06-16','Masculino','SuperUsuario','+50687654321','+50661482669', '0','000000','2022-04-28 00:00:00.000',1),
(1078,'207860234','Karla','Spencer','Padilla','spencer@gmail.com','qMuJLbVUk3ZZHRVNcz1T3w==','1995-02-14','Femenino','Vaquera','+50685129314','+50685670570', '3','000000','2022-04-28 00:00:00.000',1),
(1079,'204690347','Kimberly','Colombar','Vásquez','colovazques@gmail.com','qMuJLbVUk3ZZHRVNcz1T3w==','1999-07-09','Femenino','Peón Agrícola','+50662349801','+50670356982', '7','000000','2022-04-28 00:00:00.000',1),
(1080,'801230456','Administrador','Expediente','Digital','admin@outlook.com','qMuJLbVUk3ZZHRVNcz1T3w==','2022-04-04','Masculino','Administrador','+50685326598','+50664523465', '2','000000','2022-04-28 00:00:00.000',1);



	---GROUP
INSERT INTO [dbo].[Group]
(IdFarm, Number, [Name], [Status])
VALUES
(1, 1, 'Lechería', 1),
(1, 9, 'Terneros', 1),
(1, 2, 'Cría', 1),
(1, 3, 'Desarrollo', 1),
(1, 4, 'Engorde', 1),
(2, 5, 'Cría', 1),
(2, 6, 'Destete', 1);

		---  INSERT KIND

INSERT INTO Kind (Name, Status) VALUES
('Anabolico', 'True'),
('Analgésico', 'True'),
('Anestésico', 'True'),
('Antiácidos', 'True'),
('Antialérgico', 'True'),
('Ansiolítico', 'True'),
('Antibiótico', 'True'),
('Anticolinérgico', 'True'),
('Anticonceptivo', 'True'),
('Anticonvulsivo', 'True'),
('Antidepresivo', 'True'),
('Antidiabético', 'True'),
('Antidiarreico', 'True'),
('Antiemético', 'True'),
('Antihelmíntico', 'True'),
('Antihipertensivo', 'True'),
('Antihistamínico', 'True'),
('Antineoplásico', 'True'),
('Antiinfeccioso', 'True'),
('Antiinflamatorio', 'True'),
('Antiparkinsoniano', 'True'),
('Antimicótico', 'True'),
('Antiparasitario', 'True'),
('Antipirético', 'True'),
('Antipsicótico', 'True'),
('Antitusivo', 'True'),
('Antídoto', 'True'),
('Broncodilatador', 'True'),
('Cardiotónico', 'True'),
('Citostático o citotóxico', 'True'),
('Dermatologico', 'True'),
('Implante', 'True'),
('Hormonoterápico', 'True'),
('Obstetricia' ,'True'),
('Quimioterápico', 'True'),
('Vacuna','True');


INSERT INTO [dbo].[Breed]
([Name], [Purpose], [Genetics], [Status]) VALUES
('Gyr Brasileño', 'Leche', 'A', 1),
('Gyr Lechero', 'Leche', 'F1', 1),
('Girolando', 'Leche', 'F2', 1),
('Brahaman', 'Carne', 'A', 1),
('Pardo', 'Leche', 'A', 1),
('Indio', 'Leche', 'A', 1),
('Nelore', 'Carne', 'A', 1),
('Angus', 'Carne', 'A', 1),
('Brangus', 'Carne', 'F1', 1),
('Holstein', 'Carne', 'A', 1),
('Braholstein', 'Carne', 'F1', 1),
('Simbra', 'Carne', 'F1', 1);

	---- INSERT Farm

	
	INSERT INTO [Farm]
([Code], [Name], [Email], [Address], [Register], [Status]) VALUES
('07563486', 'ARWEN', 'arwen@outlook.com', 'Guatuso','2022-07-02 00:00:00.000', 1), 
('08653424', 'ANTARES', 'antares@outlook.com', 'Quesada','2022-07-02 00:00:00.000', 1), 
('04686588', 'ASLAM', 'aslam@outlook.com', 'Monterrey','2022-07-02 00:00:00.000', 1);

		---- INSERT BOVINOS

SELECT * FROM [Farm]

SELECT * FROM [Breed]

SELECT * FROM [Farm]

SELECT * FROM [Group]

INSERT INTO [dbo].[Bovine]
           ([Number], [Earring], [IdMother], [IdFather],[IdBreed],[IdFarm] ,[IdGroup],[Brand],[Name], [Gender],[Born],
		   [ProductionMilk],[Birth] ,[Pregnant] ,[Ovulation] ,[OvulationTimes],[StartWeight] ,[FinalWeight], [Weight], [AdmissionDate]
           ,[DischargeDate] ,[Price], [Notes], [Discards], [Status])
     VALUES
	 --- Desconocidos
	 (100, '100', 1, 1, 1, 4, 2, 'A', 'Desconocida', 'Hembra', '2018-10-20 00:00:00.000', 0, 0, 0, '2018-10-20 00:00:00.000', 0,
	 500,500,500, '2018-10-20 00:00:00.000', '2018-10-20 00:00:00.000', 800000, '', 0, 1),
	 (101, '101', 1, 1, 1, 4, 2, 'A', 'Desconocido', 'Macho', '2018-10-20 00:00:00.000', 0, 0, 0, '2018-10-20 00:00:00.000', 0,
	 500,500,500, '2018-10-20 00:00:00.000', '2018-10-20 00:00:00.000', 800000, '', 0, 1),
	 --- Toros CRIA
	 (102, '102', 1, 2, 1, 4, 2, 'A', 'Gyr', 'Macho', '2018-10-20 00:00:00.000', 0, 0, 0, '2018-10-20 00:00:00.000', 0,
	 960, 960, 960, '2018-10-20 00:00:00.000', '2018-10-20 00:00:00.000', 2200000, '', 0, 1),
	 (103, '103', 1, 2, 3, 4, 2, 'A', 'Pito', 'Macho', '2018-10-20 00:00:00.000', 0, 0, 0, '2018-10-20 00:00:00.000', 0,
	 1000, 1000, 1000, '2018-10-20 00:00:00.000', '2018-10-20 00:00:00.000', 2200000, '', 0, 1),
	 (104, '104', 1, 2, 4, 4, 2, 'A', 'Blanco', 'Macho', '2018-10-20 00:00:00.000', 0, 0, 0, '2018-10-20 00:00:00.000', 0,
	 1050, 1050, 1050, '2018-10-20 00:00:00.000', '2018-10-20 00:00:00.000', 1200000, '', 0, 1),
	 (105, '105', 1, 2, 10, 4, 2, 'A', 'Hosltein', 'Macho', '2018-10-20 00:00:00.000', 0, 0, 0, '2018-10-20 00:00:00.000', 0,
	 920, 920, 920, '2018-10-20 00:00:00.000', '2018-10-20 00:00:00.000', 1200000, '', 0, 1),
	 --- Vacas
	 (106, '106', 15, 13, 4, 4, 1, 'A', 'Lore', 'Hembra', '2018-10-20 00:00:00.000', 18, 2, 0, '2021-10-16 00:00:00.000', 0,
	 524, 562, 570, '2018-09-24 00:00:00.000', '2018-09-24 00:00:00.000', 809462, '', 0, 1),
	 (107, '107', 26, 13, 4, 4, 1, 'A', 'Zenem', 'Hembra', '2018-11-12 00:00:00.000', 18, 2, 1, '2022-04-19 10:32:00.000', 0,
	 524,562,570, '2018-09-24 00:00:00.000', '2018-09-24 00:00:00.000', 809462, '', 0, 1),
	  (108, '108', 27, 13, 4, 4, 1, 'A', 'Mirage', 'Hembra', '2018-10-17 00:00:00.000', 18, 2, 1, '2022-06-23 08:00:00.000', 0,
	 524,562,570, '2018-09-24 00:00:00.000', '2018-09-24 00:00:00.000', 809462, '', 0, 1),
	 (109, '109', 28, 13, 4, 4, 1, 'A', 'Zelmira', 'Hembra', '2018-07-29 00:00:00.000', 18, 2, 1, '2022-06-23 08:00:00.000', 0,
	 524,562,570, '2018-09-24 00:00:00.000', '2018-09-24 00:00:00.000', 809462, '', 0, 1),
	 (110, '110', 29, 13, 4, 4, 1, 'A', 'Calera', 'Hembra', '2018-08-15 00:00:00.000', 18, 2, 1, '2022-05-13 09:20:00.000', 0,
	 524,562,570, '2018-09-24 00:00:00.000', '2018-09-24 00:00:00.000', 809462, '', 0, 1),
	 (111, '111', 30, 13, 4, 4, 1, 'A', 'Karla', 'Hembra', '2018-6-22 00:00:00.000', 18, 4, 1, '2022-02-16 00:00:00.000', 0,
	 524,562,570, '2018-09-24 00:00:00.000', '2018-09-24 00:00:00.000', 809462, '', 0, 1),
	 (112, '112', 31, 13, 4, 4, 1, 'A', 'Perla', 'Hembra', '2018-8-24 00:00:00.000', 18, 2, 1, '2022-04-19 10:32:00.000', 0,
	 524,562,570, '2018-09-24 00:00:00.000', '2018-09-24 00:00:00.000', 809462, '', 0, 1),
	  (113, '113', 32, 13, 4, 1, 1, 'A', 'Ruby', 'Hembra', '2018-4-06 00:00:00.000', 18, 3, 1, '2022-05-23 08:00:00.000', 0,
	 524,562,570, '2018-09-24 00:00:00.000', '2018-09-24 00:00:00.000', 809462, '', 0, 1),
	 (114, '114', 33, 13, 4, 1, 1, 'A', 'Zeikel', 'Hembra', '2018-05-19 00:00:00.000', 18, 3, 1, '2022-06-23 08:00:00.000', 0,
	 524,562,570, '2018-09-24 00:00:00.000', '2018-09-24 00:00:00.000', 809462, '', 0, 1),
	 (115, '115', 34, 13, 4, 1, 1, 'A', 'Valera', 'Hembra', '2018-02-25 00:00:00.000', 18, 4, 1, '2022-05-13 09:20:00.000', 0,
	 524,562,570, '2018-09-24 00:00:00.000', '2018-09-24 00:00:00.000', 809462, '', 0, 1),
	 --- TOROS ENGORDE
	 (116, '116', 26, 13, 4, 1, 1, 'AW', 'Pancho 116', 'Macho', '2017-08-20 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000', 0,
	 865,885,924, '2017-08-20 00:00:00.000', '2017-08-20 00:00:00.000', 1320462, '', 0, 1),
	 (117, '117', 12, 13, 13, 1, 4, 'AW', 'Negro 117', 'Macho', '2019-07-20 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 491,525,525, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 820462, '', 0, 1),
	 (118, '118', 12, 13, 11, 1, 4, 'AW', 'Overo 118', 'Macho', '2019-08-12 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 512,585,585, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 9137700, '', 0, 1),
	 (119, '119', 12, 13, 10, 1, 4, 'AW', 'Blaky 119', 'Macho', '2020-01-07 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 562,602,620, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 1102845, '', 0, 1),
	 (120, '120', 12, 13, 9, 1, 4, 'AW', 'Angus 20', 'Macho', '2019-08-20 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 607,630,646, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 1223000, '', 0, 1),
	 (121, '121', 12, 13, 8, 1, 4, 'AW', 'Nelore 121', 'Macho', '2019-08-20 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 512,585,585, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 856230, '', 0, 1),
	 (122, '122', 12, 13, 7, 1, 4, 'AW', 'Indio 122', 'Macho', '2019-08-20 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 512,585,585, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 842674, '', 0, 1),
	 (123, '123', 12, 13, 4, 1, 4, 'Ä', 'Gir 23', 'Macho', '2019-07-20 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 491,525,525, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 820462, '', 0, 1),
	 (124, '124', 12, 13, 5, 1, 4, 'AW', 'Braham 124', 'Macho', '2019-08-12 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 512,585,585, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 9137700, '', 0, 1),
	 (125, '125', 12, 13, 6, 1, 4, 'AW', 'Pardo 125', 'Macho', '2020-01-07 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 562,602,620, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 1102845, '', 0, 1),
	 (126, '126', 12, 13, 9, 1, 4, 'AW', 'BlackUp 126', 'Macho', '2019-08-20 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 645,675,698, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 945879, '', 0, 1),
	 (127, '127', 12, 13, 8, 1, 4, 'AW', 'Giba 127', 'Macho', '2019-08-20 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 487,523,564, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 849634, '', 0, 1),
	 (128, '128', 12, 13, 8, 1, 4, 'AW', 'Orejita 128', 'Macho', '2019-08-20 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 521,534,568, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 842568, '', 0, 1),
	 (129, '129', 12, 13, 7, 1, 4, 'AW', 'Indio 122', 'Macho', '2019-08-20 00:00:00.000', 0, 0, 0, '2000-01-01 08:00:00.000',  0,
	 434,465,501, '2022-06-01 00:00:00.000', '2023-02-20 00:00:00.000', 785420, '', 0, 1);

--------------------------------------------------------------------------


INSERT INTO [exdibo].[dbo].[Medicine]
(Name, IdKind, Apply, Via, Dose, Often, Times, Withdrawal, Contraindication, Note, Register, Status)
VALUES
('Implemax', 1, 'Subcutanea', 'Inyectable', 30, 1, 1, 140, 'Reproducción Animal', '', '07-20-2022',1),
('Compudose', 1, 'Subcutanea', 'Inyectable', 200, 1, 1, 200, 'Reproducción Animal', '', '07-20-2022',1),
('Zeranol', 1, 'Subcutanea', 'Inyectable', 12, 1, 1, 90, 'Reproducción Animal', '', '07-20-2022',1),
('Penicilna', 4, 'Intramuscular', 'Inyectable', 15, 1, 3, 4, 'Penicilina, daño renal, hepatica o cardio, en lactancia o gestacion', 'Agitar bien antes de usar', '06-30-2022',1),
('Excenel', 4, 'Intramuscular', 'Inyectable', 25, 1, 3, 4, 'Penicilina o las cefalosporinas', 'Agitar bien antes de usar', '06-30-2022',1),
('Emicina', 4, 'Intramuscular', 'Inyectable', 25, 1, 3, 16, 'Tetraciclinas, daño hepática, úlceras, durante el embarazo y la lactancia', '', '06-30-2022',1),
('Oxitetraciclina', 4, 'Intramuscular', 'Inyectable', 25, 1, 3, 16, 'Tetraciclinas, daño hepática, úlceras, durante el embarazo y la lactancia', '', '06-30-2022',1)
('HISTAMINEX', 13, 'Intramuscular', 'Inyectable', 10, 1, 5, 0, 'NG', 'Puede dividirse la dosis en dos veces al dia', '06-30-2022',1),
('Bromucol', 22, 'Intramuscular', 'Inyectable', 25, 1, 5, 3, '', '', '06-30-2022',1);

-------------- INSERT  MedicineRecord ------------------

INSERT INTO [dbo].[MedicineRecord]
           ([IdMedicine],[IdBovine],[IdFarm],[IdGroup],[IdKind],[Register],[Notes], [Status],[IdUser])
     VALUES
	 (9, 42, 1, 4, 1 , '2018-05-20 00:00:00.000', '', 1, 4),
	 (9, 43, 1, 4, 1 , '2019-05-20 00:00:00.000', '', 1, 4),
	 (9, 44, 1, 4, 1 , '2020-05-20 00:00:00.000', '', 1, 4),
	(1, 12, 1, 1, 22, '2022-06-20 00:00:00.000', '', 1, 4),
	(2, 13, 1, 1, 13, '2022-06-20 00:00:00.000', '', 1, 4),
	(9, 13, 1, 4, 1 , '2022-07-20 00:00:00.000', '', 1, 4),
    (10, 38, 1, 4, 1 , '2022-07-20 00:00:00.000', '', 1, 4),
    (11, 39, 1, 4, 1 , '2022-02-18 00:00:00.000', '', 1, 4),
	(7, 13, 1, 4, 1 , '2022-05-20 00:00:00.000', '', 1, 4);


------------  INSERT OVULATION   --------

INSERT INTO [dbo].[Ovulation]
           ([IdMother], [IdFather], [IdBreed], [IdFarm], [IdGroup], [Register], [Status])
     VALUES
		(26, 38, 4, 1, 1, '2022-06-20 06:40:30.000', 0),
		(28, 38, 4, 1, 1, '2022-03-06 00:00:00.000', 0),
		(29, 38, 4, 1, 1, '2022-03-15 10:32:00.000', 0),
		(30, 38, 4, 1, 1, '2022-03-23 08:00:00.000', 0),
		(35, 38, 4, 1, 1, '2022-03-25 08:00:00.000', 0),
		(36, 38, 4, 1, 1, '2022-03-27 08:00:00.000', 1),
		(33, 38, 4, 1, 1, '2022-05-16 10:12:24.000', 1),
		(27, 38, 4, 1, 1, '2022-1-16 00:00:00.000', 0),
		(28, 38, 4, 1, 1, '2022-1-26 00:00:00.000', 0),
		(29, 38, 4, 1, 1, '2022-04-19 10:32:00.000', 0),
		(26, 38, 4, 1, 1, '2022-06-25 00:00:00.000', 0),
		(27, 38, 4, 1, 1, '2022-1-16 00:00:00.000', 1),
		(28, 38, 4, 1, 1, '2022-1-26 00:00:00.000', 1),
		(29, 38, 4, 1, 1, '2022-04-19 10:32:00.000', 1),
		(30, 38, 4, 1, 1, '2022-06-23 08:00:00.000', 1),
		(31, 38, 4, 1, 1, '2022-06-23 08:00:00.000', 1),
		(32, 38, 4, 1, 1, '2022-05-13 09:20:00.000', 1),
		(33, 38, 4, 1, 1, '2022-02-16 00:00:00.000', 1),
		(34, 38, 4, 1, 1, '2022-04-19 10:32:00.000', 1),
		(35, 38, 4, 1, 1, '2022-05-23 08:00:00.000', 1),
		(36, 38, 4, 1, 1, '2022-06-23 08:00:00.000', 1),
		(37, 38, 4, 1, 1, '2022-05-13 09:20:00.000' , 1)


		;

SELECT Id, Number, IdBreed, IdGroup, Name, Gender, Pregnant, OvulationTimes,Ovulation FROM [Bovine] WHERE Gender = 'Hembra'

SELECT * FROM [Bovine]

----- INSERT ENFERMEDADES ---------

INSERT INTO [dbo].[Enfermedad] (Enfermedad) 
VALUES ('Anaplasmosis'),('Anemia'), ('Artritis'), ('Artrosis'), ('Brucelosis'), ('Bursitis'), ('Clamidiasis'),
('Cancer'), ('Campilobacteriosis genital'), ('Carbunco bacteridiano'), ('Coccidiosis'),('Diarrea Epidemica'), 
('Diarrea Viral'), ('Dermatobia'), ('Dermatosis Nodular Contagiosa'), ('Dermatofilosis'), ('Envenenamiento Víbora'), 
('Encefalopatía Espongiforme'), ('Estreptococos'),('Estomatitis'),('Equinococosis'),('Influenza'),
('Fiebre Hemorrágica'), ('Fiebre del Nilo'), ('Fiebre Q'), ('Fiebre Aftosa'),('Fiebre del Valle'), ('Herpesvirosis'),
('Hepatitis'),('Gastroenteritis'),( 'Garrapatas'), ('Mastitis'), ('Malaria'),('Micosis'), ('Mastocitomas'), ('Muermo'),
('Neumonía'),('Ninguna'), ('Nematodos'), ('Necrosis'), ('Leucemia'),('Lengua Azul'), ('Leptospirosis'), ('Leucosis'),
('Rabia'), ('Septicemia'),('Sarna'),('Salmonella'), ('Streptococcus'), ('Peste de Rumiantes'),('Peste Bovina'), 
('Perineumonia'),('Rinotraqueítis'), ('Taura'),('Triquina'), ('Tricomonosis'), ('Tuberculosis'), ('Viruela')



 ---- SELECTs  SELECT SELECT


SELECT * FROM [MedicineRecord]

SELECT * FROM [Bovine]

SELECT * FROM [User]

SELECT * FROM [Farm]

SELECT * FROM [Farm]
--1, 2
SELECT * FROM Medicine

SELECT * FROM [Group]
--1, 2, 3, 4, 5

SELECT * FROM [Kind] 

SELECT * FROM [User]
-- 4

SELECT * FROM [Breed];

SELECT * FROM [Bovine];
--12 13

SELECT * FROM [exdibo].[dbo].[Bovine] WHERE [Id] = 14;


--- PRUEBAS DE  CONSULTAS

SELECT * FROM [Ovulation];

SELECT * FROM [Bovine];

SELECT [number] AS Preñes FROM [Bovine] WHERE [Pregnant] = 1 AND '2022-06-01' < [Ovulation]  AND '2022-06-30' > [Ovulation];

SELECT IdMother FROM [Ovulation] GROUP BY IdMother;


CREATE PROCEDURE sp_ovulation_report_from_to
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
	SELECT ov.Id, bo.Number, bo.Earring, ov.IdMother, bo.Name AS MotherName, ov.IdFather, fa.Name AS FatherName, ov.IdBreed, 
	br.Name AS BreedName, ov.IdFarm, fr.Name AS FarmName, ov.IdGroup, gr.Name AS GroupName , ov.Register, ov.Status 
	FROM [Ovulation] AS ov
	INNER JOIN [Bovine] AS bo 
	ON ov.IdMother = bo.Id
	INNER JOIN [Bovine] AS fa 
	ON ov.IdFather = fa.Id
	INNER JOIN [Breed] br
	ON ov.IdBreed = br.Id
	INNER JOIN [Farm] AS fr
	ON ov.IdFarm = fr.Id
	INNER JOIN [Group] AS gr
	ON ov.IdGroup = gr.Id
	WHERE ov.Register >= @Desde AND ov.Register <= @Hasta;
END


---- Nacimientos por Mes

SELECT DATENAME(MONTH, MONTH(bo.born)), Count(*) AS born 



CREATE PROCEDURE sp_born_by_month_report_from_to
(@Desde DATETIME, @Hasta DATETIME)
AS 

SELECT DateName( month , DateAdd( month , MONTH('2018-08-24 00:00:00.000') , -1 ) ) AS [Month], Count(*) AS Born 

BEGIN


SELECT DateName( month , DateAdd( month , MONTH(bo.born) , -1 ) ) AS [Month], Count(*) AS Born 
FROM [Bovine] bo
WHERE bo.Born >= @Desde AND bo.Born <= @Hasta
GROUP BY MONTH(bo.born)


END 

SELECT DateName( month , DateAdd( month , MONTH(bo.born) , -1 ) ) AS [Month], Count(*) AS Born 
FROM [Bovine] bo
WHERE bo.Born >= '2018-01-01' AND bo.Born <= '2022-12-12'
GROUP BY MONTH(bo.born)




SELECT * FROM [Bovine]
SELECT [number] AS Preñes FROM [Bovine] WHERE [Pregnant] = 1 AND '2022-06-01' < [Ovulation]  AND '2022-06-30' > [Ovulation]



CREATE PROCEDURE sp_withdrawal_report_from_to
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
SELECT con.Register, con.Name, con.Apply, con.Times, con.Withdrawal, bo.Number, bo.Name AS Bovine, fr.Name AS Farm, gr.Name AS [Group], ki.Name AS [Kind]  FROM(
SELECT hi.IdMedicine, hi.IdBovine, hi.IdFarm, hi.IdGroup, hi.IdKind, hi.Register, me.Name, me.Apply, me.Times, me.Withdrawal
FROM( SELECT * FROM [MedicineRecord] AS mr WHERE mr.Register >= @Desde AND mr.Register <= @Hasta) AS hi
INNER JOIN [Medicine] me
ON hi.IdMedicine = me.Id WHERE me.Withdrawal > 0) AS con
	INNER JOIN [Bovine] AS bo 
	ON con.IdBovine = bo.Id 
	INNER JOIN [Farm] AS fr
	ON con.IdFarm = fr.Id
	INNER JOIN [Group] AS gr
	ON con.IdGroup = gr.Id
		INNER JOIN [Kind] ki
	ON con.IdKind = ki.Id;
END



SELECT con.Register, con.Name, con.Apply, con.Times, con.Withdrawal, bo.Number, bo.Name AS Bovine, fr.Name AS Farm, gr.Name AS [Group], ki.Name AS [Kind]  FROM(
SELECT hi.IdMedicine, hi.IdBovine, hi.IdFarm, hi.IdGroup, hi.IdKind, hi.Register, me.Name, me.Apply,  me.Times, me.Withdrawal
FROM( SELECT * FROM [MedicineRecord] AS mr WHERE mr.Register >= '2022-01-01 00:00:00.00' AND mr.Register <= '2022-12-30 00:00:00.00') AS hi
INNER JOIN [Medicine] me
ON hi.IdMedicine = me.Id WHERE me.Withdrawal > 0) AS con
	INNER JOIN [Bovine] AS bo 
	ON con.IdBovine = bo.Id 
	INNER JOIN [Farm] AS fr
	ON con.IdFarm = fr.Id
	INNER JOIN [Group] AS gr
	ON con.IdGroup = gr.Id
		INNER JOIN [Kind] ki
	ON con.IdKind = ki.Id;



	--- PLANNING CONSULT IMPLANTs

SELECT con.Register, con.Name, con.Apply, con.Times, con.Withdrawal, bo.Number, bo.Name AS Bovine, fr.Name AS Farm, 
gr.Name AS [Group], ki.Name AS [Kind]  FROM(

SELECT mc.*
FROM ( 
	SELECT mra.*, me.Name, me.Apply, me.Times, me.Withdrawal 
	FROM (SELECT mr.IdMedicine, mr.IdBovine, mr.IdFarm, mr.IdGroup, mr.IdKind, mr.Register FROM [MedicineRecord] AS mr WHERE mr.IdKind = 1) AS mra
	INNER JOIN Medicine me
	ON mra.IdMedicine = me.Id) AS mc
WHERE (mc.Register <= '2018-07-01 00:00:00.00' AND '2018-08-30 00:00:00.00'  <=   (DATEADD(DAY, mc.Withdrawal, mc.Register))) ) AS con
	INNER JOIN [Bovine] AS bo 
	ON con.IdBovine = bo.Id 
	INNER JOIN [Farm] AS fr
	ON con.IdFarm = fr.Id
	INNER JOIN [Group] AS gr
	ON con.IdGroup = gr.Id
		INNER JOIN [Kind] ki
	ON con.IdKind = ki.Id;



SELECT DATEADD(DAY, 140, '2022-02-18 00:00:00.00') AS Fecha_Retiro; 



SELECT * FROM [User] AS mr WHERE mr.IdKind = 1

SELECT * FROM [MedicineRecord] mer

SELECT con.Register, con.Name, con.Apply, con.Times, con.Withdrawal, bo.Number, bo.Name AS Bovine, fr.Name AS Farm, gr.Name AS [Group], ki.Name AS [Kind]  
	FROM(
		SELECT mc.*
			FROM (SELECT mra.*, me.Name, me.Apply, me.Times, me.Withdrawal 
				FROM (SELECT mr.IdMedicine, mr.IdBovine, mr.IdFarm, mr.IdGroup, mr.IdKind, mr.Register 
				FROM [MedicineRecord] AS mr 
				WHERE mr.IdKind = 1) AS mra
				INNER JOIN Medicine me
				ON mra.IdMedicine = me.Id) AS mc
WHERE ( ('2022-07-01 00:00:00.000' <= mc.Register AND  mc.Register <= '2022-07-30 00:00:00.000')  OR

( '2022-07-01 00:00:00.000' <=  DATEADD(DAY, mc.Withdrawal, mc.Register)) AND DATEADD(DAY, mc.Withdrawal, mc.Register) <= '2022-07-30 00:00:00.000') OR

(mc.Register <= '2022-07-01 00:00:00.000' AND '2022-07-30 00:00:00.000' <= DATEADD(DAY, mc.Withdrawal, mc.Register)) OR

 (mc.Register > '2022-07-01 00:00:00.000' AND '2022-07-30 00:00:00.000' > (DATEADD(DAY, mc.Withdrawal, mc.Register))) ) AS con
	INNER JOIN [Bovine] AS bo 
	ON con.IdBovine = bo.Id 
	INNER JOIN [Farm] AS fr
	ON con.IdFarm = fr.Id
	INNER JOIN [Group] AS gr
	ON con.IdGroup = gr.Id
		INNER JOIN [Kind] ki
	ON con.IdKind = ki.Id;


SELECT his.* FROM 
(SELECT * FROM [MedicineRecord] mr WHERE mr.IdBovine = 32) AS his
INNER JOIN [Bovine] bo
ON his.IdBovine = bo.Id 
INNER JOIN [Medicine] AS me   
ON his.IdMedicine = me.Id
INNER JOIN [Farm] AS fr
ON his.IdFarm = fr.Id
INNER JOIN [Group] AS gr
ON his.IdGroup = gr.Id
INNER JOIN [Kind] ki
ON his.IdKind = ki.Id
INNER JOIN [User] us
ON his.IdUser = us.Id



SELECT  DateName( month , DateAdd( month , MONTH(ov.Register) , -1 ) ) AS Mes, COUNT(*) AS Total, COUNT(ov.Status) AS EFECTIVE, COUNT(ov.Status) AS FAIL FROM [Ovulation] AS ov

GROUP BY MONTH(ov.Register)



-------    PREGNANT REPORT   ----------------
CREATE PROCEDURE sp_pregnant_report_from_to
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
SELECT 
COUNT(ov.Id) AS Total,
DateName( month , DateAdd( month , MONTH(ov.Register) , -1 ) ) AS [Months],
SUM(CASE WHEN ov.Status = 1 THEN 1 ELSE 0 END) AS [Pregnants], 
SUM(CASE WHEN ov.Status = 0 THEN 1 ELSE 0 END) AS [Emptys]
FROM (SELECT * FROM [Ovulation] WHERE @Desde <= Register AND Register <= @Hasta) AS ov
GROUP BY MONTH(ov.Register)
END


SELECT pr.Id, pr.IdMother, DateName( month , DateAdd( month , MONTH(pr.Register) , -1 ) ) AS [Month] ,pr.Status FROM [Ovulation] AS pr


EXEC sp_pregnant_report_from_to  @Desde = '2022-01-01 00:00:00.000', @Hasta = '2022-08-30 23:59:50:000';


---------------------------------------------------------------------------------

  ----- REPORTE GRAFICO  ------
  
CREATE PROCEDURE sp_gonna_born_by_month
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN
SELECT pr.Id, pr.Number, pr.Earring, pr.Name AS Bovine, pr.ProductionMilk, pr.Ovulation, pr.originate, br.Name AS [Breed], fa.Name AS [Farm], gr.Name AS [Group] FROM (
SELECT bo.Id, bo.Number, bo.Earring, bo.IdBreed, bo.IdFarm, bo.IdGroup, bo.Name, bo.ProductionMilk, bo.Ovulation, DATEADD(DAY, 285, bo.Ovulation) AS originate
FROM [Bovine] AS bo 
WHERE bo.Pregnant = 1 
AND @Desde <= DATEADD(DAY, 285, bo.Ovulation)
AND DATEADD(DAY, 285, bo.Ovulation) <= DATEADD( DAY, 30, @Hasta)) AS pr
INNER JOIN [Breed] AS br
ON pr.IdBreed = br.Id
INNER JOIN [Farm] AS fa
ON pr.IdFarm = fa.Id
INNER JOIN [Group] AS gr
ON pr.IdGroup = gr.Id;
END

--------------------------------------------------------------------------------------------------------
--######################################################################################################
--- PARTE DE PRUEBAS
----- GRAFICO

SELECT pr.Id, pr.Number, pr.Earring, pr.Name AS Bovine, pr.ProductionMilk, pr.Ovulation, pr.originate, br.Name AS [Breed], fa.Name AS [Farm], gr.Name AS [Group] FROM (
SELECT bo.Id, bo.Number, bo.Earring, bo.IdBreed, bo.IdFarm, bo.IdGroup, bo.Name, bo.ProductionMilk, bo.Ovulation, DATEADD(DAY, 285, bo.Ovulation) AS originate
FROM [Bovine] AS bo 
WHERE bo.Pregnant = 1 
AND '2022-11-01 00:00:00.000' <= DATEADD(DAY, 285, bo.Ovulation)
AND DATEADD(DAY, 285, bo.Ovulation) <= DATEADD( DAY, 30, '2022-11-01 00:00:00.000')) AS pr
INNER JOIN [Breed] AS br
ON pr.IdBreed = br.Id
INNER JOIN [Farm] AS fa
ON pr.IdFarm = fa.Id
INNER JOIN [Group] AS gr
ON pr.IdGroup = gr.Id



SELECT * FROM [Bovine]


--- born from todaay - 90 days 
SELECT bo.*, DATEADD(DAY, 285, bo.Ovulation) AS originate
FROM [Bovine] AS bo 
WHERE bo.Pregnant = 1 
AND @today <= DATEADD(DAY, 285, bo.Ovulation)
AND DATEADD(DAY, 285, bo.Ovulation) <= DATEADD( DAY, 30, @today);


SELECT DATENAME(MONTH, DATEADD(DAY, 285, bo.Ovulation)) AS [Month]
FROM [Bovine] AS bo 
WHERE bo.Pregnant = 1 
AND '2022-11-01 00:00:00.000' <= DATEADD(DAY, 285, bo.Ovulation)
AND DATEADD(DAY, 285, bo.Ovulation) <= DATEADD( DAY, 90, '2022-11-01 00:00:00.000')
GROUP BY MONTH(DATEADD(DAY, 285, bo.Ovulation))


DATENAME(MONTH, bo.Origin) AS MonthOrigin, 

SELECT 
DateName(MONTH , DateAdd(MONTH , 285, bo.Ovulation)) AS [Months],
SUM(CASE WHEN bo.Pregnant = 1 THEN 1 ELSE 0 END) AS Borns
FROM(
SELECT po.*, DATEADD(DAY, 285, po.Ovulation) AS Origin  
FROM [Bovine] AS po 
WHERE po.Pregnant = 1
AND '2022-11-01 00:00:00.000' <= DATEADD(DAY, 285, po.Ovulation)
AND DATEADD(DAY, 285, po.Ovulation) <= DATEADD( DAY, 90, '2022-11-01 00:00:00.000') ) AS bo
GROUP BY MONTH(bo.Origin)




SELECT DATEADD( DAY, 180,'2022-01-01 00:00:00.000') AS birth

SELECT DATEADD( DAY, 90,'2022-11-01 00:00:00.000') AS birth



SELECT DATENAME(MONTH, DATEADD(DAY, 285, bo.Ovulation)) AS Montth , COUNT(bo.Pregnant) AS Preg
FROM [Bovine] AS bo
WHERE 
bo.Pregnant = 1 
AND '2022-11-01 00:00:00.000' <= DATEADD(DAY, 285, bo.Ovulation)
AND DATEADD(DAY, 285, bo.Ovulation) <= '2023-01-30 00:00:00.000' ---DATEADD( DAY, 90, '2022-11-01 00:00:00.000')
GROUP BY MONTH(DATEADD( DAY, 285, bo.Ovulation)) 

SELECT * FROM Bovine

SELECT DATENAME(MONTH, con.originate) AS Mon, COUNT(con.Id) AS Bor FROM (
SELECT bo.*, DATEADD(DAY, 285, bo.Ovulation) AS originate
FROM [Bovine] AS bo 
WHERE bo.Pregnant = 1 
AND '2022-11-01 00:00:00.000' <= DATEADD(DAY, 285, bo.Ovulation)
AND DATEADD(DAY, 285, bo.Ovulation) <= DATEADD( DAY, 90, '2022-11-01 00:00:00.000')
) AS con
GROUP BY MONTH((con.originate))



SELECT DATENAME(MONTH, con.originate) AS mon,  COUNT(con.Id) AS preg

FROM (
SELECT bo.*, DATEADD(DAY, 285, bo.Ovulation) AS originate
FROM [Bovine] AS bo 
WHERE bo.Pregnant = 1 
AND '2022-11-01 00:00:00.000' <= DATEADD(DAY, 285, bo.Ovulation)
AND DATEADD(DAY, 285, bo.Ovulation) <= DATEADD( DAY, 90, '2022-11-01 00:00:00.000')) AS con

GROUP BY con.originate


SELECT pr.Id, pr.Name AS Codigo, pr.Output AS Production, pr.Register, pr.Status, pr.IdBovine
SELECT * 
FROM [exdibo].[dbo].[Production] AS pr
INNER JOIN [exdibo].[dbo].[Bovine] AS bo
ON pr.IdBovine = bo.Id



CREATE PROCEDURE sp_report_production_from_to
(@Desde DATETIME, @Hasta DATETIME)
AS BEGIN 
SELECT pr.Id, pr.Name AS Codigo, pr.Output AS Production, pr.Register, pr.Status, pr.IdBovine, bo.Number, bo.Earring, bo.Name, bo.pregnant 
FROM (
SELECT p.Id, p.Name, p.Output, p.Register, p.Status, p.IdBovine
FROM [exdibo].[dbo].[Production] AS p
WHERE @Desde <= p.Register AND p.Register <= @Hasta) AS pr
INNER JOIN [exdibo].[dbo].[Bovine] AS bo
ON pr.IdBovine = bo.Id
END





SELECT * FROM [exdibo].[dbo].[Bovine] WHERE Discards = 1 AND '2022-08-01 00:00:00.000' <= DischargeDate AND DischargeDate <= '2022-08-30 00:00:00.000'     [Status] = 1 



SELECT b.Mother AS Id, bo.Number, bo.Name, b.Hijos
FROM( 
SELECT IdMother AS Mother, COUNT(Id) AS Hijos FROM Bovine
GROUP BY IdMother ) as b
INNER JOIN Bovine bo 
ON b.Mother = bo.Id
ORDER BY b.Mother


SELECT Id, Number, Name, Pregnant, Ovulation FROM [Bovine] WHERE Gender = 'Hembra';


SELECT o.Id, o.IdMother, o.Register, b.Ovulation, o.Status AS Estado, b.Pregnant  FROM Ovulation AS o 
INNER JOIN Bovine AS b
ON o.IdMother = b.Id

UPDATE Bovine SET Ovulation = (SELECT Register FROM Ovulation WHERE Id = 15) WHERE Id = 55


SELECT * FROM Bovine WHERE Gender = 'Hembra';

SELECT Id, Number,Name  
FROM Bovine 
WHERE Gender = 'Hembra' AND IdGroup = 1;