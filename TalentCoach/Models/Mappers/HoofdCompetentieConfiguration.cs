using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TalentCoach.Models.Mappers
{
    public class HoofdCompetentieConfiguration : IEntityTypeConfiguration<HoofdCompetentie>
    {
        public void Configure(EntityTypeBuilder<HoofdCompetentie> builder)
        {
            //builder.HasMany(h => h.DeelCompetenties).WithOne().OnDelete(DeleteBehavior.cascade);

        }
    }
}
