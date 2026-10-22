using Escola.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Escola.Infra.Data.EntitiesConfigurations;

public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.UsuarioId)
            .IsRequired();
        builder.Property(m => m.TurmaId)
            .IsRequired();

        builder.HasOne(m => m.Usuario)
            .WithMany(u => u.Matriculas)
            .HasForeignKey(m => m.UsuarioId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(m => m.Turma)
            .WithMany(u => u.Matriculas)
            .HasForeignKey(m => m.TurmaId)
            .OnDelete(DeleteBehavior.NoAction);

    }
}
