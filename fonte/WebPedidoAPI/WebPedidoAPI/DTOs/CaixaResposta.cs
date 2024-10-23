namespace WebPedidoAPI.DTOs
{
    public class CaixaResposta
    {
        public string CaixaId { get; set; }

        public List<string> Produtos { get; set; }

        public string Observacao { get; set; } // produtos que não cabem em caixa alguma
    }
}
