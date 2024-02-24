namespace Warehouse.WarehouseManagement;

class Employee
{
    public required string Name { get; set; }
    public required Inventory Inventory { private get; init; }

    public Boolean CheckStockOfProduct(string productName)
    {
        Console.WriteLine($"Employee {Name} is checking the stock of product {productName}...");
        try
        {
            var productStock = Inventory.GetProductStock(productName);
            Console.WriteLine($"There are currently {productStock} - {productName} in stock.");
            return true;
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine($"*** Product {productName} was not found.");
            return false;
        }
    }

    public void ProductRestock(string productName, int quantity)
    {
        Inventory.RegisterStockIncrease(productName, quantity);
    }

    public void DoStockTake()
    {
        Console.WriteLine($"Employee {Name} is doing a stock take...");
        Console.WriteLine(Inventory);
    }
}
