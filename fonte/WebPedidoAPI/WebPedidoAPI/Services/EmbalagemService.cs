using WebPedidoAPI.DTOs;
using WebPedidoAPI.Models;

namespace WebPedidoAPI.Services
{
    public class EmbalagemService
    {
        public List<Caixa> caixasDisponiveis = new List<Caixa>
    {
        new Caixa { Caixa_Id = "Caixa 1", Altura = 30, Largura = 40, Comprimento = 80 },
        new Caixa { Caixa_Id = "Caixa 2", Altura = 80, Largura = 50, Comprimento = 40 },
        new Caixa { Caixa_Id = "Caixa 3", Altura = 50, Largura = 80, Comprimento = 60 }
    };

        // Método para embalar produtos e retornar as caixas
        public List<EmbalarResposta> EmbalarProdutos(List<PedidoDTO> pedidos)
        {
            var resultado = new List<EmbalarResposta>();

            foreach (var pedido in pedidos)
            {
                var caixasParaPedido = new List<CaixaResposta>();

                foreach (var produto in pedido.Produtos)
                {
                    var caixaEscolhida = caixasDisponiveis
                        .FirstOrDefault(c => produto.Dimensoes.Altura <= c.Altura &&
                                             produto.Dimensoes.Largura <= c.Largura &&
                                             produto.Dimensoes.Comprimento <= c.Comprimento);

                    if (caixaEscolhida == null)
                    {
                        // Adiciona uma caixa com null e uma observação, mas não para a execução
                        caixasParaPedido.Add(new CaixaResposta
                        {
                            CaixaId = null,
                            Produtos = new List<string> { produto.Produto_Id },
                            Observacao = $"Produto {produto.Produto_Id} não cabe em nenhuma caixa disponível."
                        });
                    }
                    else
                    {
                        // Verifica se essa caixa já foi utilizada nesse pedido
                        var caixaExistente = caixasParaPedido.FirstOrDefault(c => c.CaixaId == caixaEscolhida.Caixa_Id);

                        if (caixaExistente != null)
                        {
                            // Adiciona o produto na caixa já existente
                            caixaExistente.Produtos.Add(produto.Produto_Id);
                        }
                        else
                        {
                            // Cria uma nova caixa e adiciona o produto
                            caixasParaPedido.Add(new CaixaResposta
                            {
                                CaixaId = caixaEscolhida.Caixa_Id,
                                Produtos = new List<string> { produto.Produto_Id },
                                Observacao = null
                            });
                        }
                    }
                }

                // Adiciona o resultado do pedido
                resultado.Add(new EmbalarResposta
                {
                    PedidoId = pedido.Pedido_Id,
                    Caixas = caixasParaPedido
                });
            }

            return resultado;
        }
    }

}
