USE DB_LojaSeuManoel
GO

-- script de carga 

-- cadastro de produto
INSERT INTO Produto (Nome, Preco, Altura, Largura, Comprimento) VALUES ('Produto 1', 150.75, 75, 45, 35);

INSERT INTO Produto (Nome, Preco, Altura, Largura, Comprimento) VALUES ('Produto 2', 200, 60.50, 40, 30);

INSERT INTO Produto (Nome, Preco, Altura, Largura, Comprimento) VALUES ('Produto 3', 320.99, 120, 55, 50);

INSERT INTO Produto (Nome, Preco, Altura, Largura, Comprimento) VALUES ('Produto 4', 450, 90, 60, 45);

INSERT INTO Produto (Nome, Preco, Altura, Largura, Comprimento) VALUES ('Produto 5', 600, 110, 70, 65);
GO

-- cadastro de pedidos
INSERT INTO Pedido (Descricao, DataPedido) VALUES ('Pedido 1', CAST(GETDATE() AS DATE)); 

INSERT INTO Pedido (Descricao, DataPedido) VALUES ('Pedido 2', CAST(GETDATE() AS DATE));  

INSERT INTO Pedido (Descricao, DataPedido) VALUES ('Pedido 3', CAST(GETDATE() - 1 AS DATE));  

INSERT INTO Pedido (Descricao, DataPedido) VALUES ('Pedido 4', CAST(GETDATE() - 1 AS DATE));  

INSERT INTO Pedido (Descricao, DataPedido) VALUES ('Pedido 5', CAST(GETDATE() - 1 AS DATE));  
GO


-- itens dos pedidos
INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (1, 1, 2);  

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (1, 3, 1); 

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (2, 2, 1);  

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (2, 4, 2);  

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (2, 5, 1);  

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (3, 2, 1);  

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (4, 1, 1);  

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (4, 2, 2); 

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (4, 4, 1);  

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (4, 5, 3);  

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (5, 3, 2);  

INSERT INTO PedidoProduto (IdPedido, IdProduto, Quantidade) VALUES (5, 4, 1); 
GO






