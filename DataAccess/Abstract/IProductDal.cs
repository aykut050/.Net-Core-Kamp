public interface IProductDal : IEntityRepository<Product>
{
    List<ProductDetailDto> GetProductDetails();
}