using ConsoleApp.Models;

namespace application {
    class Program {
        static Item[] HikerItems = [new Item("Medication", 5), new Item("Water", 4), new Item("Food", 3)]; 
        static Hiker CreateHikerFromIO(int id) {
            Console.Write($"\n---Enter details for hiker {id}:---\n");
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
            
            Console.Write($"Next, enter hiker inventory details:\n");
            foreach(Item item in HikerItems) {
                Console.Write($"* Amount of {item.Name}, value {item.Value} pts each: ");
                int amount = int.Parse(Console.ReadLine());
                hiker.inventory.AddItem(item, amount);
            }

            return hiker;   
        }
        
        static void Main(string[] args) {
            Console.Write("\n***Welcome to the application! We shall begin with entering details for hiker 1 & 2:***\n");
            
            // I had to add exception handling here because an exception due to user error
            // would bug out the terminal due to some strange control character sequence or something. 
            // Not the most polished solution but this was outside of the definition of the assignment already. 
            // Just a nice quality of life when testing out the application, in the case of user error :)
            try {
                Hiker hiker1 = CreateHikerFromIO(1);
                Hiker hiker2 = CreateHikerFromIO(2);

                Console.Write("\n***The following data was inputted:***\n");
                Console.Write("\nHiker 1:\n");
                Console.Write(hiker1.Stringify());
                Console.Write("\n\nHiker 2:\n");            
                Console.Write(hiker2.Stringify());
                Console.WriteLine("");

                bool successOfTrade = hiker1.TryTrade(hiker2);

                if(successOfTrade) {
                    Console.Write("\n***Trade between Hiker 1 & Hiker 2: Trade completed, see updated info below:***\n");
                    Console.Write("\nHiker 1:\n");
                    Console.Write(hiker1.Stringify());
                    Console.Write("\nHiker 2:\n");            
                    Console.Write(hiker2.Stringify() + "\n");
                } else {
                    Console.Write("\n***Trade between Hiker 1 & Hiker 2: Trade unsuccessful, see explanation below:***");
                    Console.Write(hiker1.TradeFailureReason(hiker2) + "\n");
                }
            } catch (Exception e) {
                Console.WriteLine("Invalid IO input, exiting program.");
                Environment.Exit(1);
            }
        }   
    }
}