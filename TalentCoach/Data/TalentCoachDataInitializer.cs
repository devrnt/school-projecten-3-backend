﻿using System;
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
                var competentie1 = new DeelCompetentie("Houdt zich aan de richtlijnen voor hygiëne, veiligheid en ergonomie");
                var competentie2 = new DeelCompetentie("Ruimt de gebruikte werkpost op na elke behandeling en reinigt deze");
                var competentie3 = new DeelCompetentie("Reinigt het gebruikte materieel en ontsmet indien nodig");
                var competentie4 = new DeelCompetentie("Sorteert afval volgens de richtlijnen");

                var competentie5 = new DeelCompetentie("Houdt zich aan de richtlijnen voor hygiëne, veiligheid en ergonomie");
                var competentie6 = new DeelCompetentie("Ruimt de gebruikte werkpost op na elke behandeling en reinigt deze");
                var competentie7 = new DeelCompetentie("Reinigt het gebruikte materieel en ontsmet indien nodig");
                var competentie8 = new DeelCompetentie("Sorteert afval volgens de richtlijnen");

                var competentie9 = new DeelCompetentie("Staat de klant te woord aan de telefoon of aan de receptie");
                var competentie10 = new DeelCompetentie("Schat de tijdsduur van de gewenste behandeling in");
                var competentie11 = new DeelCompetentie("Gebruikt informatie- en communicatietechnologie");
                var competentie12 = new DeelCompetentie("Maakt een afspraak met de klant en legt deze vast in de agenda");

                var competentie13 = new DeelCompetentie("Houdt klantenfiche bij en vult de gegevens van de behandeling in");
                var competentie14 = new DeelCompetentie("Verstrekt uitleg over de behandeling en de gebruikte producten");
                var competentie15 = new DeelCompetentie("Begeleidt de klant naar de volgende stap en garandeert opvolging");

                var competentie16 = new DeelCompetentie("Borstelt en ontwart het haar");
                var competentie17 = new DeelCompetentie("Voert elke stap van werkwijze uit volgens verdere behandeling");
                var competentie18 = new DeelCompetentie("Brengt de gewenste haar- en huidverzorging aan en masseert eventueel de hoofdhuid");

                var competentie19 = new DeelCompetentie("Voert indien nodig een voorverzorging uit");
                var competentie20 = new DeelCompetentie("Stelt de juiste omvormingsdiagnose");
                var competentie21 = new DeelCompetentie("Voert indien nodig een naverzorging uit");
                var competentie22 = new DeelCompetentie("Stemt de techniek en het materieel af op de omvorming (krullen, ontkrullen)");
                var competentie23 = new DeelCompetentie("Brengt een product aan");
                var competentie24 = new DeelCompetentie("Controleert de omvorming van het haar en respecteert de pauzetijd");
                var competentie25 = new DeelCompetentie("Analyseert en verbetert het resultaat indien nodig");
                var competentie26 = new DeelCompetentie("Neutraliseert het haar volgens de richtlijnen van het gebruikte product");

                var competentie27 = new DeelCompetentie("Stelt de juiste kleurdiagnose");
                var competentie28 = new DeelCompetentie("Berekent en past de juiste formule toe");
                var competentie29 = new DeelCompetentie("Emulgeert en spoelt het haar uit");
                var competentie30 = new DeelCompetentie("Voert een naverzorging uit");
                var competentie31 = new DeelCompetentie("Analyseert en verbetert het resultaat indien nodig");

                var competentie32 = new DeelCompetentie("Stelt de juiste diagnose");
                var competentie33 = new DeelCompetentie("Spoelt het haar");
                var competentie34 = new DeelCompetentie("Bereidt het mengsel");
                var competentie35 = new DeelCompetentie("Voert een naverzorging uit");
                var competentie36 = new DeelCompetentie("Analyseert en verbetert het resultaat indien nodig");

                var competentie37 = new DeelCompetentie("Stemt de techniek en het materiaal af op het gelegenheidskapsel");
                var competentie38 = new DeelCompetentie("Realiseert opsteekkaspels of vlechten");
                var competentie39 = new DeelCompetentie("Gebruikt de juiste producten om het gewenste resultaat te bekomen");
                var competentie40 = new DeelCompetentie("Analyseert en verbetert het resultaat indien nodig");
                var competentie41 = new DeelCompetentie("Werkt het kaspel af");



                // Activiteit
                var activiteit1 = new HoofdCompetentie("Ruimt de werkpost op en maakt hem schoon", "1e graad");
                activiteit1.AddCompetentie(competentie1);
                activiteit1.AddCompetentie(competentie2);
                activiteit1.AddCompetentie(competentie3);
                activiteit1.AddCompetentie(competentie4);

                var activiteit2 = new HoofdCompetentie("Neemt deel aan de organisatie van het kapsalon", "2e graad");
                activiteit2.AddCompetentie(competentie5);
                activiteit2.AddCompetentie(competentie6);
                activiteit2.AddCompetentie(competentie7);
                activiteit2.AddCompetentie(competentie8);

                var activiteit3 = new HoofdCompetentie("Legt een afspraak vast met de klant", "3e graad");
                activiteit3.AddCompetentie(competentie9);
                activiteit3.AddCompetentie(competentie10);
                activiteit3.AddCompetentie(competentie11);
                activiteit3.AddCompetentie(competentie12);

                var activiteit4 = new HoofdCompetentie("Volgt de klant op", "1e graad");
                activiteit4.AddCompetentie(competentie13);
                activiteit4.AddCompetentie(competentie14);
                activiteit4.AddCompetentie(competentie15);

                var activiteit5 = new HoofdCompetentie("Past shampoos en specifieke haarverzorging toe", "2e graad");
                activiteit5.AddCompetentie(competentie16);
                activiteit5.AddCompetentie(competentie17);
                activiteit5.AddCompetentie(competentie18);

                var activiteit6 = new HoofdCompetentie("Vormt het haar blijvend om (krullen, ontkrullen)", "3e graad");
                activiteit6.AddCompetentie(competentie19);
                activiteit6.AddCompetentie(competentie20);
                activiteit6.AddCompetentie(competentie21);
                activiteit6.AddCompetentie(competentie22);
                activiteit6.AddCompetentie(competentie23);
                activiteit6.AddCompetentie(competentie24);
                activiteit6.AddCompetentie(competentie25);
                activiteit6.AddCompetentie(competentie26);

                var activiteit7 = new HoofdCompetentie("Kleurt het haar (volledig of haarlokken)", "1e graad");
                activiteit7.AddCompetentie(competentie27);
                activiteit7.AddCompetentie(competentie28);
                activiteit7.AddCompetentie(competentie29);
                activiteit7.AddCompetentie(competentie30);
                activiteit7.AddCompetentie(competentie31);

                var activiteit8 = new HoofdCompetentie("Ontkleurt het haar (volledig of haarlokken)", "2e graad");
                activiteit8.AddCompetentie(competentie32);
                activiteit8.AddCompetentie(competentie33);
                activiteit8.AddCompetentie(competentie34);
                activiteit8.AddCompetentie(competentie35);
                activiteit8.AddCompetentie(competentie36);

                var activiteit9 = new HoofdCompetentie("Voert een gelegenheidskapsel uit", "2e graad");
                activiteit9.AddCompetentie(competentie37);
                activiteit9.AddCompetentie(competentie38);
                activiteit9.AddCompetentie(competentie39);
                activiteit9.AddCompetentie(competentie40);
                activiteit9.AddCompetentie(competentie41);


                var activiteiten = new List<HoofdCompetentie> { activiteit1, activiteit2, activiteit3, activiteit4, activiteit5,
                 activiteit6, activiteit7, activiteit8, activiteit9 };

                _context.HoofdCompetenties.AddRange(activiteiten);
                _context.SaveChanges();

                // Richting
                var richting = new Richting("Haarzorg", "scissors","red");
                richting.AddHoofdCompetentie(activiteit1);
                richting.AddHoofdCompetentie(activiteit2);
                richting.AddHoofdCompetentie(activiteit3);
                richting.AddHoofdCompetentie(activiteit4);
                richting.AddHoofdCompetentie(activiteit5);
                richting.AddHoofdCompetentie(activiteit6);
                richting.AddHoofdCompetentie(activiteit7);
                richting.AddHoofdCompetentie(activiteit8);
                richting.AddHoofdCompetentie(activiteit9);


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

                //werkaanbiedingen[0].AddProject(activiteit1);
                //werkaanbiedingen[1].AddProject(activiteit2);


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
