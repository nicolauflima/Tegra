# Tegra

Repositório criado para a continuação do processo seletivo na Tegra.

Este programa foi criado utilizando a programação C# e banco de dados MySQL.



A seguir serão passadas algumas configurações necessárias para criar o banco de dados:
---------------------------------------------------------------------

server=localhost;
port=3306;
User id=root;
database=tegra;
password=123;


create database tegra;

use tegra;

CREATE TABLE LIVRO(
	IDLIVRO INT PRIMARY KEY AUTO_INCREMENT,
	NOMELIVRO VARCHAR(200) NOT NULL UNIQUE,
	AUTOR VARCHAR(200) NOT NULL,
	PRECO DECIMAL(8,2) NOT NULL,
	QUANTIDADE INT(5) NOT NULL
);



INSERT INTO LIVRO VALUES(NULL,'O Programador Pragmático: De Aprendiz a Mestre','Andrew Hunt, David Thomas',125.50,50);
INSERT INTO LIVRO VALUES(NULL,'The Mythical Man-Month: Essays on Software Engineering','Frederick P. Brooks Jr.',170.19,32);
INSERT INTO LIVRO VALUES(NULL,'Expressões Regulares - Uma Abordagem Divertida','Aurelio Marinho Jargas',47.20,10);
INSERT INTO LIVRO VALUES(NULL,'Domain-Driven Design: Tackling Complexity in the Heart of Software','Eric Evans',251.14,32);
INSERT INTO LIVRO VALUES(NULL,'Padrões de Arquitetura de Aplicações Corporativas','Martin Fowler',101.59,25);
INSERT INTO LIVRO VALUES(NULL,'The Design of Design: Essays from a Computer Scientist','Frederick P. Jr. Brooks',161.75,5);
INSERT INTO LIVRO VALUES(NULL,'Shell Script Profissional','Aurelio Marinho Jargas',62.35,37);
INSERT INTO LIVRO VALUES(NULL,'NoSQL Essencial: Um Guia Conciso para o Mundo Emergente da Persistência Poliglota','Pramod J. Sadalage, Martin Fowler',52.00,19);
INSERT INTO LIVRO VALUES(NULL,'Refactoring: Improving the Design of Existing Code','Martin Fowler',220.63,43);
INSERT INTO LIVRO VALUES(NULL,'Clean Architecture: A Craftsman''s Guide to Software Structure and Design','Robert C. Martin',148.61,1);
INSERT INTO LIVRO VALUES(NULL,'Clean Code: A Handbook of Agile Software Craftsmanship','Robert C. Martin',180.04,16);
INSERT INTO LIVRO VALUES(NULL,'Clean Agile: Back to Basics','Robert C. Martin',174.20,29);
INSERT INTO LIVRO VALUES(NULL,'Building Microservices: Designing Fine-Grained Systems','Sam Newman',209.30,6);
INSERT INTO LIVRO VALUES(NULL,'Designing Data-Intensive Applications: The Big Ideas Behind Reliable, Scalable, and Maintainable Systems','Martin Kleppmann',82.99,37);
