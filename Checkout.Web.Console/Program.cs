using Checkout.Web.Client;

namespace Checkout.Web.Console
{
    /// <summary>
    /// A working example of how to implement the ApiClient generated in CS
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // ## G U I D E
            // 1. Start Checkout.Web by viewing in browser (without debug)
            // 2. Set this project as the start up app and run
            // 3. Add breakpoints as you need to debug and step through the code

            // check the Url to the Url the website runs under
            var client = new ApiClient("http://localhost:58316/");

            // change method as need on the client object
            var result = client.ProductsByCountryIdGetAsync(1, 0, 15, "1.0").GetAwaiter().GetResult();

            foreach (var item in result)
            {
                System.Console.WriteLine($"Product Id {item.Id}, Code {item.Code}, Name {item.Name}, NetPrice: {item.NetPrice}");
            }

            System.Console.ReadKey();
        }
    }
}
