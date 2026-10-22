using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.EntitiesConfigurations;

public class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(150);
        builder.Property(c => c.Descricao)
            .HasMaxLength(150);      
    }
}
