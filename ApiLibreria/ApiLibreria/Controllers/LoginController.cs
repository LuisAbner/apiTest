using ApiLibreria.Constants;
using ApiLibreria.Models;
using ApiLibreria.Repository;
using ApiLibreria.Security;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiLibreria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login(LoginUser loginUser)
        {
            UserModel ? user = await  UserRepository.Authenticate(loginUser);
            if(user != null)
            {                
                string tokenS = GenerateToken.Generate(user);
                return Ok(tokenS);
            }
            return NotFound("Usuario no encontrado");
        }

        /*private UserModel ? Authenticate(LoginUser login)
        {
            UserModel ? currentUser = UserConstants.Users.FirstOrDefault(u => u.Username.ToLower() == login.Username.ToLower()
                && u.Password == login.Password
            );
            if(currentUser != null)
            {
                return currentUser;
            }
            return null;
        }*/
        
    }
}
