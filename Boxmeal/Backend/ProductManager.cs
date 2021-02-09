using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxmeal.Backend
{
    public class ProductManager
    {
        public static List<Product> products { get; set; } //BAZA PRODUKTÓW

        public static List<Product> GetProducts() //ZWRACA PRODUKTY
        {
            return products;
        }

        public static void WriteProducts() //PRODUKTY
        {
            foreach (Product product in ProductManager.GetProducts())
            {
                product.WriteProduct();
            }
        }

        public static void CreateDataProducts() //BAZA PRODUKTÓW
        {
            string ToFilePatch = $"{Directory.GetCurrentDirectory()}\\skladniki.json";

            string JsonFile = File.ReadAllText(ToFilePatch);

            products = JsonConvert.DeserializeObject<List<Product>>(JsonFile);
        }


        private static Random rnd = new Random();
        public static Product GetRandomProduct() //LOSOWY PRODUKT
        {
            int r = rnd.Next(products.Count);

            return products[r];
        }

        public static Product GetRandomProduct(int maxKcal, String category, bool vege) //LOSOWY PRODUKT
        {
            //Console.WriteLine(maxKcal);
            int r = rnd.Next(products.Count);
            Product product = GetRandomProduct();

            int range = 65;

            while (true)
            {

                if (product.Calories < maxKcal + range && product.Calories > maxKcal - range &&
                    category.Equals(product.Category, StringComparison.OrdinalIgnoreCase))
                {
                    if (vege == false)
                    {
                        break;
                    }
                    else if (vege == product.Vegetarian)
                    {
                        break;
                    }
                }


                product = GetRandomProduct();
            }

            return product;
        }

        private static int GetCaloriesFromListAtRange(List<Product> list, int index, int count)
        {
            List<Product> products = list.GetRange(index, count);
            int calories = 0;

            products.ForEach(i => calories += i.Calories);

            return calories;
        }

        private static int GetPriceFromList(List<Product> products)
        {
            int price = 0;
            products.ForEach(i => price += i.Price);

            return price;
        }

        private static int GetDayDiet(int kcal, bool vege)
        {
            List<Product> dayProducts = new List<Product>();

            int kcl = kcal / 3;


            for (int i = 0; i < 3; i++)
            {
                dayProducts.Add(GetRandomProduct(kcl / 3, "Przystawka", vege));
                dayProducts.Add(GetRandomProduct(kcl / 3, "Główne", vege));
                dayProducts.Add(GetRandomProduct(kcl / 3, "Deser", vege));
            }

            W("Śniadanie (");
            W(dayProducts[0].Name + "/");
            W(dayProducts[1].Name + "/");
            W(dayProducts[2].Name + ") ");
            W(GetCaloriesFromListAtRange(dayProducts, 0, 3).ToString());
            W("\nObiad (");
            W(dayProducts[3].Name + "/");
            W(dayProducts[4].Name + "/");
            W(dayProducts[5].Name + ") ");
            W(GetCaloriesFromListAtRange(dayProducts, 3, 3).ToString());
            W("\nKolacja (");
            W(dayProducts[6].Name + "/");
            W(dayProducts[7].Name + "/");
            W(dayProducts[8].Name + ") ");
            Console.WriteLine(GetCaloriesFromListAtRange(dayProducts, 6, 3).ToString());



            int kca = 0;
            foreach (Product product in dayProducts)
            {
                kca += product.Calories;
            }

            Console.WriteLine("Razem kcal: " + kca);

            return GetPriceFromList(dayProducts);
        }

        public static void WriteWeeklyDiet(int kcal, bool vege = false) //WSZYSTKIE PRODUKTY 
        {

            string[] daysWeek = { "Poniedziałek", "\nWtorek", "\nŚroda", "\nCzwartek", "\nPiątek" };
            int price = 0;

            for (int i = 0; i < daysWeek.Length; i++)
            {
                Console.WriteLine(daysWeek[i]);
                price += ProductManager.GetDayDiet(kcal, vege);
            }

            Console.WriteLine("Łączna cena za 5-cio dniowy zestaw: " + price + "zł");
            price = 0;
        }

        static void W(string tekst)
        {
            Console.Write(tekst);
        }
    }
}