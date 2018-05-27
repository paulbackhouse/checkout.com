using Checkout.Web.Client;
using System;

namespace Checkout.Web.Console
{
    /// <summary>
    /// A working example of how to implement the ApiClient object (Checkout.Web.Client)
    /// </summary>
    public class Program
    {
        public static void Main(string[] args)
        {
            // ## G U I D E
            // 1. Start Checkout.Web by viewing in browser (without debug)
            // 2. Set this project as the start up app and run
            // 3. Add breakpoints as you need to debug and step through the code

            // change the Url to the Url the website runs under your env
            var client = new ApiClient("http://localhost:58316/");

            // change methods as needed on the client object

            // get paged products
            var pagedResult = client.ProductsGetAsync(1, 0, 15, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("## P R O D U C T S ##");

            foreach (var product in pagedResult.Items)
            {
                System.Console.WriteLine($"Product Id {product.Id}, Code {product.Code}, Name {product.Name}, NetPrice: {product.NetPrice}");
            }

            // get product by Id
            var productById = client.ProductsByProductIdGetAsync(1, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("## P R O D U C T   B Y  I D ##");
            System.Console.WriteLine($"Product Id {productById.Id}, Code {productById.Code}, Name {productById.Name}, NetPrice: {productById.NetPrice}");


            // get countries (note the € symbol doesn't show up in console app, in json functions as normal)
            var countries = client.CountriesGetAsync("1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("## C O U N T R I E S ##");

            foreach (var country in countries)
            {
                System.Console.WriteLine($"Country Id {country.Id}, IsoCode {country.IsoCode}, Name {country.Name}, Currency: {country.CurrencySymbol}");
            }

            // get country by Id 
            var countryById = client.CountriesByCountryIdGetAsync(2, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("## C O U N T R Y   B Y  I D ##");
            System.Console.WriteLine($"Country Id {countryById.Id}, IsoCode {countryById.IsoCode}, Name {countryById.Name}, Currency: {countryById.CurrencySymbol}");


            // create a new cart with a product
            var cartProduct = client.CartPutAsync(Guid.Empty, 2, 4, 2, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("## N E W  C A R T   P R O D U C T   A D D E D ##");
            System.Console.WriteLine($"Cart Id {cartProduct.CartId}, Product Id {cartProduct.ProductId}, Qty {cartProduct.Qty}, Net Price {cartProduct.TotalNetPriceFormatted}, Tax: {cartProduct.TotalTaxFormatted}, Gross Price {cartProduct.TotalGrossPriceFormatted}");

            // get a cart
            var cart = client.CartByCartIdGetAsync((Guid)cartProduct.CartId, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("## G E T   C A R T ##");
            System.Console.WriteLine($"Cart Id {cart.CartId}, Country IsoCode {cart.CountryIsoCode}, Item Count {cart.Items.Count}");

            // update a cart with a product
            cartProduct = client.CartPutAsync(cartProduct.CartId, 2, 5, 3, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("## U P D A T E   C A R T ##");
            System.Console.WriteLine($"Cart Id {cartProduct.CartId}, Product Id {cartProduct.ProductId}, Qty {cartProduct.Qty}, Net Price {cartProduct.TotalNetPriceFormatted}, Tax: {cartProduct.TotalTaxFormatted}, Gross Price {cartProduct.TotalGrossPriceFormatted}");

            // get a cart
            cart = client.CartByCartIdGetAsync((Guid)cartProduct.CartId, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("## G E T   C A R T ##");
            System.Console.WriteLine($"Cart Id {cart.CartId}, Country IsoCode {cart.CountryIsoCode}, Item Count {cart.Items.Count}");

            System.Console.WriteLine("");
            System.Console.WriteLine("## D E L E T E   C A R T   P R O D U CT ##");
            // delete cart product
            client.CartByCartIdByProductIdDeleteAsync((Guid)cartProduct.CartId, 4, "1.0").GetAwaiter().GetResult();
            System.Console.WriteLine($"Deleted: CartId {cartProduct.CartId}, product Id 4");

            // get a cart
            cart = client.CartByCartIdGetAsync((Guid)cartProduct.CartId, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("## G E T   C A R T ##");
            System.Console.WriteLine($"Cart Id {cart.CartId}, Country IsoCode {cart.CountryIsoCode}, Item Count {cart.Items.Count}");

            System.Console.WriteLine("");
            System.Console.WriteLine("## D E L E T E   C A R T ##");
            // delete cart
            client.CartByCartIdDeleteAsync((Guid)cartProduct.CartId, "1.0").GetAwaiter().GetResult();
            System.Console.WriteLine($"Deleted: CartId {cartProduct.CartId}");

            cart = client.CartByCartIdGetAsync((Guid)cartProduct.CartId, "1.0").GetAwaiter().GetResult();

            System.Console.WriteLine("");
            System.Console.WriteLine("## G E T   C A R T ##");
            System.Console.WriteLine($"Is Cart Null? {(cart == null ? "true" : "false")}");

            System.Console.ReadKey();
        }
    }
}
