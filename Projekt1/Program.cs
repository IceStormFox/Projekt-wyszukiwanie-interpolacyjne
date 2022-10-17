using System;
using System.Diagnostics;
using System.IO;

namespace Projekt1
{
    class Program
    {
        static void Main(string[] args)
        {

            string czytnik1;
            int indeks;
            indeks = 0;
            long ip;
            long ik;
            long isr;
            int k;
            long p;

            Stopwatch timer = new Stopwatch();

            int[] arr1 = new int[10000000];
            StreamReader dane1 = new System.IO.StreamReader(@"C:\Users\Ajsiu\source\repos\Projekt1\dane6s.txt");
            while ((czytnik1 = dane1.ReadLine()) != null)
            {
                arr1[indeks] = int.Parse(czytnik1);
                indeks++;
            }


            Console.WriteLine("Witaj. Ten program sprawdzi, czy podana przez Ciebie liczba znajduje się w pliku metodą wyszukiwania interpolacyjnego.");
            Console.WriteLine("Wpisz poszukiwaną przez siebie liczbę: ");
            popraw:
            p = -1;
            ip = 0;
            ik = indeks - 1;
            try
            {
                k = int.Parse(Console.ReadLine());


            if (k<=0)
            {
                Console.WriteLine("Wybierz liczbę większą od 0: ");
                goto popraw;
            }

            if(k>10000000)
            {
                Console.WriteLine("Przedział liczb obejmuje maksymalnie 10 000 000. Wprowadź poprawną liczbę: ");
                goto popraw;
            }

        poczatek:
            {
                timer.Start();
                while (arr1[ip] <= k && k <= arr1[ik])
                {

                    isr = (ip + ((k - arr1[ip]) * (ik - ip) / (arr1[ik] - arr1[ip])));

                    if (k != arr1[isr])
                    {
                        goto case1;
                    }
                    if (k == arr1[isr])
                    {
                        p = isr;
                        goto koniec;
                    }
                case1:
                    {
                        if (k < arr1[isr])
                        {
                            ik = isr - 1;
                            goto poczatek;
                        }
                        if (k > arr1[isr])
                        {
                            ip = isr + 1;
                            goto poczatek;
                        }
                    }
                }
            }
            timer.Stop();
            koniec:
            if(p>=0)
                {
                    Console.WriteLine("Pozycja Twojego elementu w pliku to: {0}", p+1);
                    Console.WriteLine("Czas wyszukiwania to: {0} ms", timer.ElapsedMilliseconds) ;
                    timer.Reset();
                }
            if (p<0)
                {
                    Console.WriteLine("Twojego elementu nie ma w zbiorze.");
                    Console.WriteLine("Czas wyszukiwania to: {0} ms", timer.ElapsedMilliseconds);
                    timer.Reset();
                }

            Console.WriteLine("Czy chciałbyś sprawdzić jeszcze jakiś element? y/n");
            string a;
            popraw1:
            a = Console.ReadLine();
            if (a=="y")
                {
                    Console.WriteLine("Wybierz kolejną liczbę: ");
                    goto popraw;
                }
            if (a == "n")
                {
                    Console.WriteLine("Koniec programu. Wciśnij klawisz, żeby kontynuować...");           
                }
            if (a != "y" && a != "n")
                {
                    Console.WriteLine("Wprowadź prawidłową wartość.");
                    goto popraw1;
                }
            }

            catch (Exception e)
            {
                Console.WriteLine("Nieprawidłowy typ zmiennej.");
                Console.WriteLine(e);
                Console.WriteLine("Spróbuj jeszcze raz.");
                goto popraw;
            }
            Console.ReadKey();
            
        }
    }
}
