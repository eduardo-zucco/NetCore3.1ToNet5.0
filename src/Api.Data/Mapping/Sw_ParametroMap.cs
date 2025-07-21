using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class Sw_ParametroMap : IEntityTypeConfiguration<Sw_ParametroEntity>
    {
        public void Configure(EntityTypeBuilder<Sw_ParametroEntity> builder)
        {
            builder.ToTable("SW_PARAMETRO");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("ID").ValueGeneratedOnAdd();

            builder.Property(e => e.Chave)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("CHAVE");

            builder.Property(e => e.Descricao)
                .HasMaxLength(150)
                .HasColumnName("DESCRICAO");

            builder.Property(e => e.Valor)
                .HasColumnName("VALOR");

            builder.Property(e => e.ValorInt)
                .HasColumnName("VALORINT");

            builder.Property(e => e.Filial)
                .HasMaxLength(4)
                .HasColumnName("FILIAL");

            builder.Property(e => e.Usuario)
                .HasColumnName("USUARIO");
        }
    }
}