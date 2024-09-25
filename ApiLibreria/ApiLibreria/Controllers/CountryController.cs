using ApiLibreria.Constants;
using ApiLibreria.Models;
using ApiLibreria.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ApiLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        [HttpGet]
        [Authorize]        
        public IActionResult Get()
        {
            List<CountryModel> countries = CountryConstants.Countries;
            return Ok(countries);
        }
        [HttpGet]
        [Route("api/[controller]/GetDataToke")]
        public IActionResult GetEmail()
        {
            ClaimsIdentity? identity = HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                //return Ok(userClaims.FirstOrDefault(u => u.Type == ClaimTypes.Role)?.Value);
                return Ok(userClaims.FirstOrDefault(u => u.Type == "Correo")?.Value);
            }
            return NotFound("No esta logeado");
        }
       
    }    
}
