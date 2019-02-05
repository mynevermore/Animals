using System;
using System.Collections.Generic;
using System.IO;

namespace Animals
{
    public class Program : IRecord
    {
        public static void Main()
        {
            // Creating an instance of the program due to static vs non-static method mayhem in the errors. Gah...
            Program p = new Program();

            // Creating a list so the database can be extended to many more animals if desired
            List<string> animals = new List<string>();
		        animals.Add("emu");
		        animals.Add("kangaroo");

            // Time to say hello to the user
            Intro();

            // While loop to prompt for user input until user elects to quit, 
            // will only accept valid responses and will loop until valid response received.
    	    while(true)
            {
                var response = Prompt(animals).ToLower();

	        	// Verifying user input and taking appropriate action
        		if (animals.Contains(response))
                {
                    // I would only need one if/else statement here for the two items I need to worry about, 
                    // but this wouldn't allow me to add more in future - so if/else-if/else it is.
                    if (response == animals[0])
                    {
                        Emu emu = new Emu();
                        p.AnimalChoice(emu);
                    }
			        else if(response == animals[1])
                    { 
		    	        Kangaroo roo = new Kangaroo();
		    	        p.AnimalChoice(roo);
	    	        }
                    else { }
                }
                else if(response == "quit")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That's not a valid entry, please try again.");
                }
            }

            Console.WriteLine("Goodbye");
        }

        public static void Intro()
        {
            Console.WriteLine("Welcome to the Animals Database Program.");
            Console.WriteLine("Let's find out about the animals in the database.");
        }

        public static string Prompt(IList<string> animals)
        {
            // Advising of what data is currently in the program
            Console.WriteLine("We currently have the following animals in the database:");
	    
	        foreach(var critter in animals)
	        {
		        Console.Write("{0} ", critter);
	        }

            // Prompting for input to return to Main
            Console.Write("{0}For information about these, type the name of the animal or you can type \"quit\" to exit: ", Environment.NewLine);

            var entry = Console.ReadLine();

            return entry;
        }

        private static string PromptAction()
        {
            // Time to find out if the user wants to print, save or do nothing. Passing back the response for handling.
            string entry;

            while (true)
            {
                Console.WriteLine("Do you want to [p]rint, [s]ave or do [n]othing with the data?");
                Console.Write("Please enter \"p\", \"s\" or \"n\" based on your selection:");

                entry = Console.ReadLine().ToLower();

                if (entry == "p")
                {
                    entry = "print";
                    break;
                }
                else if (entry == "s")
                {
                    entry = "save";
                    break;
                }
                else if (entry == "n")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("That's not a valid selection. Please try again.");
                }
            }

            return entry;
        }

        public void AnimalChoice(Emu emu)
        {
            // Info about emus, then prompting for action on the data.
            Console.WriteLine("{0}You've chosen to see information about emus!", Environment.NewLine);
            Console.WriteLine("Here's the information I have about emus:{0}", Environment.NewLine);

            Console.WriteLine("The emu is a {0}, its diet is {1}, it moves by {2} and it reproduces by {3}", 
                                emu.Subtype, emu.Diet, emu.Movement, emu.Reproduction);
            emu.Science();
            emu.Originate();

            var entry = PromptAction();

            if (entry == "print")
            {
                var data = PrepData(emu);
                PrintToPrinter(data);
            }
            else if (entry == "save")
            {
                var data = PrepData(emu);
                SaveToFile(data);
            }
            else
            {}
        }

        public void AnimalChoice(Kangaroo roo)
        {
            // Info about kangaroos, then prompting for action on the data.
            Console.WriteLine("You've chosen to see information about kangaroos!");
            Console.WriteLine("Here's the information I have about kangaroos:{0}", Environment.NewLine);

            Console.WriteLine("The kangaroo is a {0}, its diet is {1}, it moves by {2} and it reproduces by {3}",
                                roo.Subtype, roo.Diet, roo.Movement, roo.Reproduction);
            roo.Science();
            roo.Originate();

            var entry = PromptAction();

            if (entry == "print")
            {
                var data = PrepData(roo);
                PrintToPrinter(data);
            }
            else if (entry == "save")
            {
                var data = PrepData(roo);
                SaveToFile(data);
            }
            else
            { }
        }

        private static string[] PrepData(Emu emu)
        {
            // Prepping the data for printing or saving so that all that needs to be handled by those methods is a string array.
            string[] data = new string[12];

            data[0] = "Animal Database";
            data[1] = "";
            data[2] = "Animal selected: Emu";
            data[3] = "";
            data[4] = "Here's the information available about emus:";
            data[5] = "\t Animal subtype: " + emu.Subtype;
            data[6] = "\t Diet: " + emu.Diet;
            data[7] = "\t Movement: " + emu.Movement;
            data[8] = "\t Reproduction method: " + emu.Reproduction;
            data[9] = "";
            data[10] = emu.Scientific;
            data[11] = emu.Origin;

            return data;
        }

        private static string[] PrepData(Kangaroo roo)
        {
            // Prepping the data for printing or saving so that all that needs to be handled by those methods is a string array.
            string[] data = new string[12];

            data[0] = "Animal Database";
            data[1] = "";
            data[2] = "Animal selected: Kangaroo";
            data[3] = "";
            data[4] = "Here's the information available about kangaroos:";
            data[5] = "\t Animal subtype: " + roo.Subtype;
            data[6] = "\t Diet: " + roo.Diet;
            data[7] = "\t Movement: " + roo.Movement;
            data[8] = "\t Reproduction method: " + roo.Reproduction;
            data[9] = "";
            data[10] = roo.Scientific;
            data[11] = roo.Origin;

            return data;
        }

        public void PrintToPrinter(string[] data)
        {
            Console.WriteLine("I did try to get it to print to a printer but I was unable to work out how. Sorry.");
        }

        public void SaveToFile(string[] data)
        {
            try
            {
                string path = "C:\\Users\\Public\\32645012.txt";
                File.AppendAllLines(@path, data);
                Console.WriteLine("Saved to " + path);
                Console.WriteLine("Save successful!{0}{0}", Environment.NewLine);
            }
            catch(Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }
    }

    interface IRecord
    {
        void PrintToPrinter(string[] data);
        void SaveToFile(string[] data);
    }
}

