using ApiLibreria.Models;
using ApiLibreria.Security;
using Microsoft.EntityFrameworkCore;

namespace ApiLibreria.Repository
{
    public class UserRepository
    {
        public static async Task<UserModel ?> Authenticate(LoginUser loginUser)
        {
            User? user =  new User();
            UserModel? userModel = null;
            using (LibreriaContext context =  new LibreriaContext())
            {
                string passwordEn = EncryptPassword.Encrypt(loginUser.Password);
                user = await (from u in context.Users where u.Username == loginUser.Username && u.PasswordUs == passwordEn select u).FirstOrDefaultAsync<User>();
                if (user != null)
                {
                    userModel = new UserModel();
                    userModel.Username = user.Username;
                    await context.Entry(user).Reference(r => r.Role).LoadAsync();
                    userModel.Rol = user.Role!.Role1;

                }
            }
            
            return userModel;
        }
        public static async Task<List<User>> GetAll()
        {
            List<User> users = new List<User>();
            using (LibreriaContext context = new LibreriaContext())
            {
                users = await (from u in context.Users join r in context.Roles on u.RoleId equals r.IdRole 
                               select new User { 
                                IdUser = u.IdUser,
                                Username = u.Username,
                                RoleId = r.IdRole,
                                Role= r
                               }).ToListAsync<User>();                
            }
            return users;
        }
        public static async Task<int> Save(User user)
        {
            int isSuccess;
            using (LibreriaContext context = new LibreriaContext())
            {
                user.PasswordUs = EncryptPassword.Encrypt(user.PasswordUs);
                context.Users.Add(user);
                isSuccess = await context.SaveChangesAsync();
            }
            return isSuccess;
        }
        public static async Task<int?> DeleteById(int id)
        {
            int response = 0;
            using (LibreriaContext ctx = new LibreriaContext())
            {
                User? user = new User();
                user = await (from u in ctx.Users where u.IdUser == id select u).FirstOrDefaultAsync<User>();

                if (user != null)
                {
                    ctx.Entry(user).State = EntityState.Deleted;
                    response = ctx.SaveChanges();
                }
                else
                {
                    return null;
                }        
            }
            return response;
        }
    }
}
