namespace WebPedidoAPI.DTOs
{
    public class EmbalarResposta
    {
        public int PedidoId { get; set; }

        public List<CaixaResposta> Caixas { get; set; }
    }
}
