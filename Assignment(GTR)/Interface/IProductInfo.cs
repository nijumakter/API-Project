using Assignment_GTR_.Model;

namespace Assignment_GTR_.Interface
{
    public interface IProductInfo
    {
        public List<ProductInfo> GetProductInfoDetails();
        public ProductInfo GetProductInfoDetails(int id);
        public void AddProductInfo(ProductInfo productInfo);
        public void UpdateProductInfo(ProductInfo productInfo);
        public ProductInfo DeleteProductInfo(int id);
        public bool CheckProductInfo(int id);
    }
}
