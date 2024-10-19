-- Criação das tabelas
use DB_LojaSeuManoel; 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


-- tabela Produto
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
           WHERE CONSTRAINT_NAME = 'FK_PedidoProduto_Produto')
BEGIN
	ALTER TABLE PedidoProduto DROP CONSTRAINT FK_PedidoProduto_Produto
	PRINT 'A constraint FK_PedidoProduto_Produto foi removida.'
END
GO

IF OBJECT_ID('Produto', 'U') IS NOT NULL
BEGIN
    DROP TABLE Produto
	PRINT 'A tabela Produto foi removida.'	
END
GO

CREATE TABLE Produto (
	IdProduto INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(50) NOT NULL,
	Preco DECIMAL(10,2) NULL,
	Altura DECIMAL(5,2) NULL,
	Largura DECIMAL(5,2) NULL,
	Comprimento DECIMAL(5,2) NULL
);
GO

PRINT 'A tabela Produto foi criada.'
GO


-- tabela Pedido
IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.REFERENTIAL_CONSTRAINTS 
           WHERE CONSTRAINT_NAME = 'FK_PedidoProduto_Pedido')
BEGIN
	ALTER TABLE PedidoProduto DROP CONSTRAINT FK_PedidoProduto_Pedido
	PRINT 'A constraint FK_PedidoProduto_Pedido foi removida.'
END
GO

IF OBJECT_ID('Pedido', 'U') IS NOT NULL
BEGIN
    DROP TABLE Pedido
	PRINT 'A tabela Pedido foi removida.'	
END
GO

CREATE TABLE Pedido (
	IdPedido INT IDENTITY(1,1) PRIMARY KEY,
	Descricao VARCHAR(70) NOT NULL,	
	DataPedido DATE NOT NULL
);
GO

PRINT 'A tabela Pedido foi criada.'
GO


-- tabela PedidoProduto 
IF OBJECT_ID('PedidoProduto', 'U') IS NOT NULL
BEGIN
    DROP TABLE PedidoProduto
	PRINT 'A tabela PedidoProduto foi removida.'	
END
GO

CREATE TABLE PedidoProduto (
	IdPedido INT NOT NULL,
	IdProduto INT NOT NULL,	
	Quantidade INT NOT NULL DEFAULT 1,
	CONSTRAINT PK_PedidoProduto PRIMARY KEY (IdProduto, IdPedido),
	CONSTRAINT FK_PedidoProduto_Pedido FOREIGN KEY (IdPedido) REFERENCES Pedido(IdPedido),
	CONSTRAINT FK_PedidoProduto_Produto FOREIGN KEY (IdProduto) REFERENCES Produto(IdProduto)	
);
GO

PRINT 'A tabela PedidoProduto foi criada.'
GO