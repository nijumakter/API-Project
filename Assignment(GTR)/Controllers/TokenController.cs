using Assignment_GTR_.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Assignment_GTR_.Controllers
{
    [Route("api/token")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        public IConfiguration _configuration;
        private readonly DatabaseContext _context;

        public TokenController(IConfiguration config, DatabaseContext context)
        {
            _configuration = config;
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post(ProductInfo _productData)
        {
            if (_productData != null && _productData.CategoryName != null && _productData.Name != null)
            {
                var productInfo = await GetUser(_productData.CategoryName, _productData.Name);

                if (productInfo != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("Id", productInfo.Id.ToString()),
                        new Claim("CategoryName", productInfo.CategoryName),
                        new Claim("UnitName", (string)productInfo.UnitName),
                        
                        new Claim("ParentCode", (string)productInfo.ParentCode),
                       
                        new Claim("Description", productInfo.Description),
                        new Claim("BrandName", productInfo.BrandName),
                        new Claim("SizeName", productInfo.SizeName),
                        new Claim("ModelName", productInfo.ModelName),
                        new Claim("VariantName", (string)productInfo.VariantName),
                       
                    
                        new Claim("WarehouseList", productInfo.WarehouseList),
                        
                        new Claim("LastPurchaseSupplier", (string)productInfo.LastPurchaseSupplier),
                       
                        new Claim("LastSalesDate",(string)productInfo.LastSalesDate),
                        new Claim("LastSalesCustomer", productInfo.LastSalesCustomer),
                        new Claim("ImagePath", productInfo.ImagePath),
                        new Claim("Type", productInfo.Type),
                        new Claim("Status", productInfo.Status),
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _configuration["Jwt:Issuer"],
                        _configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.UtcNow.AddMinutes(10),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }
        private async Task<ProductInfo> GetUser(string CategoryName, string Name)
        {
            string categoryName = null;
            string name = null;
            return await _context.ProductInfos.FirstOrDefaultAsync(p => p.CategoryName == categoryName && p.Name == name);
        }


    }
}
