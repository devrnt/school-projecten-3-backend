using System;
using System.Collections.Generic;
using System.Text;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Tests.Data
{
    public class DummyApplicationDbContext
    {
        public List<Leerling> Leerlingen { get; set; }

        public DummyApplicationDbContext()
        {
            Leerlingen = new List<Leerling> {
                new Leerling("Dhondt", "Sam", new DateTime(1994, 1, 1), Geslacht.Man, "sam.dhondt@school.be"),
                new Leerling("Haleydt", "Renaat", new DateTime(1994, 2, 2), Geslacht.Man, "renaat.haleydt@school.be"),
                new Leerling("Stroobants", "Bruno", new DateTime(1997, 3, 3), Geslacht.Man, "bruno.stroobants@school.be"),
                new Leerling("Li", "Hu", new DateTime(1997, 4, 4), Geslacht.Man, "li.hu@school.be"),
                new Leerling("Lisa", "De Meester", new DateTime(1993, 4, 4), Geslacht.Vrouw, "lisa.demeester@school.be")

            };
        }
    }
}
