// See https://aka.ms/new-console-template for more information

// all logic here
// Unit tests, maybe console end to end
// Could've asked for more context, but decided to show my reasoning abilities!
// Added the unit tests that make sense
// ways to improve?: Make hiker inventory a seperate class, less clutter and more abstraction! Easy decouple
// Also conforming to the assignment structure input structure better, but that is easy
// IO not tested as always a bother and it is one of the more easier things to verify without testing, not the focus of this either
// what is easy to abstract and reasonable (inventories) and what is not (hiker description, doesn't make sense to abstract)
// Serial execution in program flow, I like to do things that way but I know other mehtods are possible

using System.Reflection.Metadata.Ecma335;
using System.Runtime;

using ConsoleApp.Models;

namespace application {
    class Program {
        static Item[] HikerItems = [new Item("Medication", 5), new Item("Water", 4), new Item("Food", 3)]; 
        static Hiker CreateHikerFromIO(int id) {
            Console.WriteLine($"Enter details for hiker {id}:");
            Console.Write("* Name of hiker: ");
            String name = Console.ReadLine();
            Console.Write("* Age of hiker: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("* Gender of hiker: ");
            String gender = Console.ReadLine();
            Console.Write("* Last position of hiker (longitude, latitude): ");
            String position = Console.ReadLine();
            Console.Write("* Does the hiker have an injury? [True/False]: ");
            bool injured = bool.Parse(Console.ReadLine());

            Hiker hiker = new Hiker{name = name, age = age, gender = gender, 
                                    position = position, injured = injured,
                                    inventory = new Inventory()};     
            
            Console.WriteLine($"Next, enter hiker inventory details:");
            foreach(Item item in HikerItems) {
                Console.Write($"* Amount of {item.Name}, value {item.Value} pts each: ");
                int amount = int.Parse(Console.ReadLine());
                hiker.inventory.AddItem(item, amount);
            }

            return hiker;   
        }
        static void Main(string[] args) {
            Console.WriteLine("Welcome to the application! We shall begin with entering details for hiker 1 & 2:");
            Console.WriteLine();

            Hiker hiker1 = CreateHikerFromIO(1);
            Hiker hiker2 = CreateHikerFromIO(2);

            Console.WriteLine("\nThe following data was inputted:");
            Console.Write("\nHiker 1:\n");
            Console.Write(hiker1.Stringify());
            Console.Write("\nHiker 2:\n");            
            Console.Write(hiker2.Stringify());
            Console.WriteLine("");

            bool successOfTrade = hiker1.TryTrade(hiker2);

            if(successOfTrade) {
                Console.WriteLine("Trade between Hiker 1 & Hiker 2: Trade completed, see updated info below:");
                Console.Write("\nHiker 1:\n");
                Console.Write(hiker1.Stringify());
                Console.Write("\nHiker 2:\n");            
                Console.Write(hiker2.Stringify());
            } else {
                Console.WriteLine("Trade between Hiker 1 & Hiker 2: Trade unsuccessful, see explanation below:");
                Console.Write(hiker1.TradeFailureReason(hiker2));
            }
        }   
    }
}