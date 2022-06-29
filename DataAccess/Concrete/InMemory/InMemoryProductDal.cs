using System.Linq.Expressions;

public class InMemoryProductDal : IProductDal
{
    List<Product> _products;
    public InMemoryProductDal()
    {
        _products = new List<Product>
        {
            new Product
            {
                ProductId = 1,
                CategoryId = 1,
                ProductName = "Elma",
                UnitPrice = 5,
                UnitsInStock = 4,
            },
            new Product
            {
                ProductId = 2,
                CategoryId = 2,
                ProductName = "Kitap",
                UnitPrice = 25,
                UnitsInStock = 6,
            },
            new Product
            {
                ProductId = 3,
                CategoryId = 1,
                ProductName = "Kek",
                UnitPrice = 10,
                UnitsInStock = 100,
            },
            new Product
            {
                ProductId = 4,
                CategoryId = 3,
                ProductName = "Çarşaf",
                UnitPrice = 70,
                UnitsInStock = 6,
            }
        };
    }
    public void Add(Product product)
    {
        _products.Add(product);
    }
    public List<Product> GetAll()
    {
        return _products;
    }
    public void Delete(Product product)
    {
        // product id'leri eşleştir
        Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

        _products.Remove(productToDelete);
    }
    public void Update(Product product)
    {
        // Product'ı bul
        Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);

        productToUpdate.CategoryId = product.CategoryId;
        productToUpdate.ProductId = product.ProductId;
        productToUpdate.ProductName = product.ProductName;
        productToUpdate.UnitPrice = product.UnitPrice;
        productToUpdate.UnitsInStock = product.UnitsInStock;
    }
    public List<Product> GetAllByCategory(int categoryId)
    {
        return _products.Where(p => p.CategoryId == categoryId).ToList();
    }

    public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
    {
        return _products;
    }

    public Product Get(Expression<Func<Product, bool>> filter)
    {
        throw new NotImplementedException();
    }

    public List<ProductDetailDto> GetProductDetails()
    {
        throw new NotImplementedException();
    }
}