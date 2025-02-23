using ConsoleApp.Models;

namespace application {
    class Program {
        static Item[] HikerItems = [new Item("Medication", 5), new Item("Water", 4), new Item("Food", 3)]; 
        static Hiker CreateHikerFromIO(int id) {
            Console.Write($"\n---Enter details for hiker {id}:---\n");
            Console.Write("* Name of hiker: ");
            string name = Console.ReadLine();
            Console.Write("* Age of hiker: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("* Gender of hiker: ");
            string gender = Console.ReadLine();
            Console.Write("* Last position of hiker (longitude, latitude): ");
            string position = Console.ReadLine();
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
            Console.Write("***Welcome to the application! We shall begin with entering details for hiker 1 & 2:***\n");
            
            // I had to add exception handling here because an exception due to user error
            // would bug out the terminal due to some strange control character sequence or something. 
            // Not the most polished solution but this was outside of the definition of the assignment already. 
            // Just a nice quality of life when testing out the application, in the case of user error :)
            try {
                Hiker hiker1 = CreateHikerFromIO(1);
                Hiker hiker2 = CreateHikerFromIO(2);

                Console.Write("***The following data was inputted:***\n\n");
                Console.Write("Hiker 1:\n");
                Console.Write(hiker1.stringify() + "\n\n");
                Console.Write("Hiker 2:\n");            
                Console.Write(hiker2.stringify() + "\n\n");

                bool successOfTrade = hiker1.TryTrade(hiker2);

                if(successOfTrade) {
                    Console.Write("***Trade between Hiker 1 & Hiker 2: Trade completed, see updated info below:***\n\n");
                    Console.Write("Hiker 1:\n");
                    Console.Write(hiker1.stringify() + "\n\n");
                    Console.Write("Hiker 2:\n");            
                    Console.Write(hiker2.stringify() + "\n");
                } else {
                    Console.Write("***Trade between Hiker 1 & Hiker 2: Trade unsuccessful, see explanation below:***\n");
                    Console.Write(hiker1.TradeFailureReason(hiker2) + "\n");
                }
            } catch (Exception e) {
                Console.Write("Invalid IO input, exiting program.\n");
                Environment.Exit(1);
            }
        }   
    }
}