var shop = new Shop();
shop.AddProduct("broccoli", 0.6m, "Sheepy Farms");
shop.AddProduct("strawberry and banana smoothie", 3m, "Innocent Smoothies");
shop.AddProduct("olive oil", 3m, "Filippo Berio");

class Employee { }

class Basket { }

class Customer { }

class Product
{
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required string Supplier { get; init; }

    public override bool Equals(object? obj)
    {
        return obj is Product product && product.Name == Name && product.Supplier == Supplier;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Supplier);
    }
}

class Inventory
{
    public Dictionary<Product, int> Stock { get; } = [];
    private readonly HashSet<Product> _products = [];
    private readonly Dictionary<string, Product> _productRegister = [];

    public override string ToString()
    {
        // return string.Join(
        //     '\n',
        //     Stock.Select(productQuantityPair =>
        //         $"Product {productQuantityPair.Key.Name}: {productQuantityPair.Value} in stock"
        //     )
        // );

        string border = String.Concat('\n', new string('-', 78), '\n');
        string headings = string.Format(
            "|{0,35} |{1,15} |{2,20} |",
            "Product Name",
            "Product Price",
            "Quantity in Stock"
        );
        string table = String.Concat(border, headings, border);

        foreach (var (product, quantity) in Stock)
        {
            string row = String.Format("|{0,35} |{1,15} |{2,20} |", product.Name, product.Price,quantity);
            table = String.Concat(table,row, border);
        }
        return table;
    }

    public void AddProductToStock(Product newProduct)
    {
        //If a New Product is being added to the list then add it to the Register
        // and setProductStock
        var name = newProduct.Name;
        if (_products.Add(newProduct))
        {
            _productRegister[name] = newProduct;
            SetProductStock(name, 0);
        }
    }

    public Product GetProductByName(string name)
    {
        //This function will return the Product from the register
        return _productRegister[name];
    }

    public void SetProductStock(string name, int newStock)
    {
        var matchingProduct = GetProductByName(name);
        Stock[matchingProduct] = newStock;
    }
}

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
