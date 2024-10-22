using WebPedidoAPI.DTOs;
using WebPedidoAPI.Models;

namespace WebPedidoAPI.Services
{
    public class EmbalagemService
    {
        public List<Caixa> caixasDisponiveis = new List<Caixa>
    {
        new Caixa { Id = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
        new Caixa { Id = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
        new Caixa { Id = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
    };

        // Método para embalar produtos e retornar as caixas
        public Dictionary<int, List<CaixaDTO>> EmbalarProdutos(List<PedidoDTO> pedidos)
        {
            var resultado = new Dictionary<int, List<CaixaDTO>>();

            foreach (var pedido in pedidos)
            {
                var caixasParaPedido = new List<CaixaDTO>();

                foreach (var produto in pedido.Produtos)
                {
                    var caixaEscolhida = caixasDisponiveis
                        .FirstOrDefault(c => produto.Dimensoes.Altura <= c.Altura &&
                                             produto.Dimensoes.Largura <= c.Largura &&
                                             produto.Dimensoes.Comprimento <= c.Comprimento);

                    if (caixaEscolhida == null)
                    {
                        throw new Exception($"Nenhuma caixa disponível para o produto {produto.Produto_Id}");
                    }

                    var caixaDTO = caixasParaPedido.FirstOrDefault(c => c.CaixaId == caixaEscolhida.Id);
                    if (caixaDTO == null)
                    {
                        caixaDTO = new CaixaDTO
                        {
                            CaixaId = caixaEscolhida.Id,
                            Produtos = new List<string>()
                        };
                        caixasParaPedido.Add(caixaDTO);
                    }

                    caixaDTO.Produtos.Add(produto.Produto_Id);
                }

                resultado.Add(pedido.Pedido_Id, caixasParaPedido);
            }

            return resultado;
        }
    }

}
