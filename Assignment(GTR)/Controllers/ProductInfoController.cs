using Assignment_GTR_.Interface;
using Assignment_GTR_.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Assignment_GTR_.Controllers
{
    [Route("api/productInfo")]
    [ApiController]
    public class ProductInfoController : ControllerBase
    {
        private readonly IProductInfo _IProductInfo;
        private ActionResult<ProductInfo> productInfo;

        public ProductInfoController(IProductInfo IProductInfo)
        {
            _IProductInfo = IProductInfo;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductInfo>>> Get()
        {
            return await Task.FromResult(_IProductInfo.GetProductInfoDetails());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductInfo>> Get(int id)
        {
            var productInfos = await Task.FromResult(_IProductInfo.GetProductInfoDetails(id));
            if (productInfos == null)
            {
                return NotFound();
            }
            return productInfos;
        }
        [HttpPost]
        public async Task<ActionResult<ProductInfo>> Post(ProductInfo productInfo)
        {
            _IProductInfo.AddProductInfo(productInfo);
            return await Task.FromResult(productInfo);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<ProductInfo>> Put(int id, ProductInfo productInfo)
        {
            if (id != productInfo.ID)
            {
                return BadRequest();
            }
            try
            {
                _IProductInfo.UpdateProductInfo(productInfo);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return await Task.FromResult(productInfo);
        }

        private bool ProductInfoExists(int id)
        {
            throw new NotImplementedException();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProductInfo>> Delete(int id)
        {
            var employee = _IProductInfo.DeleteProductInfo(id);
            return await Task.FromResult(productInfo);
        }

        private bool EmployeeExists(int id)
        {
            return _IProductInfo.CheckProductInfo(id);
        }
       
    }

    
}
