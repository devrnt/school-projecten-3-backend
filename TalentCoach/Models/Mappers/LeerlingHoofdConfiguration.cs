using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentCoach.Models.Domain;

namespace TalentCoach.Models.Mappers
{
    public class LeerlingHoofdConfiguration : IEntityTypeConfiguration<LeerlingHoofdCompetentie>
    {
        public void Configure(EntityTypeBuilder<LeerlingHoofdCompetentie> builder)
        {
            builder.HasMany(lhc => lhc.DeelCompetenties);
            //builder.HasOne(lhc => lhc.Leerling).WithMany(l => l.HoofdCompetenties);
            builder.HasOne(lhc => lhc.HoofdCompetentie);
            //builder.Ignore(l => l.HoofdCompetenties);
        }
    }
}
