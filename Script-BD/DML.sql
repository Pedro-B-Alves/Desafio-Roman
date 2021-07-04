USE Roman;
GO

INSERT INTO TipoUsuario		(tipoUsuario)
VALUES						('Administrador'),
							('Professor')
GO

INSERT INTO Equipe			(nomeEquipe)
VALUES						('Equipe 1'),
							('Equipe 2'),
							('Sem equipe')
GO

INSERT INTO Atividade		(atividade)
VALUES						('Ativa'),
							('Desativa')
GO

INSERT INTO Usuario			(idTipoUsuario, idEquipe, nome, email, senha)
VALUES						(1, 3, 'ADM', 'adm@gmail.com', 'adm123'),
							(2, 1, 'Usuario1', 'user1@gmail.com', 'user1123'),
							(2, 2, 'Usuario2', 'user2@gmail.com', 'user2123'),
							(2, 3, 'Usuario3', 'user3@gmail.com', 'user3123')
GO

INSERT INTO Projeto			(idAtividade, idUsuario, tema, projeto, descricao)
VALUES						(1, 3, 'Mobile', 'Crie um projeto mobile', 'crie um projeto mobile')
GO

