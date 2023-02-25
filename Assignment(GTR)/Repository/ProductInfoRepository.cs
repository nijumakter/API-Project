using Assignment_GTR_.Interface;
using Assignment_GTR_.Model;
using Microsoft.EntityFrameworkCore;

namespace Assignment_GTR_.Repository
{
    public class ProductInfoRepository : IProductInfo
    {

        readonly DatabaseContext _dbContext = new();

        public ProductInfoRepository(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddProductInfo(ProductInfo productInfo)
        {
            try
            {
                _dbContext.ProductInfos.Add(productInfo);
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public bool CheckProductInfo(int id)
        {
            return _dbContext.ProductInfos.Any(e => e.ID == id);
        }

        public ProductInfo DeleteProductInfo(int id)
        {
            try
            {
                ProductInfo? productInfo = _dbContext.ProductInfos.Find(id);

                if (productInfo != null)
                {
                    _dbContext.ProductInfos.Remove(productInfo);
                    _dbContext.SaveChanges();
                    return productInfo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public List<ProductInfo> GetProductInfoDetails()
        {
            try
            {
                return _dbContext.ProductInfos.ToList();
            }
            catch
            {
                throw;
            }
        }

        public ProductInfo GetProductInfoDetails(int id)
        {
            try
            {
                ProductInfo? productInfo = _dbContext.ProductInfos.Find(id);
                if (productInfo != null)
                {
                    return productInfo;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void UpdateProductInfo(ProductInfo productInfo)
        {
            try
            {
                _dbContext.Entry(productInfo).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
