using System;
using System.Diagnostics;

namespace Algorytm_zlozonosci_obliczeniowej
{
    class Program
    {
        static long Przypisz, Porownaj, Dodaj;
        static double Koszt;
        /// <summary>
        /// Zerowanie wszystkich operacji wiodacej
        /// </summary>
        /// <returns></returns>
        public static object Zeruj()
        {
            Przypisz = 0;
            Porownaj = 0;
            Dodaj = 0;
            return "koniec";
        }
        /// <summary>
        /// Sortowanie binarne gdzie pierwszy parametr to tablica a drugi to element szukany
        /// </summary>
        /// <param name="tab1"></param>
        /// <param name="sh"></param>
        /// <returns></returns>
        public static object BS(int[] tab1, int sh)
        {
            int min = 0;
            int max = tab1.Length - 1;
            int mid = 0;
            while (min <= max)
            {
                mid = (min + max) / 2;
                if (sh == tab1[mid])
                {
                    return mid;
                }
                else if (sh < tab1[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return "Koniec";
        }
        /// <summary>
        /// Przeszukiwanie binarne z Instrumentacja
        /// </summary>
        /// <param name="tab1"></param>
        /// <param name="sh"></param>
        /// <returns></returns>
        public static object BSINST(int[] tab1, int sh)
        {
            int min = 0;
            int max = tab1.Length - 1;
            int mid;
            while (min <= max)
            {
                mid = (min + max) / 2;
                Porownaj++;
                if (sh == tab1[mid])
                {
                    return mid;
                }
                else
                {
                    Porownaj++;
                    if (sh < tab1[mid])
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;
                    }
                }

            }
            return "Koniec";
        }
        /// <summary>
        /// Sortowanie liniowe gdzie pierwszy parametr to rozmiar tablicy a drugi to element szukany
        /// </summary>
        /// <param name="tab2"></param>
        /// <param name="sh2"></param>
        /// <returns></returns>
        public static object LS(int[] tab2, int sh2)
        {
            for (int i = 0; i < tab2.Length; i++)
            {
                if (tab2[i] == sh2)
                {

                    break;
                }
            }
            return "Koniec";
        }
        /// <summary>
        /// Przeszukiwanie liniowe z instrumentacja
        /// </summary>
        /// <param name="tab2"></param>
        /// <param name="sh2"></param>
        /// <returns></returns>
        public static object LSINST(int[] tab2, int sh2)
        {
            Koszt = 0;
            Przypisz = 1;
            for (int i = 0; i < tab2.Length; i++, Dodaj++)
            {
                Porownaj++;
                //Koszt += tab2[i];
                if (tab2[i] == sh2)
                {

                    break;
                }
            }
            return "Koniec";
        }


        /// <summary>
        /// Wypelnianie tablicy losowymi liczbami. Parametr to tablica
        /// </summary>
        /// <param name="tab3"></param>
        /// <returns></returns>
        public static object FillRand(int[] tab3)
        {

            Random los = new Random();
            for (int i = 0; i < tab3.Length - 1; i++)
            {
                tab3[i] = los.Next(1, 3);
            }
            Array.Sort(tab3);//sortowanie tablicy
            return "koniec";
        }
        /// <summary>
        /// Wypełnianie tablicy elementami od 0 do i w kolejnosci rosnacej
        /// </summary>
        /// <param name="tab4"></param>
        /// <returns></returns>
        public static object Fill(int[] tab4)
        {

            for (int i = 0; i < tab4.Length - 1; i++)
            {
                tab4[i] = i;
            }

            return "koniec";
        }
        //MAIN *********************************************************MAIN**************************************MAIN******************************************************
        static void Main(string[] args)
        {
            int a = 9;
            double wynik = 0;
            int cnt = 0;
            Stopwatch stoper = new Stopwatch();

            Console.WriteLine("**********************************************************************************");
            Console.WriteLine("Program oblicza czas wyszukiwania elementu w stosunku do rozmiaru tablicy\n");
            Console.WriteLine("<Pamiętaj o usunięciu menu wyboru przed wczytaniem danych!!!>\n");
            Console.WriteLine("**********************************************************************************");

            Console.WriteLine("\n1.Wyszukiwanie binarne przypadek Średni czas");
            Console.WriteLine("\n2.Wyszukiwanie liniowe przypadek Średni czas");
            Console.WriteLine("\n3.Wyszukiwanie binarne przypadek Pesymistyczny czas");
            Console.WriteLine("\n4.Wyszukiwanie liniowe przypadek Pesymistyczny czas");
            Console.WriteLine("\n5.Wyszukiwanie binarne przypadek Średni instrumentacja");
            Console.WriteLine("\n6.Wyszukiwanie liniowe przypadek Średni instrumentacja");
            Console.WriteLine("\n7.Wyszukiwanie binarne przypadek Pesymistyczny instrumentacja");
            Console.WriteLine("\n8.Wyszukiwanie liniowe przypadek Pesymistyczny instrumentacja");
            Console.Write("\nPodaj opcje: ");

            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("\nPodałes złą liczbę!!!\nPodaj liczbe: ");
            }
            //Switch dla rozdzielenia przypadków
            switch (a)
            {
                //Przypadek Średni czas------------------------------------------------------------------------------------------------------
                case 1:
                    {

                        Console.WriteLine("Szukanie binarne-------------Szukanie binarne-------------------Szukanie binarne---------------------Szukanie binarne--");


                        for (int i = 2000000; i < Math.Pow(2, 28); i += 7000000)
                        {
                            int[] tablica = new int[i];
                            Program.Fill(tablica);
                            wynik = 0;
                            for (int j = 0; j < 1900000; j++)
                            {
                                Program.Zeruj();
                                stoper.Reset();
                                stoper.Start();
                                Program.BS(tablica, tablica[j]);
                                stoper.Stop();
                                wynik += stoper.ElapsedTicks;

                            }
                            cnt = 1900000;

                            Console.WriteLine("{0:0.##};{1} ", wynik / cnt, i);

                        }



                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Szukanie liniowe-------------Szukanie liniowe-------------------Szukanie liniowe---------------------Szukanie liniowe--");//szukany srodkowy element tablicy

                        double suma = 0;

                        for (int i = 2000000; i < Math.Pow(2, 28); i += 7000000)
                        {

                            int[] tablica = new int[i];
                            Program.Fill(tablica);
                            int pomoc = tablica[(tablica.Length / 2) - 1];//zmienna która pozwoli nam wyszukać środkowy element tablicy
                            stoper.Reset();
                            stoper.Start();
                            Program.LS(tablica, pomoc);
                            stoper.Stop();
                            wynik = stoper.ElapsedTicks;
                            //suma += wynik;
                            //cnt++;
                            Console.WriteLine("{0:0.##};{1} ", wynik, i);
                        }

                        Console.WriteLine("Calkowita srednia {0:0.##}", suma / cnt);
                        break;
                    }
                //Przypadek pesymistyczny czas------------------------------------------------------------------------------------------------------
                case 3:
                    {
                        //test wypelniania tablicy
                        /*
                        int[] tabtest = new int[1000];
                        Program.Fill(tabtest);
                        foreach (var item in tablica)
                        {
                            Console.WriteLine(tabtest[item]);
                        }
                        */

                        Console.WriteLine("Szukanie binarne------czas-------Szukanie binarne--------czas-----------Szukanie binarne-----------czas----------Szukanie binarne--");

                        for (int i = 2000000; i < Math.Pow(2, 28); i += 7000000)
                        {
                            int[] tablica = new int[i];
                            Program.Fill(tablica);
                            stoper.Reset();
                            stoper.Start();
                            Program.BS(tablica, -1);
                            stoper.Stop();
                            wynik = stoper.ElapsedTicks;
                            Console.WriteLine("{0},{1}", wynik, i);
                        }

                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Szukanie liniowe------czas-------Szukanie liniowe--------czas-----------Szukanie liniowe---------czas------------Szukanie liniowe--");

                        for (int i = 0; i < Math.Pow(2, 28); i += 7000000)
                        {
                            int[] tablica = new int[i];
                            stoper.Reset();
                            stoper.Start();
                            Program.LS(tablica, -1);
                            stoper.Stop();
                            wynik = stoper.ElapsedMilliseconds;
                            Console.WriteLine("{0},{1}", wynik, i);
                        }

                        break;
                    }
                //Przypadek Średni instrumentacja------------------------------------------------------------------------------------------------------
                case 5:
                    {

                        Console.WriteLine("Szukanie binarne-----Instrumentacja--------Szukanie binarne----------Instrumentacja---------Szukanie binarne----------Instrumentacja-----------Szukanie binarne--");
                        Console.WriteLine("Porownania, Rozmiar Tablicy");
                        for (int i = 2000000; i < Math.Pow(2, 28); i += 7000000)
                        {
                            int[] tablica = new int[i];
                            Program.Zeruj();
                            Program.Fill(tablica);
                            wynik = 0;
                            for (int j = 0; j < 1900000; j++)
                            {
                                Program.Zeruj();

                                Program.BSINST(tablica, tablica[j]);

                                wynik += Porownaj;

                            }
                            cnt = 1900000;
                            Console.WriteLine("{0:0.##}/{1}", wynik / cnt, i);
                        }


                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Szukanie liniowe------Instrumentacja-------Szukanie liniowe--------Instrumentacja-----------Szukanie liniowe------------Instrumentacja---------Szukanie liniowe--"); ;
                        Console.WriteLine("Porownania, Rozmiar Tablicy");
                        double suma = 0;
                        for (int i = 2000000; i < Math.Pow(2, 28); i += 7000000)
                        {
                            int[] tablica = new int[i];
                            Program.Zeruj();
                            Program.Fill(tablica);
                            int pomoc = tablica[(tablica.Length / 2) - 1];
                            Program.LSINST(tablica, pomoc);
                            wynik = Porownaj;
                            cnt++;
                            suma += wynik;
                            Console.WriteLine("{0},{1}", wynik, i);
                        }
                        Console.WriteLine("Sredni wynik porownan {0:0.##} ", suma / cnt);
                        break;
                    }
                //Przypadek pesymistyczny instrumentacja------------------------------------------------------------------------------------------------------
                case 7:
                    {
                        Console.WriteLine("Szukanie binarne-----Instrumentacja--------Szukanie binarne----------Instrumentacja---------Szukanie binarne----------Instrumentacja-----------Szukanie binarne--");
                        Console.WriteLine("Porownania, Rozmiar Tablicy");
                        for (int i = 2000000; i < Math.Pow(2, 28); i += 7000000)
                        {
                            int[] tablica = new int[i];
                            Program.Zeruj();
                            Program.Fill(tablica);

                            Program.BSINST(tablica, -1);

                            Console.WriteLine("{0},{1}", Porownaj, i);
                        }

                        break;
                    }
                case 8:
                    {
                        Console.WriteLine("Szukanie liniowe------Instrumentacja-------Szukanie liniowe--------Instrumentacja-----------Szukanie liniowe------------Instrumentacja---------Szukanie liniowe--");
                        Console.WriteLine("Porownania, Rozmiar Tablicy");
                        for (int i = 2000000; i < Math.Pow(2, 28); i += 7000000)
                        {
                            int[] tablica = new int[i];
                            Program.Zeruj();
                            Program.Fill(tablica);
                            Program.LSINST(tablica, -1);

                            Console.WriteLine("{0}/{1}", Porownaj, i);
                        }
                        break;
                    }

                default:
                    Console.WriteLine("Program zakończy działanie...");
                    break;
            }
            Console.ReadKey();
        }
    }
}
