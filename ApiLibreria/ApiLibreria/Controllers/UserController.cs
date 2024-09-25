using ApiLibreria.Models;
using ApiLibreria.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAll()
        {
            List<User> users = await UserRepository.GetAll();
            return Ok(users);
        }
        [HttpPost]
        public async Task<IActionResult> Save(User user)
        {
            int idNewUser = await UserRepository.Save(user);
            bool response = idNewUser >= 1 ? true : false;
            if (response)
            {
                return Ok($"Registrado Correctamente, el id registrado es: {idNewUser}");
            }
            else
            {
                return NotFound("Algo salio mal no se pudo registrar");
            }
            
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(int id)
        {
            int ? response = await UserRepository.DeleteById(id);
            bool isSuccess = response == 1? true: false;
            if (isSuccess)
            {
                return Ok("Se elimino correctamente");
            }
            else if (response == null)
            {
                return NotFound("No existe registro con el ID");
            }
            return NoContent();
        }
        [HttpPut]
        public async Task<IActionResult> Update(User user)
        {
            int response = await UserRepository.Update(user);
            bool isSuccess = response == 1 ? true : false;
            if (isSuccess)
            {
                return Ok("Se edito correctamente");
            }
            else
            {
                return NotFound("No existe registro con el ID");
            }
        }
    }
}
