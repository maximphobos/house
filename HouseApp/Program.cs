using HouseApp;
using HouseApp.Helpers;

var firstHouse = Utilities.GetAddressAndNicknameFromUser(Houses.First);

var secondHouse = Utilities.GetAddressAndNicknameFromUser(Houses.Second);

if (!firstHouse.Error && !secondHouse.Error)
{
    Console.WriteLine("Find below please some info for the specified houses above:");

    Console.WriteLine($"ToString() result for the {(Houses.First)} house is: {firstHouse.House?.ToString()}");

    Console.WriteLine($"ToString() result for the {(Houses.Second)} house is: {secondHouse.House?.ToString()}");

    Console.WriteLine($"Are houses equal (by address only)?: {firstHouse.House?.Equals(secondHouse.House)}");
}
