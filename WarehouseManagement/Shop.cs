namespace Warehouse.WarehouseManagement;

class Shop
{
    private readonly HashSet<Customer> _customers = [];
    private readonly HashSet<Employee> _employees = [];
    public Inventory Inventory { get; } = new();

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