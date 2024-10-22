using System.ComponentModel.DataAnnotations.Schema;

namespace WebPedidoAPI.Models
{
    [Table("Pedido")]
    public class Pedido
    {
        public int IdPedido { get; set; }

        public string Descricao { get; set; }

        public DateTime DataPedido { get; set; } 
    }
}
