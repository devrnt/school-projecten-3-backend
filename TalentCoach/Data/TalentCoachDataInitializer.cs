using System;
using System.Collections.Generic;
using TalentCoach.Controllers;
using TalentCoach.Data.Repositories;
using TalentCoach.Dtos;
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

                var competentie9 =  new Competentie("Staat de klant te woord aan de telefoon of aan de receptie");
                var competentie10 = new Competentie("Schat de tijdsduur van de gewenste behandeling in");
                var competentie11 = new Competentie("Gebruikt informatie- en communicatietechnologie");
                var competentie12 = new Competentie("Maakt een afspraak met de klant en legt deze vast in de agenda");

                var competentie13 = new Competentie("Houdt klantenfiche bij en vult de gegevens van de behandeling in");
                var competentie14 = new Competentie("Verstrekt uitleg over de behandeling en de gebruikte producten");
                var competentie15 = new Competentie("Begeleidt de klant naar de volgende stap en garandeert opvolging");

                var competentie16 = new Competentie("Borstelt en ontwart het haar");
                var competentie17 = new Competentie("Voert elke stap van werkwijze uit volgens verdere behandeling");
                var competentie18 = new Competentie("Brengt de gewenste haar- en huidverzorging aan en masseert eventueel de hoofdhuid");

                var competentie19 = new Competentie("Voert indien nodig een voorverzorging uit");
                var competentie20 = new Competentie("Stelt de juiste omvormingsdiagnose");
                var competentie21 = new Competentie("Voert indien nodig een naverzorging uit");
                var competentie22 = new Competentie("Stemt de techniek en het materieel af op de omvorming (krullen, ontkrullen)");
                var competentie23 = new Competentie("Brengt een product aan");
                var competentie24 = new Competentie("Controleert de omvorming van het haar en respecteert de pauzetijd");
                var competentie25 = new Competentie("Analyseert en verbetert het resultaat indien nodig");
                var competentie26 = new Competentie("Neutraliseert het haar volgens de richtlijnen van het gebruikte product");

                var competentie27 = new Competentie("Stelt de juiste kleurdiagnose");
                var competentie28 = new Competentie("Berekent en past de juiste formule toe");
                var competentie29 = new Competentie("Emulgeert en spoelt het haar uit");
                var competentie30 = new Competentie("Voert een naverzorging uit");
                var competentie31 = new Competentie("Analyseert en verbetert het resultaat indien nodig");

                var competentie32 = new Competentie("Stelt de juiste diagnose");
                var competentie33 = new Competentie("Spoelt het haar");
                var competentie34 = new Competentie("Bereidt het mengsel");
                var competentie35 = new Competentie("Voert een naverzorging uit");
                var competentie36 = new Competentie("Analyseert en verbetert het resultaat indien nodig");

                var competentie37 = new Competentie("Stemt de techniek en het materiaal af op het gelegenheidskapsel");
                var competentie38 = new Competentie("Realiseert opsteekkaspels of vlechten");
                var competentie39 = new Competentie("Gebruikt de juiste producten om het gewenste resultaat te bekomen");
                var competentie40 = new Competentie("Analyseert en verbetert het resultaat indien nodig");
                var competentie41 = new Competentie("Werkt het kaspel af");



                // Activiteit
                var activiteit1 = new Activiteit("Ruimt de werkpost op en maakt hem schoon");
                activiteit1.AddCompetentie(competentie1);
                activiteit1.AddCompetentie(competentie2);
                activiteit1.AddCompetentie(competentie3);
                activiteit1.AddCompetentie(competentie4);

                var activiteit2 = new Activiteit("Neemt deel aan de organisatie van het kapsalon","2e graad", "10/05/2018");
                activiteit2.AddCompetentie(competentie5);
                activiteit2.AddCompetentie(competentie6);
                activiteit2.AddCompetentie(competentie7);
                activiteit2.AddCompetentie(competentie8);

                var activiteit3 = new Activiteit("Legt een afspraak vast met de klant");
                activiteit3.AddCompetentie(competentie9);
                activiteit3.AddCompetentie(competentie10);
                activiteit3.AddCompetentie(competentie11);
                activiteit3.AddCompetentie(competentie12);

                var activiteit4 = new Activiteit("Volgt de klant op","1e graad", "03/02/2017");
                activiteit4.AddCompetentie(competentie13);
                activiteit4.AddCompetentie(competentie14);
                activiteit4.AddCompetentie(competentie15);

                var activiteit5 = new Activiteit("Past shampoos en specifieke haarverzorging toe");
                activiteit5.AddCompetentie(competentie16);
                activiteit5.AddCompetentie(competentie17);
                activiteit5.AddCompetentie(competentie18);

                var activiteit6 = new Activiteit("Vormt het haar blijvend om (krullen, ontkrullen)","3e graad","29/10/2018");
                activiteit6.AddCompetentie(competentie19);
                activiteit6.AddCompetentie(competentie20);
                activiteit6.AddCompetentie(competentie21);
                activiteit6.AddCompetentie(competentie22);
                activiteit6.AddCompetentie(competentie23);
                activiteit6.AddCompetentie(competentie24);
                activiteit6.AddCompetentie(competentie25);
                activiteit6.AddCompetentie(competentie26);

                var activiteit7 = new Activiteit("Kleurt het haar (volledig of haarlokken)");
                activiteit7.AddCompetentie(competentie27);
                activiteit7.AddCompetentie(competentie28);
                activiteit7.AddCompetentie(competentie29);
                activiteit7.AddCompetentie(competentie30);
                activiteit7.AddCompetentie(competentie31);

                var activiteit8 = new Activiteit("Ontkleurt het haar (volledig of haarlokken)","2e graad","12/06/2016");
                activiteit8.AddCompetentie(competentie32);
                activiteit8.AddCompetentie(competentie33);
                activiteit8.AddCompetentie(competentie34);
                activiteit8.AddCompetentie(competentie35);
                activiteit8.AddCompetentie(competentie36);

                var activiteit9 = new Activiteit("Voert een gelegenheidskapsel uit");
                activiteit9.AddCompetentie(competentie37);
                activiteit9.AddCompetentie(competentie38);
                activiteit9.AddCompetentie(competentie39);
                activiteit9.AddCompetentie(competentie40);
                activiteit9.AddCompetentie(competentie41);


                var activiteiten = new List<Activiteit> { activiteit1, activiteit2, activiteit3, activiteit4, activiteit5,
                 activiteit6, activiteit7, activiteit8, activiteit9 };

                _context.Activiteiten.AddRange(activiteiten);
                _context.SaveChanges();

                // Richting
                var richting = new Richting("Haarzorg");
                richting.AddActiviteit(activiteit1);
                richting.AddActiviteit(activiteit2);
                richting.AddActiviteit(activiteit3);
                richting.AddActiviteit(activiteit4);
                richting.AddActiviteit(activiteit5);
                richting.AddActiviteit(activiteit6);
                richting.AddActiviteit(activiteit7);
                richting.AddActiviteit(activiteit8);
                richting.AddActiviteit(activiteit9);


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
                leerling1.AddCompetentieLeerling(activiteit2);
                leerling1.AddCompetentieLeerling(activiteit4);
                leerling1.AddCompetentieLeerling(activiteit6);
                leerling1.AddCompetentieLeerling(activiteit8);
                var leerling2 = new Leerling("Haleydt", "Renaat", new DateTime(1994, 2, 2), Geslacht.Man, "renaat.Haleydt@school.be", "renaathaleydt");
                leerling1.Richting = richting;
                leerling2.Richting = richting;

                var leerlingen = new List<Leerling>() { leerling1, leerling2 };

                _context.AddRange(leerlingen);
                _context.SaveChanges();


                // Werkspreuken
                var werkspreuken = new List<Werkspreuk> {
                        new Werkspreuk(1, "Alle begin is moeilijk ook op school, maar ga ervoor! Hard werken wordt beloond."),
                new Werkspreuk(2, "De eerste week zit er al op, de volgende kan alleen maar beter!")
                };

                _context.AddRange(werkspreuken);
                _context.SaveChanges();

                // Algemene Info
                var algemenInfo = new List<AlgemeneInfo>
                {
                    new AlgemeneInfo("Ik ben ziek, wat nu", "Bij ziekte gelieve de werkgever te contacteren. \nAfwezigheid moet op voorhand verwittigd worden. Is dit door omstandiheden niet mogelijk geef zo snel mogelijk een seintje."),
                    new AlgemeneInfo("Ik kan niet tijdig aanwezig zijn, wat nu?", "Geef zo rap als mogelijk een seintje aan je werkgever.\nProbeer volgende keer iets vroeger te vertrekken."),
                    new AlgemeneInfo("Ik voel me niet goed op men werk", "Contacteer uw persoonlijke stagebegeleider of probeer een gesprek te regelen met je stageleider.")
                };

                _context.AddRange(algemenInfo);
                _context.SaveChanges();

                // Specifieke Info
                var specifiekeInfo = new List<SpecifiekeInfo>
                {
                    new SpecifiekeInfo("Contactgegevens", "Vlaanderenstraat 15\n9000 Gent"){ Werkgever = werkgevers[0] },
                    new SpecifiekeInfo("Verlofregeling", "Minstens 2 weken op voorhand aanvragen"){ Werkgever = werkgevers[0] },
                    new SpecifiekeInfo("Specifieke regels voor werkkledij", "Werkschoenen ten alle tijden dragen\nVeiligheidshelm verplicht"){ Werkgever = werkgevers[0] },
                    new SpecifiekeInfo("Contactgegevens", "Lokerenveldstaat 21\n9300 Aalst"){ Werkgever = werkgevers[1] },
                    new SpecifiekeInfo("Begeleiders", "Jan Peeters\nKaren Dupont\nJef Schoenaerts"){ Werkgever = werkgevers[1] },
                };

                _context.AddRange(specifiekeInfo);
                _context.SaveChanges();

                // Gebruikers
                var gebruiker1 = new Gebruiker()
                {
                    Gebruikersnaam = "JonasDeVrient",
                    Naam = "De Vrient",
                    Voornaam = "Jonas",
                };
                const string gebruiker1wachtwoord = "jonasjonas";


                var gebruiker2 = new Gebruiker()
                {
                    Gebruikersnaam = "BrunoStroobants",
                    Naam = "Stroobants",
                    Voornaam = "Bruno",

                };
                const string gebruiker2wachtwoord = "brunobruno";
               
                var gebruikersRepo = new GebruikersRepository(_context);
                gebruikersRepo.CreateGebruiker(gebruiker1, gebruiker1wachtwoord);
                gebruikersRepo.CreateGebruiker(gebruiker2, gebruiker2wachtwoord);
            }
        }
    }
}
