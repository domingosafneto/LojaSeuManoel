namespace WebPedidoAPI.Models
{
    public class PedidoProduto
    {
        public int IdPedido { get; set; }
        public Pedido Pedido { get; set; }

        public int IdProduto { get; set; }        
        public Produto Produto { get; set; }

        public int Quantidade { get; set; }
    }
}
