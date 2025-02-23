namespace ConsoleApp.Models;

public class Hiker {
    public String name {get; set;}
    public int age {get; set;}
    public String gender {get; set;}
    public String position {get; set;}
    public bool injured {get; set;}
    public Inventory inventory {get; set;}
    
    public void SwapInventories(Hiker partner){
        Inventory inventorySwap = partner.inventory;
        partner.inventory = this.inventory;
        this.inventory = inventorySwap;
    }

    public bool TryTrade(Hiker partner){
        if(partner.inventory.CalculateValue() == this.inventory.CalculateValue() && !partner.injured && !this.injured){
            this.SwapInventories(partner);
            return true;
        }
        else {
            return false;
        }
    }

    public String TradeFailureReason(Hiker partner){
        String reasons = "";

        int thisValue = this.inventory.CalculateValue();
        int partnerValue = partner.inventory.CalculateValue();

        if(thisValue != partnerValue) {
            reasons += $" -Value of items does not match: {thisValue} vs {partnerValue}\n";
        }

        if(this.injured){
            reasons += $"- Hiker {this.name} was injured\n";
        }

        if(partner.injured){
            reasons += $"- Hiker {partner.name} was injured\n";
        }

        return reasons;
    }

    public String Stringify(){
        string hikerInfoString = $"Name: {name}, Age: {age}, Gender: {gender}, Position: {position}, Injured: {injured}\n";
        string hikerItemInfo = this.inventory.Stringify();

        return hikerInfoString + hikerItemInfo;
    }
}