using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TalentCoach.Models.Domain;

namespace TalentCoach.Models.Mappers
{
    public class LeerlingDeelConfiguration : IEntityTypeConfiguration<LeerlingDeelCompetentie>
    {
        public void Configure(EntityTypeBuilder<LeerlingDeelCompetentie> builder)
        {
            builder.HasMany(ldc => ldc.Beoordelingen);
            //builder.HasOne(ldc => ldc.Leerling);
            builder.HasOne(ldc => ldc.DeelCompetentie);
        }
    }
}
