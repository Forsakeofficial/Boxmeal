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

            if (answerUser == "a")
            {
                WP("Wybrałeś opcję zamówienia diety");
                SecondQuestion(question);

                string answerUser_2 = Console.ReadLine();
                int kalorie=0;
                     switch (answerUser_2)
                    {
                    case "a":
                        kalorie = 1000;
                        break;
                    case "b":
                        kalorie = 1500;
                        break;
                    case "c":
                        kalorie = 2000;
                        break;
                    case "d":
                        kalorie = 2500;
                        break;
                    case "e":
                        kalorie = 3000;
                        break;
                    default:
                        Console.WriteLine("Podałeś znak inny niż a, b, c, d lub e - program nie zadziała poprawnie");
                        break;
                    }
                // trzeba będzie coś zrobić, żeby tego inta "kalorie" móc wykorzystać do generowania tej diety, ale nie ogarniam za bardzo jak 
                // poniżej wydruk kontrolny
                Console.WriteLine("Wybrałeś opcję: " + kalorie + " cal");

                ThirdQuestion(question);
                string answerUser_3 = Console.ReadLine();
                bool vege=false;
                if (answerUser_3 == "t")
                {
                    vege = true;
                }
                else if (answerUser_3 == "n")
                {
                    vege = false;
                }
                else
                {
                    Console.WriteLine("Podałeś inny znak niż n lub t - program nie zadziała poprawnie");
                }
                // trzeba będzie potem użyć tej zmiennej "vege" do określenia rodzaju diety
                // poniżej wydruk kontrolny
                Console.WriteLine("Wybrałeś opcję vege: " + vege);
            }
            else if (answerUser == "b")
            {
                W("Lista dostępnych skłaników:");

                Product products = ListProducts.Item();

                products.WriteProduct();
            }
            else
            {
                W("Podałeś znak inny niż a lub b - program nie zadziała poprawnie");
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
        static void SecondQuestion(Questions question)
        {
            WP("Proszę podać wartość kaloryczną diety:");
            W("a - 1000 cal");
            W("b - 1500 cal");
            W("c - 2000 cal");
            W("d - 2500 cal");
            W("e - 3000 cal");
            WP("");
        }
        static void ThirdQuestion(Questions question)
        {
            WP("Proszę podać czy dieta ma być wegetariańska:");
            W("T - tak");
            W("N - nie");
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
