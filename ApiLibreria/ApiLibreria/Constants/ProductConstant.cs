using ApiLibreria.Models;
using Microsoft.AspNetCore.Authorization;

namespace ApiLibreria.Constants
{
    public class ProductConstant
    {        
        public static List<ProductModel> Products = new List<ProductModel>()
        {
            new ProductModel() { Name = "Coca Cola", Description = "Bebida con gas" },
            new ProductModel() { Name = "Agua Villavicencio", Description = "Agua mineral de 2L" },
        };
    }
}
