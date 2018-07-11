using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;

namespace Ollara
{
    class main
    {
        // Local Database
        static List<Race> races = new List<Race>();
        static List<Background> backgrounds = new List<Background>();
        static Party party;
        static List<Ability> abilities = new List<Ability>();
        static List<Passive> passives = new List<Passive>();
        static List<StatBoost> statBoosts = new List<StatBoost>();

        static Random rand = new Random();

        static void Main(string[] args)
        {
            Preload();
            MainMenu();
        }

        /// <summary>
        /// Preoads all the Databases into each static List to fill data for Race, Background, and Perk information.
        /// </summary>
        static void Preload()
        {
            XmlReader reader = XmlReader.Create("C:/users/Tristan.Birkinshaw/source/repos/ollara/Ollara/Ollara/Data.xml");
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Race"))
                {
                    if (reader.HasAttributes)
                    {
                        float[] attributes = { float.Parse(reader.GetAttribute("health")), float.Parse(reader.GetAttribute("energy")), float.Parse(reader.GetAttribute("might")), float.Parse(reader.GetAttribute("finesse")), float.Parse(reader.GetAttribute("astra")), float.Parse(reader.GetAttribute("agility")), float.Parse(reader.GetAttribute("toughness")), float.Parse(reader.GetAttribute("acuity")), float.Parse(reader.GetAttribute("empathy")), float.Parse(reader.GetAttribute("contempt")) };
                        races.Add(new Race(reader.GetAttribute("name"), reader.GetAttribute("denonym"), attributes, reader.GetAttribute("description")));
                    }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Background"))
                {
                    if (reader.HasAttributes)
                    {
                        float[] attributes = { float.Parse(reader.GetAttribute("health")), float.Parse(reader.GetAttribute("energy")), float.Parse(reader.GetAttribute("might")), float.Parse(reader.GetAttribute("finesse")), float.Parse(reader.GetAttribute("astra")), float.Parse(reader.GetAttribute("agility")), float.Parse(reader.GetAttribute("toughness")), float.Parse(reader.GetAttribute("acuity")), float.Parse(reader.GetAttribute("empathy")), float.Parse(reader.GetAttribute("contempt")) };
                        backgrounds.Add(new Background(reader.GetAttribute("name"), attributes, reader.GetAttribute("description")));
                    }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Ability"))
                {
                    if (reader.HasAttributes)
                    {
                        abilities.Add(new Ability(reader.GetAttribute("name"), float.Parse(reader.GetAttribute("power")), float.Parse(reader.GetAttribute("accuracy")), float.Parse(reader.GetAttribute("cost")), reader.GetAttribute("description")));
                    }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Passive"))
                {
                    if (reader.HasAttributes)
                    {
                        passives.Add(new Passive(reader.GetAttribute("name"), (Effect)Enum.Parse(typeof(Effect), reader.GetAttribute("effect")), reader.GetAttribute("description")));
                    }
                }
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "StatBoost"))
                {
                    if (reader.HasAttributes)
                    {
                        statBoosts.Add(new StatBoost(reader.GetAttribute("name"), (Stat)Enum.Parse(typeof(Stat), reader.GetAttribute("stat")), float.Parse(reader.GetAttribute("amount")), reader.GetAttribute("description")));
                    }
                }
            }
            // Debug
            Console.WriteLine("Checking Races...");
            foreach (Race race in races)
            {
                Console.WriteLine("{0} ({1}): HP:{2} EN:{3} MI:{4} FI:{5} AS:{6} AG:{7} TO:{8} AC:{9} EM:{10} CO:{11} {12}", race.Name, race.Denonym, race.Health, race.Energy, race.Might, race.Finesse, race.Astra, race.Agility, race.Toughness, race.Acuity, race.Empathy, race.Contempt, race.Description);
            }
            Console.WriteLine("\nChecking Backgrounds...");
            foreach (Background background in backgrounds)
            {
                Console.WriteLine("{0}: HP:{1} EN:{2} MI:{3} FI:{4} AS:{5} AG:{6} TO:{7} AC:{8} EM:{9} CO:{10} {11}", background.Name, background.Health, background.Energy, background.Might, background.Finesse, background.Astra, background.Agility, background.Toughness, background.Acuity, background.Empathy, background.Contempt, background.Description);
            }
            Console.WriteLine("\nChecking Abilities...");
            foreach (Ability ability in abilities)
            {
                Console.WriteLine("{0}: POW:{1} ACC:{2} COST:{3} {4}", ability.Name, ability.Power, ability.Accuracy, ability.Cost, ability.Description);
            }
            Console.WriteLine("\nChecking Passives...");
            foreach (Passive passive in passives)
            {
                Console.WriteLine("{0} ({1}) {2}", passive.Name, passive.Effect, passive.Description);
            }
            Console.WriteLine("\nChecking Stat Boosts...");
            foreach (StatBoost statBoost in statBoosts)
            {
                Console.WriteLine("{0} ({1}+{2}) {3}", statBoost.Name, statBoost.Stat, statBoost.Amount, statBoost.Description);
            }
        }

