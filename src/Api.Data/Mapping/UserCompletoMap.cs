using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class UserCompletoMap : IEntityTypeConfiguration<UserCompletoEntity>
    {
        public void Configure(EntityTypeBuilder<UserCompletoEntity> builder)
        {
            builder.ToTable("UsuariosCompleto");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(150);

            builder.Property(u => u.Uf)
                .IsRequired()
                .HasMaxLength(2);


            builder.Property(u => u.Municipio)
                .IsRequired()
                .HasMaxLength(100);


            builder.Property(u => u.Cep)
                .IsRequired()
                .HasMaxLength(10);
            
        }
    }
}