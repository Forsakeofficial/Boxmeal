using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

            product.Id = 1;
            product.Name = "Jajko";
            product.Category = "Przystawka";
            product.Calories = 20;
            product.Price = 4;
            product.Vegetarian = true;

            return product;
        }



        // to poniżej skopiowałem od wykładowcy (żeby korzystać z jsona do przechowywania składników), pozmieniałem nazwy na właściwe do naszego boxmeala, 
        // ale chyba coś tu jeszcze trzeba poprawić, bo niby działa, ale nie wiem co dalej z tym


        public List<Product> AllProducts { get; set; }

        public void CreateBase()
        {
            var ToFilePatch = $"{Directory.GetCurrentDirectory()}\\skladniki.json";
            var JsonContent = File.ReadAllText(ToFilePatch);      
            AllProducts = JsonConvert.DeserializeObject<List<Product>>(JsonContent);
        }


        public void WriteAllProducts()
        {
            foreach (Product actual in AllProducts)
                actual.WriteProduct();

        }

    }
}