        /// <summary>
        /// Displays the Main Menu and acts as a gateway for PlayGame()
        /// </summary>
        static void MainMenu()
        {
            Console.WriteLine("Welcome to Ollara!");
            bool exited = false;
            do
            {
                Console.WriteLine("[1]  New Game");
                Console.WriteLine("[2]  Continue");
                Console.WriteLine("[3]  Past Games");
                Console.WriteLine("[X]  Exit");

                Console.Write("Please choose an option  > ");
                String input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Starting new game!");
                        PreGame();
                        break;
                    case "2":
                        Console.WriteLine("Continuing current game!");
                        PreGame("savefile.txt");
                        break;
                    case "3":
                        Console.WriteLine("Printing past game records.");
                        break;
                    case "X":
                        exited = true;
                        break;
                    case "x":
                        exited = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            } while (!exited);
        }

        /// <summary>
        /// Initialises (or loads) the game state and starts character generation before starting the Game.
        /// </summary>
        /// <param name="entry">An optional parameter that can take a save file if loading gets implemented.</param>
        static void PreGame(String entry = "")
        {
            if (entry.CompareTo("") == 0)
            {
                Console.WriteLine("Creating save file \'savefile.txt\'.");
                // Create save file
                // Fill game values
                CharacterCreator();
                PerkPoolDistributor();
                Game();
            }
            else
            {
                Console.WriteLine("Loading save file \'{0}\'.", entry);
                // Load save file
                // Fill game values
            }
        }

        /// <summary>
        /// Allows the player to generate their first character, and then up to 4 additional characters.
        /// </summary>
        static void CharacterCreator()
        {
            Console.WriteLine("Welcome to the Character Creator.");
            Console.WriteLine("Here we will set up your party. You can make a party with a maximum of 5 members.");
            Console.WriteLine("Please create your first character:");
            party = new Party();
            int characterCount = 0;
            String input;
            bool finished = false;
            bool raceIsValid = false;
            bool backgroundIsValid = false;
            bool finishedIsValid = false;
            String nameIn;
            String raceIn;
            Race blankRace = new Race("", "", new float[10], "");
            Race newRace = blankRace;
            String backgroundIn;
            Background blankBackground = new Background("blank", new float[10], "blank");
            Background newBackground = blankBackground;
            do
            {
                Console.Write("Please enter a name: ");
                nameIn = Console.ReadLine();
                do
                {
                    Console.WriteLine("Please select a race from:");
                    foreach (Race race in races)
                    {
                        Console.WriteLine("{0}: HP:{1} EN:{2} MI:{3} FI:{4} AS:{5} AG:{6} TO:{7} AC:{8} EM:{9} CO:{10} {11}", race.Name, race.Health, race.Energy, race.Might, race.Finesse, race.Astra, race.Agility, race.Toughness, race.Acuity, race.Empathy, race.Contempt, race.Description);
                    }
                    Console.Write(" > ");
                    raceIn = Console.ReadLine();
                    String[] raceNames = new String[races.Count];
                    for (int i = 0; i < races.Count; i++)
                    {
                        raceNames[i] = races[i].Name;
                    }
                    if (raceNames.Contains(raceIn))
                    {
                        raceIsValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option.");
                    }
                } while (!raceIsValid);
                do
                {
                    Console.WriteLine("Please select a background from:");
                    foreach (Background background in backgrounds)
                    {
                        Console.WriteLine("{0}: HP:{1} EN:{2} MI:{3} FI:{4} AS:{5} AG:{6} TO:{7} AC:{8} EM:{9} CO:{10} {11}", background.Name, background.Health, background.Energy, background.Might, background.Finesse, background.Astra, background.Agility, background.Toughness, background.Acuity, background.Empathy, background.Contempt, background.Description);
                    }
                    Console.Write(" > ");
                    backgroundIn = Console.ReadLine();
                    String[] backgroundNames = new String[backgrounds.Count];
                    for (int i = 0; i < backgrounds.Count; i++)
                    {
                        backgroundNames[i] = backgrounds[i].Name;
                    }
                    if (backgroundNames.Contains(backgroundIn))
                    {
                        backgroundIsValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option.");
                    }
                } while (!backgroundIsValid);
                foreach (Race race in races)
                {
                    if (raceIn.CompareTo(race.Name) == 0)
                    {
                        newRace = race;
                    }
                }
                foreach (Background background in backgrounds)
                {
                    if (backgroundIn.CompareTo(background.Name) == 0)
                    {
                        newBackground = background;
                    }
                }
                party.AddMember(new Character(nameIn, newRace, newBackground));
                characterCount++;
                Console.WriteLine("You created {0}, a/n {1} {2}.", nameIn, newRace.Denonym, newBackground.Name);
                raceIn = null;
                newRace = blankRace;
                backgroundIn = null;
                newBackground = blankBackground;
                raceIsValid = false;
                backgroundIsValid = false;
                if (characterCount < 5)
                {
                    do
                    {
                        Console.WriteLine("You can create {0} more party member(s). Would you like to create another?", 5 - characterCount);
                        Console.Write(" [Y/N]  > ");
                        input = Console.ReadLine();
                        if ((input.ToLower().CompareTo("y") == 0) || input.ToLower().CompareTo("n") == 0)
                        {
                            if (input.ToLower().CompareTo("n") == 0)
                            {
                                finished = true;
                            }
                            finishedIsValid = true;
                        }
                        else
                        {
                            Console.WriteLine("Please selected a valid option.");
                        }
                    } while (!finishedIsValid);
                }
                else
                {
                    finished = true;
                }
            } while (!finished);
            Console.WriteLine("This is your party:");
            foreach (Character member in party.PartyMembers)
            {
                Console.WriteLine("{0}, a {1} {2}.", member.Name, member.Race.Denonym, member.Background.Name);
            }
        }

