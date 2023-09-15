using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPottential.Entities
{
    public class Venda
    {
        public int Id { get; set; }
        public Vendedor Vendedor { get; set; }
        public DateTime Data { get; set; }
        public string IdentificadorPedido { get; set; }
        public List<ItemVenda> ItensVenda { get; set; }
        public string Status { get; set; }
    }

    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
    }

    public class ItemVenda
    {
        public int Id { get; set; }
        public string NomeProduto { get; set; }
        public decimal Preco { get; set; }
    }
}