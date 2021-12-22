CREATE PROCEDURE [dbo].[sp_updatePrzepis]
@id int,
@nazwa VARCHAR(50),
@opis VARCHAR (1000),
@skladniki VARCHAR(1000)
AS
UPDATE Przepisy SET Nazwa=@nazwa, Opis=@opis, Skladniki=@skladniki WHERE Id=@id