        /// <summary>
        /// Randomly distributes some Perks from the static Perk List into a pool the player can select from and apply to their characters.
        /// </summary>
        static void PerkPoolDistributor()
        {
            List<Perk> randPerks = new List<Perk>();

            // For now this just fills the list with random perks, but will be optimised and made better later
            int perkCount = 10;
            int randNum;
            for (int i = 0; i < perkCount; i++)
            {
                randNum = rand.Next(1, 4);
                switch (randNum)
                {
                    case 1:
                        randPerks.Add(abilities[rand.Next(0, abilities.Count)]);
                        break;
                    case 2:
                        randPerks.Add(passives[rand.Next(0, passives.Count)]);
                        break;
                    case 3:
                        randPerks.Add(statBoosts[rand.Next(0, statBoosts.Count)]);
                        break;
                }
            }
            foreach (Perk perk in randPerks)
            {
                Console.WriteLine(perk.Name);
            }
            // Perks will also be applied to characters here

        }

        /// <summary>
        /// Plays the actual Game.
        /// </summary>
        static void Game()
        {
            Console.WriteLine("Your party appears in a dungeon.");
            bool gameOver = false;
            Room room;
            String input;
            do
            {
                Console.WriteLine("You enter a room.");
                room = CreateRoom();
                Console.WriteLine("[1] To the left is {0}.", room.LeftPortal);
                Console.WriteLine("[2] In the middle is {0}.", room.MiddlePortal);
                Console.WriteLine("[3] To the right is {0}.", room.RightPortal);
                Console.WriteLine("[X] Exit.");
                Console.Write("Where do you want to go?  > ");
                input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        PortalHandler(room.LeftPortal);
                        break;
                    case "2":
                        PortalHandler(room.MiddlePortal);
                        break;
                    case "3":
                        PortalHandler(room.RightPortal);
                        break;
                    case "X":
                        gameOver = true;
                        break;
                    case "x":
                        gameOver = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        break;
                }
            } while (!gameOver);
        }

        /// <summary>
        /// Creates a Room with four sides that have random events at them.
        /// </summary>
        /// <returns>A new Room object.</returns>
        static Room CreateRoom()
        {
            Array values = Enum.GetValues(typeof(Portal));

            Portal leftPortal = (Portal)values.GetValue(rand.Next(values.Length));
            Portal middlePortal = (Portal)values.GetValue(rand.Next(values.Length));
            Portal rightPortal = (Portal)values.GetValue(rand.Next(values.Length));
            Room newRoom = new Room(leftPortal, middlePortal, rightPortal);

            return newRoom;
        }

        /// <summary>
        /// Handles player interaction with the specified Portal.
        /// </summary>
        static void PortalHandler(Portal portal)
        {

        }

        /// <summary>
        /// Plays out a Battle.
        /// </summary>
        static void Battle()
        {

        }
    }
}
