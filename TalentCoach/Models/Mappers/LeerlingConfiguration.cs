using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentCoach.Models.Domain;

namespace TalentCoach.Models.Mappers
{
    public class LeerlingConfiguration : IEntityTypeConfiguration<Leerling>
    {
        public void Configure(EntityTypeBuilder<Leerling> builder)
        {
            builder.Ignore(l => l.VerwijderdeWerkaanbiedingen);
            builder.Ignore(l => l.BewaardeWerkaanbiedingen);
            builder.HasMany(l => l.HoofdCompetenties).WithOne().OnDelete(DeleteBehavior.Cascade);
            //builder.Ignore(l => l.HoofdCompetenties);
        }
    }
}
