using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjetoPottential.Entities;
using ProjetoPottential.Context;

namespace ProjetoPottential.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : ControllerBase
    {
        private readonly VendaContext _context;

        public VendaController(VendaContext context)
        {
            _context = context;
        }
        
        [HttpPost]
        public IActionResult RegistrarVenda([FromBody] Venda vendaDTO)
        {
            if (vendaDTO == null || vendaDTO.ItensVenda == null || !vendaDTO.ItensVenda.Any())
            {
                return BadRequest("Dados de venda inválidos");
            }

            // Valide os dados da venda conforme necessário
            // ...

            var vendedor = vendaDTO.Vendedor;

            // Crie uma nova venda com status "Aguardando pagamento"
            var novaVenda = new Venda
            {
                Vendedor = vendedor,
                Data = DateTime.Now,
                Status = "Aguardando pagamento",
                ItensVenda = vendaDTO.ItensVenda
            };

            _context.Vendas.Add(novaVenda);
            _context.SaveChanges();

            return CreatedAtAction("BuscarVenda", new { id = novaVenda.Id }, novaVenda);
        }

        [HttpGet("{id}")]
        public IActionResult BuscarVenda(int id)
        {
            var venda = ObterVendaPorId(id);

            if (venda == null)
            {
                return NotFound(); // Retorna 404 se a venda não for encontrada
            }

            return Ok(venda);
        }

        private Venda ObterVendaPorId(int id)
        {
            // Simule a busca da venda por ID (substitua por sua lógica real)
            // Exemplo: return _vendaRepository.GetById(id);

            // Este é um exemplo simples com uma venda em memória (simulado)
            var venda = new Venda
            {
                Id = id,
                Vendedor = new Vendedor { Id = 1, Nome = "Vendedor de Exemplo" },
                Data = DateTime.Now,
                IdentificadorPedido = "12345",
                ItensVenda = new List<ItemVenda>
                {
                    new ItemVenda { Id = 1, NomeProduto = "Produto A", Preco = 10.0m },
                    new ItemVenda { Id = 2, NomeProduto = "Produto B", Preco = 15.0m }
                },
                Status = "Aguardando pagamento"
            };

            return venda;
        }

        [HttpPut("{id}")]
        public IActionResult AtualizarStatusVenda(int id, [FromBody] string novoStatus)
        {
            var venda = ObterVendaPorId(id);

            if (venda == null)
            {
                return NotFound(); // Retorna 404 se a venda não for encontrada
            }

            // Valide o novoStatus e permita somente as transições válidas
            // ...

            venda.Status = novoStatus;

            // Atualize a venda (simulando uma persistência em memória)
            // Exemplo: _vendaRepository.Update(venda);

            return Ok(venda);
        }
    }
}
