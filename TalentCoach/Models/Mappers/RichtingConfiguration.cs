using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalentCoach.Models.Domain;

namespace TalentCoach.Models.Mappers
{
    public class RichtingConfiguration : IEntityTypeConfiguration<Richting>
    {
        public void Configure(EntityTypeBuilder<Richting> builder)
        {
            builder.HasMany(r => r.HoofdCompetenties).WithOne().OnDelete(DeleteBehavior.SetNull);
        }
    }
}
