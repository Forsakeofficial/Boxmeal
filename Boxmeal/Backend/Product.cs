using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxmeal.Backend
{
    public class Product
    { 
        public int Id { get; set; }
        public string Category { get; set; }
        public int Calories { get; set; }
        public int Price { get; set; }
        public string Name { get; set; }
        public bool Vegetarian { get; set; }

        //zmieniłem Calories i Price na int - bo potrzebujemy ich potem do liczenia, a wyświetlanie z cal lub PLN to można łatwo zrobić z intami też


        public void WriteProduct()
        {
            Console.WriteLine(String.Format("{0}. {1} ({2}), {3} cal, {4} PLN, WEGETARIAŃSKIE: {5}", this.Id, this.Name, this.Category, this.Calories, this.Price, this.Vegetarian));
        }
    }
}
