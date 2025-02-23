namespace ConsoleApp.Models;

public class Inventory {
    public List<(Item, int)> Contents {get; set;} = [];
    public void AddItem(Item item, int amount) {
        this.Contents.Add((item, amount));
    }
    public int CalculateValue(){
        return Contents.Aggregate(0, (sum, item) => sum + item.Item1.Value * item.Item2);
    }
    public String Stringify(){
        string inventoryString = "Items in inventory:\n";

        foreach ((Item, int) item in this.Contents) {
            inventoryString += $" -{item.Item1.Name}: {item.Item2}\n";
        }

        inventoryString += $" -> Total value of inventory: {this.CalculateValue()}";

        return inventoryString;
    }
}