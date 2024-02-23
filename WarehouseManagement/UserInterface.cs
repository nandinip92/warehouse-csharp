namespace Warehouse.WarehouseManagement;

class UserInterface
{
    public required Shop Shop { private get; init; }

    public void run()
    {
        while (true)
        {
            Console.WriteLine("What is your name??");
            var name = Console.ReadLine() ?? "";
            Console.Write(
                "Are you an Employee of this Store or a Customer?? (Employee/Customer) >>> "
            );
            if (Enum.TryParse<Role>(Console.ReadLine(), ignoreCase: true, out var role))
            {
                if (role == Role.Employee)
                {
                    GreetEmployee(name);
                }
            }
        }
    }

    private void GreetEmployee(string name)
    {
        Console.WriteLine("*******************************");
        Console.WriteLine("*       WELCOME EMPLOYEE      *");
        Console.WriteLine("*******************************");

        var employee = Shop.WelcomeEmployee(name);
        int action = 4;
        do
        {
            Console.WriteLine(">>>>>>>");
            Console.WriteLine("Why are you here ??");
            Console.WriteLine("[1] Check a Product's Stock");
            Console.WriteLine("[2] Restock a product");
            Console.WriteLine("[3] Do a Stock Take");
            Console.WriteLine("[4] Exit");
            Console.WriteLine(">>>>>>>");
            Console.Write($"{name}, please enter an action you would like to process (1/2/3/4) >>> ");
            action = int.Parse(Console.ReadLine() ?? "4");
            switch (action)
            {
                case 1:
                    Console.Write("Which product's stock you would like to check? >>");
                    var productToCheck = Console.ReadLine() ?? "";
                    employee.CheckStockOfProduct(productToCheck);
                    break;
                case 2:
                    Console.Write(
                        $"Which product would {name} like to register new stock for? >>> "
                    );
                    var productToRestock = Console.ReadLine() ?? "";
                    if (employee.CheckStockOfProduct(name))
                    {
                        Console.Write($"What quantity of stock would {name} like to add?  >>>");
                        if (int.TryParse(Console.ReadLine(), out var quantityRestock))
                        {
                            employee.ProductRestock(productToRestock, quantityRestock);
                        }
                    }
                    break;
                case 3:
                    break;

                default:
                    break;
            }
        } while (action<4);
    }
}

enum Role
{
    Employee,
    Customer
}
