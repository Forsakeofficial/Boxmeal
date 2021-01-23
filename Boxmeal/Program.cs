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
                WP("okej");
                SecondQuestion(question);

                string answerUser_2 = Console.ReadLine();
                int kalorie;
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
                        Console.WriteLine("Podałeś znak z poza zakresu odpowiedzi, program nie zadziała poprawnie");
                        break;
                    }
                // trzeba będzie coś zrobić, żeby tego inta "kalorie" móc wykorzystać do generowania tej diety, ale nie ogarniam za bardzo jak 

                ThirdQuestion(question);
                Console.ReadLine();

                //trzeba dodać, żeby przetworzyło odpowiedź użytkownika i użyć jej potem do generowania, ale to już nie dzisiaj, bo na dziś mam już dosyć tego syfu...

            }
            else if (answerUser == "b")
            {
                W("Lista dostępnych skłaników:");

                Product products = ListProducts.Item();
                products.WriteProduct();
            }
            else
            {
                W("Nie ma takiej odpowiedzi lub po prostu wpisałeś jakieś głupoty");
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
