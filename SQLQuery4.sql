CREATE TABLE [dbo].[Likes] (
    [NazwaUzytkownika] VARCHAR (100) NOT NULL,
    [IdPrzepisu]       INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([NazwaUzytkownika] ASC, [IdPrzepisu] ASC)
);
