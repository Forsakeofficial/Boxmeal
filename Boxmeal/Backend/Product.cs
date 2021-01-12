using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxmeal.Backend
{
    public class Product
    { 
        public string Name {get; set;}
        public string Category { get; set; }
        public string Calories { get; set; }
        public string Price { get; set; }
        public bool Vegetarian { get; set; }

        public void WriteProduct()
        {
            Console.WriteLine(String.Format("{0} {1} {2} {3} {4}", this.Name, this.Category, this.Calories, this.Price, this.Vegetarian));
        }
    }
}
