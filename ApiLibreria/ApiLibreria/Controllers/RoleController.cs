using ApiLibreria.Models;
using ApiLibreria.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get(int idRole)
        {
            Role? role = new Role();
            role = await RoleRepository.GetById(idRole);
            if (role != null) {
                return Ok(role);
            }
            return NotFound("NO se encontro ningun registro con el ID");            
        }
    }
}
