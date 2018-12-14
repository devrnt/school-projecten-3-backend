using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Mappers
{
    public class DeelCompetentieConfiguration : IEntityTypeConfiguration<HoofdCompetentie>
    {
        public void Configure(EntityTypeBuilder<HoofdCompetentie> builder)
        {
            builder.HasMany(r => r.DeelCompetenties).WithOne().OnDelete(DeleteBehavior.Cascade);

        }
    }
}
