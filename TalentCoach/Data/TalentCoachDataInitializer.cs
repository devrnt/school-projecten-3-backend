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
        private ILeerlingenRepository _llnRepo;
        private IRichtingenRepository _richtingRepo;

        public TalentCoachDataInitializer(ApplicationDbContext context, ILeerlingenRepository repo1, IRichtingenRepository repo2)
        {
            _context = context;
            _llnRepo = repo1;
            _richtingRepo = repo2;
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
                var richtingHaarzorg = new Richting("Haarzorg", "scissors", "rood", "BSO");
                richtingHaarzorg.AddHoofdCompetentie(activiteit1);
                richtingHaarzorg.AddHoofdCompetentie(activiteit2);
                richtingHaarzorg.AddHoofdCompetentie(activiteit3);
                richtingHaarzorg.AddHoofdCompetentie(activiteit4);
                richtingHaarzorg.AddHoofdCompetentie(activiteit5);
                richtingHaarzorg.AddHoofdCompetentie(activiteit6);
                richtingHaarzorg.AddHoofdCompetentie(activiteit7);
                richtingHaarzorg.AddHoofdCompetentie(activiteit8);
                richtingHaarzorg.AddHoofdCompetentie(activiteit9);

                // Voeg later competenties toe
                var richtingInformatica = new Richting("Informatica", "laptop", "blauw", "TSO");
                var richtingKantoor = new Richting("Kantoor", "computer", "paars", "TSO");
                var richtingVerkoop = new Richting("Verkoop", "sales", "groen", "TSO");
                var richtingBasisMechanica = new Richting("Basismechanica carrosserie", "wrench", "oranje", "TSO");
                var richtingHandel = new Richting("Handel", "weegschaal", "geel", "TSO");
                var richtingElektrischeInstallaties = new Richting("Elektrische installaties Elektrotechnicus duaal (7de jaar)", "bliksem", "zwart", "TSO");
                var richtingAutoTechnieken = new Richting("Auto technieken", "car", "blauw", "TSO");
                var richtingMechanischeTechnieken = new Richting("Mechanische technieken", "cogs", "groen", "TSO");
                var richtingTechniekWetenschappen = new Richting("Techniek-wetenschappen", "flask", "geel", "TSO");
                var richtingVoedingVerzorging = new Richting("Voeding-verzorging", "medkit", "oranje", "TSO");
                var richtingVerzorging = new Richting("Verzorging", "doctor", "oranje", "TSO");
                var richtingSociaalTechnischeWetenschappen = new Richting("Sociaal-technische Wetenschappen", "child", "rood", "TSO");
                var richtingBuurtsportMedewerker = new Richting("Buurtsport medewerker", "sport", "paars", "Leren en werken");
                var richtingMedewerkerSnackbarKeukenmedewerker = new Richting("Medewerker snackbar | Keukenmedewerker", "food", "blauw", "Leren en werken");
                var richtingMedewerkerGroenEnTuinbeheer = new Richting("Medewerker groen- en tuinbeheer", "plant", "groen", "Leren en werken");
                var richtingOnderhoudswerkerGebouwenTegelzetter = new Richting("Polyvalent onderhoudswerker gebouwen | Tegelzetter", "building", "geel", "TSO");
                var richtingSchilderDecorateur = new Richting("Schilder-decorateur", "paint", "oranje", "Leren en werken");
                var richtingWinkelbediende = new Richting("Winkelbediende", "retail", "rood", "Leren en werken");
                var richtingPCTechnicus = new Richting("PC-technicus", "plug", "paars", "BSO");
                var richtingVerzorgende = new Richting("Verzorgende / zorgkundige", "doctor", "blauw", "BSO");

                var richtingen = new List<Richting>()
                {
                    richtingHaarzorg, richtingInformatica, richtingKantoor, richtingVerkoop, richtingBasisMechanica,richtingHandel,
                    richtingElektrischeInstallaties, richtingAutoTechnieken, richtingMechanischeTechnieken,
                    richtingTechniekWetenschappen, richtingVoedingVerzorging, richtingVerzorging,
                    richtingSociaalTechnischeWetenschappen, richtingBuurtsportMedewerker,
                    richtingMedewerkerSnackbarKeukenmedewerker, richtingMedewerkerGroenEnTuinbeheer,
                    richtingOnderhoudswerkerGebouwenTegelzetter, richtingSchilderDecorateur,
                    richtingWinkelbediende, richtingPCTechnicus, richtingVerzorgende
                };

                richtingen.ForEach(richting => _richtingRepo.AddRichting(richting));
                _richtingRepo.SaveChanges();

                // Werkgevers
                var werkgevers = new List<Werkgever>
                {
                    new Werkgever("Holywood Hairdresser Agency", "Holywood road 12, Los Angeles, CA", "holywoodhair@holywood.com", 0476345197),
                    new Werkgever("Kapsalon Dina", "Dorp 15, 9200 Gent", "dina@kapsalon.be", 0476345197),
                    new Werkgever("Kapper Alfredo", "Nonnemeerstraat 19, 9200 Gent", "alfredo@haarlak.be", 0476345197),
                    new Werkgever("Dunder Mifflin", "Scranton, PA", "dundermifflin@theoffice.com", 04987602),
                    new Werkgever("Jan De Nul", "Zeestraat 2, 9300 Aalst", "jan@denul.be", 053305746),
                };
                _context.AddRange(werkgevers);
                _context.SaveChanges();

                // Werkaanbiedingen
                var list_interesses = new List<string>();
                list_interesses.Add("haar");

                list_interesses.Add("teamwork");
                list_interesses.Add("kindersnit");
                list_interesses.Add("salon");

                list_interesses.Add("zelfstandig");
                list_interesses.Add("ervaring");
                list_interesses.Add("kapper");

                list_interesses.Add("trendy");
                list_interesses.Add("fashion");
                list_interesses.Add("chanel");

                list_interesses.Add("hair coloring");
                list_interesses.Add("artistiek");
                list_interesses.Add("experimenteel");

                list_interesses.Add("bagger");
                list_interesses.Add("boot");
                list_interesses.Add("techniek");

                list_interesses.Add("administratief");
                list_interesses.Add("office");
                list_interesses.Add("kantoor");

                list_interesses.Add("boekhouding");
                list_interesses.Add("management");
                list_interesses.Add("economie");

                var werkaanbiedingen = new List<Werkaanbieding>()
                {
                    new Werkaanbieding("assistent hairdresser voor acteur Bert Pritt")
                    {
                        Werkgever = werkgevers[0]
                    },
                    new Werkaanbieding("Stage in kapsalon Dina")
                    {
                        Werkgever = werkgevers[1]
                    },
                     new Werkaanbieding("Stage bij experimentele kapper Alfredo")
                    {
                        Werkgever = werkgevers[2]
                    },
                    new Werkaanbieding("Assistent boekhouder")
                    {
                        Werkgever = werkgevers[3]
                    },
                    new Werkaanbieding("Baggerwerk")
                    {
                        Werkgever = werkgevers[4]
                    },
                    new Werkaanbieding("Administratief bediende")
                    {
                        Werkgever = werkgevers[3]
                    }
                };
                var tags1 = new List<string>() { list_interesses[0], list_interesses[8], list_interesses[2], list_interesses[9] };
                var tags2 = new List<string>() { list_interesses[0], list_interesses[1], list_interesses[2], list_interesses[3] };
                var tags3 = new List<string>() { list_interesses[0], list_interesses[10], list_interesses[11], list_interesses[12] };
                var tags4 = new List<string>() { list_interesses[16], list_interesses[17], list_interesses[18] };
                var tags5 = new List<string>() { list_interesses[13], list_interesses[14], list_interesses[15] };
                var tags6 = new List<string>() { list_interesses[16], list_interesses[19], list_interesses[20], list_interesses[21] };


                foreach (var item in tags1)
                {
                    werkaanbiedingen[0].AddInteresse(item);
                }

                foreach (var item in tags2)
                {
                    werkaanbiedingen[1].AddInteresse(item);
                }

                foreach (var item in tags3)
                {
                    werkaanbiedingen[2].AddInteresse(item);
                }

                foreach (var item in tags4)
                {
                    werkaanbiedingen[3].AddInteresse(item);
                }

                foreach (var item in tags5)
                {
                    werkaanbiedingen[4].AddInteresse(item);
                }

                foreach (var item in tags6)
                {
                    werkaanbiedingen[5].AddInteresse(item);
                }

                _context.AddRange(werkaanbiedingen);
                _context.SaveChanges();

                // Leerlingen
                var leerling1 = new Leerling("Dhondt", "Sam", new DateTime(1993, 7, 5), Geslacht.Man, "sam.dhondt@school.be") { Werkgever = werkgevers[0] };
                leerling1.AddGereageerdeWerkaanbieding(werkaanbiedingen[0], Like.Yes);
                leerling1.AddGereageerdeWerkaanbieding(werkaanbiedingen[3], Like.No);

                var leerling2 = new Leerling("Haleydt", "Renaat", new DateTime(1994, 2, 2), Geslacht.Man, "renaat.Haleydt@school.be");

                var leerling3 = new Leerling("De Smet", "Eline", new DateTime(1998, 2, 1), Geslacht.Vrouw, "eline.desmet@school.be");

                var leerling4 = new Leerling("Vervaert", "Piet", new DateTime(1996, 4, 16), Geslacht.Man, "piet.vervaert@school.be");

                leerling1.Richting = richtingHaarzorg;
                foreach (var item in tags2)
                {
                    leerling1.AddInteresse(item);
                }
                leerling2.Richting = richtingHaarzorg;
                foreach (var item in tags3)
                {
                    leerling2.AddInteresse(item);
                }
                leerling3.Richting = richtingVerzorging;
                //nog geen passende interesses
                leerling4.Richting = richtingAutoTechnieken;
                foreach (var item in tags5)
                {
                    leerling4.AddInteresse(item);
                }
                _llnRepo.AddLeerling(leerling1);
                var l = richtingHaarzorg.HoofdCompetenties;
                var ler = _llnRepo.AddLeerling(leerling2);
                _llnRepo.AddLeerling(leerling3);
                _llnRepo.AddLeerling(leerling4);

                // Werkspreuken
                var werkspreuken = new List<Werkspreuk> {
                     new Werkspreuk(1, "Alle begin is moeilijk ook op school, maar ga ervoor! Hard werken wordt beloond."),
                     new Werkspreuk(2, "De eerste week zit er al op, de volgende kan alleen maar beter!"),
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

                // === Gebruikers === 
                // Leerlingen - hebben geen toegang tot de webapp
                var gebruikerLeerling1 = new Gebruiker()
                {
                    Gebruikersnaam = "Leerling",
                    GebruikersRol = GebruikersRol.Leerling,
                    ConcreteGebruikerId = 2
                };
                const string gebruiker1wachtwoord = "leerling";


                var gebruikerLeerling2 = new Gebruiker()
                {
                    Gebruikersnaam = "BrunoStroobants",
                    GebruikersRol = GebruikersRol.Leerling,
                    // dit is een tijdelijke link naar een leerling
                    ConcreteGebruikerId = 1
                };
                const string gebruiker2wachtwoord = "brunobruno";

                var gebruikersRepo = new GebruikersRepository(_context);
                gebruikersRepo.CreateGebruiker(gebruikerLeerling1, gebruiker1wachtwoord);
                gebruikersRepo.CreateGebruiker(gebruikerLeerling2, gebruiker2wachtwoord);

                // Leerkrachten - hebben toegang tot het platform
                var gebruikerLeerkracht1 = new Gebruiker()
                {
                    Gebruikersnaam = "SamDhondt",
                    GebruikersRol = GebruikersRol.Leerkracht
                };
                const string gebruikerLeerkracht1wachtwoord = "samsamsam";


                var gebruikerLeerkracht2 = new Gebruiker()
                {
                    Gebruikersnaam = "Leerkracht",
                    GebruikersRol = GebruikersRol.Leerkracht
                };
                const string gebruikerLeerkracht2wachtwoord = "leerkracht";

                var gebruikerLeerkracht3 = new Gebruiker()
                {
                    Gebruikersnaam = "Sofie_DeJuf",
                    GebruikersRol = GebruikersRol.Leerkracht
                };
                const string gebruikerLeerkracht3wachtwoord = "leerkracht";

                var gebruikerLeerkracht4 = new Gebruiker()
                {
                    Gebruikersnaam = "Tom_Barman",
                    GebruikersRol = GebruikersRol.Leerkracht
                };
                const string gebruikerLeerkracht4wachtwoord = "leerkracht";

                var gebruikerLeerkracht5 = new Gebruiker()
                {
                    Gebruikersnaam = "Felix_Steels",
                    GebruikersRol = GebruikersRol.Leerkracht
                };
                const string gebruikerLeerkracht5wachtwoord = "leerkracht";

                var gebruikerLeerkracht6 = new Gebruiker()
                {
                    Gebruikersnaam = "Jan_Demeester",
                    GebruikersRol = GebruikersRol.Leerkracht
                };
                const string gebruikerLeerkracht6wachtwoord = "leerkracht";


                gebruikersRepo.CreateGebruiker(gebruikerLeerkracht1, gebruikerLeerkracht1wachtwoord);
                gebruikersRepo.CreateGebruiker(gebruikerLeerkracht2, gebruikerLeerkracht2wachtwoord);
                gebruikersRepo.CreateGebruiker(gebruikerLeerkracht3, gebruikerLeerkracht3wachtwoord);
                gebruikersRepo.CreateGebruiker(gebruikerLeerkracht4, gebruikerLeerkracht4wachtwoord);
                gebruikersRepo.CreateGebruiker(gebruikerLeerkracht5, gebruikerLeerkracht5wachtwoord);
                gebruikersRepo.CreateGebruiker(gebruikerLeerkracht6, gebruikerLeerkracht6wachtwoord);


                var gebruikerWerkgever = new Gebruiker()
                {
                    Gebruikersnaam = "Werkgever",
                    GebruikersRol = GebruikersRol.Werkgever,
                    // dit is een tijdelijke link naar een werkgever
                    ConcreteGebruikerId = 1
                };
                const string gebruikerWerkgeverWachtwoord = "werkgever";

                gebruikersRepo.CreateGebruiker(gebruikerWerkgever, gebruikerWerkgeverWachtwoord);

                //Leerkrachten aan richting toevoegen
                richtingHaarzorg.AddLeerkracht(gebruikerLeerkracht1);
                richtingHaarzorg.AddLeerkracht(gebruikerLeerkracht3);

                richtingInformatica.AddLeerkracht(gebruikerLeerkracht5);

                richtingKantoor.AddLeerkracht(gebruikerLeerkracht6);

                richtingVerkoop.AddLeerkracht(gebruikerLeerkracht4);

                _context.SaveChanges();


            }
        }
    }
}
