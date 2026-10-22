using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.EntitiesConfigurations;

public class NotaConfiguration : IEntityTypeConfiguration<Nota>
{
    public void Configure(EntityTypeBuilder<Nota> builder)
    {
        builder.HasKey(n => n.Id);
        builder.Property(n => n.ValorNota)
            .IsRequired();
        builder.Property(n => n.MatriculaId)
            .IsRequired();

        builder.HasOne(n => n.Matricula)
            .WithMany(m => m.Notas)
            .HasForeignKey(n => n.MatriculaId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
