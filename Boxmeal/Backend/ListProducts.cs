using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxmeal.Backend
{
    public class ListProducts
    {
        public static Product Item()
        {
            Product product = new Product();

            product.Name = "Jajko";
            product.Category = "Przystawka";
            product.Calories = 20 + "cal";
            product.Price = 4 + "PLN";
            product.Vegetarian = true;

            return product;
        }

    }
}
