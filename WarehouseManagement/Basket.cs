namespace Warehouse.WarehouseManagement;

/*Following Basket class uses Dictionary datastructure*/
class Basket
{
    private readonly Dictionary<Product, int> _productsDict = [];

    public override string ToString()
    {
        string border = String.Concat('\n', new string('-', 110), '\n');
        string headings = string.Format(
            "|{0,35} |{1,15} |{2,20} |{3,30} |",
            "Product Name",
            "Product Price",
            "Quantity",
            "Price AsPer Quantity"
        );
        string table = String.Concat(border, headings, border);
        foreach (var (product, quantity) in _productsDict)
        {
            string row = String.Format(
                "|{0,35} |{1,15} |{2,20} | {3,30}|",
                product.Name,
                product.Price,
                quantity,
                product.Price * quantity
            );
            table = String.Concat(table, row, border);
        }
        return table;
    }

    public void AddProduct(Product product)
    {
        if (!_productsDict.TryAdd(product, 1))
        {
            _productsDict[product] += 1;
        }
    }

    public decimal CalculateBill()
    {
        var pricePerQuantity = _productsDict.Select(product => product.Key.Price * product.Value);
        return pricePerQuantity.Sum();
    }
}

/*Following Basket class uses List datastructure*/
// class Basket{
//     private readonly List<Product> _products = [];

//     public override string ToString()
//     {
//         string border = String.Concat('\n', new string('-', 78), '\n');
//         string headings = string.Format("|{0,35} |{1,15} |", "Product Name", "Product Price");
//         string table = String.Concat(border, headings, border);
//         _products.ForEach(product =>
//         {
//             string row = String.Format("|{0,35} |{1,15} |", product.Name, product.Price);
//             table = String.Concat(table, row, border);
//         });
//         return table;
//     }

//     public void AddProduct(Product product)
//     {
//         _products.Add(product);
//     }

//     public decimal CalculateBill()
//     {
//         return _products.Sum(product => product.Price);
//     }
// }
