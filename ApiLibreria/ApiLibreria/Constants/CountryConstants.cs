using ApiLibreria.Models;

namespace ApiLibreria.Constants
{
    public class CountryConstants
    {
        public static List<CountryModel> Countries = new List<CountryModel>()
        {
            new CountryModel()
            {
                Name= "Mexico",
            },
            new CountryModel()
            {
                Name = "Peru"
            }
        };
    }
}
