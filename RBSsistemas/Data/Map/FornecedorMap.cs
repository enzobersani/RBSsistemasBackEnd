using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RBSsistemas.Models;

namespace RBSsistemas.Data.Map
{
    public class FornecedorMap : IEntityTypeConfiguration<FornecedorModel>
    {
        public void Configure(EntityTypeBuilder<FornecedorModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.NomeFantasia).IsRequired().HasMaxLength(150);
            builder.Property(x => x.RazaoSocial).IsRequired().HasMaxLength(150);
            builder.Property(x => x.CNPJ).IsRequired().HasMaxLength(14);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(150);
            builder.Property(x => x.Telefone).IsRequired().HasMaxLength(11);
        }
    }
}
