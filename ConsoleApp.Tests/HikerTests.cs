namespace ConsoleApp.Tests;

using ConsoleApp.Models;

public class HikerTests
{
    [Theory]
    [InlineData(false, false, 1, 0, 0, 2, true)]
    [InlineData(false, true, 1, 0, 0, 2, false)]
    [InlineData(false, false, 2, 0, 0, 2, false)]
    public void TradeFailsWhenIntended(bool hikerInjury1, bool hikerInjury2, 
                              int hikerMushrooms1, int hikerApples1, 
                              int hikerMushrooms2, int hikerApples2, bool expected) {
       
        Item mushroom = new Item("Mushroom", 4);
        Item apples = new Item("Apples", 2);

        Hiker hiker1 = new Hiker{name = "1", age = 0, 
                                 gender = "", position = "", 
                                 injured = hikerInjury1, 
                                 inventory = new Inventory{Contents = [(mushroom, hikerMushrooms1), (apples, hikerApples1)]}};

        Hiker hiker2 = new Hiker{name = "2", age = 0, 
                                 gender = "", position = "", 
                                 injured = hikerInjury2, 
                                 inventory = new Inventory{Contents = [(mushroom, hikerMushrooms2), (apples, hikerApples2)]}};

        bool tradeSuccess = hiker1.TryTrade(hiker2);

        Assert.Equal(expected, tradeSuccess);
    }

    [Theory]
    [InlineData(false, false, 1, 0, 0, 2, "")]
    [InlineData(false, true, 1, 0, 0, 2, "- Hiker 2 was injured\n")]
    [InlineData(false, false, 2, 0, 0, 2, " -Value of items does not match: 8 vs 4\n")]
    public void TradeFailureReasonCorrect(bool hikerInjury1, bool hikerInjury2, 
                              int hikerMushrooms1, int hikerApples1, 
                              int hikerMushrooms2, int hikerApples2, string expected) {
    
        Item mushroom = new Item("Mushroom", 4);
        Item apples = new Item("Apples", 2); 

        Hiker hiker1 = new Hiker{name = "1", age = 0, 
                                 gender = "", position = "", 
                                 injured = hikerInjury1, 
                                 inventory = new Inventory{Contents = [(mushroom, hikerMushrooms1), (apples, hikerApples1)]}};

        Hiker hiker2 = new Hiker{name = "2", age = 0, 
                                 gender = "", position = "", 
                                 injured = hikerInjury2, 
                                 inventory = new Inventory{Contents = [(mushroom, hikerMushrooms2), (apples, hikerApples2)]}};
       
        string failureReason = hiker1.TradeFailureReason(hiker2);
        
        Assert.Equal(failureReason, expected);
    }
}