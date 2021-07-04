CREATE DATABASE Roman;
GO

USE Roman;
GO

CREATE TABLE TipoUsuario
(
	idTipoUsuario		INT PRIMARY KEY IDENTITY,
	tipoUsuario			VARCHAR(200) UNIQUE NOT NULL
)
GO

CREATE TABLE Equipe
(
	idEquipe			INT PRIMARY KEY IDENTITY,
	nomeEquipe			VARCHAR(200) UNIQUE NOT NULL
)
GO

CREATE TABLE Atividade
(
	idAtividade			INT PRIMARY KEY IDENTITY,
	atividade			VARCHAR(200) UNIQUE NOT NULL
)

CREATE TABLE Usuario
(
	idUsuario			INT PRIMARY KEY IDENTITY,
	idTipoUsuario		INT FOREIGN KEY REFERENCES TipoUsuario (idTipoUsuario),
	idEquipe			INT FOREIGN KEY REFERENCES Equipe (idEquipe),
	nome				VARCHAR(200) NOT NULL,
	email				VARCHAR(200) UNIQUE NOT NULL,
	senha				VARCHAR(200) NOT NULL,
);
GO

CREATE TABLE Projeto
(
	idProjeto			INT PRIMARY KEY IDENTITY,
	idUsuario			INT FOREIGN KEY REFERENCES Usuario (idUsuario),
	idAtividade			INT FOREIGN KEY REFERENCES Atividade (idAtividade),
	tema				VARCHAR(200) NOT NULL,
	projeto				VARCHAR(200) NOT NULL,
	descricao			VARCHAR(500),
)
GO