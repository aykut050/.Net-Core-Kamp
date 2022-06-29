public class ProductManager : IProductService
{
    IProductDal _productDal;
    public ProductManager(IProductDal productDal)
    {
        _productDal = productDal;
    }

    public IResult Add(Product product)
    {
        if (product.ProductName.Length < 2)
            return new ErrorResult(Message.ProductNameInvalid);

        _productDal.Add(product);
        return new Result(true, Message.productAdded);
    }

    public IDataResult<List<Product>> GetAll()
    {
        if (DateTime.Now.Hour == 22)
        {
            return ErrorResult();
        }

        return new DataResult<List<Product>>(_productDal.GetAll(), true, "Ürünler Eklendi");
    }

    public List<Product> GetAllByCategoryId(int id)
    {
        return _productDal.GetAll(p=>p.CategoryId == id);
    }

    public Product GetById(int productId)
    {
        return _productDal.Get(p => p.ProductId == productId);
    }

    public List<Product> GetByUnitPrice(decimal min, decimal max)
    {
        return _productDal.GetAll(p=>p.UnitPrice >= min && p.UnitPrice <= max);
    }

    public List<ProductDetailDto> GetProductDetails()
    {
        return _productDal.GetProductDetails();
    }
}