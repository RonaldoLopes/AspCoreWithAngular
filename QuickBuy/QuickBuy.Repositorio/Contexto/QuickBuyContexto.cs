using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using QuickBuy.Dominio.Entidades;
using QuickBuy.Dominio.ObjetoDeValor;
using QuickBuy.Repositorio.Config;

namespace QuickBuy.Repositorio.Contexto
{
    public class QuickBuyContexto : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<ItemPedido> ItensPedido { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }

        public QuickBuyContexto(DbContextOptions options) : base(options)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Classes de mapeamento
            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemPedidoConfiguration());
            modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguration());

            //carga inicial exemplo
            modelBuilder.Entity<FormaPagamento>().HasData(
            new FormaPagamento()
            {
                Id = 1, Nome = "Boleto", Descricao = "Forma de Pagamento Boleto",
            },
            new FormaPagamento()
            {
                Id = 2,
                Nome = "Cartão de crédito",
                Descricao = "Forma de Pagamento Cartão crédito",
            },
            new FormaPagamento()
            {
                Id = 3,
                Nome = "Depósito",
                Descricao = "Forma de Pagamento depósito",
            }
            );

            base.OnModelCreating(modelBuilder);
        }

    }
}
