using HouseApp.Responses;

namespace HouseApp.Helpers
{
    internal class Utilities
    {
        public static GetAddressAndNicknameFromUserResponse GetAddressAndNicknameFromUser(Houses house)
        {
            var getAddressAndNicknameFromUserResponse = new GetAddressAndNicknameFromUserResponse
            {
                Error = false,
                ErrorMessage = string.Empty
            };

            try
            {
                //Get user's address
                var address = string.Empty;
                while (address.Length < 5)
                {
                    Console.Write($"Please, enter {house} house address (more then 5 letters):");
                    var enteredAddress = Console.ReadLine();
                    address = enteredAddress == null ? string.Empty : enteredAddress.Trim();
                }

                Console.WriteLine($"{house} house address is: {address}");

                //Get user's nickname
                var nickname = string.Empty;
                Console.Write($"Please, enter {house} house nickname (if not necessary, just press Enter):");
                nickname = Console.ReadLine()?.Trim();
                Console.WriteLine(!string.IsNullOrWhiteSpace(nickname)
                    ? $"{house} house nickname is: {nickname}"
                    : $"You haven't entered {house} house nickname.");

                getAddressAndNicknameFromUserResponse.House = new House(address)
                {
                    Nickname = nickname,
                };

                //Get user's changed address
                var changeAddressConfirmationValue = string.Empty;

                while (changeAddressConfirmationValue != "Y" && changeAddressConfirmationValue != "N")
                {
                    Console.Write($"Do you want to change {house} house address? (Y or N):");
                    changeAddressConfirmationValue = Console.ReadLine()?.Trim().ToUpper();
                }

                if (changeAddressConfirmationValue == "Y")
                {
                    bool isChanged = false;

                    while (isChanged == false)
                    {
                        Console.Write($"Please, enter {house} house new address (more then 5 letters):");
                        var firstHouseNewAddress = Console.ReadLine()?.Trim();

                        var result = getAddressAndNicknameFromUserResponse.House.ChangeAddress(firstHouseNewAddress);
                        isChanged = !result.Error;
                        if (result.Error)
                            Console.WriteLine(result.ErrorMessage);
                    }

                    Console.WriteLine($"{house} house new address is: {getAddressAndNicknameFromUserResponse.House.Address}");
                }
            }
            catch (Exception exc)
            {
                string errorMessage = $"There was an error during GetAddressAndNicknameFromUser method execution " +
                    $"for the {house} house. Error message: {exc.Message}";
                getAddressAndNicknameFromUserResponse.Error = true;
                getAddressAndNicknameFromUserResponse.ErrorMessage = errorMessage;
                Console.WriteLine(errorMessage);
            }

            return getAddressAndNicknameFromUserResponse;
        }
    }
}
