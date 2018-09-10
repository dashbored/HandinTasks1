using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HängaGubbe
{
    class HängaGubbe
    {
        static void Main(string[] args)
        {
            Console.Title = "Hänga Gubbe";
            List<char> gissadeTecken = new List<char>();
            List<char> felTecken = new List<char>();
            int antalGissningar = 6;
            string input = null;

            IntroPrint();

            string hemligtOrd = ValAvOrdväljare();

            char[] svar = new char[hemligtOrd.Length];

            InitialiseraSvar(svar);
            string svarString = new string(svar);
            svarString = KonverteraStringTillVersaler(svarString);

            Console.Clear();

            while ((antalGissningar > 0) && (svarString != hemligtOrd))
            {
                PrintaOrd(svar);
                PrintaMissar(felTecken);

                Console.Write("\nGissa en bokstav eller ordet: ");
                input = Console.ReadLine();
                input = KonverteraStringTillVersaler(input);
                Console.Clear();
                if (input.Length > 1)
                {
                    if (hemligtOrd == input)
                    {
                        svarString = hemligtOrd;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Fel ord!\n");
                        antalGissningar--;
                        SkrivUtGissningar(antalGissningar);
                    }
                }
                else if (input.Length == 0)
                {
                    Console.WriteLine("Mata in ett tecken.");
                    SkrivUtGissningar(antalGissningar);
                }
                else
                {
                    if (gissadeTecken.Contains(input[0]))
                    {
                        Console.WriteLine("Du har redan gissat på den karaktären.");
                        SkrivUtGissningar(antalGissningar);
                    }
                    else
                    {

                        gissadeTecken.AddRange(input);
                        if (hemligtOrd.Contains(gissadeTecken.Last()))
                        {
                            for (int i = 0; i < hemligtOrd.Length; i++)
                            {
                                if (hemligtOrd[i] == input[0])
                                {
                                    svar[i] = input[0];
                                }
                            }
                            Console.WriteLine("Bra!");
                            SkrivUtGissningar(antalGissningar);
                        }
                        else
                        {
                            felTecken.AddRange(input);
                            antalGissningar--;
                            Console.WriteLine("Fel!");
                            SkrivUtGissningar(antalGissningar);
                        }

                    }
                }
                svarString = new string(svar);
            }
            Console.Clear();
            if (svarString == hemligtOrd)
            {
                Console.WriteLine("HURRA! Du klarade det med {0} gissningar kvar!\n", antalGissningar);
            }
            else
            {
                Console.WriteLine("Tyvärr, gubben dog.\n");
            }
            Console.WriteLine("Det rätta ordet var {0}", hemligtOrd);

            Console.ReadLine();
        }

        private static string ValAvOrdväljare()
        {
            string hemligtOrd;
            int val;
            Console.WriteLine("Välj ett alternativ: ");
            Console.WriteLine("1) Välj ett eget ord.");
            Console.WriteLine("2) Låt datorn välja ett ord.");
            int.TryParse(Console.ReadLine(), out val);
            if (val == 1)
            {
                Console.Clear();
                Console.WriteLine("Du valde att mata in ett ord själv.");
                EnterToContinue();
                hemligtOrd = HämtaOrdFrånKonsol();
            }
            else if (val == 2)
            {
                Console.Clear();
                Console.WriteLine("Du valde att datorn fick välja ord.");
                EnterToContinue();

                hemligtOrd = SlumpatOrd();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Du gjorde inget korrekt val och får därför välja ord själv.");
                EnterToContinue();
                hemligtOrd = HämtaOrdFrånKonsol();
            }

            return hemligtOrd;
        }

        private static string SlumpatOrd()
        {
            string hemligtOrd;
            Random rnd = new Random();
            string[] slumpadeOrd = new string[] { "BANAN", "GRODA", "PROGRAMMERARE", "FORDONSSKATT", "NACKADEMIN", "ALFABETET" };
            hemligtOrd = slumpadeOrd[rnd.Next(0, 6)];
            return hemligtOrd;
        }

        private static void EnterToContinue()
        {
            Console.WriteLine("Tryck på enter för att fortsätta...");
            Console.ReadLine();
        }

        private static void PrintaMissar(List<char> felTecken)
        {
            Console.Write("\nMissar: ");
            foreach (char c in felTecken)
            {
                Console.Write(c.ToString().ToUpper() + " ");
            }
        }

        private static void PrintaOrd(char[] svar)
        {
            Console.Write("Ord: ");
            foreach (char c in svar)
            {
                Console.Write(c + " ");
            }
        }

        private static void InitialiseraSvar(char[] svar)
        {
            for (int i = 0; i < svar.Length; i++)
            {
                svar[i] = '_';
            }
        }

        private static void SkrivUtGissningar(int antalGissningar)
        {
            Console.WriteLine("Du har {0} gissningar kvar.\n", antalGissningar);
        }

        private static string HämtaOrdFrånKonsol()
        {
            string hemligtOrd;
            Console.Clear();
            Console.WriteLine("Den som ska spela måste titta bort nu!");
            Console.Write("Skriv in ett ord: ");
            hemligtOrd = Console.ReadLine();
            while (hemligtOrd.Length < 1)
            {
                Console.WriteLine("\nOrdet måste innehålla minst ett tecken.");
                Console.Write("Skriv in ett ord: ");
                hemligtOrd = Console.ReadLine();
            }
            hemligtOrd = hemligtOrd.ToUpper();

            return hemligtOrd;
        }

        private static string KonverteraStringTillVersaler(string s)
        {
            s = s.ToUpper();
            return s;
        }

        private static void IntroPrint()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine();
            }

            Console.WriteLine("\t\t\t\t\t\t       _____");
            Console.WriteLine("\t\t\t\t\t\t      |/    |");
            Console.WriteLine("\t\t\t\t\t\t      |     O");
            Console.WriteLine("\t\t\t\t\t\t      |    /|\\");
            Console.WriteLine("\t\t\t\t\t\t      |    / \\");
            Console.WriteLine("\t\t\t\t\t\t    _/ \\_       ");
            Console.WriteLine("\t\t\t\t\t\t   |_____|_______(\\____    ");
            Console.WriteLine();


            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t\t\t\t%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            }

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("\t\t\t\t%                                                  %");
            }

            Console.WriteLine("\t\t\t\t%                   HÄNGA GUBBE                    %");

            for (int i = 0; i < 2; i++)
            {
                Console.WriteLine("\t\t\t\t%                                                  %");
            }

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("\t\t\t\t%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%");
            }

            //BeepSong();

            System.Threading.Thread.Sleep(1000);
            for (int i = 0; i < 30; i++)
            {
                Console.WriteLine();
                System.Threading.Thread.Sleep(100);
            }
            Console.Clear();
        }

        private static void BeepSong()
        {
            //const int A = 440;
            //const int B = 494;
            const int Csharp = 554;
            
            const int D = 587;
            const int E = 659;
            const int F = 698;
            //const int Gsharp = 392;

            Console.Beep(D, 1000);
            Console.Beep(D, 750);
            Console.Beep(D, 250);
            Console.Beep(D, 1000);
            Console.Beep(F, 750);
            Console.Beep(E, 250);
            Console.Beep(E, 750);
            Console.Beep(D, 250);
            Console.Beep(D, 750);
            Console.Beep(Csharp, 250);
            Console.Beep(D, 1000);
        }
    }
}
