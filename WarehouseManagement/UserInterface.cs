namespace Warehouse.WarehouseManagement;

class UserInterface
{
    public required Shop Shop { private get; init; }

    public void PrintWelcomeBanner(string name)
    {
        Console.WriteLine(new string('*', 50));
        Console.WriteLine($"*\t\t WELCOME {name}\t\t*");
        Console.WriteLine(new string('*', 50));
    }

    public void run()
    {
        while (true)
        {
            PrintWelcomeBanner("TO THE SHOP");
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
                else if (role == Role.Customer)
                {
                    GreetCustomer(name);
                }
            }
        }
    }

    private void GreetEmployee(string name)
    {
        PrintWelcomeBanner("EMPLOYEE");

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
            Console.Write(
                $"{name}, please enter an action you would like to process (1/2/3/4) >>> "
            );
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
                    if (employee.CheckStockOfProduct(productToRestock))
                    {
                        Console.Write($"What quantity of stock would {name} like to add?  >>>");
                        if (int.TryParse(Console.ReadLine(), out var quantityRestock))
                        {
                            employee.ProductRestock(productToRestock, quantityRestock);
                        }
                        else
                        {
                            Console.WriteLine(
                                "Sorry, please enter a valid quantity next time...!!!"
                            );
                        }
                    }
                    break;
                case 3:
                    employee.DoStockTake();
                    break;

                default:
                    Console.WriteLine($"\n\tBYE BYE Employe {name}. See you soon....!!!\n\n");
                    break;
            }
        } while (action < 4);
    }

    public void GreetCustomer(string name)
    {
        PrintWelcomeBanner("Customer");
        var customer = Shop.WelcomeCustomer(name);
        int action = 3;
        do
        {
            Console.WriteLine(">>>>>>>");
            Console.WriteLine("Why are you here ??");
            Console.WriteLine("[1] Add an item to the Basket");
            Console.WriteLine("[2] View Basket");
            Console.WriteLine("[3] Checkout");
            Console.WriteLine(">>>>>>>");
            Console.Write(
                $"{name}, please enter an action you would like to process (1/2/3) >>> "
            );
            action = int.Parse(Console.ReadLine() ?? "3");
            switch (action)
            {
                case 1:
                    Console.Write($"{name}, Which product would you like to add? >>>");
                    var productToAdd = Console.ReadLine() ?? "";
                    customer.AddToBasket(productToAdd);
                    break;
                case 2:
                    customer.ViewBasket();
                    break;
                case 3:
                    customer.CheckOut();
                    Shop.SayGoodByeToCustomer(customer);
                    break;
                default:
                    break;
            }
        } while (action < 3);
    }
}

enum Role
{
    Employee,
    Customer
}
