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
        private static int calories;

        static void Main(string[] args)
        {
            
            Console.WriteLine("*******************************************");
            Console.WriteLine("******************BOXMEAL******************");
            Console.WriteLine("*******************************************");

            //-------------------------------------------------------------//
            ProductManager.CreateDataProducts();

            bool startAnswerUser = true;

            while (startAnswerUser)
            {
                FirstQuestion(); //START pierwszego pytania

                string userAnswer = Console.ReadLine(); //odpowiedź uzytkownika na 1 pytanie

                if (userAnswer == "a" || userAnswer == "A")
                {
                    WP("Wybrałeś a - dietę");
                    SecoundQuestion(); //START drugiego 

                    string userAnswer2 = Console.ReadLine(); //odpowiedź 2
                    switch (userAnswer2)
                    {
                        case "a":
                        case "A":
                            W("Wybrałeś/aś a czyli 1000 kalorii");
                            calories = 1000;
                            ThirdQuestion();
                            break;

                        case "b":
                        case "B":
                            W("Wybrałeś/aś b czyli 1500 kalorii");
                            calories = 1500;
                            ThirdQuestion();
                            break;

                        case "c":
                        case "C":
                            W("Wybrałeś/aś c czyli 2000 kalorii");
                            calories = 2000;
                            ThirdQuestion();
                            break;

                        case "d":
                        case "D":
                            W("Wybrałeś/aś d czyli 2500 kalorii");
                            calories = 2500;
                            ThirdQuestion();
                            break;

                        case "e":
                        case "E":
                            W("Wybrałeś/aś e czyli 3000 kalorii");
                            calories = 3000;
                            ThirdQuestion();
                            break;

                        default:
                            Console.WriteLine("Podałeś nieprawidłową odpowiedź");
                            break;
                    }
                }
                else if (userAnswer == "b" || userAnswer == "B")
                {
                    W("Lista dostępnych składników:");
                    ProductManager.WriteProducts();
                }
                else if(userAnswer == "c"||userAnswer =="C")
                {
                    startAnswerUser = false;
                }
                else
                {
                    W("Nie ma takiej odpowiedzi lub po prostu wpisałeś jakieś głupoty");
                }


                Console.ReadLine();
            }
        }







        static void FirstQuestion()
        {
            WP("Co chcesz zrobić?");
            W("a - zamówić dietę");
            W("b - wyświetlić dostępne składniki");
            W("c - zamknąć program");
            WP("");
        }

        static void SecoundQuestion()
        {
            WP("Proszę podać wartość kaloryczną diety:");
            W("a. - 1000 cal");
            W("b. - 1500 cal");
            W("c. - 2000 cal");
            W("d. - 2500 cal");
            W("e. - 3000 cal");
            WP("");
        }

        static void ThirdQuestion()
        {
            WP("Proszę podać czy dieta ma być wegetariańska:");
            W("T - tak");
            W("N - nie");
            WP("");
            string userAnswer = Console.ReadLine();
            if (userAnswer == "T" || userAnswer == "t")
            {
                ProductManager.WriteWeeklyDiet(calories, true);
            }
            else if (userAnswer == "N" || userAnswer == "n")
            {
                ProductManager.WriteWeeklyDiet(calories);
            }
            else
            {
                W("Nie ma takiej odpowiedzi lub po prostu wpisałeś jakieś głupoty");
            }
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

