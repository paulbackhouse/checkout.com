namespace Checkout
{
    public class Constants
    {
        public const char Delimiter = '|';

        public struct CacheLengths
        {
            public const double Short = 10;        // 10 seconds
            public const double Medium = 30;       // 30 seconds
            public const double Long = 60;         // 60 seconds
            public const double Hourly = 3600;     // 1 hour
            public const double Daily = 1440;      // 1 day
            public const double Weekly = 10080;    // 6.5 days
            public const double Monthly = 43200;   // 30 days
        }

        public struct ContentTypes
        {
            public const string applicationJson = "application/json";
        }


    }
}
