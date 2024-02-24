namespace Warehouse.WarehouseManagement;

class Shop
{
    private readonly HashSet<Customer> _customers = [];
    private readonly HashSet<Employee> _employees = [];
    public Inventory Inventory { get; } = new();

    public Employee WelcomeEmployee(string employeeName)
    {
        var newEmployee = new Employee { Name = employeeName, Inventory = this.Inventory };
        _employees.Add(newEmployee);
        Console.WriteLine($"Employee {employeeName} has entered the store...");
        return newEmployee;
    }

    public Customer WelcomeCustomer(string customerName)
    {
        var newCustomer = new Customer { Name = customerName, Inventory = this.Inventory };
        _customers.Add(newCustomer);
        return newCustomer;
    }

    public void SayGoodByeToCustomer(Customer customer)
    {
        _customers.Remove(customer);
        Console.WriteLine($"Customer {customer.Name} has left the store.");
    }

    public void AddProduct(string name, decimal price, string supplier)
    {
        var newProduct = new Product
        {
            Name = name,
            Price = price,
            Supplier = supplier
        };
        Inventory.AddProductToStock(newProduct);
    }
}
