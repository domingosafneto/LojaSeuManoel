use DB_LojaSeuManoel

select 
    p.idpedido,
    p.descricao as descricaopedido,
    pp.idproduto,
    prod.nome as nomeproduto,
    prod.preco,
    pp.quantidade,
    (prod.preco * pp.quantidade) as totalitem
from 
    pedido p
    inner join pedidoproduto pp on p.idpedido = pp.idpedido
    inner join produto prod on pp.idproduto = prod.idproduto
where 
    p.idpedido = 1;