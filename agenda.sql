CREATE DATABASE agenda;
USE agenda;

CREATE TABLE tbcontato(
codcontato INT NOT NULL PRIMARY KEY auto_increment,
nome VARCHAR (100),
telefone CHAR (14),
celular CHAR (15),
email VARCHAR (100)
);

CREATE TABLE tbllogin(
login VARCHAR (30) NOT NULL PRIMARY KEY,
senha VARCHAR (30) NOT NULL
);

INSERT INTO tbllogin (login, senha)
VALUES ('adm', '123');

INSERT INTO tbcontato (nome, telefone, celular, email)
VALUES ('Samara Ferreira', '(11) 5555-4444', '(11) 97777-8888', 'samara.ferreira27@gmail.com');

INSERT INTO tbcontato (nome, telefone, celular, email)
VALUES ('Samantha Lima', '(11) 5987-2346', '(11) 98991-2589', 'sam.lima@gmail.com');

SELECT * FROM tbcontato;