using Microsoft.EntityFrameworkCore;
using RBSsistemas.Data.Map;
using RBSsistemas.Models;

namespace RBSsistemas.Data
{
    public class RBSsistemasDBcontext : DbContext
    {
        public RBSsistemasDBcontext(DbContextOptions<RBSsistemasDBcontext> options)
            : base(options)
        {
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
        public DbSet<FornecedorModel> Fornecedor { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            base.OnModelCreating(modelBuilder);
        }
    } 
}
