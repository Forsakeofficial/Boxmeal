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
        // ale chyba coś tu jeszcze trzeba poprawić


        public List<Product> Baza { get; set; }

        private void UtworzBazeProduktow()
        {
            

            string sciezkaDoSkladnikow = $"{Directory.GetCurrentDirectory()}\\skladniki.json";

            string tekstPliku = File.ReadAllText(sciezkaDoSkladnikow);
            
            Baza = JsonConvert.DeserializeObject<List<Product>>(tekstPliku);
        }


    }
}
