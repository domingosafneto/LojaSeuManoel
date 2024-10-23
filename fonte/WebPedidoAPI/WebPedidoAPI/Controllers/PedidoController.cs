using Microsoft.AspNetCore.Mvc;
using WebPedidoAPI.DTOs;
using WebPedidoAPI.Services;

namespace WebPedidoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly EmbalagemService _embalagemService;

        public PedidoController(EmbalagemService embalagemService)
        {
            _embalagemService = embalagemService;
        }
        
        [HttpPost("embalar")]
        public IActionResult EmbalarPedidos([FromBody] List<PedidoDTO> pedidos)
        {
            try
            {
                if (pedidos == null || pedidos.Count == 0)
                {
                    return BadRequest(new { message = "Nenhum pedido fornecido." });
                }
                
                var resultado = _embalagemService.EmbalarProdutos(pedidos);
                
                return Ok(new { pedidos = resultado });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }

}
