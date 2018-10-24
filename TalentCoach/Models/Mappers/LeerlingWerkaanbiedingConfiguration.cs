using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentCoach.Models.Domain;

namespace TalentCoach.Models.Mappers
{
    public class LeerlingWerkaanbiedingConfiguration : IEntityTypeConfiguration<LeerlingWerkaanbieding>
    {

        public void Configure(EntityTypeBuilder<LeerlingWerkaanbieding> builder)
        {
            builder.HasKey(lw => new { lw.LeerlingId, lw.WerkaanbiedingId });

            builder.HasOne(lw => lw.Leerling)
                   .WithMany(l => l.GereageerdeWerkaanbiedingen)
                   .HasForeignKey(lw => lw.LeerlingId);

            builder.HasOne(lw => lw.Werkaanbieding)
                   .WithMany()
                   .HasForeignKey(lw => lw.WerkaanbiedingId);
        }
    }
}
