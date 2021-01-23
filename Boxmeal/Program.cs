using Boxmeal.Backend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxmeal
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******************************************");
            Console.WriteLine("******************BOXMEAL******************");
            Console.WriteLine("*******************************************");

            Questions question = new Questions();

            FirstQuestion(question);


            string answerUser = Console.ReadLine();

            if(answerUser.Contains("a"))
            {
                WP("Dieta wygląda następująco:");
            }
            else if(answerUser.Contains("b"))
            {
                W("Lista dostępnych skłaników:");

                Product products = ListProducts.Item();
                products.WriteProduct();
            }
            else
            {
                W("Nie ma takiej odpowiedzi");
            }

            Console.ReadLine();

        }

        static void FirstQuestion(Questions question)
        {
            WP("Co chcesz zrobić?");
            W("a - zamówić dietę");
            W("b - wyświetlić dostępne składniki");
            WP("");
        }

        static void W(string tekst)
        {
            Console.WriteLine(tekst);
        }

        static void WP(string tekst)
        {
            Console.WriteLine();
            Console.WriteLine(tekst);
        }
    }
}
