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

            //to poniżej jest potrzebne do wyświetlania tego jsona ze składnikami
            ListProducts MyList = new ListProducts();
            MyList.CreateBase();

            //poniżej zmienna potrzebna do tego, żeby program możnabyło cofać do początku
            string ReloadApk = "";

            //poniżej etykieta, żeby móc wykonać program ponownie
            StartOfProgram:

            FirstQuestion(question);

            string answerUser = Console.ReadLine();

            if (answerUser == "a" || answerUser =="A")
            {
                WP("Wybrałeś opcję zamówienia diety...");
                SecondQuestion(question);

                string answerUser_2 = Console.ReadLine();
                int kalorie=0;
                
                     switch (answerUser_2)
                    {
                    case "a": case "A":
                        kalorie = 1000;
                        break;
                    case "b": case "B":
                        kalorie = 1500;
                        break;
                    case "c": case "C":
                        kalorie = 2000;
                        break; 
                    case "d": case "D":
                        kalorie = 2500;
                        break;
                    case "e": case "E":
                        kalorie = 3000;
                        break;
                    default:
                        Console.WriteLine("Podałeś znak inny niż a, b, c, d lub e - program nie zadziała poprawnie");
                        goto EndOfProgram;
                    }
                // trzeba będzie coś zrobić, żeby tego inta "kalorie" móc wykorzystać do generowania tej diety, ale nie ogarniam za bardzo jak 

                    ThirdQuestion(question);
                    string answerUser_3 = Console.ReadLine();
                    bool vege = false;
                    switch(answerUser_3)
                    {
                        case "t": case "T":
                            vege = true;
                            break;
                        case "n": case "N":
                            vege = false;
                            break;
                        default:
                            Console.WriteLine("Podałeś inny znak niż n lub t - program nie zadziała poprawnie");
                            goto EndOfProgram;
                    }
                // trzeba będzie potem użyć tej zmiennej "vege" do określenia rodzaju diety

                // poniżej wydruk kontrolny (wymagany w zadaniu)
                        if (vege == true)
                        {
                            Console.WriteLine("Wybrałeś opcję: " + kalorie + " cal, WEGETARIAŃSKA");
                        }
                        else
                        {
                            Console.WriteLine("Wybrałeś opcję: " + kalorie + " cal, NIEWEGETARIAŃSKA");
                        }
                        W("");
                        W("Czy potwierdzasz swój wybór? (t/n)");
                        string answerUser_4 = Console.ReadLine();
                        if (answerUser_4 == "t" || answerUser_4 == "T")
                        {
     //!!!!!!!!!!!TUTAJ TRZEBA UMIEŚCIĆ PROGRAM/FUNKCJĘ/METODĘ/WHATEVER - COŚ CO BĘDZIE USTALAĆ NAM TĘ DIETĘ
                            W("Kliknij enter, aby wyświetlić swój plan diety");
                            Console.ReadLine();





    //!!!!!!!!!!!!to w tym przedziale (nad tym komentarzem, a pod poprzednim)
                        }
                        else if (answerUser_4 == "n" || answerUser_4 == "N")
                        {
                            W("Czy chcesz zacząć od nowa? (T/N)");
                            ReloadApk = Console.ReadLine();
                            if (ReloadApk == "T" || ReloadApk == "t")
                            {
                                goto StartOfProgram; 
                            }
                            else
                            {
                                goto EndOfProgram; 
                            }
                        }
                        else
                        {
                            W("Podałeś znak inny niż t lub n - program nie zadziała poprawnie");
                            goto EndOfProgram;
                        }
                    
                
            }
            else if (answerUser == "b" || answerUser == "B")
            {
                W("Lista dostępnych skłaników:");
                W("[lp.] [kategoria] [nazwa produktu] [kaloryczność] [cena] [vege?]");

                
                MyList.WriteAllProducts();

                //poniżej zakomentowany stary kod Kuby
                //Product products = ListProducts.Item();
                //products.WriteProduct();
                W("");
                W("    Załadować program ponownie? (t/n)");
                ReloadApk = Console.ReadLine();
                if (ReloadApk == "t" || ReloadApk == "T")
                {
                    goto StartOfProgram;
                }
                else if (ReloadApk == "n" || ReloadApk == "N")
                {
                    goto EndOfProgram;
                }
                else
                {
                    W("Podałeś inny znak niż t lub n - program się wywali");
                    goto EndOfProgram;
                }

            }
            else
            {
                W("Podałeś znak inny niż a lub b - program nie zadziała poprawnie");
                goto EndOfProgram;
            }


            //poniżej dałem etykietkę EndOfProgram, żeby dało się zakończyć program w dowolnym miejscu robiąc "goto EndOfProgram"
            EndOfProgram:

            W("Dziękujemy za skorzystanie z naszego programu");
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
