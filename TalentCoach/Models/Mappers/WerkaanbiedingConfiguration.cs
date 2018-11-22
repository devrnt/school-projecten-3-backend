using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentCoach.Models.Domain;

namespace TalentCoach
{
    public class WerkaanbiedingConfiguration : IEntityTypeConfiguration<Werkaanbieding>
    {
        public void Configure(EntityTypeBuilder<Werkaanbieding> builder)
        {
            builder.HasOne(wa => wa.Werkgever)
                   .WithMany();
        }
    }
}
