using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;

namespace Ollara
{
    class main
    {
        static List<Race> races = new List<Race>();
        static List<Background> backgrounds = new List<Background>();
        static Party party;

        static void Main(string[] args)
        {
            // Load game values
            Preload();

            MainMenu();

            // Keep everything open for debugging
            // Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static void Preload()
        {
            XmlReader reader = XmlReader.Create("C:/users/Tristan.Birkinshaw/source/repos/ollara/Ollara/Ollara/Races.xml");
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
            }
            reader = XmlReader.Create("C:/users/Tristan.Birkinshaw/source/repos/ollara/Ollara/Ollara/Backgrounds.xml");
            while (reader.Read())
            {
                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "Background"))
                {
                    if (reader.HasAttributes)
                    {
                        float[] attributes = { float.Parse(reader.GetAttribute("health")), float.Parse(reader.GetAttribute("energy")), float.Parse(reader.GetAttribute("might")), float.Parse(reader.GetAttribute("finesse")), float.Parse(reader.GetAttribute("astra")), float.Parse(reader.GetAttribute("agility")), float.Parse(reader.GetAttribute("toughness")), float.Parse(reader.GetAttribute("acuity")), float.Parse(reader.GetAttribute("empathy")), float.Parse(reader.GetAttribute("contempt")) };
                        backgrounds.Add(new Background(reader.GetAttribute("name"), attributes, reader.GetAttribute("description")));
                    }
                }
            }
        }

        static void MainMenu()
        {
            Console.WriteLine("Welcome to Ollara!");
            bool selected = true;
            do
            {
                selected = true;
                Console.WriteLine("[1]  New Game");
                Console.WriteLine("[2]  Continue");
                Console.WriteLine("[3]  Past Games");
                Console.WriteLine("[X]  Exit");

                Console.Write(" > ");
                String input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        Console.WriteLine("Starting new game!");
                        PlayGame();
                        break;
                    case "2":
                        Console.WriteLine("Continuing current game!");
                        PlayGame("savefile.txt");
                        break;
                    case "3":
                        Console.WriteLine("Printing past game records.");
                        break;
                    case "X":
                        break;
                    case "x":
                        break;
                    default:
                        Console.WriteLine("Incorrect input");
                        selected = false;
                        break;
                }
            } while (!selected);
        }

        static void PlayGame(String entry = "")
        {
            List<Character> party = new List<Character>();
            // List<RoomEntity> room = new List<RoomEntity>();
            if (entry.CompareTo("") == 0)
            {
                Console.WriteLine("Creating save file \'savefile.txt\'.");
                // Create save file
                // Fill game values
                CharacterCreator();
                Game();
            }
            else
            {
                Console.WriteLine("Loading save file \'{0}\'.", entry);
                // Load save file
                // Fill game values
            }
        }

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
            String name;
            String race;
            Race blankRace = new Race("", "", new float[10], "");
            Race newRace = blankRace;
            String background;
            Background blankBackground = new Background("blank", new float[10], "blank");
            Background newBackground = blankBackground;
            do
            {
                Console.Write("Please enter a name: ");
                name = Console.ReadLine();
                do
                {
                    Console.WriteLine("Please select a race from:");
                    for (int i = 0; i < races.Count; i++)
                    {
                        Console.WriteLine("{0}: HP:{1} EN:{2} MI:{3} FI:{4} AS:{5} AG:{6} TO:{7} AC:{8} EM:{9} CO:{10} {11}", races[i].Name, races[i].Health, races[i].Energy, races[i].Might, races[i].Finesse, races[i].Astra, races[i].Agility, races[i].Toughness, races[i].Acuity, races[i].Empathy, races[i].Contempt, races[i].Description);
                    }
                    Console.Write(" > ");
                    race = Console.ReadLine();
                    String[] raceNames = new String[races.Count];
                    for (int i = 0; i < races.Count; i++)
                    {
                        raceNames[i] = races[i].Name;
                    }
                    if (raceNames.Contains(race))
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
                    for (int i = 0; i < backgrounds.Count; i++)
                    {
                        Console.WriteLine("{0}: HP:{1} EN:{2} MI:{3} FI:{4} AS:{5} AG:{6} TO:{7} AC:{8} EM:{9} CO:{10} {11}", backgrounds[i].Name, backgrounds[i].Health, backgrounds[i].Energy, backgrounds[i].Might, backgrounds[i].Finesse, backgrounds[i].Astra, backgrounds[i].Agility, backgrounds[i].Toughness, backgrounds[i].Acuity, backgrounds[i].Empathy, backgrounds[i].Contempt, backgrounds[i].Description);
                    }
                    Console.Write(" > ");
                    background = Console.ReadLine();
                    String[] backgroundNames = new String[backgrounds.Count];
                    for (int i = 0; i < backgrounds.Count; i++)
                    {
                        backgroundNames[i] = backgrounds[i].Name;
                    }
                    if (backgroundNames.Contains(background))
                    {
                        backgroundIsValid = true;
                    }
                    else
                    {
                        Console.WriteLine("Please select a valid option.");
                    }
                } while (!backgroundIsValid);
                for (int i = 0; i < races.Count; i++)
                {
                    if (race.CompareTo(races[i].Name) == 0)
                    {
                        newRace = races[i];
                    }
                }
                for (int i = 0; i < backgrounds.Count; i++)
                {
                    if (background.CompareTo(backgrounds[i].Name) == 0)
                    {
                        newBackground = backgrounds[i];
                    }
                }
                party.AddMember(new Character(name, newRace, newBackground));
                characterCount++;
                Console.WriteLine("You created {0}, a {1} {2}.", name, newRace.Denonym, newBackground.Name);
                race = null;
                newRace = blankRace;
                background = null;
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
            } while (!finished);
            Console.WriteLine("This is your party:");
            for (int i = 0; i < party.PartySize; i++)
            {
                Console.WriteLine("{0}, a {1} {2}.", party.PartyMembers[i].Name, party.PartyMembers[i].Race.Denonym, party.PartyMembers[i].Background.Name);
            }
        }

        static void Game()
        {

        }
    }
}
