using System;

namespace ClientLibrary.Helpers
{
    public static class Constants
    {
        public const string AirportBaseUrl = "api/airport";
        public const string BaggageBaseUrl = "api/baggage";
        public const string CityBaseUrl = "api/city";
        public const string FlightBaseUrl = "api/flight";
        public const string FlightClassBaseUrl = "api/flightclass";
        public const string PassengerBaseUrl = "api/passenger";
        public const string TicketBaseUrl = "api/ticket";
        public const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";

        private static readonly Random random = new();
        public static string GenerateRandomString(int length)
        {
            char[] buffer = new char[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = chars[random.Next(chars.Length)];
            }
            return new string(buffer);
        }
    }
}
