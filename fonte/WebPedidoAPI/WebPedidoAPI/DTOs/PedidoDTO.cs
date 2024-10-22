namespace WebPedidoAPI.DTOs
{
    public class PedidoDTO
    {
        public int Pedido_Id { get; set; }

        public List<ProdutoDTO> Produtos { get; set; }
    }
}
