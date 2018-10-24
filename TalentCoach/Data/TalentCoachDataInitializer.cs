using System;
using System.Collections.Generic;
using TalentCoach.Models;
using TalentCoach.Models.Domain;

namespace TalentCoach.Data
{
    public class TalentCoachDataInitializer
    {
        private readonly ApplicationDbContext _context;

        public TalentCoachDataInitializer(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitializeData()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {

                // Competenties
                var competentie1 = new Competentie("Houdt zich aan de richtlijnen voor hygiëne, veiligheid en ergonomie");
                var competentie2 = new Competentie("Ruimt de gebruikte werkpost op na elke behandeling en reinigt deze");
                var competentie3 = new Competentie("Reinigt het gebruikte materieel en ontsmet indien nodig");
                var competentie4 = new Competentie("Sorteert afval volgens de richtlijnen");

                var competentie5 = new Competentie("Houdt zich aan de richtlijnen voor hygiëne, veiligheid en ergonomie");
                var competentie6 = new Competentie("Ruimt de gebruikte werkpost op na elke behandeling en reinigt deze");
                var competentie7 = new Competentie("Reinigt het gebruikte materieel en ontsmet indien nodig");
                var competentie8 = new Competentie("Sorteert afval volgens de richtlijnen");


                // Activiteit
                var activiteit1 = new Activiteit("Ruimt de werkpost op en maakt hem schoon");
                activiteit1.AddCompetentie(competentie1);
                activiteit1.AddCompetentie(competentie2);
                activiteit1.AddCompetentie(competentie3);
                activiteit1.AddCompetentie(competentie4);

                var activiteit2 = new Activiteit("Neemt deel aan de organisatie van het kapsalon");
                activiteit2.AddCompetentie(competentie5);
                activiteit2.AddCompetentie(competentie6);
                activiteit2.AddCompetentie(competentie7);
                activiteit2.AddCompetentie(competentie8);

                var activiteiten = new List<Activiteit> { activiteit1, activiteit2 };

                _context.Activiteiten.AddRange(activiteiten);
                _context.SaveChanges();

                // Richting
                var richting = new Richting("Haarzorg");
                richting.AddActiviteit(activiteit1);
                richting.AddActiviteit(activiteit2);

                _context.Add(richting);
                _context.SaveChanges();

                // Werkgevers
                var werkgevers = new List<Werkgever>
                {
                    new Werkgever("Jan De Nul", "Zeestraat 2, 9300 Aalst", "jan@denul.be", 053305746),
                    new Werkgever("Kapsalon Dina", "Dorp 15, 9200 Gent", "dina@kapsalon.be", 0476345197),
                    new Werkgever("Dunder Mifflin", "Scranton, PA", "dundermifflin@theoffice.com", 04987602)
                };
                _context.AddRange(werkgevers);
                _context.SaveChanges();

                // Werkaanbiedingen
                var werkaanbiedingen = new List<Werkaanbieding>
                {
                    new Werkaanbieding("Loodgieter op een boot") { Tags = "zelfstandig arbeider loodgieter", Werkgever = werkgevers[0] },
                    new Werkaanbieding("Stage in kapsalon Dina") { Tags = "teamwork bediende kapper", Werkgever = werkgevers[1] },
                    new Werkaanbieding("Assistent boekhouder") { Tags = "zelfstandig bediende boekhouden", Werkgever = werkgevers[2] },
                    new Werkaanbieding("Baggerwerk") { Tags = "teamwork bagger", Werkgever = werkgevers[0] },
                    new Werkaanbieding("Administratief bediende") { Tags = "zelfstandig administratief bediende", Werkgever = werkgevers[2] }
                };

                werkaanbiedingen[0].AddProject(activiteit1);
                werkaanbiedingen[1].AddProject(activiteit2);


                _context.AddRange(werkaanbiedingen);
                _context.SaveChanges();

                // Leerlingen
                var leerling1 = new Leerling("Dhondt", "Sam", new DateTime(1993, 7, 5), Geslacht.Man, "sam.dhondt@school.be", "samdhondt") { Interesses = "teamwork" };
                leerling1.AddGereageerdeWerkaanbieding(werkaanbiedingen[0], Like.Yes);
                leerling1.AddGereageerdeWerkaanbieding(werkaanbiedingen[3], Like.No);
                var leerling2 = new Leerling("Haleydt", "Renaat", new DateTime(1994, 2, 2), Geslacht.Man, "renaat.Haleydt@school.be", "renaathaleydt");
                leerling1.Richting = richting;
                leerling2.Richting = richting;

                var leerlingen = new List<Leerling>() { leerling1, leerling2 };

                _context.AddRange(leerlingen);
                _context.SaveChanges();


                // Werkspreuken
                var werkspreuken = new List<Werkspreuk> {
                        new Werkspreuk(1, "Eerste week is altijd moeilijk. Toch succes"),
                new Werkspreuk(2, "De tweede week is van start, blijven volhouden!")
            };

                _context.AddRange(werkspreuken);
                _context.SaveChanges();

            }
        }
    }
}
