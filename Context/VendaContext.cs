using System;
using Microsoft.EntityFrameworkCore;
using ProjetoPottential.Entities;

namespace ProjetoPottential.Context
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options) : base(options) { }

    public DbSet<Venda> Vendas { get; set; }
    public DbSet<Vendedor> Vendedores { get; set; }
    public DbSet<ItemVenda> ItensVenda { get; set; }
    }
}