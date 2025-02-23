namespace ConsoleApp.Models;

public class Inventory {
    public List<(Item, int)> Contents {get; set;} = [];
    public void AddItem(Item item, int amount) {
        this.Contents.Add((item, amount));
    }
    public int CalculateValue(){
        return Contents.Aggregate(0, (sum, item) => sum + item.Item1.Value * item.Item2);
    }
    public string stringify(){
        string inventorystring = "Items in inventory:\n";

        foreach ((Item, int) item in this.Contents) {
            inventorystring += $" -{item.Item1.Name}: {item.Item2}\n";
        }

        inventorystring += $" -> Total value of inventory: {this.CalculateValue()}";

        return inventorystring;
    }
}