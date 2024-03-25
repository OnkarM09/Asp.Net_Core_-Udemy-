using ClassLibrary1;

List<Product> products = new List<Product>();

string? choice;
do
{
    Console.WriteLine("Please enter product id");
    int prodId = int.Parse(Console.ReadLine());
    Console.WriteLine("Please enter product name");
    string? pName = Console.ReadLine();
    Console.WriteLine("Please enter purchased date in dd-MMM-yyy format!");
    DateTime pDate = DateTime.Parse(Console.ReadLine());
    Console.WriteLine("Please enter product price");
    int pPrice = int.Parse(Console.ReadLine());
    Console.WriteLine("Do you wish to add another product detail? Please enter 'Yes' to continue and 'No' if you not wish.");
    choice = Console.ReadLine();

    Product product = new Product()
    {
        ProductId = prodId,
        ProductName = pName,
        PurchasedDate = pDate,
        ProductPrice = pPrice
    };
    products.Add(product);
} while (choice != "No");

foreach (Product product in products)
{
    Console.WriteLine(product.ProductName);
}