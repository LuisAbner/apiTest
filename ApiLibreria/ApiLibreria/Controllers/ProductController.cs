using ApiLibreria.Constants;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet]
        
        public IActionResult Get()
        {
            var listProduct = ProductConstant.Products;

            return Ok(listProduct);
        }
    }
}
