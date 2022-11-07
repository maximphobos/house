using HouseApp.Responses;

namespace HouseApp
{
    internal class House
    {
        public string Address { get; private set; }

        public string? Nickname { get; set; }

        public House(string address)
        {
            Address = address;
        }

        public ChangeAddressResponse ChangeAddress(string? newAddress)
        {
            var changeAddressResponse = new ChangeAddressResponse
            {
                Error = false,
                ErrorMessage = String.Empty
            };

            try
            {
                if (newAddress?.Length > 5)
                {
                    Address = newAddress;
                }
                else
                {
                    changeAddressResponse.Error = true;
                    changeAddressResponse.ErrorMessage = "Address length should be more then 5 letters (!)";
                }
            }
            catch (Exception exc)
            {
                changeAddressResponse.Error = true;
                changeAddressResponse.ErrorMessage = exc.Message;
            }

            return changeAddressResponse;
        }

        public override string ToString()
        {
            if (!string.IsNullOrWhiteSpace(Nickname))
            {
                return Nickname;
            }
            else
            {
                return Address;
            }
        }

        public override bool Equals(object? obj)
        {
            if (obj is House house)
            {
                return house.Address.Trim().ToLower() == Address.Trim().ToLower();
            }

            return false;
        }

        public static bool operator == (House first, House second) => first.Equals(second);

        public static bool operator != (House first, House second) => !(first == second);

        public override int GetHashCode()
        {
            return HashCode.Combine(Address);
        }
    }
}
