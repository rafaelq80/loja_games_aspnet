using loja_games.Model;
using Microsoft.EntityFrameworkCore;

namespace loja_games.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura os nomes das tabelas
            modelBuilder.Entity<Produto>().ToTable("tb_produtos");
            modelBuilder.Entity<Categoria>().ToTable("tb_categorias");
            modelBuilder.Entity<User>().ToTable("tb_usuarios");

            // Relacionamento Produto -> Categoria
            _ = modelBuilder.Entity<Produto>()
                .HasOne(_ => _.Categoria)
                .WithMany(t => t.Produto)
                .HasForeignKey("CategoriaId")
                .OnDelete(DeleteBehavior.Cascade);

        }

        // Registro das Entidades
        public DbSet<Produto> Produtos { get; set; } = null!;
        public DbSet<Categoria> Categorias { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
    }
}
