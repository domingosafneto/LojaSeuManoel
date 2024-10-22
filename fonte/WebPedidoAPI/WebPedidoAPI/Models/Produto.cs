using System.ComponentModel.DataAnnotations.Schema;

namespace WebPedidoAPI.Models
{
    [Table("Produto")]
    public class Produto
    {
        public int IdProduto { get; set; }

        public string Nome { get; set; }

        public decimal Preco { get; set; }

        public decimal? Altura { get; set; }

        public decimal? Largura { get; set; }

        public decimal? Comprimento { get; set; }
    }
}
