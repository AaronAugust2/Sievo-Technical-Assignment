namespace ConsoleApp.Tests;

using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Headers;
using ConsoleApp.Models;
public class InvetoryTests
{
  [Theory]
    [InlineData(1, 0, 4)]
    [InlineData(0, 1, 2)]
    [InlineData(2, 3, 14)]
    public void InventorySumCorrect(int mushroomAmount, int appleAmount, int expected) {
        Item mushroom = new Item("Mushroom", 4);
        Item apples = new Item("Apples", 2);

        Inventory inventory = new Inventory{};
        inventory.AddItem(mushroom, mushroomAmount);
        inventory.AddItem(apples, appleAmount);

        int sum = inventory.CalculateValue();

        Assert.Equal(expected, sum);
    }
}