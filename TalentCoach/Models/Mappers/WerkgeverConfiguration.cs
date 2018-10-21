using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentCoach.Models.Domain;

namespace TalentCoach.Models.Mappers
{
    public class WerkgeverConfiguration : IEntityTypeConfiguration<Werkgever>
    {
        public void Configure(EntityTypeBuilder<Werkgever> builder)
        {
            builder.HasMany(wg => wg.Werkaanbiedingen)
                .WithOne(wa => wa.Werkgever);
        }
    }
}
