using ApiLibreria.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiLibreria.Repository
{
    public class RoleRepository
    {
        public static async Task<Role?> GetById(int id)
        {
            Role ? role = new Role();
            using (LibreriaContext context = new LibreriaContext())
            {
                role = await (from r in context.Roles where r.IdRole == id select r).FirstOrDefaultAsync();
                if(role != null)
                {
                    await context.Entry(role).Collection(r => r.Users).LoadAsync();                    
                }

            }
            return role;
        }
    }
}
