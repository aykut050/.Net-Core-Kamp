ProductManager productManager = new ProductManager(new EfProductDal());

foreach (var item in productManager.GetProductDetails())
{
    
}